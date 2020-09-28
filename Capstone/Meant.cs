
namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Meant : VendingItem
    {
        public const string Message = "Crunch, Crunch, Yum!";

        public Meant(
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
