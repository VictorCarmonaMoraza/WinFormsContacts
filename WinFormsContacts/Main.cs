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
using WinFormsContacts.Interfaces;
using WinFormsContacts.Model;

namespace WinFormsContacts
{
    public partial class Main : Form
    {
        private BusinessLogicLayer _businessLgicLayer;

        public Main()
        {
            InitializeComponent();
            _businessLgicLayer = new BusinessLogicLayer();
        }

        #region EVENTS
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }
        #endregion



        #region PRIVATE METHODS

        private void OpenContactDetailsDialog()
        {
            //Creamos el objeto
            ContactsDetails contactsDetails = new ContactsDetails();

            contactsDetails.ShowDialog(this);
        }

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        /// <summary>
        /// Funcion para cargar todos los contactos en la grilla
        /// </summary>
        public void PopulateContacts()
        {
            List<Contact> contacts = _businessLgicLayer.listaContactos();
            //Añadimos a la grilla la fuente de datos
            gridContacts.DataSource = contacts;
        }
    }
}
