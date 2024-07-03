using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = [
            new Contact{ ContactId = 1, Name="john doe", Email="johnd@gmail.com" },
            new Contact{ ContactId = 2, Name="joe cee", Email="jc@gmail.com" },
            new Contact{ ContactId = 3, Name="alex g", Email="alexg@gmail.com" },
            new Contact{ ContactId = 4, Name="james f", Email="jf@gmail.com" },
        ];

        public static List<Contact> GetContacts() { return _contacts; }

        public static Contact? GetContactById(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }
    }

}
