using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTourDal : EfEntityBaseRepository<Tour, DoraTurizmDbContext>, ITourDal
    {
        public async Task<Tour> GetByUrl(string tourUrl)
        {
            using (DoraTurizmDbContext context = new())
            {
                return await context.Tours.FirstOrDefaultAsync(x => x.TourUrl == tourUrl);    
            }
        }
    }
}
