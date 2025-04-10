namespace KonekCommon
{
    public class KonekAccount

    {

        private string _pin = "1234";
        public string Pin
        {
            get { return _pin; }
            set
            {
                if (value.Length == 4 || value.Length == 6)
                {
                    _pin = value;
                }
            }
        }


        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AccountName { get; set; }

        public double LoadBalance { get; set; }
        
    }
}
