using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Garage.Client;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private Dictionary<string, Client> m_ListOfVehiclesInTheGarag;

        public Garage()
        {
            m_ListOfVehiclesInTheGarag = new Dictionary<string, Client>();
        }

        public bool CheckIfVehicleInGarage(string i_LicenseNumber)
        {
            bool isInGarage = false;

            if (!m_ListOfVehiclesInTheGarag.ContainsKey(i_LicenseNumber))
            {
                throw new FormatException("Vehicle is NOT in the Garage");
            }
            else
            {
                isInGarage = true;
            }

            return isInGarage;
        }

        public bool CheckIfVehicleIsNotInGarage(string i_LicenseNumber)
        {
            bool isNotInGarage = false;

            if (m_ListOfVehiclesInTheGarag.ContainsKey(i_LicenseNumber))
            {
                throw new FormatException("Vehicle is already in the Garage");
            }
            else
            {
                isNotInGarage = true;
            }

            return isNotInGarage;
        }

        public void AddVehicle(Vehicle i_VehicleToAdd, Client i_NewClient)
        {
            m_ListOfVehiclesInTheGarag.Add(i_VehicleToAdd.LicenseNumber, i_NewClient);
        }
        
        //without filtering
        public List<string> ListOfVehiclesInTheGarage()
        {
            List <string> ListOfVehiclesInTheGarage = new List<string>();

            foreach (Client client in m_ListOfVehiclesInTheGarag.Values)
            {
                ListOfVehiclesInTheGarage.Add(client.ClientVehicle.LicenseNumber);
            }

            return ListOfVehiclesInTheGarage;
        }

        //filter by status 
        public List<string> ListOfVehiclesInTheGarageByStatus(eStatus i_RequestedStatus)
        {
            List<string> ListOfVehiclesInTheGarageByStatus = new List<string>();

            foreach (Client client in m_ListOfVehiclesInTheGarag.Values)
            {
                if (client.CurrentStatus == i_RequestedStatus)
                {
                    ListOfVehiclesInTheGarageByStatus.Add(client.ClientVehicle.LicenseNumber);
                }
            }

            return ListOfVehiclesInTheGarageByStatus;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, Client.eStatus i_NewStatus)
        {
            if (CheckIfVehicleInGarage(i_LicenseNumber))
            {
                Client tempClient = m_ListOfVehiclesInTheGarag[i_LicenseNumber];
                tempClient.CurrentStatus = i_NewStatus;
                m_ListOfVehiclesInTheGarag[i_LicenseNumber] = tempClient;
            }
        }

        public void InfaliteWheelsToMaximum(string i_LicenseNumber)
        {
            if (CheckIfVehicleInGarage(i_LicenseNumber))
            {
                Client currentClient = m_ListOfVehiclesInTheGarag[i_LicenseNumber];
                Vehicle currentVehicle = currentClient.ClientVehicle;

                foreach (Wheel wheel in currentVehicle.WheelsList)
                {
                    wheel.InFlateToMaximum();
                }
            }
        }

        public void FuelVehicle(string i_LicenseNumber, FuelBased.eFuelType i_FuelType, string i_AmountToFill)
        {
            if (CheckIfVehicleInGarage(i_LicenseNumber))
            {
                Client currentClient = m_ListOfVehiclesInTheGarag[i_LicenseNumber];
                Vehicle currentVehicle = currentClient.ClientVehicle;

                if (currentVehicle.EnergyType.TypeOfEnergy == EnergyType.eEnergyType.Electric)
                {
                    throw new FormatException("This Vehicel is electrical. You cannot pump it with fuel");
                }
                else
                {
                    FuelFuelBasedVehicel(currentVehicle, i_FuelType, i_AmountToFill);
                }
            }
        }

        //vehicel is fuelBased and in garage
        public void FuelFuelBasedVehicel(Vehicle i_CurrentVehicle, FuelBased.eFuelType i_FuelType, string i_AmountToFillString)
        {
            FuelBased.eFuelType currentFuelType = (i_CurrentVehicle.EnergyType as FuelBased).FuelType;

            if (currentFuelType != i_FuelType)
            {
                throw new FormatException("This Vehicel runs on " + currentFuelType + ". You cannot pump it with " + i_FuelType);
            }
            else
            {
                if (Validation.IsFloatInRange(i_CurrentVehicle.EnergyType.MaxEnergy - i_CurrentVehicle.EnergyType.CurrentEnergy, i_AmountToFillString, out float AmountToFillFloat))
                {
                    i_CurrentVehicle.EnergyType.CurrentEnergy += AmountToFillFloat;
                    i_CurrentVehicle.CalculatingRemainingEnergyPercentage();
                }
            }
        }

        public void ChargeAnElectricVehicel(string i_LicenseNumber, string i_MinutesToAdd)
        {
            if (CheckIfVehicleInGarage(i_LicenseNumber))
            {
                Client currentClient = m_ListOfVehiclesInTheGarag[i_LicenseNumber];
                Vehicle currentVehicle = currentClient.ClientVehicle;

                if (currentVehicle.EnergyType.TypeOfEnergy == EnergyType.eEnergyType.FuelBased)
                {
                    throw new FormatException("This Vehicel is fuelBased. You cannot pump it with electricity");
                }
                else
                {
                    AddElectricityToElectricVehicel(currentVehicle, i_MinutesToAdd);
                }
            }
        }

        public void AddElectricityToElectricVehicel(Vehicle i_CurrentVehicle, string i_MinutesToAdd)
        {
            float EnergyToAdd = FromMinutesToHours(i_MinutesToAdd);
            float Range = i_CurrentVehicle.EnergyType.MaxEnergy - i_CurrentVehicle.EnergyType.CurrentEnergy;

            if (EnergyToAdd <= Range && EnergyToAdd > 0)
            {
                i_CurrentVehicle.EnergyType.CurrentEnergy += EnergyToAdd;
                i_CurrentVehicle.CalculatingRemainingEnergyPercentage();
            }
            else
            {
                throw new ValueOutOfRangeException(0, Range);
            }
        }

        public float FromMinutesToHours(string i_MinutesToConvert)
        {
            float minutes = Validation.FromStringToFloat(i_MinutesToConvert);

            return minutes / 60;
        }

        public void DisplayVehicelInformation(string i_LicenseNumber)
        {
            if (CheckIfVehicleInGarage(i_LicenseNumber))
            {
                Client currentClient = m_ListOfVehiclesInTheGarag[i_LicenseNumber];
                currentClient.ToString();
            }
        }

        public bool IsGarageEmpty()
        {
            bool IsEmpty = false;

            if  (m_ListOfVehiclesInTheGarag.Count == 0)
            {
                IsEmpty = true;
            }
            return IsEmpty;
        }
    }
}
