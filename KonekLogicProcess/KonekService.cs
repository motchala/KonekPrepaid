using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonekCommon;
using KonekDataServices;


// manages the variables, as well as the logic of functions from the main application
namespace KonekLogicProcess
{
    public class KonekService
    {
        KonekDataService DataService = new KonekDataService();
        //InMemoryDataService MemoryService = new InMemoryDataService();
        
        public static int choiceMenu;           // getting main menu input
        public static int loadAmount;           // getting load amount input
        public static int secretBack = 0;       // secret number to return to main menu
        public static int choicePromo;          // getting promo menu choice 0-4
        public static int kon59 = 59,           // coresponding value of available promos
                          kon99 = 99,
                          kon149 = 149,
                          kon300 = 300;
        public static double totalRewardPts = 0;
        public static string promoName = string.Empty;
        
        // this checks the validity of the inputted account on the Login part
        public bool ValidateAccount(string accountNumber, string userPin)
        {
            return ValidateKonekAccount(accountNumber, userPin);
        }

        // this takes the account info when checking for ano, when choosing Check Account on the main menu 
        public string GetAccountName(string phoneNumber)
        {
            return DataService.GetAccountNameByPhoneNumber(phoneNumber);
        }

        public string GetAccountEmail(string accountNumber)
        {
            return DataService.GetEmailByPhoneNumber(accountNumber);
        }

        public double GetAccountBalance(string accountNumber)
        {
            return DataService.GetAccountBalanceByPhoneNumber(accountNumber);
        }

        public double GetAccountRewardPoints(string accountNumber)
        {
            return DataService.GetRewardPoints(accountNumber);
        }





        // adds purchased load to total balance
        public void LoadProcess(string accountNumber)
        {
            double currentBalance = DataService.GetAccountBalanceByPhoneNumber(accountNumber);
            double newBalance = currentBalance + loadAmount;
            DataService.UpdateAccountBalance(accountNumber, newBalance);
            RewardProcessLoad(accountNumber);
        }


        // adds corresponding rewardPoints after successful load transaction
        public void RewardProcessLoad(string accountNumber)
        {
            double earnedPoints = 0;

            if (loadAmount >= 10 && loadAmount <= 30)
                earnedPoints = 1.0;
            else if (loadAmount > 30 && loadAmount <= 80)
                earnedPoints = 2.0;
            else if (loadAmount > 80 && loadAmount <= 150)
                earnedPoints = 3.0;
            else if (loadAmount > 150 && loadAmount <= 300)
                earnedPoints = 4.5;
            else if (loadAmount > 300 && loadAmount <= 500)
                earnedPoints = 5.0;
            else if (loadAmount > 500 && loadAmount <= 1000)
                earnedPoints = 6.0;
            else if (loadAmount > 1000)
                earnedPoints = 7.5;

            if (earnedPoints > 0)
            {
                totalRewardPts += earnedPoints;
                DataService.AddRewardPointsLoad(accountNumber, earnedPoints);
            }
            else
            {
                Console.WriteLine("Do bigger transactions to get reward points.");
            }
        }

        




        // checks if load balance is sufficient for purchasing a promo
        public bool CanPurchasePromo(string accountNumber)
        {
            int[] promoPrices = { 0, kon59, kon99, kon149, kon300 };

            if (choicePromo >= 1 && choicePromo <= 4)
            {
                double currentBalance = DataService.GetAccountBalanceByPhoneNumber(accountNumber);
                return currentBalance >= promoPrices[choicePromo];
            }
            return false;
        }
        
        // chinecheck lang neto kung naka subscribe kana ba to any promo or what 
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
                double currentBalance = DataService.GetAccountBalanceByPhoneNumber(accountNumber);
                double newBalance = currentBalance - promoPrices[choicePromo];
                DataService.UpdateAccountBalance(accountNumber, newBalance);
                RewardProcessPromo(accountNumber);

                //this one updates the promo name when checking for the account's current active promo
                DataService.UpdateAccountPromo(accountNumber, promoName);
            }
        }


        // adds the corresponding rewardPoints after a successful promo purchase
        public void RewardProcessPromo(string accountNumber)
        {
            double earnedPoints = 0;

            if (choicePromo == 1)
            {
                earnedPoints += 1.2;
            }
            else if (choicePromo == 2)
            {
                earnedPoints += 1.8;
            }
            else if (choicePromo == 3)
            {
                earnedPoints += 2.5;
            }
            else if (choicePromo == 4)
            {
                earnedPoints += 2.9;
            }
            else
            {
            }

            if (choicePromo >= 1 || choicePromo <= 4)
            {
                totalRewardPts += earnedPoints;
                DataService.AddRewardPointsPromo(accountNumber, earnedPoints);
            }
        }

        public string GetActivePromo(string accountNumber)
        {
            return DataService.GetAccountPromo(accountNumber);
        }







        




        public bool ValidateKonekAccount(string accountNumber, string userPin)
        {
            var account = GetKonekAccount(accountNumber, userPin);

            if (account.PhoneNumber != null)
            {
                return true;
            }

            return false;
        }

        private KonekAccount GetKonekAccount(string accountNumber, string PIN)
        {
            var konekAccount = DataService.GetAllAccounts();
            var foundAccount = new KonekAccount();

            foreach (var account in konekAccount)
            {
                if (account.PhoneNumber == accountNumber && account.Pin == PIN)
                {
                    foundAccount = account;
                }
            }
            return foundAccount;
        }

        public double GetAccountBalance(string accountNumber, string PIN)
        {
            var konekAccount = GetKonekAccount(accountNumber, PIN);
            return konekAccount.LoadBalance;
        }
    }
}



