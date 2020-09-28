namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Coke : VendingItem
    {
        public const string Message = "Crunch, Crunch, Yum!";

        public Coke(
            string productName,
            decimal price,
            int itemsRemaining)
                : base(
                productName,
                price,
                itemsRemaining,
                Message)
        {
        }
    }
}
