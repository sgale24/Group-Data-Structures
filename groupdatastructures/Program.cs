using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupdatastructures
{
    class Program
    {

        //----------STACK----------//

        //STACK MENU
        static void stackMenu(Stack<string> s)
        {
            
            string item;
            bool menu = true;
            while (menu)
            {
                string input;
                Console.Clear();
                Console.WriteLine("1. Add one time to Stack");
                Console.WriteLine("2. Add Huge List of Items to Stack");
                Console.WriteLine("3. Display Stack");
                Console.WriteLine("4. Delete from Stack");
                Console.WriteLine("5. Clear Stack");
                Console.WriteLine("6. Search Stack");
                Console.WriteLine("7. Return to main menu");

                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Enter what you would like to add: ");
                    item = Console.ReadLine();
                    s.Push(item);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                else if (input == "2")
                {
                    addHugeListStck(s);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                else if (input == "3")
                {
                    displayStck(s);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                    continue;
                }
                else if (input == "4")
                {
                    Console.WriteLine("Which item would you like to remove from the Stack?: ");
                    item = Console.ReadLine();
                    stckDelete(s, item);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                else if (input == "5")
                {
                    s.Clear();
                    Console.WriteLine("The Stack has been cleared.");
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                else if (input == "6")
                {
                    Console.WriteLine("Which item would you like to find in the Stack?: ");
                    item = Console.ReadLine();
                    stckSearch(s, item);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                else if (input == "7")
                {
                    menu = false;
                }
            }
        }


        //2. ADD HUGE LIST
        static void addHugeListStck(Stack<string> stack)
        {
            stack.Clear();
            Console.WriteLine("Adding the list...");
            int i = 1;
            string s = "New Entry ";
            for (i = 1; i < 2001; i++)
            {
                stack.Push(s + i);
            }
            Console.WriteLine("Entries completed.");
        }

        //3. DISPLAY STACK
        static void displayStck(Stack<string> s)
        {
            Stack<string> stack2 = new Stack<string>();
            string i;
            if (s.Count() <=0)
            {
                Console.WriteLine("Stack is empty...");
            }
            while (s.Count() > 0)
            {
                i = s.Pop();
                stack2.Push(i);
                Console.WriteLine(i);
            }
            while (stack2.Count() > 0)
            {
                s.Push(stack2.Pop());
            }
        }


        //4. DELETE STACK ITEM 
        //if the item is in the stack, pop each item until you find it and add those items to a second stack
        //pop the item to be deleted then add the item from the new stack back onto the original stack.
        static void stckDelete(Stack<string> s, string item)
        {
            Stack<string> stack2 = new Stack<string>();
            string current = "";

            if (s.Contains(item))   
            {
                while (item != current)
                {
                    current = s.Pop();
                    if (item == current)
                    {
                        continue;
                    }
                    else
                    {
                        stack2.Push(current);
                    }
                }
                for (int i = 0; i < s.Count(); i++ )
                {
                    stack2.Push(s.Pop());
                }
                int y = stack2.Count();
                for (int i = 0; i < y; i++ )
                {
                    s.Push(stack2.Pop());
                }
                Console.WriteLine(item + " was deleted from the stack.");
            }
            else
            {
                Console.WriteLine(item + " was not found in the stack...");
            }
        }
        //5. CLEAR is written in the menu code, since it is an existing method

        //6. SEARCH STACK checks if the item exists in the stack and returns how long it took to find
        static void stckSearch(Stack<string> s, string item)
        {
            bool contains = false;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //begin timer
            sw.Start();
            contains = s.Contains(item);    //check if the item is in the stack
            sw.Stop();
            if (contains)   //if the item is in the stack say so and show how long it took to find
            {
                Console.WriteLine(item + " was found");
                Console.WriteLine(sw.Elapsed.ToString());
            }
            else
            {
                Console.WriteLine(item + " was not found");
            }
        }

        //----------QUEUE----------//
        static void QueueMenu(Queue<string> myQ)
        {
             //sAns collects user input
            String sAns = "1";
            //create my new Q called myQ
            //Queue<String> myQ = new Queue<string>();
            //do this until the user decides to go back to the main menu by hitting 7
            while (sAns != "7")
            {
                //display the queue menu
                Console.Clear();
                Console.WriteLine("1. Add one item to Queue \n2. Add Huge List of Items to Queue \n3. Display Queue\n4. Delete from Queue\n5. Clear Queue\n6. Search Queue\n7. Return to Main Menu");
                Console.WriteLine("\nwhat would you like to do, please use numbers only: ");
                //grab user input
                sAns = Console.ReadLine();
                
                // add one entry to the queue
                if (sAns == "1")
                {
                    string qString;
                    Console.WriteLine("enter the string you want to add to the queue:");
                    qString = Console.ReadLine();

                    myQ.Enqueue(qString);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();

                }

                // add a huge entry to the queue
                if (sAns == "2")
                {
                    myQ.Clear();

                    for (int i = 0; i < 2000; i++)
                    {
                        myQ.Enqueue("New Entry " + (i + 1));
                    }

                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                //display the queue
                if (sAns == "3")
                {

                    foreach (string print in myQ)
                    {
                        Console.WriteLine("\n" + print);
                    }
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }

                //delete from the queue
                if (sAns == "4")
                {
                    Console.WriteLine("Which item would you like to remove from the Queue?: ");
                    sAns = Console.ReadLine();
                    qDelete(myQ, sAns);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }
                //clear the queue
                if (sAns == "5")
                {
                    myQ.Clear();
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }

                //search in the queue
                if (sAns == "6")
                {
                    Console.WriteLine("Which item would you like to find in the Queue?: ");
                    sAns = Console.ReadLine();
                    qSearch(myQ, sAns);
                    Console.WriteLine("Press Enter to Continue:");
                    Console.Read();
                }

            }
        }

        //search the queue method
        static void qSearch(Queue<string> s, string item)
        {
            bool contains = false;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //begin timer
            sw.Start();
            contains = s.Contains(item);    //check if the item is in the queue
            sw.Stop();
            if (contains)   //if the item is in the queue say so and show how long it took to find
            {
                Console.WriteLine(item + " was found");
                Console.WriteLine(sw.Elapsed.ToString());
            }
            else
            {
                Console.WriteLine(item + " was not found");
            }
        }

       
//delete from the queue method
static void qDelete(Queue<string> s, string item)
        {
            Queue<string> stack2 = new Queue<string>();
            string current = "";

            if (s.Contains(item))   
            {
                while (item != current)
                {
                    current = s.Dequeue();
                    if (item == current)
                    {
                        continue;
                    }
                    else
                    {
                        stack2.Enqueue(current);
                    }
                }
                for (int i = 0; i < s.Count(); i++ )
                {
                    stack2.Enqueue(s.Dequeue());
                }
                int y = stack2.Count();
                for (int i = 0; i < y; i++ )
                {
                    s.Enqueue(stack2.Dequeue());
                }
                Console.WriteLine(item + " was deleted from the queue.");
            }
            else
            {
                Console.WriteLine(item + " was not found in the queue...");
            }
        }

        static void addHugeListQ(Queue<string> q)
        {
            q.Clear();
            int i = 0;
            string s = "New Entry ";
            for (i = 0; i < 2000; i++)
            {
                q.Enqueue(s + i);
            }
        }

        //DISPLAY QUEUE
        static void displayQ(Queue<string> q)
        {
            if (q.Count() > 0)
            {
                foreach (string i in q)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Queue is empty...");
            }
        }


        //DICTIONARY
        static void dictionaryMenu(Dictionary<string, int> userDictionary)
        {
            string userInput;
            string key;
            string userSearch;
            int dictionaryCount = 1;
            bool menu = true;
//            Dictionary<string, int> userDictionary = new Dictionary<string, int>();
            Dictionary<string, int> holderDictionary = new Dictionary<string, int>();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            while (menu)
            {
                //MENU
                Console.Clear();
                Console.WriteLine("1. Add one time to Dictionary\n2. Add Huge List of Items to Dictionary\n3. Display Dictionary\n4. Delete from Dictionary\n5. Clear Dictionary\n6. Search Dictionary\n7. Return to Main Menu\n");
                userInput = Console.ReadLine();
                int hugeListCount = 1; //set hugeListCount here so that it starts at 1 if item 2 is selected
                if (userInput == "1") // ADD ONE TIME TO DICTIONARY
                {
                    Console.WriteLine("\nWhat would you like to add to the dictionary?");
                    userDictionary.Add(Console.ReadLine(), dictionaryCount++);
                    Console.WriteLine("\nEntry was successfully added to the dictionary.  Press ENTER to continue.");
                    Console.Read();
                }
                else if (userInput == "2") // ADD HUGE LIST OF ITEMS TO DICTIONARY
                {
                    userDictionary.Clear();
                    for (int iCount = 0; iCount < 2000; iCount++)
                    {
                        userDictionary.Add("New Entry " + hugeListCount, hugeListCount);
                        hugeListCount++;
                    }
                    Console.WriteLine("Entries Completed.  Press ENTER to continue");
                    Console.Read();
                }
                else if (userInput == "3") // DISPLAY DICTIONARY
                {
                    Console.WriteLine();
                    foreach (KeyValuePair<string, int> kvp in userDictionary)
                    {
                        Console.WriteLine(kvp.Key.PadRight(20, ' ') + kvp.Value);
                    }
                    Console.WriteLine("Press ENTER to continue.");
                    Console.Read();
                }
                else if (userInput == "4")//DELETE FROM DICTIONARY
                {
                    Console.WriteLine("\nWhat would you like to delete?");
                    string userDelete = Console.ReadLine();
                    if (userDictionary.ContainsKey(userDelete) == true)
                    {
                        userDictionary.Remove(userDelete);
                        Console.WriteLine("\n" + userDelete + " was successfully deleted! Press ENTER to continue.");
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine(userDelete + "does not exist.  Press ENTER to continue.");
                        Console.Read();
                    }
                }
                else if (userInput == "5")// CLEAR DICTIONARY
                {
                    userDictionary.Clear();
                    Console.WriteLine("\nThe Dictionary was cleared. Press ENTER to continue.");
                    Console.Read();
                }
                else if (userInput == "6")// SEARCH DICTIONARY
                {
                    Console.WriteLine("\nWhat would you like to search for?");
                    userSearch = Console.ReadLine();
                    sw.Start(); //START STOP WATCH
                    bool search = userDictionary.ContainsKey(userSearch);
                    sw.Stop();
                    if (search == true)
                    {
                        Console.WriteLine("\nThe dictionary contains " + userSearch + ".\nThe search took " + sw.Elapsed + ".");
                        Console.WriteLine("Press ENTER to continue");
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine("\nThe dictionary does not contain this value.");
                        Console.WriteLine("Press ENTER to continue");
                        Console.Read();

                    }
                }
                else if (userInput == "7")//RETURN TO MAIN MENU
                {
                    menu = false;
                }
                else//OUTPUT ERROR IF THERE IS NOT A NUMBER ENTERED BETWEEN 1-7
                {
                    Console.WriteLine("\nPlease enter a valid menu number.");
                }
            }
        }


 


        //MAIN PROGRAM
        static void Main(string[] args)
        {
            //Outermost while loop to return to main menu
            bool menu = true ;
            int userInput;
            int userInput2;

            //Initialize data types before the while loop so they can be adjusted within other methods
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();


            while (menu)
            {
                Console.Clear();
                Console.WriteLine("1. Stack");
                Console.WriteLine("2. Queue");
                Console.WriteLine("3. Dictionary");
                Console.WriteLine("4. Exit");

                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 1)
                {
                 
                    
                    stackMenu(stack);
                }

                if (userInput == 2)
                {
                    QueueMenu(queue);
                    //queueMenu
                }

                if (userInput == 3)
                {
                    dictionaryMenu(dict);
                    //dictMenu

                }

                if (userInput == 4)
                {
                    Console.WriteLine("Goodbye");
                    menu = false;
                }

            }





        }
    }
}
