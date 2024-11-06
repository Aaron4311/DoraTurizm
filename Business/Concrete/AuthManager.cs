using Business.Abstract;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Dtos;
using Core.Entities.Сoncrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IRefreshTokenDal _refreshTokenDal;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IRefreshTokenDal refreshTokenDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _refreshTokenDal = refreshTokenDal;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var claims = await _userService.GetClaimsAsync(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.accessTokenCreated);
        }

        public async Task<IDataResult<AccessToken>> RenewAccessTokenAsync(string refreshToken)
        {
            var refreshTokenEntity = await _refreshTokenDal.GetAsync(x => x.Token == refreshToken );
            if (refreshTokenEntity == null || refreshTokenEntity.Expiration < DateTime.Now)
            {
                return new ErrorDataResult<AccessToken>(Messages.invalidRefreshToken);
            }
            var user = await _userService.GetByIdAsync(refreshTokenEntity.UserId);
            if (user.Data == null)
            {
                return new ErrorDataResult<AccessToken>(Messages.userDidNotFound);
            }
            var claims = await _userService.GetClaimsAsync(user.Data);
            var newAccessToken = _tokenHelper.CreateToken(user.Data, claims);

            return new SuccessDataResult<AccessToken>(newAccessToken, Messages.accessTokenRenewed);
        }


        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<IDataResult<TokenDto>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMailAsync(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<TokenDto>(Messages.userDidNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<TokenDto>(Messages.userDidNotFound);
            }

            var claims = await _userService.GetClaimsAsync(userToCheck.Data);
            var accessToken = _tokenHelper.CreateToken(userToCheck.Data, claims);

            var refreshToken = _tokenHelper.GenerateRefreshToken();
            var expiration = DateTime.Now.AddMinutes(60);
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = userToCheck.Data.Id,
                Expiration = expiration
            };
            await _refreshTokenDal.AddAsync(refreshTokenEntity);

            var tokenDto = new TokenDto
            {
                AccessToken = accessToken.Token,
                AccessTokenExpiration = accessToken.Expiration,
                RefreshToken = refreshToken,
                RefreshTokenExpiration = expiration
            };

            return new SuccessDataResult<TokenDto>(tokenDto, Messages.loginSuccessful);
        }



        [ValidationAspect(typeof(UserForRegisterDtoValidator))]

        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userService.AddAsync(user);
            return new SuccessDataResult<User>(user, Messages.userIsRegistered);
        }

        public async Task<IResult> UserExistsAsync(string email)
        {
            if ( _userService.GetByMailAsync(email).Result.Data != null)
            {
                return new ErrorResult(Messages.userExists);
            }
            return new SuccessResult();
        }
    }
}
