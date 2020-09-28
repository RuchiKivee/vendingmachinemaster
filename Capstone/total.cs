using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class total
    {
        //public int quantity { get; set; }
        public void totalamount()
        {
            
            int mult, price, itemsRemaining;
            Console.WriteLine("Enter Value of price and itemsRemaining\n");
            price = Convert.ToInt32(Console.ReadLine());
            itemsRemaining = Convert.ToInt32(Console.ReadLine());

            mult = price * itemsRemaining;
            Console.WriteLine("The Multiplication of {0} and {1} = {2}\n", price, itemsRemaining, mult);

        }
    }
}
