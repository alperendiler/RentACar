using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,ReCapContext>, IBrandDal
    {
    }
}
