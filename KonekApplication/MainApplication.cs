using System.Globalization;
using KonekLogicProcess;
namespace KonekApplication
{
    internal class MainApplication
    {
        KonekLogicProcess.KonekService konekService = new KonekLogicProcess.KonekService();
        static string inputNumber = string.Empty;
        public MainApplication()
        {
            Login();
        }




        public void Login()
        {
            string userPin = string.Empty;
            Console.Write("Login\n");

            do
            {


                Console.Write("\nAccount Number: ");
                inputNumber = Console.ReadLine();

                Console.Write("Enter Password: ");
                userPin = Console.ReadLine();
                Console.Clear();

                if (!konekService.ValidateAccount(inputNumber, userPin))
                {
                    Console.WriteLine("FAILED: Incorrect PIN. Please try again.");
                }
            } while (!konekService.ValidateAccount(inputNumber, userPin));
            Console.Clear();
            mainMenu();
            Console.WriteLine();
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
                KonekService.choiceMenu = Convert.ToInt32(Console.ReadLine());

                if (KonekService.choiceMenu == 0)
                {
                    BorderText();
                    Environment.Exit(0);                        // code to exit/terminate program
                }
                else if (KonekService.choiceMenu == 1)
                {
                    LoadMenu();
                }
                else if (KonekService.choiceMenu == 2)
                {
                    PromoMenu();                                // promo menu
                }
                else if (KonekService.choiceMenu == 3)
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
            KonekService.loadAmount = Convert.ToInt32(Console.ReadLine());

            if (KonekService.loadAmount == KonekService.secretBack)
            {
                HalfBorderText();
                Console.WriteLine("    ! Returning to main menu... !");
                HalfBorderText(); Thread.Sleep(2200);
            }
            else if (KonekService.loadAmount < 10)
            {
                Thread.Sleep(420);
                HalfBorderText();
                Console.WriteLine("    ! Minimum load is 10 pesos !");
                HalfBorderText();
                Thread.Sleep(500);
            }
            else
            {
                konekService.LoadProcess(inputNumber);
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
            KonekService.choicePromo = Convert.ToInt32(Console.ReadLine());

            if (KonekService.choicePromo == 0)
            {
                BorderText();
                return;
            }
            else if (KonekService.choicePromo < 1 || KonekService.choicePromo > 4)
            {
                InvalidDisplay();
                return;
            }

            if (konekService.CanPurchasePromo(inputNumber))
            {
                konekService.PromoLoadUpdate(inputNumber);
                PromoNamer();
                PromoSuccessDisplay();
                BorderText();
                SoundEffects();
            }
            else
            {
                Insufficient();
            }
        }

        
     
        // CHECK ACCOUNT || Displays the balance and current active promo
        public void AccountDisplay()
        {
            BorderText();
            Console.WriteLine("\tLoad Balance: [" + konekService.GetAccountBalance(inputNumber) + "]");
            CheckActivePromo();
            BorderText();
        }

        // CHECK ACCOUNT || this check the active promo. then prints only the active promo specifically the active promo print
        public void CheckActivePromo()
        {
            if (konekService.SubscriptionChecker(inputNumber))
            {
                Console.WriteLine("\tActive Promo: [" + KonekService.promoName + "]");
            }
            else
            {
                Console.WriteLine("\tNo active promo or insufficient load.");
            }
        }

        // displays the name of the active promo. displays the specific promo chosen by the user.
        // nilagyan lang ng katumbas na string (supposedly... kaso hindi na gumana nung sineparate na yung data sa business logic)
        public void PromoNamer()
        {
            switch (KonekService.choicePromo)
            {
                case 1: KonekService.promoName = "Konek59"; break;
                case 2: KonekService.promoName = "Konek99"; break;
                case 3: KonekService.promoName = "Konek149"; break;
                case 4: KonekService.promoName = "Konek300"; break;
                default: KonekService.promoName = "! unknown !"; break;
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
            Console.WriteLine("\n\t[You're now subscribed to " + KonekService.promoName + " promo]");
        }
        public void InvalidDisplay()
        {
            HalfBorderText();
            Console.WriteLine("\t! Invalid Choice ! ");
            HalfBorderText();
        }


        public static void Main(string[] args)
        {
            new MainApplication();
        }

    }
}

/*
        public void LoadMenu()
        {
            BorderText();
            Console.WriteLine("LOAD MENU:\n");
            Console.Write("Enter Load Amount: ");
            KonekService.loadAmount = Convert.ToInt32(Console.ReadLine());

            if (KonekService.loadAmount == KonekService.secretBack)
            {
                HalfBorderText();
                Console.WriteLine("    ! Returning to main menu... !");
                HalfBorderText(); Thread.Sleep(2200); // a visual delay
            }
            else if (KonekService.loadAmount < 10)
            {
                Thread.Sleep(420);
                HalfBorderText();
                Console.WriteLine("    ! Minimum load is 10 pesos !");
                HalfBorderText();
                Thread.Sleep(500);
            }
            else
            {
                KonekService.LoadProcess();
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
            KonekService.choicePromo = Convert.ToInt32(Console.ReadLine());

            if (KonekService.choicePromo == 0) // returns you to main menu
            {
                BorderText();
                return;
            }
            else if (KonekService.choicePromo < 1 || KonekService.choicePromo > 4)
            {
                InvalidDisplay(); // error promo choice
                return;
            }

            if (KonekService.CanPurchasePromo())
            {
                KonekService.PromoLoadUpdate();
                PromoNamer();
                PromoSuccessDisplay();
                BorderText();
                SoundEffects();
            }
            else if (!KonekService.CanPurchasePromo())
            {
                Insufficient();
            }
        }


        public void CheckActivePromo()
        {
            if (KonekService.SubscriptionChecker != null)
            {
                Console.WriteLine("\tActive Promo: [" + KonekService.promoName + "]");
            }
            else
            {
                Console.WriteLine("\t ! ERROR ! ");
            }
        }
        */
