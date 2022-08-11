using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Car
{
    public class FuelBasedCar : Car
    {
        private FuelBased m_FuelTypeAndTankSize;
        public FuelBasedCar()
        {
            m_FuelTypeAndTankSize = new FuelBased(38f, FuelBased.eFuelType.Octan95);
            this.EnergyType = m_FuelTypeAndTankSize;
        }

        public override string ToString()
        {
            return String.Format(@"Car type: FuelBased Car 
            {0}", base.ToString());
        }
    }
}
