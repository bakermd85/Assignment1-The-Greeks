﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_The_Greeks
{

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

            printWelcome();
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
            Console.WriteLine("The distance between points 1 and 2 is: {0:F3} units.", distance);
            Console.WriteLine("The angle between points 1 and 2 is: {0:F3} degrees.", angle);
        }
    }
}