using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Model;

namespace WinFormsContacts.Capa_Acceso_Datos
{
    /// <summary>
    /// Accede a los datos y ejecua consultas
    /// </summary>
    public class DataAccessLayer
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
    }

    
}
