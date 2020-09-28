namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Water : VendingItem
    {
        public const string Message = "Crunch, Crunch, Yum!";

        public Water(
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
