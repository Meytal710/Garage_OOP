using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_WheelsList;
        private EnergyType m_EnergyType;

        public Vehicle()
        {
            m_ModelName = "";
            m_LicenseNumber = "";
            m_RemainingEnergyPercentage = 0;
            m_WheelsList = new List<Wheel>();
            m_EnergyType = null;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        public List<Wheel> WheelsList
        {
            get
            {
                return m_WheelsList;
            }
            set
            {
                WheelsList = value;
            }
        }

        public EnergyType EnergyType
        {
            get
            {
                return m_EnergyType;
            }
            set
            {
                m_EnergyType = value;
            }
        }

        public void CalculatingRemainingEnergyPercentage()
        {
            m_RemainingEnergyPercentage = m_EnergyType.CurrentEnergy / m_EnergyType.MaxEnergy;
        }

        public void UpdateCurrentEnergy()
        {
            this.EnergyType.CurrentEnergy = this.EnergyType.MaxEnergy * RemainingEnergyPercentage / 100;
        }

        public override string ToString()
        {
            return String.Format(@"Model Name: {0},
            License Number: {1},
             {2},
            Wheel Details:
            number of wheels: {3},
            {4}
            Remaining Energy Percentage: {5}", m_ModelName, m_LicenseNumber,
            m_EnergyType.ToString(), WheelsList.Count, WheelsList.ToString(), m_RemainingEnergyPercentage);
        }
    }
}
