using cadastroClientes.Models;
using Microsoft.Data.SqlClient;

namespace cadastroClientes.Services
{
    public class ListaClientesDao
    {

        public static List<Cliente> PartialListaClientes(string connectionString)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {

                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM CrudClientes..Clientes", con))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var cliente = new Cliente
                                {
                                    Id = Convert.ToInt32(rdr["Id"]),
                                    Nome = rdr["Nome"].ToString(),
                                    Email = rdr["Email"].ToString(),
                                    CPF = rdr["CPF"].ToString(),
                                    Telefone = rdr["Telefone"].ToString(),
                                    DatNascimento = Convert.ToDateTime(rdr["DatNascimento"]),
                                    DatCadastro = Convert.ToDateTime(rdr["DatCadastro"])
                                };
                                listaClientes.Add(cliente);
                            }
                        }
                    }
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes: " + ex.Message);
            }
        }


        public static bool DeleteCliente(string cpf, string connectionString)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sqlQuery = "DELETE FROM CrudClientes..Clientes WHERE CPF = @CPF";

                    using (var cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@CPF", cpf);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Cliente _PartialDadosClienteModal(int id, string connectionString)
        {
            var cliente = new Cliente();
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM CrudClientes..Clientes WHERE Id = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                cliente.Id = Convert.ToInt32(rdr["Id"]);
                                cliente.Nome = rdr["Nome"].ToString();
                                cliente.Email = rdr["Email"].ToString();
                                cliente.CPF = rdr["CPF"].ToString();
                                cliente.Telefone = rdr["Telefone"].ToString();
                                cliente.DatNascimento = Convert.ToDateTime(rdr["DatNascimento"]);
                                cliente.DatCadastro = Convert.ToDateTime(rdr["DatCadastro"]);
                            }
                        }
                    }
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes: " + ex.Message);
            }
        }

        public static bool UpdateCliente(Cliente cliente, string connectionString)
        {
            List<string> camposAtualizar = new List<string>();
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string sqlQuery = "UPDATE CrudClientes..Clientes SET Nome = @NOME, Email = @EMAIL, Telefone = @TELEFONE, CPF = @CPF WHERE Id = @ID";

                    using (var cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", cliente.Id);
                        cmd.Parameters.AddWithValue("@NOME", cliente.Nome);
                        cmd.Parameters.AddWithValue("@EMAIL", cliente.Email);
                        cmd.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
                        cmd.Parameters.AddWithValue("@CPF", cliente.CPF);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
