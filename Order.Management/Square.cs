// Remove unused packages
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class Square : Shape
    {
        //Potentially reuse object Shape and for particular shape it can be inherited from it 
        //Extend the object by giving colour, shapre and price and additional charge property

        public int SquarePrice = 1;
        public Square(int numberOfRedSquares, int numberOfBlueSquares, int numberOfYellowSquares)
        {
            // Make it constant
            Name = "Square";
            base.Price = SquarePrice;
            //make it constant 
            AdditionalCharge = 1;
            base.NumberOfRedShape = numberOfRedSquares;
            base.NumberOfBlueShape = numberOfBlueSquares;
            base.NumberOfYellowShape = numberOfYellowSquares;
        }

        public override int Total()
        {
            return RedSquaresTotal() + BlueSquaresTotal() + YellowSquaresTotal();
        }

        public int RedSquaresTotal()
        {
            return (base.NumberOfRedShape * Price);
        }
        public int BlueSquaresTotal()
        {
            return (base.NumberOfBlueShape * Price);
        }
        public int YellowSquaresTotal()
        {
            return (base.NumberOfYellowShape * Price);
        }
    }
}
