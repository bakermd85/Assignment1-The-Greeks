using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_The_Greeks
{

    public class Coordinates
    {
        public double xPoint;
        public double yPoint;
        public string name;

        public Coordinates()
        {
            name = "point";
            xPoint = 0;
            yPoint = 0;
        }

        public Coordinates(string id, double x, double y)
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

    public class Delta
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

        public Delta(string id, double fx, double fy, double sx, double sy)
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

        public void PrintDelta()
        {
            Console.WriteLine("For {0}: ", name);
            Console.WriteLine("DeltaX = {0}", deltaX);
            Console.WriteLine("DeltaY = {0}\n", deltaY);
        }

        public double GetDistance()
        {
            return distance;
        }

        public double GetAngle()
        {
            return angle;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    class Program
    {
                
        /// <summary>
        /// This will calculate the distance 
        /// between two points and the angle between those points.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Coordinates firstCoordinates = new Coordinates("Point1", 0, 0);
            Coordinates secondCoordinates = new Coordinates("Point2", 0, 0);
            
            printWelcome();

            firstCoordinates.GetCoordinates();
            secondCoordinates.GetCoordinates();

            Delta delta = new Delta("Delta", firstCoordinates, secondCoordinates);

            printAnswer(firstCoordinates, secondCoordinates, delta);

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

        static void printAnswer(Coordinates first, Coordinates second, Delta delta)
        {
            first.PrintCoordinates();
            second.PrintCoordinates();
            Console.WriteLine("The distance between {0} and {1} is {2:F3} units.", first.GetName(), second.GetName(), delta.GetDistance());
            Console.WriteLine("The angle between {0} and {1} is {2:F3} degrees.\n", first.GetName(), second.GetName(), delta.GetAngle());
        }
    }
}
