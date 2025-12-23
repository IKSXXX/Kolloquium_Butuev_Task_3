using System.Collections.Generic;
using System.Linq;

namespace CarFleetApp
{
    public class CarFleet
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public CarFleet(string name)
        {
            Name = name;
            Cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public int TotalCars => Cars.Count;
    }
}