using KonekCommon;

namespace KonekDataService
{
    public class AccountDataService
    {
        List<KonekAccount> accountList = new List<KonekAccount>();
        double totalRewardPts;
        public AccountDataService() 
        {
            DummyAccounts();
        }

        public void DummyAccounts()
        {
            KonekAccount account1 = new KonekAccount();
            account1.PhoneNumber = "09662668443";
            account1.Pin = "1234";
            account1.Email = "iamfrederickr@gmail.com";
            account1.AccountName = "Frederick Rosales";
            account1.LoadBalance = 70;
            account1.TotalRewardPoints = 1.25;
            accountList.Add(account1);

            KonekAccount account2 = new KonekAccount();
            account2.PhoneNumber = "09073738134";
            account2.Pin = "0101";
            account2.Email = "tepot@gmail.com";
            account2.AccountName = "Kuya Tepot";
            account2.LoadBalance = 450;
            account2.TotalRewardPoints = 0.75;
            accountList.Add(account2);

            KonekAccount account3 = new KonekAccount();
            account3.PhoneNumber = "09163932930";
            account3.Pin = "1111";
            account3.Email = "iseng@gmail.com";
            account3.AccountName = "Manang Iseng";
            account3.LoadBalance = 15;
            account3.TotalRewardPoints = 2.15;
            accountList.Add(account3);
        }


        public bool ValidateKonekAccount(string accountNumber, string pin)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber && account.Pin == pin)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetAccountNameByPhoneNumber(string accountNumber)
        {
            foreach(var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    return account.AccountName;
                }
            }
            return "No Balance !";
        }

        public string GetEmailByPhoneNumber(string accountNumber)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    return account.Email;
                }
            }
            return "No Email";
        }


        public double GetAccountBalanceByPhoneNumber(string accountNumber) 
        { 
            foreach(var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    return account.LoadBalance;
                }
            }
            return 0;
        }


        public void UpdateAccountBalance(string accountNumber, double amount)
        {
            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].PhoneNumber == accountNumber)
                {
                    accountList[i].LoadBalance = amount;
                }
            }
        }


        public void UpdateAccountPromo(string accountNumber, string promo)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    account.ActivePromo = promo;
                }
            }
        }

        public string GetAccountPromo(string accountNumber)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    return account.ActivePromo;
                }
            }
            return "No active promo";
        }


        public double GetRewardPoints(string accountNumber)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    return account.TotalRewardPoints;
                }
            }
            return 0.0;
        }

        public void AddRewardPointsLoad(string accountNumber, double points)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    account.TotalRewardPoints += points;
                }
            }
        }
         public void AddRewardPointsPromo(string accountNumber, double points)
        {
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    account.TotalRewardPoints += points;
                }
            }
        }

    } 
}
