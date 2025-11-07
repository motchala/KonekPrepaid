using KonekLogicProcess;
using Microsoft.Extensions.Configuration;

namespace KonekApplication
// runs the whole application, takes care of the UI and UI its processes

{
    internal class MainApplication
    {
        private readonly KonekService konekService;
        private static string inputNumber = string.Empty;

        public MainApplication()
        {
            /*
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var emailService = new EmailService(configuration);
            konekService = new KonekService(emailService);
            */
            Login();
        }

        
        public void Login()
        {
                Console.Write("Konek LOGIN\n\n");

            do
            {
                Console.Write("\nEnter Number: ");
                inputNumber = Console.ReadLine();

                Console.Write("Enter Password: ");
                KonekService.userPin = Console.ReadLine();

                if (!konekService.ValidateAccount(inputNumber, KonekService.userPin)) // false
                {
                    Console.WriteLine("\n\t! FAILED. Account don't match. Please try again !");
                    Thread.Sleep(2200);
                    Console.Clear();
                    Login();
                }
            } while (!konekService.ValidateAccount(inputNumber, KonekService.userPin)); // true
            Console.Clear();
            MainMenu();
            Console.WriteLine();
        }
          


        public void MainMenu()
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
                    Console.Clear();

                    LoadMenu();
                }
                else if (KonekService.choiceMenu == 2)
                {
                    Console.Clear();

                    PromoMenu();                                // promo menu
                }
                else if (KonekService.choiceMenu == 3)
                {
                    Console.Clear();

                    AccountDisplay();                           // checks account info
                }
                else
                {
                    InvalidDisplay();
                    Thread.Sleep(2000);
                    Console.Clear();
                    MainMenu();
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
                Console.WriteLine("    ! Returning to main menu !");
                HalfBorderText(); Thread.Sleep(2200);
                Console.Clear();
                MainMenu();
            }
            else if (KonekService.loadAmount < 10)
            {
                Thread.Sleep(420);
                HalfBorderText();
                Console.WriteLine("    ! Transaction Unsuccessful !\n" +
                    "    ! Minimum load is 10 pesos !");
                HalfBorderText();
                Thread.Sleep(2800);
                Console.Clear();
                MainMenu();
            }
            else
            {
                konekService.LoadProcess(inputNumber);
                LoadSuccessDisplay();
                Thread.Sleep(300);
                BorderText();
                Thread.Sleep(2800);
                Console.Clear();
                MainMenu();
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
                Console.Clear();
                MainMenu();
            }
            else if (KonekService.choicePromo < 1 || KonekService.choicePromo > 4)
            {
                InvalidDisplay();
                Thread.Sleep(2000);
                Console.Clear();
                PromoMenu();
            }

            if (konekService.CanPurchasePromo(inputNumber))
            {
                PromoNamer();
                konekService.UpdatesLoadBalance_FromPromo(inputNumber);
                PromoSuccessDisplay();
                Thread.Sleep(2000);
                Console.Clear();
                MainMenu();
            }
            else
            {
                Insufficient();
                Thread.Sleep(2500);
                Console.Clear();
                PromoMenu();
            }
        }

        
     
        // CHECK ACCOUNT || Displays the account's details, balance and current active promo
        public void AccountDisplay()
        {
            BorderText();
            Console.WriteLine("ACCOUNT DETAILS:\n");
            Console.WriteLine("User: [" + konekService.GetAccountName(inputNumber) + "]");
            Console.WriteLine("Email: [" + konekService.GetAccountEmail(inputNumber) + "]\n");
            Console.WriteLine("Load Balance: [" + konekService.GetAccountBalance(inputNumber) + "]");
            Console.WriteLine("Reward Points: [" + konekService.GetAccountRewardPoints(inputNumber) + "]");
            CheckActivePromo();
            BorderText();
        }

        // CHECK ACCOUNT || this check the active promo. then prints only the active promo specifically the active promo print
        public void CheckActivePromo()
        {
            string promoName = konekService.GetActivePromo(inputNumber);
            if (!string.IsNullOrEmpty(promoName))
            {
                Console.WriteLine("Active Promo: [" + promoName + "]");
            }
            else
            {
                Console.WriteLine("No Active Promo");
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
            BorderText();
            SoundEffects();
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