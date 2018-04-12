namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     This is a class that is used to store connection strings to the application settings
    /// </summary>
    public class SavedConnection
    {
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Instance { get; set; }
        public int Timeout { get; set; }

        public override string ToString()
        {
            return NickName;
        }
    }
}