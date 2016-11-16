using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemRepo
    {
        //Create a new instance to access properties from entities, called x for simplicity
        BeverageAFoghelEntities x = new BeverageAFoghelEntities();
        //New boolean var to see if the database contains said id
        bool containId = false;
        //New beverage for searchById method
        Beverage bev = new Beverage();
        //New beverage list for searching by every other property
        List<Beverage> bevs;



        //new method for printing objects
        public void printAll()
        {
            //for each drink in our entities list, must say .Beverages for actual values in list, print out a formatted string that displays
            //all values in list form for a new beverage
            foreach (Beverage drink in x.Beverages)
            {
                Console.WriteLine(drink.id + " | " + drink.name + " | " + drink.pack + " | " + drink.price + " | " + drink.active + "\n");
            }
        }
        //New method for determing if the ID is already used in set, which has a paramater of object string to comapare to the list
        public void hasId(string Id)
        {
            //Loop Through beverages
            foreach (Beverage drink in x.Beverages)
            {
                if (Id.Equals(drink.id))
                {
                    containId = true;
                }
                else
                {
                    containId = false;
                }
            }
        }
        //Method that searches through list by id, void method
        public void searchByID(string Id)
        {
            //Try and catch statement to handle errors
            //In try use lamba expression to find object by ID and then print formatted string for beverage found
            try
            {
                bev = x.Beverages.Where(drink => drink.id == Id).First();
                Console.WriteLine(bev.id + " | " + bev.name + " | " + bev.pack + " | " + bev.price + " | " + bev.active);
            }
            catch (Exception e)
            {
                //print that bev was not found
                Console.WriteLine("Error, beverage not found");
                //Prompt user to try a new Id 
                Console.WriteLine("Would you like to enter a different id? (y/n)");
                // new var for new user promt
                string newUserInput = Console.ReadLine();
                //new if statement to retry new id
                if (newUserInput.Equals("y"))
                {
                    //Ask for a new Id
                    Console.WriteLine("Enter new Id");
                    //Get new id and set to var newID
                    string newId = Console.ReadLine();
                    //call method again
                    searchByID(newId);
                }
                //else exit the program
                else if(newUserInput.Equals("n"))
                {
                    Console.WriteLine("Have a nice day");
                }
                else
                {
                    Console.WriteLine("Would you like to enter a different id? (y/n)");
                     newUserInput = Console.ReadLine();
                }
            }

        }

        //Method that searches by name, pretty much the same as searchById method but just uses list instead of one object 
        //WHEN USERINPUT IS AN INT IT TERMINATES THE PROGRAM WITHOUT DOING ANYTHING
        public void searchByName(string name)
        {
            try
            {
                bevs = x.Beverages.Where(drink => drink.name == name).ToList();
                //Foreach loop because it is a list now
                foreach (Beverage y in bevs)
                {
                    Console.WriteLine(y.id + " | " + y.name + " | " + y.pack + " | " + y.price + " | " + y.active + "\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, beverage not found");
                Console.WriteLine("Would you like to enter a different name?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                int newUserInput = int.Parse(Console.ReadLine());
                if (newUserInput == 1)
                {
                    Console.WriteLine("Enter new name");
                    string newName = Console.ReadLine();
                    searchByName(newName);
                }
                else
                {
                    Console.WriteLine("Have a nice day");
                }
            }

        }

        //Method that adds object to the database, takes parameter drink of type beverage 
        public void addToDataBase()
        {
            //new beverage variable
            Beverage drink = new Beverage();
            //new var for id
            Console.WriteLine("Enter a new id");
            string idI = Console.ReadLine();
            drink.id = idI;
            //new var for name
            Console.WriteLine("Enter a new name");
            string nameI = Console.ReadLine();
            drink.name = nameI;
            //new var for pack
            Console.WriteLine("Enter a new pack size (In Mililiters)");
            string packI = Console.ReadLine() + "ml";
            drink.pack = packI;
            //new var for price
            Console.WriteLine("Enter a new price");
            decimal priceI = decimal.Parse(Console.ReadLine());
            drink.price = priceI;
            //new var for active
            Console.WriteLine("Is this drink still in production? (y/n)");
            //new string for active answer
            string activeI = Console.ReadLine();
            //new bool to see if item is still in production, use .equals because thats whats need for a string 
            bool isDrinkable = false;
            if (activeI.Equals("y"))
            {
                isDrinkable = true;
            }
            else if (activeI.Equals("n"))
            {
                isDrinkable = false;
            }
            else
            {
                Console.WriteLine("Try again");
            }
            drink.active = isDrinkable;



            try
            {
                //Add beverarge to the list
                x.Beverages.Add(drink);
                //save changes
                x.SaveChanges();
                //print line
                Console.WriteLine("New Beverage added to the database!");
            }
            catch (Exception e)
            {
                //If doesn't work remove 
                x.Beverages.Remove(drink);
                Console.WriteLine("This Id already exsists would you like to try again? (y/n)");
                string userInput = Console.ReadLine();
                if (userInput.Equals("y"))
                {
                    addToDataBase();
                }
                else if (userInput.Equals("n"))
                {
                    Console.WriteLine("Buenas Dias");
                }
                else
                {
                    Console.WriteLine("This Id already exsists would you like to try again? (y/n)");
                    userInput = Console.ReadLine();
                }


            }


        }

        //Method that Removes an object from the database
        public void removeFromDataBase(string id)
        {
            try
            {
                //get object to delete from database
                Beverage drink = x.Beverages.Find(id);
                //remove
                x.Beverages.Remove(drink);
                //save
                x.SaveChanges();

                Console.WriteLine(drink.id + " | " + drink.name + " | " + drink.pack + " | " + drink.price + " | " + drink.active);
            }catch(Exception e)
            {
                Console.WriteLine("Beverage doesn't exsist would you like to try again? (y/n)");
                string ui = Console.ReadLine();
                if (ui.Equals("y"))
                {
                    Console.WriteLine("enter new id");
                    string nui = Console.ReadLine();
                    removeFromDataBase(nui);
                }else if (ui.Equals("n"))
                {
                    Console.WriteLine("Arivederchi");
                }else
                {
                    Console.WriteLine("Beverage doesn't exsist would you like to try again? (y/n)");
                    ui = Console.ReadLine();
                }
                
            }

        }

        //Method to update
        public void updateInDataBase(string id)
        {
            //new beverage reference 
            Beverage drink = x.Beverages.Find(id);
            if(drink == null)
            {
                //Try again
            }else
            {
                //Update name
                Console.WriteLine("Would you like to update the name? (y/n)");
                string ui = Console.ReadLine();
                if (ui.Equals("y"))
                {
                    Console.WriteLine("Enter new name");
                    string n = Console.ReadLine();
                    drink.name = n;
                    Console.WriteLine();
                }
                //update pack
                Console.WriteLine("Would you like to update the pack? (y/n)");
                string ui1 = Console.ReadLine();
                if (ui1.Equals("y"))
                {
                    Console.WriteLine("Enter new pack size");
                    string  p = Console.ReadLine()+" ml";
                    drink.pack = p;
                    Console.WriteLine();
                }
                //Update Price
                Console.WriteLine("Would you like to update the price? (y/n)");
                string ui2 = Console.ReadLine();
                if (ui2.Equals("y"))
                {
                    Console.WriteLine("Enter new price");
                    decimal pr = Decimal.Parse(Console.ReadLine());
                    drink.price = pr;
                    Console.WriteLine();
                }
                //update activity
                bool isDrinkable = false;
                Console.WriteLine("Would you like to update the activity? (y/n)");
                string ui3 = Console.ReadLine();
                if (ui3.Equals("y"))
                {
                    Console.WriteLine("Is this drink active? (y/n)");
                    string act = Console.ReadLine();
                    if (act.Equals("y"))
                    {
                        isDrinkable = true;
                    }
                    else if (act.Equals("n"))
                    {
                        isDrinkable = false;
                    }else
                    {
                        Console.WriteLine("Is this drink active? (y/n)");
                        act = Console.ReadLine();
                    }
                    drink.active = isDrinkable;

                    x.SaveChanges();
                }
            }
        }


    }
}
