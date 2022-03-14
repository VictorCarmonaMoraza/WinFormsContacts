using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Interfaces;
using WinFormsContacts.Model;

namespace WinFormsContacts.Capa_Acceso_Datos
{
    /// <summary>
    /// Accede a los datos y ejecua consultas
    /// </summary>
    public class DataAccessLayer: IAccesoDatos
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WinFormsContacts;Data Source=VICTORPC");



        public void InsertContact(Contact contact)
        {
            try
            {
                //Abrimos conexion
                conn.Open();

                //Escribimos la query
                string query = @"INSERT INTO Contacts (FirstName,LastName,Phone,Address) VALUES
                                (@FirstName, @LastName, @Phone, @Address)";

                //Parametros

                SqlParameter firstName = new SqlParameter("@FirstName", contact.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", contact.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter address = new SqlParameter("@Address", contact.Address);

                //Consulta a ejecutar
                SqlCommand command = new SqlCommand(query, conn);

                //
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                //Ejecutmos la query
                command.ExecuteNonQuery();

            } 
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Contact> GetContacts()
        {

            List<Contact> contacts = new List<Contact>();
            try
            {
                //Abrimos conexion
                conn.Open();

                //Escribimos la query
                string query = @"SELECT Id, FirstName, LastName, Phone, Address FROM Contacts";

                //Consulta a ejecutar
                SqlCommand command = new SqlCommand(query, conn);

                //
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        FirstName = reader["Firstname"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
                reader.Close();

                //Ejecutmos la query
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            //Pase lo que pase retorno la lista de contactos
            return contacts;
        }
    }

    
}
