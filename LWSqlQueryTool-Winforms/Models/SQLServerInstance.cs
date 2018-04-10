namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     A class that represents a SQL Server instance returned by SmoApplication.EnumAvailableSqlServers(false);
    /// </summary>
    public class SQLServerInstance
    {
        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string Name { get; set; }
        public string IsClustered { get; set; }
        public string Version { get; set; }
        public string Local { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}