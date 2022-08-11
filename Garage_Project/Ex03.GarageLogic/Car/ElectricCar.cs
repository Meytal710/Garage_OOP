using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Car
{
    public class ElectricCar : Car
    {
        private EnergyType m_MaxBatteryLife;

        public ElectricCar()
        {
            m_MaxBatteryLife = new EnergyType(3.3f, EnergyType.eEnergyType.Electric);
            this.EnergyType = m_MaxBatteryLife;
        }

        public override string ToString()
        {
            return String.Format(@"Car type: Electric Car 
             {0}", base.ToString());
        }
    }
}
