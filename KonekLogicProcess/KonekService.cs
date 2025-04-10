using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonekDataService;

namespace KonekLogicProcess
{
    public class KonekService
    {
        // Login variables
        // public static string accNumber = "09662668443";
        // public static string accPassword = "fred123";
        // public static string inputNumber, inputPassword;
        AccountDataService DataService = new AccountDataService();
        
        public static int choiceMenu;           // getting main menu input
        public static int loadAmount;           // getting load amount input
        public static int secretBack = 0;      // secret number to return to main menu
        public static int choicePromo;          // getting promo menu choice 0-4
        //public static int loadBalance = 70;     // initial but dynamic load balance value
        public static int kon59 = 59,           // coresponding value of available promos
                          kon99 = 99,
                          kon149 = 149,
                          kon300 = 300;  
        public static string promoName = "";
        

        public bool ValidateAccount(string accountNumber, string userPin)
        {
            return DataService.ValidateKonekAccount(accountNumber, userPin);
        }

        public double GetAccountBalance(string accountNumber)
        {
            return DataService.GetAccountBalance(accountNumber);
        }


        // adds the purchased load to the load balance
        public void LoadProcess(string accountNumber)
        {
            double currentBalance = DataService.GetAccountBalance(accountNumber);
            double newBalance = currentBalance + loadAmount;
            DataService.UpdateAccountBalance(accountNumber, newBalance);
        }
        /*
        public static void LoadProcess()
        {
            KonekService.LoadBalance += KonekService.loadAmount;
        }
        */
        // checks if load balance is sufficient for purchasing a promo
        public bool CanPurchasePromo(string accountNumber)
        {
            int[] promoPrices = { 0, kon59, kon99, kon149, kon300 };

            if (choicePromo >= 1 && choicePromo <= 4)
            {
                double currentBalance = DataService.GetAccountBalance(accountNumber);
                return currentBalance >= promoPrices[choicePromo];
            }
            return false;
        }
        /*
        public static bool CanPurchasePromo()
        {
            int[] promoPrices = { 0, kon59, kon99, kon149, kon300 };
            if (choicePromo >= 1 && choicePromo <= 4)
            {
                return LoadBalance >= promoPrices[choicePromo];
            }
            return false;
        }
        */

        // chinecheck lang neto kung naka subscribe kana ba on any promo or what 
        public bool SubscriptionChecker(string accountNumber)
        {
            return CanPurchasePromo(accountNumber);
               
        }

        // updates the load balance after a promo purchase
        public void PromoLoadUpdate(string accountNumber)
        {
            int[] promoPrices = { 0, kon59, kon99, kon149, kon300 };

            if (choicePromo >= 1 && choicePromo <= 4)
            {
                double currentBalance = DataService.GetAccountBalance(accountNumber);
                double newBalance = currentBalance - promoPrices[choicePromo];
                DataService.UpdateAccountBalance(accountNumber, newBalance);
            }
        }
        /*
        public static void PromoLoadUpdate()
        {
            int[] promoPrices = { 0, kon59, kon99, kon149, kon300 };

            if (choicePromo >= 1 && choicePromo <= 4)
            {
                loadBalance -= promoPrices[choicePromo];
            }
        }
        */
    }
}



