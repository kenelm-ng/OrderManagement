// Remove unused packages
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Circle : Shape
    {
        //Potentially reuse object Shape and for particular shape it can be inherited from it 
        //Extend the object by giving colour, shapre and price and additional charge property

        public int circlePrice = 3;
        public Circle(int red, int blue, int yellow)
        {
            // Make it constant
            Name = "Circle";
            base.Price = circlePrice;
            // Make it constant
            AdditionalCharge = 1;
            base.NumberOfRedShape = red;
            base.NumberOfBlueShape = blue;
            base.NumberOfYellowShape = yellow;
        }
        public override int Total()
        {
            return RedCirclesTotal() + BlueCirclesTotal() + YellowCirclesTotal();
        }

        public int RedCirclesTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueCirclesTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowCirclesTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
