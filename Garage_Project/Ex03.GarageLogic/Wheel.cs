using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_RecommendedMaxAirPressure;

        public Wheel(float i_RecommendedMaxAirPressure)
        {
            r_RecommendedMaxAirPressure = i_RecommendedMaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float RecommendedMaxAirPressure
        {
            get
            {
                return r_RecommendedMaxAirPressure;
            }
        }

        public void Inflate(string i_AirToAddString)
        {
            if (Validation.IsFloatInRange((r_RecommendedMaxAirPressure - m_CurrentAirPressure), i_AirToAddString, out float airToAddFloat))
            {
                m_CurrentAirPressure += airToAddFloat;
            }
        }

        public void InFlateToMaximum()
        {
            m_CurrentAirPressure = r_RecommendedMaxAirPressure;
        }

        public override string ToString()
        {
            return String.Format(@"Manufacturer Name: {0},
            Current Air Pressure: {1},
            Recommended Max Air Pressure: {2}",
                m_ManufacturerName, m_CurrentAirPressure, r_RecommendedMaxAirPressure);
        }
    }
}
