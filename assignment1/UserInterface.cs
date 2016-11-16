//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {

        //Create new var for WineItemRepo class
        WineItemRepo x = new WineItemRepo();
        
        //Create new variables for the program
        //user choice var, instantiated at zero for reference, then after DisplayOpenScreenMethod it inherits a new value and if value is above 7 
        //it calls function again asking user to reenter what is desired to be done
        int userChoice = 0;

        //Method to print opening display screen. Displays options offered
        //Make method return a vaild int for userChoice
        public int DisplayOpenScreen()
        {
            Console.WriteLine("1. Print the list?");
            Console.WriteLine("2. Search by id");
            Console.WriteLine("3. Search by name");
            Console.WriteLine("4. Add a new beverage to the list");
            Console.WriteLine("5. Update information for a beverage"); 
            Console.WriteLine("6. Delete a beverage");
            Console.WriteLine("Enter any number other than 1---6 to exit");

            //Set UserChoice to option picked
            userChoice = int.Parse(Console.ReadLine());
            //Return User Choice    
            return userChoice;
        }
        //Method that gets userChoice using the DisplayOpenScreenMethod, which uses the DisplayOpenScreen method
        public void getChoiceNumber(int choice)
        {
            //Call DisplayOpenScreen method to get userChoice
            choice = userChoice;
            //Switch statement for each user choice, so that action is done for valid option choice, if not
            //Method is called again until vaild choice is picked
            switch (choice)
            {
                //PrintList
                case 1:
                    x.printAll();
                    break;
                //Search for Items in list
                case 2:
                    Console.WriteLine("Enter Id of beverage");
                    string id = Console.ReadLine();
                    x.searchByID(id);
                    break;
                case 3:
                    Console.WriteLine("Enter name of beverage");
                    string name = Console.ReadLine();
                    x.searchByName(name);
                    break;
                case 4:
                    x.addToDataBase();
                    break;
                case 5:
                    Console.WriteLine("Enter Id of beverage");
                    string idy = Console.ReadLine();
                    x.updateInDataBase(idy);
                    break;
                case 6:
                    Console.WriteLine("Enter Id of beverage");
                    string idx = Console.ReadLine();
                    x.removeFromDataBase(idx);
                    break;

                //Exit
                default:
  
                    break;
            }
        }

      


    }
  }

