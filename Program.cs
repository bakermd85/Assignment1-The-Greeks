using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_The_Greeks
{

    public class userCoordinates
    {
        public double xPoint;
        public double yPoint;
        public string name;

        public userCoordinates()
        {
            name = "point";
            xPoint = 0;
            yPoint = 0;
        }

        public userCoordinates(string id, double x, double y)
        {
            name = id;
            xPoint = x;
            yPoint = y;
        }

        public void SetCoordinates(double x, double y)
        {
            xPoint = x;
            yPoint = y;
        }

        public void SetName(string id)
        {
            name = id;
        }

        public double GetX()
        {
            return xPoint;
        }

        public double GetY()
        {
            return yPoint;
        }

        public string GetName()
        {
            return name;
        }

        public void GetCoordinates()
        {
            Console.Write("Please enter the x value for {0}: ", name);
            while (!double.TryParse(Console.ReadLine(), out xPoint))
            {
                Console.Write("Invalid entry. Try again: ");
            }

            Console.Write("Please enter the y value for {0}: ", name);
            while (!double.TryParse(Console.ReadLine(), out yPoint))
            {
                Console.Write("Invalid entry. Try again: ");
            }
        }

        public void PrintCoordinates()
        {
            Console.WriteLine("For {0}:", name);
            Console.WriteLine("x = {0:F3}", xPoint);
            Console.WriteLine("y = {0:F3}\n", yPoint);
        }

    }

    public class userDelta
    {
        public string name;
        public double firstX;
        public double firstY;
        public double secondX;
        public double secondY;
        public double deltaX;
        public double deltaY;
        public double distance;
        public double angle;

        public userDelta()
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

        public userDelta(string id, double fx, double fy, double sx, double sy)
        {
            name = id;
            firstX = fx;
            firstY = fy;
            secondX = sx;
            secondY = sy;
            deltaX = secondX - firstX;
            deltaY = secondY - firstY;
            distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);
        }

        public userDelta(string id, userCoordinates first, userCoordinates second)
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

        public void printDelta()
        {
            Console.WriteLine("For {0}: ", name);
            Console.WriteLine("DeltaX = {0}", deltaX);
            Console.WriteLine("DeltaY = {0}\n", deltaY);
        }

        public double getDistance()
        {
            return distance;
        }

        public double getAngle()
        {
            return angle;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        public struct coordinates
        {
            public double x;
            public double y;

            public coordinates(double pointX, double pointY)
            {
                x = pointX;
                y = pointY;
            }
        }

        public struct deltas
        {
            public double x;
            public double y;

            public deltas(double deltaX, double deltaY)
            {
                x = deltaX;
                y = deltaY;
            }
        }

        static coordinates point1;
        static coordinates point2;
        static deltas delta;
        static double distance;
        static double angle;
               
        /// <summary>
        /// This will calculate the distance 
        /// between two points and the angle between those points.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            userCoordinates firstCoordinates = new userCoordinates("Point1", 0, 0);
            userCoordinates secondCoordinates = new userCoordinates("Point2", 0, 0);
            

            printWelcome();

            firstCoordinates.GetCoordinates();
            secondCoordinates.GetCoordinates();

            userDelta delta = new userDelta("Delta", firstCoordinates, secondCoordinates);

            printAnswer(firstCoordinates, secondCoordinates, delta);

            retrieveCoordinates();
            calculateDeltas();
            calculateDistance();
            calculateAngle();
            printValues();

            Console.ReadLine();

        }

        static void printWelcome()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("**                       WELCOME!                       **");
            Console.WriteLine("** This application will calculate the distance between **");
            Console.WriteLine("** two points and the angle between those points.       **");
            Console.WriteLine("**********************************************************");

            return;
        }

        static void retrieveCoordinates()
        {

            Console.Write("Please enter the x value for point 1: ");
            while (!double.TryParse(Console.ReadLine(), out point1.x))
            {
                Console.Write("Invalid entry. Try again: ");
            }

            Console.Write("Please enter the y value for point 1: ");
            while (!double.TryParse(Console.ReadLine(), out point1.y))
            {
                Console.Write("Invalid entry. Try again: ");
            }

            Console.Write("Please enter the x value for point 2: ");
            while (!double.TryParse(Console.ReadLine(), out point2.x))
            {
                Console.Write("Invalid entry. Try again: ");
            }

            Console.Write("Please enter the y value for point 2: ");
            while (!double.TryParse(Console.ReadLine(), out point2.y))
            {
                Console.Write("Invalid entry. Try again: ");
            }
        }

        static void calculateDeltas()
        {
            delta.x = point2.x - point1.x;
            delta.y = point2.y - point1.y;
        }

        static void calculateDistance()
        {
            distance = Math.Sqrt((delta.x*delta.x) + (delta.y*delta.y));
        }

        static void calculateAngle()
        {
            angle = Math.Atan2(delta.y, delta.x) * (180/Math.PI);
        }

        static void printValues()
        {
            Console.WriteLine("\nYou entered:");
            Console.WriteLine("Point 1 X: {0:F3}", point1.x);
            Console.WriteLine("Point 1 Y: {0:F3}", point1.y);
            Console.WriteLine("Point 2 X: {0:F3}", point2.x);
            Console.WriteLine("Point 2 Y: {0:F3}\n", point2.y);
            Console.WriteLine("The distance between points 1 and 2 is: {0:F3} units. ", distance);
            Console.WriteLine("The angle between points 1 and 2 is: {0:F3} degrees.", angle);
        }

        static void printAnswer(userCoordinates first, userCoordinates second, userDelta delta)
        {
            first.PrintCoordinates();
            second.PrintCoordinates();
            Console.WriteLine("The distance between {0} and {1} is {2}.", first.GetName(), second.GetName(), delta.getDistance());
            Console.WriteLine("The angle between {0} and {1} is {2}.\n", first.GetName(), second.GetName(), delta.getAngle());
        }
    }
}
