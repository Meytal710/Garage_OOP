using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Truck
{
    public class FuelBasedTruck : Truck
    {
        private FuelBased m_FuelTypeAndVolum;

        public FuelBasedTruck()
        {
            m_FuelTypeAndVolum = new FuelBased(120f, FuelBased.eFuelType.Soler);
            this.EnergyType = m_FuelTypeAndVolum;
        }

        public override string ToString()
        {
            return String.Format(@"Truck type: Fuel Based Truck
            {0}", base.ToString());
        }
    }
}
