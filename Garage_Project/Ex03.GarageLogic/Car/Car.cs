using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Car
{
    public class Car : Vehicle
    {
        private const int k_TirePressure = 29;
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car()
        {
            Wheel firstWheel = new Wheel(k_TirePressure);
            Wheel secondWheel = new Wheel(k_TirePressure);
            Wheel ThridWheel = new Wheel(k_TirePressure);
            Wheel FourthWheel = new Wheel(k_TirePressure);
            WheelsList.Add(firstWheel);
            WheelsList.Add(secondWheel);
            WheelsList.Add(ThridWheel);
            WheelsList.Add(FourthWheel);
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public enum eColor
        {
            Red = 1,
            White = 2,
            Green = 3,
            Blue = 4
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("Car Color: {0}, Number of Doors: {1}", m_Color, m_NumberOfDoors);
        }
    }
}
