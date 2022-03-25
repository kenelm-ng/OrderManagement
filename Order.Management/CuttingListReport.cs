using System;
// KN: Remove unused package
using System.Collections.Generic;
using System.Text;

// KN: CuttingListReport, InvoiceReport, PaitingReport can be rewritten into one class, CuttingListReport, InvoiceReport, PaitingReport can be inhertied from it with its own methods and properties.
namespace Order.Management
{
    class CuttingListReport : Order
    {
        // KN: Make it private
        public int tableWidth = 20;
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString());
            generateTable();
        }

        //KN: Make method naming consistent, lower case for G - GenerateTable()
        //KN: Use a loop to print the message with array of objects 
        public void generateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square",base.OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", base.OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }

        // KN: should be a private method
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        // KN: should be a private method
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

        // KN: should be a private method
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
