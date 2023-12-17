using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules.FluentValdation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidation))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(Check(rental));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddedRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedRental);
        }
        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
         
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
        }

        // rules

        public IResult CheckIfReturnCar(Rental rental, DateTime returnDate)
        {
            var result = _rentalDal.GetAll(c => c.CarId == rental.CarId && (returnDate < DateTime.Now));

            if (result != null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Check(Rental rental)
        {
           

            // Kiralama tarihi bugünden küçük olamaz ve kiralama tarihi geri dönüş tarihinden küçük olamaz
            if (rental.RentDate.Date < DateTime.Today || rental.RentDate.Date >= rental.ReturnDate.Date)
            {
                return new ErrorResult(Messages.ErrorRentalAdd);
            }

            // Mevcut kiralamaların dönüş tarihleri kontrol ediliyor
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && rental.RentDate.Date < r.ReturnDate.Date);

            if (result.Any())
            {
                return new ErrorResult(Messages.ErrorRentalAdd);
            }
            return new SuccessResult();
        }

     
    }   
}
