using Contacts.maui.Models;
using Contact = Contacts.maui.Models.Contact;

namespace Contacts.maui.View;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact? contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            //lblName.Text = contact?.Name;
            namePlaceHolder.Text = contact?.Name;
            emailPlaceHolder.Text = contact?.Email;
            phoneNumPlaceHolder.Text = contact?.Phone;
            addressPlaceHolder.Text = contact?.Address;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void btnSubmit_Clicked(object sender, EventArgs e)
    {
        Contact newContact = new Contact{ 
            ContactId = contact?.ContactId, 
            Name = namePlaceHolder.Text, 
            Email = emailPlaceHolder.Text, 
            Phone = phoneNumPlaceHolder.Text,
            Address = addressPlaceHolder.Text,
        };
        ContactRepository.UpdateContactById(contact?.ContactId, newContact);
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}