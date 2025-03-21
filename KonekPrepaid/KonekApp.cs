using System.Runtime.CompilerServices;

namespace KonekPrepaid
{
    public class KonekApp
    {
        int loadBalance = 70, loadAmnt, back = -1;
        int choice1;
        int kon59 = 59,
            kon99 = 99,
            kon149 = 149,
            kon300 = 300,
            konChoice;
        KonekApp() // constructor that calls each method separately
        {
            mainMenu();
            promoMenu();
        }





        public void mainMenu()
        {
            Console.WriteLine("\t\t\tWelcome to Konek App");


            while (true) // looping
            {

                Console.WriteLine("MENU:\n\n" +
                    "[1] Buy Load\n" +
                    "[2] Buy Promos\n" +
                    "[3] Check Balance\n" +
                    "[0] Exit App\n");

                Console.Write("Choose menu: ");
                choice1 = Convert.ToInt32(Console.ReadLine());

                if (choice1 == 0)
                {
                    Environment.Exit(0);
                    // break; // exits the program
                }
                else if (choice1 == 1)
                {
                    displayBorder();
                    Console.Write("Enter Load Amount: ");
                    loadAmnt = Convert.ToInt32(Console.ReadLine());

                        if (loadAmnt == back)
                        {
                            Console.WriteLine("\n\t! Returned you back to the Main Menu !");
                            continue;
                        }
                        loadBalance += loadAmnt;
                        Console.WriteLine("\n\t[Load Balance = " + loadBalance + "]");

                    }
                    else if (choice1 == 2)
                    {
                    promoMenu(); // method calling
                }
                else if (choice1 == 3)
                {
                    Console.WriteLine("\n\t[Load Balance: " + loadBalance + "]");
                    displayBorder();
                    continue;
                }
                else
                {
                    Console.WriteLine("\n! Invalid Choice !");
                }
            }
        }





        public void promoMenu()
        {
            displayBorder();
                        Console.WriteLine("\tPROMO:\n\n" +
                "\t[1] Konek59\n" +
                "\t[2] Konek99\n" +
                "\t[3] Konek149\n" +
                "\t[4] Konek300\n" +
                "\t[0] Back\n");
                        Console.Write("\tChoose promo: ");
                        konChoice = Convert.ToInt32(Console.ReadLine());

            if (konChoice == 0)
            {
                displayBorder();
                return;
            }
            else if (konChoice == 1)
            {
                if (loadBalance >= kon59)
                {
                    Console.WriteLine("\n\t\t[You're now subscribed to Konek59 promo.]");
                    Console.Beep();
                    loadBalance -= kon59;
                    displayBorder();
                }
                else
                {
                    insufficientLoad();
                }
            }
            else if (konChoice == 2)
            {
                if (loadBalance >= kon99)
                {
                    Console.WriteLine("\n\t\t[You're now subscribed to Konek99 promo.]");
                    Console.Beep();
                    loadBalance -= kon99;
                    displayBorder();
                }
                else
                {
                    insufficientLoad();
                }
            }
            else if (konChoice == 3)
            {
                if (loadBalance >= kon149)
                {
                    Console.WriteLine("\n\t\t[You're now subscribed to Konek149 promo.]");
                    Console.Beep();
                    loadBalance -= kon149;
                    displayBorder();
                }
                else
                {
                    insufficientLoad();
                }
            }
            else if (konChoice == 4)
            {
                if (loadBalance >= kon300)
                {
                    Console.WriteLine("\n\t\t[You're now subscribed to Konek300 promo.]");
                    Console.Beep();
                    loadBalance -= kon300;
                    displayBorder();
                }
                else
                {
                    insufficientLoad();
                }
            }
            else
            {
                Console.WriteLine("\n\t! Invalid Choice !");
            }
        }




        static void displayBorder() // repetitive code, too long to use in every code block 
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
        }
        public void insufficientLoad() // repetitive code, too long to use in every code block
        {
            Console.WriteLine("\n\t\t! You don't have enough load balance to subscribe to this promo !");
            displayBorder();

        }




        static void Main(string[] args) // main method!
        {
            new KonekApp();
            displayBorder();
        }
    }
}
