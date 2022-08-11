using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private const int k_TirePressure = 31;
        private eLicenseType m_LicenseType;
        private int m_EnegineVolume;

        public MotorCycle()
        {
            Wheel firstWheel = new Wheel(k_TirePressure);
            Wheel secondWheel = new Wheel(k_TirePressure);
            WheelsList.Add(firstWheel);
            WheelsList.Add(secondWheel);
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EnegineVolume
        {
            get
            {
                return m_EnegineVolume;
            }
            set
            {
                m_EnegineVolume = value;
            }
        }

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            B1 = 3,
            BB = 4
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"Motorcycle License Type: {0}, ", m_LicenseType);
        }
    }
}
