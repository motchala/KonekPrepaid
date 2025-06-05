/*
using KonekCommon;
using System.IO; // Make sure this is included for File operations
using System.Collections.Generic; // Make sure this is included for List

namespace KonekDataServices
{
    public class TextFileDataService : IKonekDataService
    {
        string filePath = "accounts_Txt.txt";
        List<KonekAccount> konAccounts = new List<KonekAccount>();

        public TextFileDataService()
        {
            // The constructor calls GetDataFromFile() when an instance is created
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            //konAccounts.Clear(); // <-- Good practice: Clear existing data before reloading
                                 // Prevents duplicates if GetDataFromFile is called multiple times

            // Handle file not found gracefully
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Warning: Account data file not found at {filePath}. Creating an empty one.");
                // Optionally create the file if it doesn't exist to prevent errors later
                File.WriteAllText(filePath, "");
                return; // No data to load if file doesn't exist
            }

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                // Skip empty lines to prevent errors
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                try
                {
                    var parts = line.Split('|');

                    // Ensure exactly 7 parts are present (PhoneNumber, Pin, Email, AccountName, LoadBalance, TotalRewardPoints, ActivePromo)
                    if (parts.Length != 7) // <--- FIX 1: Changed from 6 to 7
                    {
                        Console.WriteLine($"Error: Invalid line skipped in {filePath}. Expected 7 parts, got {parts.Length}: {line}");
                        continue;
                    }

                    konAccounts.Add(new KonekAccount
                    {
                        PhoneNumber = parts[0].Trim(),
                        Pin = parts[1].Trim(),
                        Email = parts[2].Trim(),
                        AccountName = parts[3].Trim(),
                        LoadBalance = Convert.ToDouble(parts[4]),
                        TotalRewardPoints = Convert.ToDouble(parts[5]),
                        ActivePromo = parts[6].Trim() // <--- FIX 2: Add this line to assign ActivePromo
                    });
                }
                catch (FormatException fex) // More specific error handling for Convert.ToDouble
                {
                    Console.WriteLine($"Error parsing numeric data in line: {line} - {fex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing line: {line} - {ex.Message}");
                }
            }
        }

        private void WriteDataToFile()
        {
            var lines = new string[konAccounts.Count];

            for (int i = 0; i < konAccounts.Count; i++)
            {
                // Correctly writing all 7 fields including ActivePromo
                lines[i] = $"{konAccounts[i].PhoneNumber}|{konAccounts[i].Pin}|{konAccounts[i].Email}|" +
                           $"{konAccounts[i].AccountName}|{konAccounts[i].LoadBalance}|" +
                           $"{konAccounts[i].TotalRewardPoints}|{konAccounts[i].ActivePromo}";
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

        public List<KonekAccount> GetAccounts()
        {
            // Returns the currently loaded accounts.
            // If any updates happened in memory (via InMemoryDataService),
            // ensure InMemoryDataService eventually calls UpdateAccount() here
            // to persist changes to the file.
            return konAccounts;
        }

        public void CreateAccount(KonekAccount KAccount)
        {
            // Correctly writing all 7 fields for new accounts
            var newLine = $"{KAccount.PhoneNumber}|{KAccount.Pin}|{KAccount.Email}|{KAccount.AccountName}|" +
                          $"{KAccount.LoadBalance}|{KAccount.TotalRewardPoints}|{KAccount.ActivePromo}\n";
            File.AppendAllText(filePath, newLine);

            // Also add to the in-memory list so it's available immediately
            konAccounts.Add(KAccount);
        }

        public void UpdateAccount(KonekAccount account)
        {
            int index = FindIndex(account);

            if (index != -1) // Ensure account exists before updating
            {
                // Update all fields that might change.
                // Your current code only updates AccountName and LoadBalance.
                // Make sure to update other fields if they are modified.
                konAccounts[index].Pin = account.Pin; // If PIN can be updated
                konAccounts[index].Email = account.Email;
                konAccounts[index].AccountName = account.AccountName;
                konAccounts[index].LoadBalance = account.LoadBalance;
                konAccounts[index].TotalRewardPoints = account.TotalRewardPoints;
                konAccounts[index].ActivePromo = account.ActivePromo;

                WriteDataToFile();
            }
            else
            {
                Console.WriteLine($"Error: Account with Phone Number {account.PhoneNumber} not found for update.");
            }
        }

        public void RemoveAccount(KonekAccount account)
        {
            int index = -1;
            for (int i = 0; i < konAccounts.Count; i++)
            {
                if (konAccounts[i].PhoneNumber == account.PhoneNumber)
                {
                    index = i;
                    break; // Found, break the loop
                }
            }

            if (index != -1) // Ensure account exists before removing
            {
                konAccounts.RemoveAt(index);
                WriteDataToFile();
            }
            else
            {
                Console.WriteLine($"Error: Account with Phone Number {account.PhoneNumber} not found for removal.");
            }
        }
    }
}
*/



























using KonekCommon;
using System;
using System.Security.Principal;

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

