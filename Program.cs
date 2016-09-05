using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_The_Greeks
{

    /// <summary>
    /// Holds x and y coordinates for a point in space and a name for the set of coordinates.
    /// </summary>
    public class Coordinates
    {
        //variable declaration for Coordinates
        public double xPoint;
        public double yPoint;
        public string name;

        //default constructor for Coordinates
        public Coordinates()
        {
            name = "point";
            xPoint = 0;
            yPoint = 0;
        }

        //explicit-value constructor for Coordinates
        public Coordinates(string id, double x, double y)
        {
            name = id;
            xPoint = x;
            yPoint = y;
        }

        /// <summary>
        /// Provides a means to set or change the xPoint and yPoint in Coordinates.
        /// </summary>
        /// <param name="x">"x" coordinate in a cartesian coordinate system</param>
        /// <param name="y">"y" coordinate in a cartesian coordinate system</param>
        /// <returns>void</returns>
        public void SetCoordinates(double x, double y)
        {
            xPoint = x;
            yPoint = y;
        }

        /// <summary>
        /// Provides a means to set or change the name of the Coordinate.
        /// </summary>
        /// <param name="id">A string value that can be printed to the screen for the user's understanding.</param>
        /// <returns>void</returns>
        public void SetName(string id)
        {
            name = id;
        }

        /// <summary>
        /// Provides access to the value stored in xPoint.
        /// </summary>
        /// <returns>a value of type double that is equal to the value stored in Coordinate.xPoint.</returns>
        public double GetX()
        {
            return xPoint;
        }

        /// <summary>
        /// Provides access to the value stored in yPoint.
        /// </summary>
        /// <returns>a value of type double that is equal to the value stored in Coordinate.yPoint.</returns>
        public double GetY()
        {
            return yPoint;
        }

        /// <summary>
        /// Provides access tot he value stored in name.
        /// </summary>
        /// <returns>a type string containing the identifiable name of Coordinate for the user.</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Gets the x and y coordinates from the user.
        /// </summary>
        /// <returns>void</returns>
        public void GetCoordinates()
        {

            //Requests the x value and does some validation to ensure the value is an appropriate double value.
            Console.Write("Please enter the x value for {0}: ", name);
            while (!double.TryParse(Console.ReadLine(), out xPoint))
            {
                Console.Write("Invalid entry. Try again: ");
            }
            
            //Requests the y value and does some validation to ensure the value is an appropriate double value.
            Console.Write("Please enter the y value for {0}: ", name);
            while (!double.TryParse(Console.ReadLine(), out yPoint))
            {
                Console.Write("Invalid entry. Try again: ");
            }
        }

        /// <summary>
        /// Prints the name, x and y coordinates to the screen.
        /// </summary>
        /// <returns>void</returns>
        public void PrintCoordinates()
        {
            Console.WriteLine("For {0}:", name);
            Console.WriteLine("x = {0:F3}", xPoint);
            Console.WriteLine("y = {0:F3}\n", yPoint);
        }

    }

    /// <summary>
    /// Calculates the differences between two x coordinates and between two y coordinates. The differences between the two sets of x and y values are then used to calculate
    ///     the distance and angle between the two sets of coordinates.
    /// </summary>
    public class Delta
    {

        //variable declarations
        public string name;
        public double firstX;
        public double firstY;
        public double secondX;
        public double secondY;
        public double deltaX;
        public double deltaY;
        public double distance;
        public double angle;
        
        //Default constructor declaration
        public Delta()
        {
            name = "Delta";
            firstX = 0;
            firstY = 0;
            secondX = 0;
            secondY = 0;
            deltaX = 0;
            deltaY = 0;
            distance = 0;
            angle = 0;
        }

        //Explicit-value constructor declaration
        //The values for two points can be specifically chosen.
        public Delta(string id, double fx, double fy, double sx, double sy)
        {

            //only name, firstX, firstY, secondX and secondY are assigned.
            name = id;
            firstX = fx;
            firstY = fy;
            secondX = sx;
            secondY = sy;

            //deltaX, deltaY, distance and angle are calculated based on the values provided above.
            deltaX = secondX - firstX;
            deltaY = secondY - firstY;
            distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);
        }

        //Explicit-value constructor declaration.
        //Two points can be provided and deltaX, deltaY, distance and angle can be calculated for those two points.
        public Delta(string id, Coordinates first, Coordinates second)
        {
            name = id;
            firstX = first.GetX();
            firstY = first.GetY();
            secondX = second.GetX();
            secondY = second.GetY();
            deltaX = secondX - firstX;
            deltaY = secondY - firstY;
            distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);
        }
        
        /// <summary>
        /// Prints to the screen, for the user, the deltaX and deltaY.
        /// </summary>
        /// <returns>void</returns>
        public void PrintDelta()
        {
            Console.WriteLine("For {0}: ", name);
            Console.WriteLine("DeltaX = {0}", deltaX);
            Console.WriteLine("DeltaY = {0}\n", deltaY);
        }

        /// <summary>
        /// Provides the distance between two points.
        /// </summary>
        /// <returns>The distance between two points as a double value.</returns>
        public double GetDistance()
        {
            return distance;
        }
        
        /// <summary>
        /// Provides the angle between two points.
        /// </summary>
        /// <returns>The angle between two points as a double value.</returns>
        public double GetAngle()
        {
            return angle;
        }

    }

    /// <summary>
    /// This class is used to specifically output to the screen the answers for assignment 1.
    /// </summary>
    class Program
    {
                
        /// <summary>
        /// Provides a welcome message for the user explaining what this program does.
        /// Prompts the user for two sets of x and y coordinates.
        /// Calculates the distance and angle between the two sets of coordinates provided by the user.
        /// Prints to the screen the distance and angle between the two sets of coordinates.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Explicit declaration of first and second coordinates that the user will be prompted for. The default values for both sets of coordinates is 0, 0. 
            Coordinates firstCoordinates = new Coordinates("Point1", 0, 0);
            Coordinates secondCoordinates = new Coordinates("Point2", 0, 0);
            
            //Prints a welcome message explaining what this program does for the user.
            printWelcome();

            //Prompt the user for the first and second sets of coordinates.
            firstCoordinates.GetCoordinates();
            secondCoordinates.GetCoordinates();

            //Explicit declaration of delta for the first and second coordinates. This declaration has to occur after the values for both sets of coordinates are
            //obtained from the user, or the delta will just be 0.
            Delta delta = new Delta("Delta", firstCoordinates, secondCoordinates);

            //Prints the calculated values for distance and angle to the screen for the user, along with a confirmation of the values provided by the user.
            printAnswer(firstCoordinates, secondCoordinates, delta);

            //ReadKey is used to pause the program.
            Console.ReadKey();
        }

        /// <summary>
        /// Prints a welcome message for the user explaining what this program does.
        /// </summary>
        /// <returns>void</returns>
        static void printWelcome()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("**                       WELCOME!                       **");
            Console.WriteLine("** This application will calculate the distance between **");
            Console.WriteLine("** two points and the angle between those points.       **");
            Console.WriteLine("**********************************************************");
        }

        /// <summary>
        /// Prints the first and second set of coordinates to the screen along with the distance and angle between the coordinates.
        /// </summary>
        /// <param name="first">First set of x,y cartesian coordinates used to calculate distance and angle between two points.</param>
        /// <param name="second">Second set of x,y cartesian coordinates used to calculate distance and angle between two points.</param>
        /// <param name="delta">Actual calculations identifying deltaX, deltaY, distance and angle between two points.</param>
        static void printAnswer(Coordinates first, Coordinates second, Delta delta)
        {
            //Prints to the screen the two sets of coordinates being compared.
            first.PrintCoordinates();
            second.PrintCoordinates();

            //Prints to the screen the distance and angle betwee the coordinates being compared.
            Console.WriteLine("The distance between {0} and {1} is {2:F3} units.", first.GetName(), second.GetName(), delta.GetDistance());
            Console.WriteLine("The angle between {0} and {1} is {2:F3} degrees.\n", first.GetName(), second.GetName(), delta.GetAngle());
        }
    }
}
