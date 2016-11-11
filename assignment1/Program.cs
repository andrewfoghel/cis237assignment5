//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new userInterface instance , I am going call it x for simplicty, and because I like algebra
            UserInterface x = new UserInterface();
            //Create var that is of type int to hold user choice from DisplayOpenScreen method in UserInterface
            int choice = x.DisplayOpenScreen();
            x.getChoiceNumber(choice);
        }

    }
    }

