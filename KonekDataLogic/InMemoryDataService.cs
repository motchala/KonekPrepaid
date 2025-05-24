using KonekCommon;

namespace KonekDataServices
{
    public class InMemoryDataService : IKonekDataService
    {
        List<KonekAccount> accountList = new List<KonekAccount>();
        public InMemoryDataService()
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



        public void CreateAccount(KonekAccount konekAccount)
        {
            accountList.Add(konekAccount);

        }

        public List<KonekAccount> GetAccounts()
        {
            return accountList;
        }

        public void RemoveAccount(KonekAccount konekAccount)
        {
            accountList.RemoveAll(a => a.PhoneNumber == konekAccount.PhoneNumber); // REMOVE MO ITO MAMAYA PLEASE
        }

        public void UpdateAccount(KonekAccount konekAccount)
        {
            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].PhoneNumber == konekAccount.PhoneNumber)
                {
                    accountList[i].LoadBalance = konekAccount.LoadBalance;
                }
            }
        }
    } 
}
