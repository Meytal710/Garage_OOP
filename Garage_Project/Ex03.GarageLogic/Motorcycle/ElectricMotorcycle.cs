using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : MotorCycle
    {
        private EnergyType m_MaxBatteryLife;

        public ElectricMotorcycle()
        {
            m_MaxBatteryLife = new EnergyType(2.5f, EnergyType.eEnergyType.Electric);
            this.EnergyType = m_MaxBatteryLife;
        }

        public override string ToString()
        {
            return String.Format(@"Motorcycle type: Electric Motorcycle 
             {0}", base.ToString());
        }
    }
}
