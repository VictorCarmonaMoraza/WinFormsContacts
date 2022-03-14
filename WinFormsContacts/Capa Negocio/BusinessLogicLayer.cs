using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Capa_Acceso_Datos;
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



        //Metodo para acceder a la capa de acceso a datos
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

            }
            //para que no de error de momento
            return contact;
        }
    }
}
