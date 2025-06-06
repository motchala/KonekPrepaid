using KonekCommon;

namespace KonekDataServices
{
    public class KonekDataService
    {
        private IKonekDataService iDataService;

        public KonekDataService()
        {
             iDataService = new InMemoryDataService();
            // iDataService = new TextFileDataService();
            // iDataService = new JsonFileDataService();
            // iDataService = new DBDataService();
        }

        public List<KonekAccount> GetAllAccounts()
        {
            return iDataService.GetAccounts();
        }

        public void AddAccount(KonekAccount konekAccount)
        {
            iDataService.CreateAccount(konekAccount);
        }

        public void UpdateAccount(KonekAccount konekAccount)
        {
            iDataService.UpdateAccount(konekAccount);
        }

        public void RemoveAccount(KonekAccount konekAccount)
        {
            iDataService.RemoveAccount(konekAccount);
        }

        public bool ValidateKonekAccount(string accountNumber, string pin)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber && accounts[i].Pin == pin)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetAccountNameByPhoneNumber(string accountNumber)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    return accounts[i].AccountName;
                }
            }
            return "No Balance !";
        }

        public string GetEmailByPhoneNumber(string accountNumber)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    return accounts[i].Email;
                }
            }
            return "No Email";
        }

        public double GetAccountBalanceByPhoneNumber(string accountNumber)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    return accounts[i].LoadBalance;
                }
            }
            return 0;
        }

        public void UpdateAccountBalance(string accountNumber, double amount)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    accounts[i].LoadBalance = amount;
                    iDataService.UpdateAccount(accounts[i]);
                    break;
                }
            }
        }

        public void UpdateAccountPromo(string accountNumber, string promo)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    accounts[i].ActivePromo = promo;
                    iDataService.UpdateAccount(accounts[i]);
                    break;
                }
            }
        }

        public string GetAccountPromo(string accountNumber)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    return accounts[i].ActivePromo;
                }
            }
            return "No active promo";
        }

        public double GetRewardPoints(string accountNumber)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    return accounts[i].TotalRewardPoints;
                }
            }
            return 0;
        }

        public void AddRewardPointsLoad(string accountNumber, double points)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    accounts[i].TotalRewardPoints += points;
                    iDataService.UpdateAccount(accounts[i]);
                    break;
                }
            }
        }

        public void AddRewardPointsPromo(string accountNumber, double points)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    accounts[i].TotalRewardPoints += points;
                    iDataService.UpdateAccount(accounts[i]);
                    break;
                }
            }
        }
    }
}








// trial and error na code haha pagaaralan ko pa like ano mga mali ko rito

/* 
using KonekCommon;

namespace KonekDataServices
{
    public class KonekDataService
    {
        private TextFileDataService dataService;

        public KonekDataService()
        {
            dataService = new TextFileDataService();
        }

        public List<KonekAccount> GetAllAccounts()
        {
            return dataService.GetAccounts();
        }

        public void AddAccount(KonekAccount konekAccount)
        {
            dataService.CreateAccount(konekAccount);
        }

        public void UpdateAccount(KonekAccount konekAccount)
        {
            dataService.UpdateAccount(konekAccount);
        }

        public void RemoveAccount(KonekAccount konekAccount)
        {
            dataService.RemoveAccount(konekAccount);
        }

        public bool ValidateKonekAccount(string accountNumber, string pin)
        {
            var accountList = dataService.GetAccounts();
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
            var accountList = dataService.GetAccounts();
            foreach (var account in accountList)
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
            var accountList = dataService.GetAccounts();
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
            var accountList = dataService.GetAccounts();
            foreach (var account in accountList)
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
            var accountList = dataService.GetAccounts();
            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].PhoneNumber == accountNumber)
                {
                    accountList[i].LoadBalance = amount;
                    dataService.UpdateAccount(accountList[i]);
                }
            }
        }

        public void UpdateAccountPromo(string accountNumber, string promo)
        {
            var accountList = dataService.GetAccounts();
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    account.ActivePromo = promo;
                    dataService.UpdateAccount(account);
                }
            }
        }

        public string GetAccountPromo(string accountNumber)
        {
            var accountList = dataService.GetAccounts();
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
            var accountList = dataService.GetAccounts();
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
            var accountList = dataService.GetAccounts();
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    account.TotalRewardPoints += points;
                    dataService.UpdateAccount(account);
                }
            }
        }

        public void AddRewardPointsPromo(string accountNumber, double points)
        {
            var accountList = dataService.GetAccounts();
            foreach (var account in accountList)
            {
                if (account.PhoneNumber == accountNumber)
                {
                    account.TotalRewardPoints += points;
                    dataService.UpdateAccount(account);
                }
            }
        }
    }
}
*/


/*
using KonekCommon;

namespace KonekDataServices
{
    public class KonekDataService
    {
        IKonekDataService ikonekDataService;

        public KonekDataService()
        {
            ikonekDataService = new TextFileDataService();
            //ikonekDataService = new InMemoryDataService();
            //ikonekDataService = new JsonFileDataService();

        }
        public List<KonekAccount> GetAllAccounts()
        {
            return ikonekDataService.GetAccounts();
        }

        public void AddAccount(KonekAccount konekAccount)
        {
            ikonekDataService.CreateAccount(konekAccount);
        }

        public void UpdateAccount(KonekAccount konekAccount)
        {
            ikonekDataService.UpdateAccount(konekAccount);
        }

        public void RemoveAccount(KonekAccount konekAccount)
        {
            ikonekDataService.RemoveAccount(konekAccount);
        }




        public bool ValidateKonekAccount(string accountNumber, string pin) // remove mo 'to mamaya please
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
            foreach (var account in accountList)
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
            foreach (var account in accountList)
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

*/