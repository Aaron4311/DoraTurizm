using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TourManager : ITourService
    {
        private readonly ITourDal _tourDal;

        public TourManager(ITourDal tourDal)
        {
            _tourDal = tourDal;
        }
        
        public async Task<IResult> AddAsync(Tour tour)
        {
            await _tourDal.AddAsync(tour);
            return new SuccessResult(Messages.tourIsAdded);
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            var tourToDelete = _tourDal.GetAsync(x => x.Id == id).Result;
            await _tourDal.DeleteAsync(tourToDelete);
            return new SuccessResult(Messages.tourIsRemoved);
        }

        public async Task<IDataResult<List<Tour>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Tour>>(await _tourDal.GetAllAsync(), Messages.toursAreListed);
        }

        public async Task<IDataResult<Tour>> GetAsync(int id)
        {
            return new SuccessDataResult<Tour>(await _tourDal.GetAsync(x => x.Id == id), Messages.tourIsListed);
        }

        public async Task<IDataResult<Tour>> GetTourByUrl(string tourUrl)
        {
            return new SuccessDataResult<Tour>(await _tourDal.GetByUrl(tourUrl), Messages.tourIsListed);
        }

        public async Task<IResult> UpdateAsync(Tour tour)
        {
            await _tourDal.UpdateAsync(tour);
            return new SuccessResult(Messages.tourIsUpdated);
        }
    }
}
