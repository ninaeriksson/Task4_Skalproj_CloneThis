/************************************************************************
Övning 4, C# - Minneshantering
Nina Eriksson
2025-06-12
*************************************************************************/

/************************************************************************
Fråga 1. https://www.linkedin.com/pulse/heap-stack-allocation-c-comprehensive-guide-andre-baltieri-hm6nf/

Fråga 2. Värdetyper lagrar själva värdet direkt i variabeln, medan referenstyper lagrar en referens (en adress)
till en annan minnesplats där värdet finns. Värdetyper i C# lagras på stacken medan referenstyper lagras på heapen.

Fråga 3. Första metoden returnerar värdet x har, alltså 3. Värdetyperna kopier bara värdet när man sätter ena variabeln
till den andra (ex y = x). I andra metoden skapas två referenser till MyInt upp. När man skriver y = x ställer man om så
att y pekar på samma som x. Alltså pekar både x och y på samma. Ändrar man y.MyValue så ändras även x.MyValue till samma.

Fråga. Rekursiva funktioner anropar sig själva, vilket innebär att en ny stackframe skapas för varje anrop, vilket kan
leda till ökad minneskonsumtion. Iterativa algoritmer, å andra sidan, använder loopar och behöver inte skapa nya
stackframes, vilket gör dem mer minneseffektiva. 

*************************************************************************/

