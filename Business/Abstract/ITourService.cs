using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITourService
    {
        Task<IDataResult<List<Tour>>> GetAllAsync();
        Task<IDataResult<Tour>> GetAsync(int id);
        Task<IResult> AddAsync(Tour tour);
        Task<IResult> UpdateAsync(Tour tour);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<Tour>> GetTourByUrl(string tourUrl);
    }
}
