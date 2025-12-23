using System;

namespace CarFleetApp
{
    public enum BodyType
    {
        Sedan,
        StationWagon,
        Hatchback,
        Limousine,
        SUV
    }

    public class Car
    {
        public string Brand { get; set; }
        public int MaxSpeed { get; set; }
        public int EnginePower { get; set; }
        public BodyType BodyType { get; set; }

        public Car(string brand, int maxSpeed, int enginePower, BodyType bodyType)
        {
            Brand = brand;
            MaxSpeed = maxSpeed;
            EnginePower = enginePower;
            BodyType = bodyType;
        }

        public void Upgrade()
        {
            MaxSpeed = (int)(MaxSpeed * 1.1);
            EnginePower = (int)(EnginePower * 1.15);
        }

        public override string ToString()
        {
            return $"{Brand} - {MaxSpeed} км/ч, {EnginePower} л.с. ({BodyType})";
        }
    }
}