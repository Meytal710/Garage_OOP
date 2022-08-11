using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Validation
    {
        public static bool IsFloatInRange(float i_Range, string i_InputString, out float io_InputFloat)
        {
            bool isValid = false;

            if (Single.TryParse(i_InputString, out io_InputFloat))
            {
                if (io_InputFloat <= i_Range && io_InputFloat > 0)
                {
                    isValid = true;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, i_Range);
                }
            }
            else
            {
                throw new FormatException("This is an invalid input, it should be a float!");
            }

            return isValid;
        }

        public static bool IsIntInRange(int i_Start ,int i_End, string i_InputString, out int io_InputInt)
        {
            bool isValid = false;

            if (int.TryParse(i_InputString, out io_InputInt))
            {
                if (io_InputInt <= i_End && io_InputInt >= i_Start)
                {
                    isValid = true;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_Start, i_End);
                }
            }
            else
            {
                throw new FormatException("This is an invalid input, it should be an integer!");
            }

            return isValid;
        }

        public static float FromStringToFloat(string i_InputString)
        {
            if (!Single.TryParse(i_InputString, out float outputFloat))
            {
                throw new FormatException("This is an invalid input, it should be a float!");
            }

            return outputFloat;
        }

        public static int FromStringToInt(string i_InputString)
        {
            if (!int.TryParse(i_InputString, out int outputInt))
            {
                throw new FormatException("This is an invalid input, it should be a int!");
            }

            return outputInt;
        }
    }
}
