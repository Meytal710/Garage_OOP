using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Truck
{
    public class Truck : Vehicle
    {
        private const int k_TirePressure = 24;
        private const int k_NumberOfWheels = 16;
        private bool m_ContainsCooledCargo;
        private float m_CargoTankVolume;

        public Truck()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.WheelsList.Add(new Wheel(k_TirePressure));
            }
        }

        public bool ContainsCooledCargo
        {
            get
            {
                return m_ContainsCooledCargo;
            }
            set
            {
                m_ContainsCooledCargo = value;
            }
        }

        public float CargoTankVolume
        {
            get
            {
                return m_CargoTankVolume;
            }
            set
            {
                m_CargoTankVolume = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"
            Cooled Cargo on Truck ? {0}, 
            Cargo tank volume: {1}", m_ContainsCooledCargo, m_CargoTankVolume);
        }
    }
}
