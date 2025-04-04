using System.Globalization;
using KonekLogicProcess;
namespace KonekApplication
{
    public class KonekApp
    {
        BusinessDataLogic BDL = new BusinessDataLogic();
        public KonekApp()
        {
            Login();
        }


        
        // string accEmail = "iamfrederickr@gmail.com";          // still dunno how ill implement this but might add this later on
        
        public void Login()
        {
            Console.Write("Login\n");
            Console.Write("\nAccount Number: ");
            BusinessDataLogic.inputNumber = Console.ReadLine();
            Console.Write("Enter Password: ");
            BusinessDataLogic.inputPassword = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                if (BusinessDataLogic.inputNumber == BusinessDataLogic.accNumber && 
                    BusinessDataLogic.inputPassword == BusinessDataLogic.accPassword)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine("\n\tLogged In Succesfully!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    mainMenu();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\n\t! Wrong Account Credentials!");
                    return;
                }
            }
        }



        public void mainMenu()
        {
            Console.WriteLine("\t\tWelcome to Konek App!");
            BorderText();

            while (true)
            {
                Console.WriteLine("MAIN MENU:\n\n" +
                    "[1] Buy Load\n" +
                    "[2] Buy Promos\n" +
                    "[3] Check Account\n" +
                    "[0] Exit App\n");
                Console.Write("Choose menu: ");
                BusinessDataLogic.choiceMenu = Convert.ToInt32(Console.ReadLine());

                if (BusinessDataLogic.choiceMenu == 0)
                {
                    BorderText();
                    Environment.Exit(0);                        // code to exit/terminate program
                }
                else if (BusinessDataLogic.choiceMenu == 1)
                {
                    LoadMenu();
                }
                else if (BusinessDataLogic.choiceMenu == 2)
                {
                    PromoMenu();                                // promo menu
                }
                else if (BusinessDataLogic.choiceMenu == 3)
                {
                    AccountDisplay();
                }
                else
                {
                    InvalidDisplay();
                }
            }
        }




        public void LoadMenu()
        {
            BorderText();
            Console.WriteLine("LOAD MENU:\n");
            Console.Write("Enter Load Amount: ");
            BusinessDataLogic.loadAmount = Convert.ToInt32(Console.ReadLine());

            if (BusinessDataLogic.loadAmount == BusinessDataLogic.secretBack)
            {
                HalfBorderText();
                Console.WriteLine("    ! Returning to main menu... !");
                HalfBorderText(); Thread.Sleep(2200); // a visual delay
            }
            else if (BusinessDataLogic.loadAmount < 10)
            {
                Thread.Sleep(420);
                HalfBorderText();
                Console.WriteLine("    ! Minimum load is 10 pesos !");
                HalfBorderText();
                Thread.Sleep(500);
            }
            else
            {
                BusinessDataLogic.LoadProcess();
                LoadSuccessDisplay();
                Thread.Sleep(300);
                BorderText();
                Thread.Sleep(300);
            }
        }


        public void PromoMenu()
        {
            BorderText();
            Console.WriteLine("PROMO MENU:\n\n" +
                "[1] Konek59\n" +
                "[2] Konek99\n" +
                "[3] Konek149\n" +
                "[4] Konek300\n" +
                "[0] Back\n");
            Console.Write("Choose promo: ");
            BusinessDataLogic.choicePromo = Convert.ToInt32(Console.ReadLine());

            if (BusinessDataLogic.choicePromo == 0) // returns you to main menu
            {
                BorderText();
                return;
            }
            else if (BusinessDataLogic.choicePromo < 1 || BusinessDataLogic.choicePromo > 4)
            {
                InvalidDisplay(); // error promo choice
                return;
            }

            if (BusinessDataLogic.CanPurchasePromo())
            {
                BusinessDataLogic.PromoLoadUpdate();
                PromoNamer();
                PromoSuccessDisplay();
                BorderText();
                SoundEffects();
            }
            else if (!BusinessDataLogic.CanPurchasePromo())
            {
                Insufficient();
            }
        }





        // CHECK ACCOUNT || Displays the balance and current active promo
        public void AccountDisplay()
        {
            BorderText();
            Console.WriteLine("\tLoad Balance: [" + BusinessDataLogic.loadBalance + "]");
            CheckActivePromo();
            BorderText();
        }




        // CHECK ACCOUNT || this check the active promo. then prints only the active promo specifically the active promo print
        public void CheckActivePromo()
        {
            if (BusinessDataLogic.SubscriptionChecker != null)
            {
                Console.WriteLine("\tActive Promo: [" + BusinessDataLogic.promoName + "]");
            }
            else
            {
                Console.WriteLine("\t ! ERROR ! ");
            }
        }


        // displays the name of the active promo. displays the specific promo chosen by the user.
        // nilagyan lang ng katumbas na string
        public void PromoNamer()
        {
            switch (BusinessDataLogic.choicePromo)
            {
                case 1: BusinessDataLogic.promoName = "Konek59"; break;
                case 2: BusinessDataLogic.promoName = "Konek99"; break;
                case 3: BusinessDataLogic.promoName = "Konek149"; break;
                case 4: BusinessDataLogic.promoName = "Konek300"; break;
                default: BusinessDataLogic.promoName = "! unknown !"; break;
            }
        }





        // INTERFACE! DESIGN!
        public void BorderText()
        {
            Console.WriteLine("\n--------------------------------------------------------\n");
        }
        public void HalfBorderText()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - -\n");
        }
        public void SoundEffects() // for when successful promo subscription
        {
            Thread.Sleep(400);
            Console.Beep();
        }

        public void LoadSuccessDisplay()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\n          [Successful Load Transaction]");
        }
        public void Insufficient()
        {
            Thread.Sleep(700);
            HalfBorderText();
            Console.WriteLine("\t! Insufficient Load ! ");
            HalfBorderText();
        }
        public void PromoSuccessDisplay()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\n\t[You're now subscribed to " + BusinessDataLogic.promoName + " promo]");
        }
        public void InvalidDisplay()
        {
            HalfBorderText();
            Console.WriteLine("\t! Invalid Choice ! ");
            HalfBorderText();
        }









        public static void Main(string[] args)
        {
            new KonekApp();
        }

    }
}
