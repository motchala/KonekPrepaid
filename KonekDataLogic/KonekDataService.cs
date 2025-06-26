using KonekCommon;

namespace KonekDataServices
{
    public class KonekDataService
    {
        private IKonekDataService iDataService;

        public KonekDataService()
        {
            // iDataService = new InMemoryDataService();
            // iDataService = new TextFileDataService();
            // iDataService = new JsonFileDataService();
            iDataService = new DBDataService();
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
        public string GetAccountNumberByPhoneNumber(string accountNumber)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    return accounts[i].PhoneNumber;
                }
            }
            return "No Phone Number";
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

        // takes the
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




        // For REWARD PROMO CHOICES
        public void UpdateAccountRewardPromo(string accountNumber, string reward)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    accounts[i].ActivePromo = reward;
                    iDataService.UpdateAccount(accounts[i]);
                    break;
                }
            }
        }
        public void UpdateAccountRewardPts(string accountNumber, double amount)
        {
            var accounts = iDataService.GetAccounts();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == accountNumber)
                {
                    accounts[i].TotalRewardPoints = amount;
                    iDataService.UpdateAccount(accounts[i]);
                    break;
                }
            }
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

        public string GetAccountRewardPromo(string accountNumber)
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



        // for adding lang ng reward points after a transaction
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
