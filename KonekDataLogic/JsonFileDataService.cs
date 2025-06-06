using System.Text.Json;
using KonekCommon;

namespace KonekDataServices
{
    public class JsonFileDataService : IKonekDataService
    {
        static List<KonekAccount> konekAccounts = new List<KonekAccount>();
        static string jsonFilePath = "accounts_Json.json";

        public JsonFileDataService()
        {
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(jsonFilePath);

            konekAccounts = JsonSerializer.Deserialize<List<KonekAccount>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(konekAccounts, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(jsonFilePath, jsonString);
        }

        private int FindAccountIndex(string number, string pin)
        {
            var accounts = GetAccounts();

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].PhoneNumber == number && accounts[i].Pin == pin)
                {
                    return i;
                }
            }

            return -1;
        }

        public void CreateAccount(KonekAccount bankAccount)
        {
            konekAccounts.Add(bankAccount);
            WriteJsonDataToFile();
        }

        public List<KonekAccount> GetAccounts()
        {
            return konekAccounts;
        }

        
        public void RemoveAccount(KonekAccount account)
        {
            var index = FindAccountIndex(account.PhoneNumber, account.Pin);
            if (index == -1) return;

            konekAccounts.RemoveAt(index);
            WriteJsonDataToFile();
        }
        

        public void UpdateAccount(KonekAccount bankAccount)
        {
            var index = FindAccountIndex(bankAccount.PhoneNumber, bankAccount.Pin);

            konekAccounts[index].Pin = bankAccount.Pin;
            konekAccounts[index].PhoneNumber = bankAccount.PhoneNumber;
            konekAccounts[index].Email = bankAccount.Email;
            konekAccounts[index].AccountName = bankAccount.AccountName;
            konekAccounts[index].LoadBalance = bankAccount.LoadBalance;
            konekAccounts[index].TotalRewardPoints = bankAccount.TotalRewardPoints;

            WriteJsonDataToFile();

        }
    }
}
