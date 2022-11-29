using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class Inventory
    {

           //fields
           private  static string _inputName;

           private  static int _inputQuantity;

           private static string _inputCountry;

           //property
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Country { get; set;}    



        //constructor



        public Inventory()
        {

        }
        public Inventory(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;

        }

        public  void SaveItem()
        {

            try
            {
                Name = GetName();

                Quantity = GetQuantity();

                Country = GetCountry();

                if (string.IsNullOrEmpty(Name))
                {
                    throw new InventoryException("Name is required ");
                }
              

                if (Quantity < 0)
                {
                    throw new ArgumentOutOfRangeException("Value must be zero or higher");
                }

                if (string.IsNullOrEmpty(Country))
                {
                    throw new ArgumentNullException("Country is required ");
                }

            }
            catch (InventoryException e)
            {
                PrintColorMessage(ConsoleColor.Yellow, e.Message);
                SaveItem();
            }
            catch (ArgumentNullException e )
            {
                PrintColorMessage(ConsoleColor.Red, e.Message);
                SaveItem();

            }
            catch (ArgumentOutOfRangeException e)
            {
                PrintColorMessage(ConsoleColor.Blue, e.Message);
                SaveItem();

            }
            catch(FormatException e)
            {
                PrintColorMessage(ConsoleColor.Cyan, e.Message);
                PrintColorMessage(ConsoleColor.Cyan, e.StackTrace);
                PrintColorMessage(ConsoleColor.Cyan, e.HelpLink);
                SaveItem();
            }
           
         
            
        }


          static string GetName()
          {
            Console.WriteLine("Please enter a name : ");
            _inputName = Console.ReadLine();
            
            return _inputName;


          }

        static string GetCountry()
        {
            Console.WriteLine("Please enter a  country : ");
            _inputCountry = Console.ReadLine();

            return _inputCountry;


        }

        static int GetQuantity()
        {
            Console.WriteLine("Please enter a quantity : ");
            _inputQuantity = int.Parse(Console.ReadLine());
            return _inputQuantity;


        }

        // print color message
        public static void PrintColorMessage(ConsoleColor color, string message)
        {

            Console.ForegroundColor = color;

            //tell user its not a number
            Console.WriteLine(message);

            //reset text color
            Console.ResetColor();

        }
          public  class Application
          {
            public static void Run()
            {
                PrintColorMessage(ConsoleColor.Yellow, "***Welcome to Custom Exception App***");
                Inventory inventory = new Inventory();
                inventory.SaveItem();



            }
          }



        }



    }

