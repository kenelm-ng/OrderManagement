// Remove unused packages
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Triangle : Shape
    {
        //Potentially reuse object Shape and for particular shape it can be inherited from it 
        //Extend the object by giving colour, shapre and price and additional charge property

        public int TrianglePrice = 2;
        public Triangle(int numberOfRedTriangles, int numberOfBlueTriangles, int numberOfYellowTriangles)
        {
            // Make it constant
            Name = "Triangle";
            base.Price = TrianglePrice;
            // Make it constant
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedTriangles;
            base.NumberOfBlueShape = numberOfBlueTriangles;
            base.NumberOfYellowShape = numberOfYellowTriangles;
        }
        public override int Total()
        {
            return RedTrianglesTotal() + BlueTrianglesTotal() + YellowTrianglesTotal();
        }

        public int RedTrianglesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueTrianglesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowTrianglesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    
}
}
