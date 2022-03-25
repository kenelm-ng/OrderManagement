﻿using System;
using System.Collections.Generic;
// KN: Remove unused package
using System.Text;

// KN: CuttingListReport, InvoiceReport, PaitingReport can be rewritten into one class, CuttingListReport, InvoiceReport, PaitingReport can be inhertied from it with its own methods and properties.
namespace Order.Management
{
    class InvoiceReport : Order
    {
        // KN: Make it private
        public const int tableWidth = 73;
        public InvoiceReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour invoice report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
            OrderSquareDetails();
            OrderTriangleDetails();
            OrderCircleDetails();
            RedPaintSurcharge();
        }

        public void RedPaintSurcharge()
        {
            Console.WriteLine("Red Color Surcharge       " + TotalAmountOfRedShapes() + " @ $" + base.OrderedBlocks[0].AdditionalCharge + " ppi = $" + TotalPriceRedPaintSurcharge());
        }

        public int TotalAmountOfRedShapes()
        {
            return base.OrderedBlocks[0].NumberOfRedShape + base.OrderedBlocks[1].NumberOfRedShape +
                   base.OrderedBlocks[2].NumberOfRedShape;
        }

        public int TotalPriceRedPaintSurcharge()
        {
            return TotalAmountOfRedShapes() * base.OrderedBlocks[0].AdditionalCharge;
        }
        // KN: Make it a loop for printing the array of objects
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", base.OrderedBlocks[0].NumberOfRedShape.ToString(), base.OrderedBlocks[0].NumberOfBlueShape.ToString(), base.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].NumberOfRedShape.ToString(), base.OrderedBlocks[1].NumberOfBlueShape.ToString(), base.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", base.OrderedBlocks[2].NumberOfRedShape.ToString(), base.OrderedBlocks[2].NumberOfBlueShape.ToString(), base.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }

        // KN: Same maths calculation
        // KN: Order details can be rewritten to as a method accepting shape variable 
        public void OrderSquareDetails()
        {
            Console.WriteLine("\nSquares 		  " + base.OrderedBlocks[0].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[0].Price + " ppi = $" + base.OrderedBlocks[0].Total());
        }
        // KN: Order details can be rewritten to as a method accepting shape variable 
        public void OrderTriangleDetails()
        {
            Console.WriteLine("Triangles 		  " + base.OrderedBlocks[1].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[1].Price + " ppi = $" + base.OrderedBlocks[1].Total());
        }
        // KN: Order details can be rewritten to as a method accepting shape variable 
        public void OrderCircleDetails()
        {
            Console.WriteLine("Circles 		  " + base.OrderedBlocks[2].TotalQuantityOfShape() + " @ $" + base.OrderedBlocks[2].Price + " ppi = $" + base.OrderedBlocks[2].Total());
        }

        // KN: can be a private method
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        // KN: can be a private method
        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        // KN: can be a private method
        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
