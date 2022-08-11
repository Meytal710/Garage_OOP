using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedMotorcycle : MotorCycle
    {
        private FuelBased m_FuelTypeAndTankSize;

        public FuelBasedMotorcycle()
        {
            m_FuelTypeAndTankSize = new FuelBased(6.2f, FuelBased.eFuelType.Octan98);
            this.EnergyType = m_FuelTypeAndTankSize;
        }

        public override string ToString()
        {
            return String.Format(@"Motorcycle type: FuelBased Motorcycle 
             {0}", base.ToString());
        }
    }
}