using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        static List<string> myList = new List<string>();
        static Queue<string> myQueue = new Queue<string>();
        static Stack<string> myStack = new Stack<string>();

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7, 8, 9, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. ReverseText"
                    + "\n5. CheckParenthesis"
                    + "\n6. RecursiveEven"
                    + "\n7. RecursiveFibonacci"
                    + "\n8. IterativeEven"
                    + "\n9. IterativeFibonacci"
                    + "\n0. Exit the application"
                    + "\nChoice:");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ReverseText();
                        break;
                    case '5':
                        CheckParanthesis();
                        break;
                    case '6':
                        Console.Write("Calculate the n:th even number. Enter n: ");
                        string? input1 = Console.ReadLine();
                        int inputInt1 = CheckInputString(input1);
                        if (inputInt1 != -1)
                            Console.WriteLine("RecurseEven: " + RecursiveEven(inputInt1));
                        else
                            Console.WriteLine("Something went wrong.");
                        break;
                    case '7':
                        Console.Write("Recursive fibonacci f(n). Enter n: ");
                        string? input2 = Console.ReadLine();
                        int inputInt2 = CheckInputString(input2);
                        if (inputInt2 != -1)
                            Console.WriteLine($"f({input2}): " + RecursiveFibonacci(inputInt2));
                        else
                            Console.WriteLine("Something went wrong.");
                        break;
                    case '8':
                        Console.Write("Calculate the n:th even number. Enter n: ");
                        string? input3 = Console.ReadLine();
                        int inputInt3 = CheckInputString(input3);
                        if (inputInt3 != -1)
                            Console.WriteLine("IterativeEven: " + IterativeEven(inputInt3));
                        else
                            Console.WriteLine("Something went wrong.");
                        break;
                    case '9':
                        Console.Write("Iterative fibonacci f(n). Enter n: ");
                        string? input4 = Console.ReadLine();
                        int inputInt4 = CheckInputString(input4);
                        if (inputInt4 != -1)
                            Console.WriteLine($"f({input4}): " + IterativeFibonacci(inputInt4));
                        else
                            Console.WriteLine("Something went wrong.");
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6, 7, 8, 9)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        private static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //Capacity is the number of the elements which the List can store before resizing of List needed

            //Listan ökar sin kapasitet när man lägger till string nummer 5. Kapasiteten börjar med 4 sedan när fler
            //platser behövs fördubblas det. Kapasiteten ökade från 4 till 8 till 16 till 32, så långt jag testade.
            //Vid borttagning av element så minskar inte kapasiteten.
            while (true)
            {
                Console.WriteLine("Add or remove a string. Start the string with + or - (0 for exit)");
                string? input = Console.ReadLine();
                char choice = input![0];
                string? value = input.Substring(1);

                switch (choice)
                {
                    case '+':
                        Console.WriteLine($"myList.Count (before): {myList.Count}");
                        Console.WriteLine($"myList.Capacity (before): {myList.Capacity}");
                        myList.Add(value);
                        Console.WriteLine($"myList.Count (after): {myList.Count}");
                        Console.WriteLine($"myList.Capacity (after): {myList.Capacity}");
                        break;
                    case '-':
                        Console.WriteLine($"myList.Count (before): {myList.Count}");
                        Console.WriteLine($"myList.Capacity (before): {myList.Capacity}");
                        myList.RemoveAll(item => item == value);
                        Console.WriteLine($"myList.Count (after): {myList.Count}");
                        Console.WriteLine($"myList.Capacity (after): {myList.Capacity}");

                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Start input with + or - (0 to exit)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        private static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            while (true)
            {
                Console.WriteLine("1. Enqueue\n2. Dequeue. \n0. Exit");
                string? input = Console.ReadLine();
                char choice = input![0];

                switch (choice)
                {
                    case '1':
                        Console.Write("Enter name to add: ");
                        string? addName = Console.ReadLine();
                        Console.WriteLine($"myQueue.Count (before {addName}): {myQueue.Count}");
                        if (addName != null)
                        {
                            myQueue.Enqueue(addName);
                            Console.WriteLine($"myQueue.Count (after {addName}): {myQueue.Count}");
                        }
                        else
                            Console.WriteLine("No name was given");
                        break;
                    case '2':
                        try
                        {
                            Console.WriteLine($"myQueue.Count (before): {myQueue.Count}");
                            string removedPerson = myQueue.Dequeue();
                            Console.WriteLine($"myQueue.Count (after): {myQueue.Count} ({removedPerson} has left the queue)");
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("The queue is empty");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something went wrong");
                        }
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter valid input (0 for exit)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        private static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            while (true)
            {
                Console.WriteLine("1. Push\n2. Pop \n0. Main meny");
                string? input = Console.ReadLine();
                char choice = input![0];

                switch (choice)
                {
                    case '1':
                        Console.Write("Enter name to push: ");
                        string? addName = Console.ReadLine();
                        Console.WriteLine($"myStack.Count (before {addName}): {myStack.Count}");
                        if (addName != null)
                        {
                            myStack.Push(addName);
                            Console.WriteLine($"myStack.Count (after {addName}): {myStack.Count}");
                        }
                        else
                            Console.WriteLine("No name was given");
                        break;
                    case '2':
                        try
                        {
                            Console.WriteLine($"myStack.Count (before): {myStack.Count}");
                            string removedPerson = myStack.Pop();
                            Console.WriteLine($"myStack.Count (after): {myStack.Count} ({removedPerson} has been removed from stack)");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something went wrong");
                        }
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter valid input (0 for exit)");
                        break;
                }
            }
        }

        private static void ReverseText()
        {
            Console.Write("Write something: ");
            string? inputString = Console.ReadLine();
            if (inputString != null)
            {
                foreach (char c in inputString)
                {
                    myStack.Push(c.ToString());
                }
                Console.Write("Reverse: ");
                while (myStack.Count > 0)
                {
                    string poppedChar = myStack.Pop();
                    Console.Write(poppedChar);
                }
                Console.WriteLine();
            }
        }

        private static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            //Metoden läser av varje char i en sträng. Hittas en start-parentes läggs den på stacken. Hittas en slut-parentes tittar
            //man om motsvarande start-parentes finns högst upp på stacken. Om så är fallet, tas start-parentesen bort från
            //stacken (man har hittat ett korrekt parentes-par).
            //Om stacken är tom i slutet innebär det att alla start-parenteser har motsvarande slut-parentes.
            Console.Write("Input: ");
            string? inputString = Console.ReadLine();
            if (inputString != null)
            {
                foreach (char c in inputString)
                {
                    if (c.Equals('(') || c.Equals('{') || c.Equals('['))
                        myStack.Push(c.ToString());
                    else if (c.Equals(')'))
                    {
                        if (myStack.Count > 0 && myStack.Peek().Equals("("))
                            myStack.Pop();
                    }
                    else if (c.Equals('}'))
                    {
                        if (myStack.Count > 0 && myStack.Peek().Equals("{"))
                            myStack.Pop();
                    }
                    else if (c.Equals(']'))
                    {
                        if (myStack.Count > 0 && myStack.Peek().Equals("["))
                            myStack.Pop();
                    }
                }

                if (myStack.Count == 0)
                {
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
            }
        }


        private static int CheckInputString(string? inputString)
        {
            try
            {
                int inputNumber = Int32.Parse(inputString);
                if (inputNumber < 0)
                    throw new Exception();
                return inputNumber;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return RecursiveEven(n - 1) + 2;
        }

        private static int RecursiveFibonacci(int n)
        {
            if (n < 2)
                return n;
            else
                return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }

        private static int IterativeEven(int n)
        {
            int result = 2;
            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }
            return result;
        }

        private static int IterativeFibonacci(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}

