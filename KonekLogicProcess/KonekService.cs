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
        
        public static string userPin = string.Empty; // for login
        public static int choiceMenu;           // getting main menu input
        public static int loadAmount;           // getting load amount input
        public static int secretBack = 0;       // secret number to return to main menu
        public static int choicePromo;          // getting promo menu choice 0-4
        public static int kon59 = 59,           // coresponding value of available promos
                          kon75 = 75,
                          kon99 = 99,
                          kon129 = 129,
                          kon35plus = 35,
                          kon249plus = 249,
                          kon99plus = 99,
                          kon360plus = 360;
        public static int choiceReward; // for rewards basta
        public static double // rewardChoices
                        reward1 = 2.0, 
                        reward2 = 4.5,
                        reward3 = 2.9,
                        reward4 = 1.2, // panel 1 hanggang dito
                        reward5 = 0.5,
                        reward6 = 0.7,
                        reward7 = 2.0,
                        reward8 = 12.0; // panel 2 ito
        public static double totalRewardPts = 0;
        public static string promoName = string.Empty;
        
        // this checks the validity of the inputted account on the Login part
        public bool ValidateAccount(string accountNumber, string userPin) // ito, para lang  magamit ko 'to  sa ibang project.
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
        public string GetAccountNumber(string accountNumber)
        {
            return DataService.GetAccountNumberByPhoneNumber(accountNumber);
        }

        public double GetAccountBalance(string accountNumber)
        {
            return DataService.GetAccountBalanceByPhoneNumber(accountNumber);
        }

        public double GetAccountRewardPoints(string accountNumber)
        {
            return DataService.GetRewardPoints(accountNumber);
        }
        // lahat ng method sa taas is para lang magamit/ma-return ko sya sa MainApplication/UI part ko.




        // adds purchased load to total balance
        public void LoadProcess(string accountNumber)
        {
            double currentBalance = DataService.GetAccountBalanceByPhoneNumber(accountNumber);
            double newBalance = currentBalance + loadAmount;
            DataService.UpdateAccountBalance(accountNumber, newBalance);
            RewardFromLoad(accountNumber);
        }


        // adds corresponding rewardPoints after successful load transaction
        public void RewardFromLoad(string accountNumber)
        {
            double earnedPoints = 0;

            if (loadAmount >= 10 && loadAmount <= 30)
                earnedPoints = 0.5;
            else if (loadAmount > 30 && loadAmount <= 80)
                earnedPoints = 1.0;
            else if (loadAmount > 80 && loadAmount <= 150)
                earnedPoints = 1.5;
            else if (loadAmount > 150 && loadAmount <= 300)
                earnedPoints = 2.5;
            else if (loadAmount > 300 && loadAmount <= 500)
                earnedPoints = 3.8;
            else if (loadAmount > 500 && loadAmount <= 1000)
                earnedPoints = 4.9;
            else if (loadAmount > 1000)
                earnedPoints = 5.0;

            if (earnedPoints > 0)
            {
                totalRewardPts += earnedPoints;
                DataService.AddRewardPointsLoad(accountNumber, earnedPoints);
            }
        }

        




        // checks if load balance is sufficient for purchasing promo
        public bool CanPurchasePromo(string accountNumber)
        {
            int[] promoPrices = { 0, kon59, kon75, kon99, kon129, kon99plus, kon360plus, kon35plus, kon249plus };

            if (choicePromo >= 1 && choicePromo <= 8)
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
        public void UpdatesLoadBalance_FromPromo(string accountNumber)
        {
            int[] promoPrices = { 0, kon59, kon75, kon99, kon129, kon99plus, kon360plus, kon35plus, kon249plus };
            if (choicePromo >= 1 && choicePromo <= 8)
            {
                double currentBalance = DataService.GetAccountBalanceByPhoneNumber(accountNumber);
                double newBalance = currentBalance - promoPrices[choicePromo];
                DataService.UpdateAccountBalance(accountNumber, newBalance);
                RewardFromPromo(accountNumber);

                //this one updates the promo name when checking for the account's current active promo
                DataService.UpdateAccountPromo(accountNumber, promoName);
            }
        }


        // adds the corresponding rewardPoints after a successful promo purchase
        public void RewardFromPromo(string accountNumber)
        {
            double earnedPoints = 0;

            if (choicePromo == 1)
            {
                earnedPoints += 0.2;
            }
            else if (choicePromo == 2)
            {
                earnedPoints += 0.9;
            }
            else if (choicePromo == 3)
            {
                earnedPoints += 1.2;
            }
            else if (choicePromo == 4)
            {
                earnedPoints += 1.5;
            }
            else if (choicePromo == 5)
            {
                earnedPoints += 1.9;
            }
            else if (choicePromo == 6)
            {
                earnedPoints += 2.7;
            }
            else if (choicePromo == 7)
            {
                earnedPoints += 3.2;
            }
            else if (choicePromo == 8)
            {
                earnedPoints += 4.1;
            }
            else
            {
            }

            if (choicePromo >= 1 && choicePromo <= 8)
            {
                totalRewardPts += earnedPoints;
                DataService.AddRewardPointsPromo(accountNumber, earnedPoints);
            }
        }

        public string GetActivePromo(string accountNumber)
        {
            return DataService.GetAccountPromo(accountNumber);
        }






        // FOR REWARD CHOICES
        public bool CanPurchaseReward(string accountNumber)
        {
            double[] rewardPrices = { 0, reward1, reward2, reward3, reward4, reward5, reward6, reward7, reward8 };

            if (choiceReward >= 1 && choiceReward <= 8)
            {
                double currentRewardPts = DataService.GetRewardPoints(accountNumber);
                return currentRewardPts >= rewardPrices[choiceReward];
            }
            return false;
        }

        public bool SubscriptionRewardChecker(string accountNumber)
        {
            return CanPurchaseReward(accountNumber);
        }

        public void UpdatesRewardPoints_FromReward(string accountNumber)
        {
            double[] rewardPrices = { 0, reward1, reward2, reward3, reward4, reward5, reward6, reward7, reward8 };
            if (choiceReward >= 1 && choiceReward <= 8)
            {
                double currentRewardPts = DataService.GetRewardPoints(accountNumber);
                double newRewardPtsBalance = currentRewardPts - rewardPrices[choiceReward];
                DataService.UpdateAccountRewardPts(accountNumber, newRewardPtsBalance);

                //this one updates the promo name when checking for the account's current active promo
                DataService.UpdateAccountPromo(accountNumber, promoName);
            }
        }










        // LOGIN. 2nd checking process
        public bool ValidateKonekAccount(string accountNumber, string userPin) // this one also checks if yung pinagkukuhanan ng data is merong data. not just any data tho, appropriate data.
        {
            var account = GetKonekAccount(accountNumber, userPin);

            if (account.PhoneNumber != null)
            {
                return true;
            }

            return false;
        }
        public List<KonekAccount> GetData()
        {
            return DataService.GetAllAccounts();
        }
        // LOGIN. 1st checking process
        private KonekAccount GetKonekAccount(string accountNumber, string PIN) // this one does the literal checking if the account matches the inputted account
        {
            var konekAccount = GetData();
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



