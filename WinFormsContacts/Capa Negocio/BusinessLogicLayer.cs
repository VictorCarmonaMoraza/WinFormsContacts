using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Capa_Acceso_Datos;
using WinFormsContacts.Interfaces;
using WinFormsContacts.Model;

namespace WinFormsContacts.Capa_Negocio
{
    public class BusinessLogicLayer
    {
       

        private DataAccessLayer _dataAccessLayer;


        public BusinessLogicLayer()
        {
            
            _dataAccessLayer = new DataAccessLayer();
        }



        /// <summary>
        /// Metodo para guardar un contacto
        /// </summary>
        /// <param name="contact">modelo de contacto</param>
        /// <returns></returns>
        public Contact SaveContact(Contact contact)
        {
            //El contacto es nuevo
            if(contact.Id == 0)
            {
                //Crearemos un metodo para insertar yq eu llamaremos
                _dataAccessLayer.InsertContact(contact);
               
            }
            //Es un Update
            else
            {
                _dataAccessLayer.UpdateContact(contact);
            }
            //para que no de error de momento
            return contact;
        }

        public List<Contact> listaContactos()
        {
            return  _dataAccessLayer.GetContacts();
        }

        public void DeleteContact(int id)
        {
            _dataAccessLayer.DeleteContact(id);
        }
    }
}
