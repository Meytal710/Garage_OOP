using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Garage;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_OurGarage;

        public void Run()
        {
            Console.WriteLine(@"==============================================

Welcome To Galgaliey Sophie And Manoey Meytal!

==============================================

Press enter to continue...");
            Console.ReadLine();
            m_OurGarage = new Garage();
            bool StillRunning = true;
            
            while (StillRunning)
            {
                Console.Clear();
                Messeges.OptionsMessege();
                string OptionChosenString = Console.ReadLine();

                try
                {
                    GarageLogic.Validation.IsIntInRange(0, 8, OptionChosenString, out int OptionChosenInt);
                    if (m_OurGarage.IsGarageEmpty() && OptionChosenInt != 1)
                    {
                        Console.Clear();
                        Messeges.GarageIsEmptyMessege();
                        continue;
                    }
                    switch (OptionChosenInt)
                    {
                        case (1):
                            InsertVehicleIntoGarage.InsertAVehicle(m_OurGarage);
                            break;
                        case (2):
                            // add to all the other cases the "garage is empty" messege.
                            DisplayAListOfVehiclesInGarage();
                            break;
                        case (3):
                            ChangeAVehicleStatus();
                            break;
                        case (4):
                            InflateWheelsToMaximum();
                            break;
                        case (5):
                            RefuelAFuelBasedVehicle();
                            break;
                        case (6):
                            ChargeAnElectricVehicle();
                            break;
                        case (7):
                            DisplayVehicleInformation();
                            break;
                        case (8):
                            StillRunning = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                 
            }
        }

        public void DisplayAListOfVehiclesInGarage()
        {
            Console.Clear();
            bool InvalidInput = true;
            List<string> ListOfVehicleToPrint = null;
            bool CatchedException = false;

            while (InvalidInput)
            {
                try
                {
                    Messeges.DisplayAListOfVehiclesInGarageMessege();
                    string TypeOfListString = Console.ReadLine();
                    GarageLogic.Validation.IsIntInRange(0, 4, TypeOfListString, out int TypeOfListInt);
                    Console.Clear();

                    switch (TypeOfListInt)
                    {
                        case (1):
                            ListOfVehicleToPrint = m_OurGarage.ListOfVehiclesInTheGarage();
                            Console.WriteLine("The list of all vehicle in the garage is:");
                            break;

                        case (2):
                            ListOfVehicleToPrint = m_OurGarage.ListOfVehiclesInTheGarageByStatus(Client.eStatus.InRepair);
                            Console.WriteLine("The list of all vehicle InRepair in the garage is:");
                            break;

                        case (3):
                            ListOfVehicleToPrint = m_OurGarage.ListOfVehiclesInTheGarageByStatus(Client.eStatus.Repaired);
                            Console.WriteLine("The list of all vehicle Repaired in the garage is:");
                            break;

                        case (4):
                            ListOfVehicleToPrint = m_OurGarage.ListOfVehiclesInTheGarageByStatus(Client.eStatus.PaiedFor);
                            Console.WriteLine("The list of all vehicle PaiedFor in the garage is:");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    Console.Clear();
                    CatchedException = true;
                }
                finally
                {
                    if (!CatchedException)
                    {
                        foreach (string vehicle in ListOfVehicleToPrint)
                        {
                            Console.WriteLine(vehicle);
                        }
                        InvalidInput = false;
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                    }
                }
            }
        }

        public void ChangeAVehicleStatus()
        {
            bool CatchedException = false;
            string Status = "";
            bool InvalidInput = true;

            while (InvalidInput)
            {
                Console.Clear();
                Console.WriteLine(@"Please enter vehicle's License Number.

Or press 'e' to go back to all the options");
                string LicenseNumberString = Console.ReadLine();

                if (LicenseNumberString == "e")
                {
                    break;
                }

                try
                {
                    Messeges.ChangeAVehicleStatusMessege();
                    string newStatusString = Console.ReadLine();
                    GarageLogic.Validation.IsIntInRange(0, 3, newStatusString, out int newStatusInt);

                    switch (newStatusInt)
                    {
                        case (1):
                            m_OurGarage.ChangeVehicleStatus(LicenseNumberString, Client.eStatus.InRepair);
                            Status = "InRepair";
                            break;
                        case (2):
                            m_OurGarage.ChangeVehicleStatus(LicenseNumberString, Client.eStatus.Repaired);
                            Status = "Repaired";
                            break;
                        case (3):
                            m_OurGarage.ChangeVehicleStatus(LicenseNumberString, Client.eStatus.PaiedFor);
                            Status = "PaiedFor";
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    CatchedException = true;
                    Console.ReadLine();
                }
                finally
                {
                    if (!CatchedException)
                    {
                        Console.WriteLine(string.Format(@"Moved {0} to {1} status..

Press enter to continue...", LicenseNumberString , Status));
                        Console.ReadLine();
                        InvalidInput = false;
                    }
                }
            }
        }

        public void InflateWheelsToMaximum()
        {
            string LicenseNumberString;
            bool CatchedException = true;

            while (CatchedException)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(@"Please enter vehicle's License Number.

Or press 'e' to go back to all the options");
                    LicenseNumberString = Console.ReadLine();
                    if(LicenseNumberString == "e")
                    {
                        break;
                    }
                    m_OurGarage.InfaliteWheelsToMaximum(LicenseNumberString);
                    CatchedException = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        } 

        public void RefuelAFuelBasedVehicle()
        {
            string LicenseNumberString;
            bool CatchedException = true;
            bool InvalidInput = true;

            while (InvalidInput)
            {
                string FuelTypeString = "";
                string AmountToFillString = "";
                Console.Clear();
                Console.WriteLine(@"Please enter vehicle's License Number.

Or press 'e' to go back to all the options");
                LicenseNumberString = Console.ReadLine();
                if (LicenseNumberString == "e")
                {
                    break;
                }
                try
                {
                    if (m_OurGarage.CheckIfVehicleInGarage(LicenseNumberString))
                    {
                        CatchedException = false;
                    }

                    Messeges.GetFuelTypeMessege();
                    FuelTypeString = Console.ReadLine();
                    GarageLogic.Validation.IsIntInRange(0, 4, FuelTypeString, out int FuelTypeInt);
                    Console.WriteLine(@"Please enter amount of fuel to fill.

Or press 'e' to go back to all the options");
                    if (LicenseNumberString == "e")
                    {
                        break;
                    }
                    AmountToFillString = Console.ReadLine();
                    GarageLogic.Validation.IsIntInRange(0, 4, AmountToFillString, out int AmountToFillInt);

                    switch (FuelTypeInt)
                    {
                        case (1):
                            m_OurGarage.FuelVehicle(LicenseNumberString, GarageLogic.FuelBased.eFuelType.Octan98, AmountToFillString);
                            FuelTypeString = "Octan98";
                            break;
                        case (2):
                            m_OurGarage.FuelVehicle(LicenseNumberString, GarageLogic.FuelBased.eFuelType.Octan96, AmountToFillString);
                            FuelTypeString = "Octan96";
                            break;
                        case (3):
                            m_OurGarage.FuelVehicle(LicenseNumberString, GarageLogic.FuelBased.eFuelType.Octan95, AmountToFillString);
                            FuelTypeString = "Octan95";
                            break;
                        case (4):
                            m_OurGarage.FuelVehicle(LicenseNumberString, GarageLogic.FuelBased.eFuelType.Soler, AmountToFillString);
                            FuelTypeString = "Solar";
                            break;
                    }
                }
                catch (Exception e)
                {
                    CatchedException = true;
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                finally
                {
                    if (!CatchedException)
                    {
                        Console.WriteLine(@"Filled Vehicle {0} with {1} and amount of {2}
Press enter to continue...", LicenseNumberString, FuelTypeString, AmountToFillString);
                        Console.ReadLine();
                        InvalidInput = false;
                    }
                }
            }
        }

        public void ChargeAnElectricVehicle()
        {
            bool CatchedException = true;

            while (CatchedException)
            {
                Console.Clear();
                Console.WriteLine(@"Please enter vehicle's License Number.

Or press 'e' to go back to all the options");
                string LicenseNumberString = Console.ReadLine();
                if (LicenseNumberString == "e")
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine(@"Please enter number of minutes to charge.

Or press 'e' to go back to all the options");
                string NumberOfMinutesToChargeString = Console.ReadLine();
                if (NumberOfMinutesToChargeString == "e")
                {
                    break;
                }

                try
                {
                    m_OurGarage.ChargeAnElectricVehicel(LicenseNumberString, NumberOfMinutesToChargeString);
                    CatchedException = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void DisplayVehicleInformation()
        {
            bool CatchedException = true;

            while (CatchedException)
            {
                Console.Clear();
                Console.WriteLine(@"Please enter vehicle's License Number.

Or press 'e' to go back to all the options");
                string LicenseNumberString = Console.ReadLine();
                if (LicenseNumberString == "e")
                {
                    break;
                }

                try
                {
                    m_OurGarage.DisplayVehicelInformation(LicenseNumberString);
                    CatchedException = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }

        public enum eVehicleType
        {
            FuelBasedMotorcycle = 1,
            ElectricMotorcycle = 2,
            FuelBasedCar = 3,
            ElectricCar = 4,
            FuelBasedTruck = 5
        }
    }
}

