using Ex03.GarageLogic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Car;
using Ex03.GarageLogic.Truck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class InsertVehicleIntoGarage
    {

        public static void InsertAVehicle(Garage i_OurGarage)
        {
            Console.Clear();

            // get client info
            Console.WriteLine("Please enter the client's name.");
            string ClientName = Console.ReadLine();
            Console.WriteLine("Please enter the client's phone number.");
            string phoneNumber = Console.ReadLine();

            // get vehicle info
            int TypeOfVehicleInt = GetVehicleType();
            Console.WriteLine("Please enter vehicle's model name.");
            string VehicleModelNameString = Console.ReadLine();
            string VehicleLicenseNumberString = GetVehicleLicenseNumber(i_OurGarage);
            float VehicleEnergyPrecentage = GetVehicleEnergyPrecentage();

            //create new vehicle and update info
            Vehicle NewVehicle = CreateVehicle.CreateNewVehicle(TypeOfVehicleInt);
            NewVehicle.ModelName = VehicleModelNameString;
            NewVehicle.LicenseNumber = VehicleLicenseNumberString;
            NewVehicle.RemainingEnergyPercentage = VehicleEnergyPrecentage;
            NewVehicle.UpdateCurrentEnergy();

            switch (TypeOfVehicleInt)
            {
                case (1):
                    InsertAMotorcycle(NewVehicle);
                    break;
                case (2):
                    InsertAMotorcycle(NewVehicle);
                    break;
                case (3):
                    InsertACar(NewVehicle);
                    break;
                case (4):
                    InsertACar(NewVehicle);
                    break;
                case (5):
                    InsertATruck(NewVehicle);
                    break;
            }

            //get wheel info
            Console.WriteLine("Please enter Wheel Manufacturer Name.");
            string WheelManufacturerNameString = Console.ReadLine();
            float WheelPressureFloat = GetCurrentWheelPressure(NewVehicle.WheelsList[0].RecommendedMaxAirPressure);

            //update wheel and update info
            foreach (Wheel wheel in NewVehicle.WheelsList)
            {
                wheel.ManufacturerName = WheelManufacturerNameString;
                wheel.CurrentAirPressure = WheelPressureFloat;
            }

            Console.WriteLine("Your Vehicle was succsefully insert to the garage!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Client NewClient = new Client(ClientName, phoneNumber, NewVehicle);
            NewClient.CurrentStatus = Client.eStatus.InRepair;
            i_OurGarage.AddVehicle(NewVehicle, NewClient);
        }

        public static int GetVehicleType()
        {
            bool ValidVehicleType = false;
            int TypeOfVehicleInt = 0;

            while (!ValidVehicleType)
            {
                try
                {
                    Messeges.GetVehicleTypeMessege();
                    string TypeOfVehicleString = Console.ReadLine();
                    Validation.IsIntInRange(0, 5, TypeOfVehicleString, out TypeOfVehicleInt);
                    ValidVehicleType = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }

            return TypeOfVehicleInt;
        }

        public static string GetVehicleLicenseNumber(Garage i_OurGarage)
        {
            string VehicleLicenseNumberString = "";

            try
            {
                Console.WriteLine("Please enter vehicle's license number.");
                VehicleLicenseNumberString = Console.ReadLine();
                i_OurGarage.CheckIfVehicleIsNotInGarage(VehicleLicenseNumberString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The vehicel's status was changed to 'In Repair'.");
                i_OurGarage.ChangeVehicleStatus(VehicleLicenseNumberString, Client.eStatus.InRepair);
            }

            return VehicleLicenseNumberString;
        }

        public static float GetVehicleEnergyPrecentage() 
        {
            string VehicleCurrentEnergyString;
            bool ValidEnergyPrecentage = false;
            float VehicleCurrentEnergyfloat = 0;

            while (!ValidEnergyPrecentage)
            {
                try
                {
                    Console.WriteLine("Please enter vehicle's Current Energy Precentage.");
                    VehicleCurrentEnergyString = Console.ReadLine();
                    Validation.IsFloatInRange(100, VehicleCurrentEnergyString, out VehicleCurrentEnergyfloat);
                    ValidEnergyPrecentage = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return VehicleCurrentEnergyfloat;
        }

        public static float GetCurrentWheelPressure(float i_MaxWheelPressure)
        {
            string CurrentWheelAirPressureString;
            bool ValidAirPressure = false;
            float CurrentWheelAirPressureFloat = 0;

            while (!ValidAirPressure)
            {
                try
                {
                    Console.WriteLine("Please enter current wheel air pressure.");
                    CurrentWheelAirPressureString = Console.ReadLine();

                    Validation.IsFloatInRange(i_MaxWheelPressure, CurrentWheelAirPressureString, out CurrentWheelAirPressureFloat);
                    ValidAirPressure = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return CurrentWheelAirPressureFloat;
        }

        public static void InsertAMotorcycle(Vehicle i_NewVehicle)
        {
            string LicenseTypeString;
            bool ValidLicenseType = false;
            int LicenseTypeInt = 0;

            while (!ValidLicenseType)
            {
                try
                {
                    Messeges.GetLicenseTypeMessege();
                    LicenseTypeString = Console.ReadLine();
                    Validation.IsIntInRange(0, 4, LicenseTypeString, out LicenseTypeInt);
                    ValidLicenseType = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            (i_NewVehicle as MotorCycle).LicenseType = (MotorCycle.eLicenseType)LicenseTypeInt;
            int EngineVolumeInt = 0;
            bool ValidEngineVolume = false;

            while (!ValidEngineVolume)
            {
                try
                {
                    Console.WriteLine("Please enter Engine Volume.");
                    string EngineVolumeString = Console.ReadLine();
                    EngineVolumeInt = Validation.FromStringToInt(EngineVolumeString);
                    ValidEngineVolume = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            (i_NewVehicle as MotorCycle).EnegineVolume = EngineVolumeInt;
        }

        public static void InsertACar(Vehicle i_NewVehicle)
        {
            string CarColorString;
            bool ValidCarColor = false;
            int CarColorInt = 0;

            while (!ValidCarColor)
            {
                try
                {
                    Messeges.GetCarColorMessege();
                    CarColorString = Console.ReadLine();
                    Validation.IsIntInRange(0, 4, CarColorString, out CarColorInt);
                    ValidCarColor = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            (i_NewVehicle as Car).Color = (Car.eColor)CarColorInt;
            string NumberOfDoorsString;
            bool ValidNumberOfDoors = false;
            int NumberOfDoorsInt = 0;

            while (!ValidNumberOfDoors)
            {
                try
                {
                    Messeges.GetNumberOfDoorsMessege();
                    NumberOfDoorsString = Console.ReadLine();
                    Validation.IsIntInRange(2, 5, NumberOfDoorsString, out NumberOfDoorsInt);
                    ValidNumberOfDoors = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            (i_NewVehicle as Car).NumberOfDoors = (Car.eNumberOfDoors)NumberOfDoorsInt;
        }

        public static void InsertATruck(Vehicle i_NewVehicle)
        {
            string ContainsCooledCargoString;
            bool ValidContainsCooledCargo = false;
            int ContainsCooledCargoInt = 0;

            while (!ValidContainsCooledCargo)
            {
                try
                {
                    Messeges.GetCooledCargoMessege();
                    ContainsCooledCargoString = Console.ReadLine();
                    Validation.IsIntInRange(0, 2, ContainsCooledCargoString, out ContainsCooledCargoInt);
                    ValidContainsCooledCargo = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (ContainsCooledCargoInt == 1)
            {
                (i_NewVehicle as Truck).ContainsCooledCargo = true;
            }
            else
            {
                (i_NewVehicle as Truck).ContainsCooledCargo = false;
            }

            string CargoTankVolumeString;
            bool ValidCargoTankVolume = false;
            float CargoTankVolumeFloat = 0;

            while (!ValidCargoTankVolume)
            {
                try
                {
                    Console.WriteLine("Please enter Cargo Tank Volume");
                    CargoTankVolumeString = Console.ReadLine();
                    CargoTankVolumeFloat = Validation.FromStringToFloat(CargoTankVolumeString);
                    ValidCargoTankVolume = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            (i_NewVehicle as Truck).CargoTankVolume = CargoTankVolumeFloat;
        }
    }
}

