using System.Runtime.CompilerServices;

namespace KonekPrepaid
{
    public class KonekApp
    {
        static void Main(string[] args)
        {
            int loadBalance = 70, loadTotal = 70, loadAmnt, back = -1;
            int choice1;
            int kon59 = 59,
                kon99 = 99,
                kon149 = 149,
                kon300 = 300,
                konChoice;

            Console.WriteLine("\t\t\tWelcome to Konek App!");

            while (true)
            {
                Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                Console.WriteLine("MENU:\n\n" +
                    "1. Buy Load\n" +
                    "2. Buy Promos\n" +
                    "3. Check Balance\n" +
                    "0. Exit App\n");
              
                    Console.Write("Choose menu: ");
                    choice1 = Convert.ToInt32(Console.ReadLine());
                
                    if (choice1 == 0)
                    {
                        break;
                    }
                    else if (choice1 == 1)
                    {
                        Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                        Console.Write("Enter Load Amount: ");
                        loadAmnt = Convert.ToInt32(Console.ReadLine());

                        if (loadAmnt == back)
                        {
                            Console.WriteLine("\n\t! Returned you back to the Main Menu !");
                            continue;
                        }
                        loadTotal += loadAmnt;
                        Console.WriteLine("\n\t[Load Balance = " + loadTotal + "]");

                    }
                    else if (choice1 == 2)
                    {
                        Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                        Console.WriteLine("\tPROMO:\n\n" +
                            "\t1. Konek59\n" +
                            "\t2. Konek99\n" +
                            "\t3. Konek149\n" +
                            "\t4. Konek300\n" +
                            "\t0. Back\n");
                        Console.Write("\tChoose promo: ");
                        konChoice = Convert.ToInt32(Console.ReadLine());

                        if (konChoice == 0)
                        {
                            continue;
                        }
                        else if (konChoice == 1)
                        {
                            if (loadTotal >= kon59)
                            {
                                Console.WriteLine("\n\t\t[You're now subscribed to Konek59 promo.]");
                                Console.Beep();
                                loadTotal -= kon59;
                                Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\t\t! You don't have enough load balance to subscribe to this promo. !");
                            }
                        }
                        else if (konChoice == 2)
                        {
                            if (loadTotal >= kon99)
                            {
                                Console.WriteLine("\n\t\t[You're now subscribed to Konek99 promo.]");
                                Console.Beep();
                                loadTotal -= kon99;
                                Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\t\t! You don't have enough load balance to subscribe to this promo. !");
                            }
                        }
                        else if (konChoice == 3)
                        {
                            if (loadTotal >= kon149)
                            {
                                Console.WriteLine("\n\t\t[You're now subscribed to Konek149 promo.]");
                                Console.Beep();
                                loadTotal -= kon149;
                                Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\t\t! You don't have enough load balance to subscribe to this promo !");
                            }
                        }
                        else if (konChoice == 4)
                        {
                            if (loadTotal >= kon300)
                            {
                                Console.WriteLine("\n\t\t[You're now subscribed to Konek300 promo.]");
                                Console.Beep();
                                loadTotal -= kon300;
                                Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n");

                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\n\t\t! You don't have enough load balance to subscribe to this promo !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\t! Invalid Choice !");
                        }
                    }
                    else if (choice1 == 3)
                    {
                        Console.WriteLine("\n\t[Load Balance: " + loadTotal + "]");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\n! Invalid Choice !");
                    }
                
            }
        }
    }
}
