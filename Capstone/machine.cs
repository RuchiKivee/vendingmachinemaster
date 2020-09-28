﻿
namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class machine
    {
        private Logger Log = new Logger();
        public Dictionary<string, VendingItem> Items = new Dictionary<string, VendingItem>();
        FileHandler HandleFiles = new FileHandler();

        public Money Money { get; }
        public string NotEnoughMoneyError = "Not enough money in the machine to complete the transaction.";
        public string MessageToUser;


        public machine()
        {
           
            this.Items = this.HandleFiles.GetItems();

            this.Money = new Money(this.Log);

        }
        public void DisplayCurrentItem()
        {
            Console.WriteLine($"\n\n{"#".PadRight(5)} {"Stock"} { "Product".PadRight(47) } { "Price".PadLeft(7)}");
            foreach (KeyValuePair<string, VendingItem> kvp in this.Items)
            {
                if (kvp.Value.ItemsRemaining > 0)
                {
                    string itemNumber = kvp.Key.PadRight(5);
                    string itemsRemaining = kvp.Value.ItemsRemaining.ToString().PadRight(5);
                    string productName = kvp.Value.ProductName.PadRight(40);
                    string price = kvp.Value.Price.ToString("C").PadLeft(7);
                    Console.WriteLine($"{itemNumber} {itemsRemaining} {productName} Costs: {price} each");
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.ProductName} IS SOLD OUT.");
                }
            }
        }

        public decimal MoneyInMachine
        {
            get
            {
                return this.Money.MoneyInMachine;
            }
        }

        public bool ItemExists(string itemNumber)
        {
            return this.Items.ContainsKey(itemNumber);
        }

        public bool RetreiveItem(string itemNumber)
        {
            // If the item exists (not Q1 or something like that)
            // and we can remove the item
            // and we have more money in the machine than the price
            if (this.ItemExists(itemNumber)
                && this.Money.MoneyInMachine >= this.Items[itemNumber].Price
                && this.Items[itemNumber].ItemsRemaining > 0
                && this.Items[itemNumber].RemoveItem())
            {
                // Logging message "CANDYBARNAME A1"
                string message = $"{this.Items[itemNumber].ProductName.ToUpper()} {itemNumber}";

                // Logging before: current money in machine
                decimal before = this.Money.MoneyInMachine;

                // Remove the money
                this.Money.RemoveMoney(this.Items[itemNumber].Price);

                // Logging after: current money in machine
                decimal after = this.Money.MoneyInMachine;

                // Log the log
                this.Log.Log(message, before, after);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}