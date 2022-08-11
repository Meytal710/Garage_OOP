using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class Messeges
    {
        public static void GetVehicleTypeMessege()
        {
            Console.WriteLine(String.Format(@"
What type of vehicle would you like to insert to the garage?

============================================================

1. Fuel Based Motorcycle.

2. Electric Motorcycle.

3. Fuel Based Car.

4. Electric Car.

5. Fuel Based Truck."));
        }

        public static void OptionsMessege()
        {
            Console.WriteLine(String.Format(@"
What would you like to do?

==========================================================

1. Insert a new vehicel into the garage.

2. Display a list of license numbers currently in the garage.

3. Change a certain vehicle’s status.

4. Inflate tires to maximum.

5. Refuel a fuel-based vehicle.

6. Charge an electric-based vehicle.

7. Display vehicle information.

8. Exit.

=========================================================="));
        }

        public static void DisplayAListOfVehiclesInGarageMessege()
        {
            Console.WriteLine(String.Format(@"
What type of list would you like?

1. ALL vehicles in the garage

2. Vehicles in repair.

3. Repaired vehicles.

4. Payed for vehicles."));
        }

        public static void ChangeAVehicleStatusMessege()
        {
            Console.WriteLine(String.Format(@"
What is the new status?

1. Vehicel in repair.

2. Repaired vehicle.

3. Payed for vehicle."));
        }

        public static void GetFuelTypeMessege()
        {
            Console.WriteLine(String.Format(@"
What is the type of fuel you want to use?

1. Octan98.

2. Octan96.

3. Octan95

4. Solar."));
        }

        public static void GetLicenseTypeMessege()
        {
            Console.WriteLine(String.Format(@"
What is the license type?

1. A.

2. A1.

3. B1.

4. BB."));
        }

        public static void GetCarColorMessege()
        {
            Console.WriteLine(String.Format(@"
What is car's color?

1. Red.

2. White.

3. Green.

4. Blue."));
        }

        public static void GetNumberOfDoorsMessege()
        {
            Console.WriteLine(String.Format(@"
How many Door?

2. Two.

3. Three.

4. Four.

5. Five."));
        }

        public static void GetCooledCargoMessege()
        {
            Console.WriteLine(String.Format(@"
Does the truck containes cooled cargo?

1. Yes.

2. No."));
        }

        public static void GarageIsEmptyMessege()
        {
            Console.WriteLine(@"There is no vehicles in our garage. Please insert a new vehicle (option 1)
Press enter to go back to all the others options");
            Console.ReadLine();
        }
    }
}

