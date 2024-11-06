﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Сoncrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRefreshTokenDal : EfEntityBaseRepository<RefreshToken,DoraTurizmDbContext>,IRefreshTokenDal
    {
    }
}