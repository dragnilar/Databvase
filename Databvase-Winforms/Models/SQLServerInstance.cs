namespace Databvase_Winforms.Models
{
    /// <summary>
    ///     A class that represents a SQL Server instance returned by SmoApplication.EnumAvailableSqlServers(false);
    ///     This class should be used only for displaying server instances in cases where SmoApplication.EnumAvailableServers is used.
    ///     If you need to work with an actual instance, use the Server class instead.
    /// </summary>
    public class SQLServerInstance
    {
        public string ServerName { get; set; }
        public string InstanceName { get; set; }
        public string Name { get; set; }
        public bool IsClustered { get; set; }
        public string Version { get; set; }
        public bool Local { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}