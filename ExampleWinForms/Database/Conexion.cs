namespace ExampleWinForms.Database
{
    public static class Conexion
    {
        public static string GetConexion()
        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
            return con;
        }
    }
}