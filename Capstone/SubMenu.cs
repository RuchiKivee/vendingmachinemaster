namespace Capstone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SubMenu
    {
       
        private VendingMachine vm;

        public SubMenu(VendingMachine vm)
        {
            this.vm = vm;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("1] >> Feed Money");
                Console.WriteLine("2] >> Select Product");
                Console.WriteLine("3] >> Finish Transaction");
                //Console.WriteLine("4] >> total amount");
                Console.WriteLine("Q] >> Return to Main Menu");
                Console.WriteLine($"Money in Machine: {this.vm.MoneyInMachine.ToString("C")}");
                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine(">>> How much do you want to insert?");
                    while (true)
                    {
                        Console.Write("1, 2, 5, 10 dollars? ");
                        string amountToSubmit = Console.ReadLine();
                        if (amountToSubmit == "1"
                            || amountToSubmit == "2"
                            || amountToSubmit == "5"
                            || amountToSubmit == "10")
                        {
                            if (!this.vm.Money.AddMoney(amountToSubmit))
                            {
                                Console.WriteLine("Insert a valid amount.");
                            }
                            else
                            {
                                Console.WriteLine($"Money in Machine: {this.vm.Money.MoneyInMachine.ToString("C")}");
                                break;
                            }
                        }
                    }

                }
                else if (input == "2")
                {
                    while (true)
                    {
                        this.vm.DisplayAllItems();
                        Console.Write(">>> What item do you want? ");
                        string choice = Console.ReadLine();
                        
                        //Console.Write("How Much You Have? ");

                        if (this.vm.ItemExists(choice) && this.vm.RetreiveItem(choice))
                        {
                            Console.WriteLine($"Product Price : {this.vm.VendingMachineItems[choice].Price}");
                            decimal quantity, total;
                            Console.Write("Enter the Quantity : ");
                            quantity = Convert.ToDecimal(Console.ReadLine());
                            total = quantity * this.vm.VendingMachineItems[choice].Price;
                            Console.WriteLine("multiplication is ={0}\n", total);
                            Console.WriteLine($"Your Money : {this.vm.Money.MoneyInMachine.ToString("C")}");
                            Console.WriteLine($"Enjoy your {this.vm.VendingMachineItems[choice].ProductName}\n{this.vm.VendingMachineItems[choice].MessageWhenVended}");
                            Console.WriteLine("Order Successfully");

                            Console.WriteLine("Give your Feedback");
                            Console.WriteLine("1] ");
                            Console.WriteLine("2] ");
                            Console.WriteLine("3] ");
                            Console.WriteLine("4] ");
                            
                            string inputt = Console.ReadLine();
                            if(inputt == "1")
                            {
                                Console.WriteLine("Good");
                            }
                            if (inputt == "2")
                            {
                                Console.WriteLine("Bad");
                            }
                            if (inputt == "3")
                            {
                                Console.WriteLine("Very Good");
                            }
                            if (inputt == "4")
                            {
                                Console.WriteLine("Excellent");
                                break;
                            }

                           

                            Console.ReadLine();
                            Console.Clear();
                            


                        }
                       
                        if (!this.vm.ItemExists(choice))
                        {
                            Console.Clear();
                            Console.WriteLine("Order not Successfully");
                            Console.WriteLine("**INVALID ITEM**");
                            break;
                        }

                        else if (this.vm.ItemExists(choice) && this.vm.Money.MoneyInMachine > this.vm.VendingMachineItems[choice].Price)
                        {
                            Console.WriteLine(this.vm.VendingMachineItems[choice].MessageWhenSoldOut);
                          
                        }
                        else if (this.vm.Money.MoneyInMachine < this.vm.VendingMachineItems[choice].Price)
                        {
                        
                            Console.WriteLine(this.vm.NotEnoughMoneyError);
                            break;
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Finishing Transaction");
                    Console.WriteLine(this.vm);
                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
            }
        }
    }
}
