using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CrudADO
{
    internal class ADOEstatus : ICRUDEstatus
    {
        string _cnnString = ConfigurationManager.ConnectionStrings["EstatusConnection"].ConnectionString;
        
        List<Estatus> listEstatus = new List<Estatus>();
        string query;
        SqlCommand comando;

        public ADOEstatus()
        {
        }

        public void Actualizar(Estatus estatus)
        {
            query = $"update EstatusAlumnos set Clave='{estatus.clave}', Nombre='{estatus.nombre}' where id='{estatus.id}'";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
        }

        public int Agregar(Estatus estatus)
        {
            int a;
            query = $"insert into EstatusAlumnos (id, clave, nombre) values({estatus.id},'{estatus.clave}','{estatus.nombre}')";

            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                a = comando.ExecuteNonQuery();
                con.Close();
            }
            return a;
        }

        public List<Estatus> Consultar()
        {
            query = $"select id, clave, nombre from EstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    listEstatus.Add(
                        new Estatus()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            clave = reader["clave"].ToString(),
                            nombre = reader["nombre"].ToString(),
                        }
                    );
                }
                con.Close();
            }

            return listEstatus;
        }

        public Estatus Consultar(int id)
        {
            Estatus obj = new Estatus();            

            query = $"consultarEstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idRegistro", id);

                con.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    obj.id = Convert.ToInt32(reader["id"]);
                    obj.clave = reader["clave"].ToString();
                    obj.nombre = reader["nombre"].ToString();                    
                }
                con.Close();
            }
            return obj;
        }

        public void Eliminar(int id)
        {
            query = $"sp_EliminarEstatusAlu";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idEstatus", id);

                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }
            Console.WriteLine($"\nSe eliminó el objeto con id: {id}");
        }
    }
}
