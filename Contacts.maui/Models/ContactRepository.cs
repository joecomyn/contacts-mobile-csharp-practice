using Microsoft.Maui.ApplicationModel.Communication;
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
            new Contact{ ContactId = 1, Name="john doe", Email="johnd@gmail.com", Phone="072139816", Address="123 Goop Ave" },
            new Contact{ ContactId = 2, Name="joe cee", Email="jc@gmail.com", Phone="0777651239", Address="123 Goop Ave" },
            new Contact{ ContactId = 3, Name="alex g", Email="alexg@gmail.com", Phone="0712312319", Address="123 Goop Ave" },
            new Contact{ ContactId = 4, Name="james f", Email="jf@gmail.com", Phone="0777657849", Address="123 Goop Ave" },
        ];

        public static List<Contact> GetContacts() { return _contacts; }

        public static Contact? GetContactById(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }

        public static void UpdateContactById(int? contactId, Contact contact)
        {
            if(contactId == null) throw new ArgumentNullException(nameof(contact));

            int index = _contacts.FindIndex(x => (x.ContactId == contactId));

            _contacts[index] = contact;
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId+1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int? contactId)
        {
            if(contactId == null) return;
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if(contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string Filter)
        {

            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(Filter, StringComparison.OrdinalIgnoreCase))?.ToList();

            if(contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(Filter, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(Filter, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(Filter, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            return contacts;
        }
    }

}
