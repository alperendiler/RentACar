
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;

CarManager carManager = new CarManager(new EfCarDal());


foreach (var car in carManager.GetCarDetails().Data)
{
    Console.WriteLine(car.BrandName);
    Console.WriteLine(car.ColorName);
    Console.WriteLine(car.DailyPrice);
    Console.WriteLine("---------------------------------");

}


