

namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Snickers : VendingItem
    {
        public const string Message = "Crunch, Crunch, Yum!";

        public Snickers(
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
