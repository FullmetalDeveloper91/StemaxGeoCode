namespace StemaxGeoCode.Repository
{
    public class DbConnectionStringBuilder
    {
        private string server = "127.0.0.1";
        private string port = "5432";
        private string user = "root";
        private string password = "root";
        private string database = "mgs";

        public DbConnectionStringBuilder SetServer(string server) { this.server = server; return this; }
        public DbConnectionStringBuilder SetPort(string port) { this.port = port; return this; }
        public DbConnectionStringBuilder SetUser(string user) { this.user = user; return this; }
        public DbConnectionStringBuilder SetPassword(string password) { this.password = password; return this; }
        public DbConnectionStringBuilder SetDatabaseName(string database) { this.database = database; return this; }

        public string Build()
        {
            return $"Server={server};Port={port};User Id={user};Password={password};Database={database}";
        }
    }
}
