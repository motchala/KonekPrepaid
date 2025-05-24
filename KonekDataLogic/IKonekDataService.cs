using KonekCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonekDataServices
{
    public interface IKonekDataService
    {
        public List<KonekAccount> GetAccounts();
        public void CreateAccount(KonekAccount konekAccount);
        public void UpdateAccount(KonekAccount konekAccount);
        public void RemoveAccount(KonekAccount konekAccount);
    } 
}
