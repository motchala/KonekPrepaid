using KonekCommon;

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
