using Ex03.GarageLogic.Car;
using Ex03.GarageLogic.Truck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Garage
{
    public class CreateVehicle
    {
        public static Vehicle CreateNewVehicle(int i_VehicleType)
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case (1):
                    newVehicle = new FuelBasedMotorcycle();
                    break;
                case (2):
                    newVehicle = new ElectricMotorcycle();
                    break;
                case (3):
                    newVehicle = new FuelBasedCar();
                    break;
                case (4):
                    newVehicle = new ElectricCar();
                    break;
                case (5):
                    newVehicle = new FuelBasedTruck();
                    break;
                default:
                    throw new ArgumentException("Invalid Vehicle Type");
            }

            return newVehicle;
        }
    }
}

