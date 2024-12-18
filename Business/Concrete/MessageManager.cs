using Business.Abstract;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        [ValidationAspect(typeof(MessageValidator))]
        [CacheRemoveAspect("IMessageService.GetAsync")]
        [CacheRemoveAspect("IMessageService.GetAllAsync")]
        public async Task<IResult> AddAsync(Message message)
        {
            await _messageDal.AddAsync(message);
            return new SuccessResult(Messages.messageIsAdded);
        }

        [CacheRemoveAspect("IMessageService.GetAsync")]
        [CacheRemoveAspect("IMessageService.GetAllAsync")]
        public async Task<IResult> DeleteAsync(int id)
        {
            var messageToDelete = await _messageDal.GetAsync(x => x.Id == id);
            await _messageDal.DeleteAsync(messageToDelete);
            return new SuccessResult(Messages.messageIsDeleted);
        }
        [CachingAspect]
        public async Task<IDataResult<List<Message>>> GetAllAsync()
        {
           return new SuccessDataResult<List<Message>>(await _messageDal.GetAllAsync(),Messages.messagesAreListed);
        }
        [CachingAspect]
        public async Task<IDataResult<Message>> GetAsync(int id)
        {
            return new SuccessDataResult<Message>(await _messageDal.GetAsync(x => x.Id == id), Messages.messageIsListed);
        }

        [ValidationAspect(typeof(MessageValidator))]
        [CacheRemoveAspect("IMessageService.GetAsync")]
        [CacheRemoveAspect("IMessageService.GetAllAsync")]
        public async Task<IResult> UpdateAsync(Message message)
        {
            await _messageDal.UpdateAsync(message);
            return new SuccessResult(Messages.messageIsUpdated);
        }
    }
}
