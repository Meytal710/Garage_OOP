using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class EnergyType
    {
        private readonly eEnergyType r_EnergyType;
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public EnergyType(float i_MaxEnergy, eEnergyType i_EnergyType)
        {
            r_MaxEnergy = i_MaxEnergy;
            r_EnergyType = i_EnergyType;
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                m_CurrentEnergy = value;
            }
        }

        public eEnergyType TypeOfEnergy
        {
            get
            {
                return r_EnergyType;
            }
        }

        public void AddEnergy(string i_EnergyToAddString)
        {
            if (Validation.IsFloatInRange(r_MaxEnergy - m_CurrentEnergy, i_EnergyToAddString, out float EnergyToAddFloat))
            {
                m_CurrentEnergy += EnergyToAddFloat;
            }
        }

        public enum eEnergyType
        {
            FuelBased = 1,
            Electric = 2
        }

        public override string ToString()
        {
            return String.Format(@"Type of energy: {0}
            Current Amount Of Energy: {1}. Max Energy: {2}",
            r_EnergyType, m_CurrentEnergy, r_MaxEnergy);
        }
    }
}
