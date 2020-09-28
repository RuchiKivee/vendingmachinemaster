namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Menu
    {



        public void Display()
        {
            VendingMachine vm = new VendingMachine();
            machine m = new machine();

            PrintHeader();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1] Display Vending Machine Items");
                Console.WriteLine("2] Purchase");
                Console.WriteLine("3] Display the current inventory");
                Console.WriteLine("Q] Quit");

                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Displaying Items");
                    vm.DisplayAllItems();
                }
                else if (input == "2")
                {
                    SubMenu subMenu = new SubMenu(vm);
                    subMenu.Display();
                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else if (input == "3")
                {
                    Console.WriteLine("Displaying current inventory");
                    m.DisplayCurrentItem();
                }
                
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE BEST VENDING MACHINE EVER!!!! (Distant crowd roar)");
        }

    }
}
