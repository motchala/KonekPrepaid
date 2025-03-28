using KonekLogicProcess;
namespace KonekApplication
{
    public class KonekApp
    {
        BusinessDataLogic BDL = new BusinessDataLogic();
        public KonekApp()
        {
            mainMenu();
        }



        
        public void mainMenu()
        {
            Console.WriteLine("\t\t\tWelcome to Konek App!");
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
            Console.WriteLine("\tLOAD MENU:\n");
            Console.Write("\tEnter Load Amount: ");
            BusinessDataLogic.loadAmount = Convert.ToInt32(Console.ReadLine());

            if (BusinessDataLogic.loadAmount == BusinessDataLogic.secretBack)
            {
                HalfBorderText();
                Console.WriteLine("! Returning to main menu... !");
                HalfBorderText(); Thread.Sleep(2200); // a visual delay
            }
            else if(BusinessDataLogic.loadAmount < 10)
            {
                HalfBorderText();
                Console.WriteLine("! Minimum load is 10 pesos !");
                HalfBorderText();
            }
            else
            {
                BusinessDataLogic.LoadProcess();
                LoadSuccessDisplay();
                Thread.Sleep(500);
                BorderText();
            }
            
        }


        public void PromoMenu()
        {
            BorderText();
            Console.WriteLine("\tPROMO MENU:\n\n" +
                "\t[1] Konek59\n" +
                "\t[2] Konek99\n" +
                "\t[3] Konek149\n" +
                "\t[4] Konek300\n" +
                "\t[0] Back\n");
            Console.Write("\tChoose promo: ");
            BusinessDataLogic.choicePromo = Convert.ToInt32(Console.ReadLine());

            if (BusinessDataLogic.choicePromo == 0) // returns you to main menu
            {
                BorderText();
                return;
            }
            else if (BusinessDataLogic.choicePromo < 1 || BusinessDataLogic.choicePromo > 4)
            {
                InvalidDisplay();
                return;
            }

            if (BusinessDataLogic.CanPurchasePromo())
            {
                BusinessDataLogic.LoadBalUpdate();
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



        public void AccountDisplay()
        {
            BorderText();
            Console.WriteLine("\tCurrent Load Balance = [" + BusinessDataLogic.loadBalance + "]");
            CheckActivePromo();
            BorderText();
        }





        // Designs lang palamuti
        public void BorderText()
        {
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
        }
        public void HalfBorderText()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - -\n");
        }
        public void SoundEffects() // for when successful promo subscription
        {
            Console.Beep();
        }
       
        public void LoadSuccessDisplay()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\n\t[Successful Load Transaction]");
        }
        public void Insufficient()
        {
            HalfBorderText();
            Console.WriteLine("\t! Insufficient Load ! ");
            HalfBorderText();
        }
        public void PromoSuccessDisplay()
        {
            Console.WriteLine("\n\t\t[You're now subscribed to " + BusinessDataLogic.promoName + " promo]");
        }
        public void InvalidDisplay()
        {
            HalfBorderText();
            Console.WriteLine("\t ! Invalid Choice ! "); 
            HalfBorderText();
        }









        public static void Main(string[] args)
        {
            new KonekApp();
        }

    }
}
