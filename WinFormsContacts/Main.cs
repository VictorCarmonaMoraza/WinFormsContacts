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

        //Cuandop se haga click en la celda Edit
        private void gridContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Obtengo la celda que he clickeado
            DataGridViewLinkCell cell =(DataGridViewLinkCell) gridContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value.ToString() == "Edit")
            {
                ContactsDetails contactsDetails = new ContactsDetails();
                contactsDetails.LoadContact(new Contact
                {
                    Id = int.Parse((gridContacts.Rows[e.RowIndex].Cells[0]).Value.ToString()),
                    FirstName = (gridContacts.Rows[e.RowIndex].Cells[1]).Value.ToString(),
                    LastName = (gridContacts.Rows[e.RowIndex].Cells[2]).Value.ToString(),
                    Phone = (gridContacts.Rows[e.RowIndex].Cells[3]).Value.ToString(),
                    Address = (gridContacts.Rows[e.RowIndex].Cells[4]).Value.ToString(),
                });
                contactsDetails.ShowDialog(this);
            }else if (cell.Value.ToString() == "Delete")
            {
                int Id = int.Parse((gridContacts.Rows[e.RowIndex].Cells[0]).Value.ToString());
                DeleteContact(Id);
                PopulateContacts();
            }
        }

        private void DeleteContact(int id)
        {
            _businessLgicLayer.DeleteContact(id);
        }
    }
}
