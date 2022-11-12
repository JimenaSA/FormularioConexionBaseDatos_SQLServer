using System;
using System.Data;
using System.Data.SqlClient;
using ExampleWinForms.Database;
using ExampleWinForms.Repository.IRepository;

namespace ExampleWinForms.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public bool GuardaCategoria(string nombre)
        {
            try
            {
                var connectionString = Conexion.GetConexion();
                var result = false;
                using (var con = new SqlConnection(connectionString))
                {
                    var query = @"Insert into dbo.Categoria (Nombre, FechaCreacion) values (@nombre, GETDATE());";
                    using (var command = new SqlCommand(query, con))
                    {
                        command.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                
                        con.Open();
                        result = (command.ExecuteNonQuery() > 0);
                        con.Close();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}