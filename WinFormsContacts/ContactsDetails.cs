using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsContacts.Capa_Negocio;
using WinFormsContacts.Model;

namespace WinFormsContacts
{
    public partial class ContactsDetails : Form
    {
        private BusinessLogicLayer _businessLogicLayer;

        public ContactsDetails()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Como estamos en esta clase la podemos cerrar desde aqui
            this.Close();
        }

        /// <summary>
        /// Cuando hacemos click en el boton Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        #region PRIVATE METHODS

        /// <summary>
        /// Comprobamos si el telefono es nulo
        /// </summary>
        /// <returns></returns>
        private string phoneIsNull()
        {
            string phone ="";

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                phone = "Desconocido";
            }
            else
            {
                phone = txtPhone.Text;
            }
            return phone;
        }

        /// <summary>
        /// Comprobamos si la direccion es esta vacia
        /// </summary>
        /// <returns></returns>
        private string addressIsNull()
        {
            string address = "";

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                address = "Desconocido";
            }
            else
            {
                address = txtPhone.Text;
            }
            return address;
        }

        /// <summary>
        /// Metodo para guardar un contacto
        /// </summary>
        private void SaveContact()
        {
            //1-Creamos un nuevo contacto
            Contact contact = new Contact();

            //2-Cargamos las propiedades del objeto con los valores de la caja de texto
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Phone = phoneIsNull();
            contact.Address = addressIsNull();

            //3-LLamaremos a la capa de negocio
            _businessLogicLayer.SaveContact(contact);
        }

        #endregion
    }
}
