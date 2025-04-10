using KonekCommon;

namespace KonekDataService
{
    public class AccountDataService
    {
        List<KonekAccount> accountList = new List<KonekAccount>();

        public AccountDataService() 
        {
            DummyAccounts();
        }

        private void DummyAccounts()
        {
            KonekAccount account1 = new KonekAccount();
            account1.PhoneNumber = "09662668443";
            account1.Pin = "1234";
            account1.Email = "iamfrederickr@gmail.com";
            account1.AccountName = "Frederick";
            account1.LoadBalance = 70;
            accountList.Add(account1);

            KonekAccount account2 = new KonekAccount();
            account2.PhoneNumber = "09073738134";
            account2.Pin = "0101";
            account2.Email = "tepot@gmail.com";
            account2.AccountName = "Kuya Tepot";
            account2.LoadBalance = 450;
            accountList.Add(account2);

            KonekAccount account3 = new KonekAccount();
            account3.PhoneNumber = "09163932930";
            account3.Pin = "1111";
            account3.Email = "iseng@gmail.com";
            account3.AccountName = "Manang Iseng";
            account3.LoadBalance = 15;
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


        public double GetAccountBalance(string accountNumber) 
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















    } 
}
