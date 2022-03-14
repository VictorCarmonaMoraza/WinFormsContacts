using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Model;

namespace WinFormsContacts.Interfaces
{
    public interface IAccesoDatos
    {
        void InsertContact(Contact contact);

        List<Contact> GetContacts();
    }
}
