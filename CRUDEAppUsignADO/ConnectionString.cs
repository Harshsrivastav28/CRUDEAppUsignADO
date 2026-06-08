namespace CRUDEAppUsignADO
{
    public static class ConnectionString
    {
        private static string cs = "Server=localhost;Database=CrudADOdb;Trusted_Connection=True";
        public static string dbcs { get => cs; }
      
}
}
