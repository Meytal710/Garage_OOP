using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBased : EnergyType
    {
        private eFuelType m_FuelType;

        public FuelBased(float i_MaxEnergy, eFuelType i_FuelType) : base(i_MaxEnergy, eEnergyType.FuelBased)
        {
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        public enum eFuelType
        {
            Octan98 = 1,
            Octan95 = 2,
            Soler = 3,
            Octan96 = 4
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(
               "FuelBased Vehical with {1} type of fuel", m_FuelType);
        }
    }
}
