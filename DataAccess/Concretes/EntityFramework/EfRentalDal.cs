using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {

            using (ReCapContext context = new ReCapContext())
            {

                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId

                             select new RentalDetailsDto
                             {
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = co.ColorName,
                                 CarId = c.CarId,
                                 RentalId = r.RentalId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CustomerId = cu.CustomerId
                            

    };
                return result.ToList();
            }
        }
    }
}
