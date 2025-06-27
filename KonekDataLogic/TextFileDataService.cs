using KonekCommon;

namespace KonekDataServices
{
    public class TextFileDataService : IKonekDataService
    {
        List<KonekAccount> konAccounts = new List<KonekAccount>();
        string filePath = "accounts_Txt.txt";

        public TextFileDataService()
        {
            GetDataFromFile();  
        }


        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                konAccounts.Add(new KonekAccount
                {
                    PhoneNumber = parts[0].Trim(),
                    Pin = parts[1].Trim(),
                    Email = parts[2].Trim(),
                    AccountName = parts[3].Trim(),
                    LoadBalance = Convert.ToDouble(parts[4]),
                    TotalRewardPoints = Convert.ToDouble(parts[5]),
                    //ActivePromo = parts[6].Trim()
                });
            }
        }

        private void WriteDataToFile()
        {
            var lines = new string[konAccounts.Count];

            for (int i = 0; i < konAccounts.Count; i++)
            {
                lines[i] = $"{konAccounts[i].PhoneNumber}|{konAccounts[i].Pin}|{konAccounts[i].Email}|{konAccounts[i].AccountName}|{konAccounts[i].LoadBalance}|{konAccounts[i].TotalRewardPoints}";
            }

            File.WriteAllLines(filePath, lines);
        }
        
        public int FindIndex(KonekAccount account)
        {
            for (int i = 0; i < konAccounts.Count; i++)
            {
                if (konAccounts[i].PhoneNumber == account.PhoneNumber)
                {
                    return i;
                }
            }

            return -1;
        }

        

        public void CreateAccount(KonekAccount KAccount)
        {
            var newLine = $"{KAccount.PhoneNumber}|{KAccount.Pin}|{KAccount.Email}|{KAccount.AccountName}|{KAccount.LoadBalance}|{KAccount.TotalRewardPoints}";
            
            File.AppendAllText(filePath, newLine);
        }

        public List<KonekAccount> GetAccounts()
        {
            return konAccounts;
        }

        public void RemoveAccount(KonekAccount account)
        {
            int index = -1;
            for (int i = 0; i < konAccounts.Count; i++)
            {
                if (konAccounts[i].PhoneNumber == account.PhoneNumber)
                {
                    index = i;
                }
            }

            konAccounts.RemoveAt(index);

            WriteDataToFile();
        }

        public void UpdateAccount(KonekAccount account)
        {
            int index = FindIndex(account);

            konAccounts[index].AccountName = account.AccountName;
            konAccounts[index].LoadBalance = account.LoadBalance;

            WriteDataToFile();

        }
    }
}