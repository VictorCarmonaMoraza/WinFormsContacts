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
            //1-Creamos un nuevo contacto
            Contact contact = new Contact();

            //2-Cargamos las propiedades del objeto con los valores de la caja de texto
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Phone = phoneIsNull();
            contact.Address = txtAddress.Text;

            //3-LLamaremos a la capa de negocio
            //_businessLogicLayer
            
        }

        #region PRIVATE METHODS
        private string phoneIsNull()
        {
            string valor ="";

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                valor = "Desconocido";
            }
            else
            {
                valor = txtPhone.Text;
            }
            return valor;
        }

        #endregion
    }
}
