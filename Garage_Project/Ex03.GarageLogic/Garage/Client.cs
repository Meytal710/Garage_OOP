using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Garage
{
    public class Client
    {
        private string m_ClientName;
        private string m_ClientPhoneNumber;
        private Vehicle m_ClientVehicle;
        private eStatus m_CurrentStatus;

        public Client(string i_ClientName, string i_ClientPhoneNumber, Vehicle i_ClientVehicle)
        {
            m_ClientName = i_ClientName;
            m_ClientPhoneNumber = i_ClientPhoneNumber;
            m_ClientVehicle = i_ClientVehicle;
        }

        public string ClientName
        {
            get
            {
                return m_ClientName;
            }
            set
            {
                m_ClientName = value;
            }
        }

        public string ClientPhoneNumber
        {
            get
            {
                return m_ClientPhoneNumber;
            }
            set
            {
                m_ClientPhoneNumber = value;
            }
        }

        public Vehicle ClientVehicle
        {
            get
            {
                return m_ClientVehicle;
            }
            set
            {
                m_ClientVehicle = value;
            }
        }

        public eStatus CurrentStatus
        {
            get
            {
                return m_CurrentStatus;
            }
            set
            {
                m_CurrentStatus = value;
            }
        }

        public enum eStatus
        {
            InRepair = 1,
            Repaired = 2,
            PaiedFor = 3
        }

        public override string ToString()
        {
            return String.Format(@"Owner Name: {0}, 
                                 {1}", m_ClientName, m_ClientVehicle.ToString());
        }
    }
}




