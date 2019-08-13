﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.CSharp8
{
    public class ReadonlyMembers : IRunner
    {
        public async Task Run()
        {
            Console.WriteLine("Readonly members");
            await Task.Delay(10); // just to delete the warning

            new Point() { X = 0, Y = 1 }.ToString();
        }

        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            // If we remove readonly from Distance, we'll get a warning
            // warning CS8656: Call to non-readonly member 'Point.Distance.get' from a 'readonly' member results in an implicit copy of 'this'
            public readonly double Distance => Math.Sqrt(X * X + Y * Y);

            public readonly override string ToString()
            {
                // X = 1; will produce a coompilation error
                return $"({X}, {Y}) is {Distance} from the origin";
            }
        }
    }
}