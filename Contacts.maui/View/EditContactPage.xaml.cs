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
            contactCtl.Name = contact?.Name;
            contactCtl.Email = contact?.Email;
            contactCtl.Phone = contact?.Phone;
            contactCtl.Address = contact?.Address;
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void btnSubmit_Clicked(object sender, EventArgs e)
    {

        Contact Contact = new Contact{ 
            ContactId = contact?.ContactId, 
            Name = contactCtl.Name, 
            Email = contactCtl.Email, 
            Phone = contactCtl.Phone,
            Address = contactCtl.Address,
        };
        ContactRepository.UpdateContactById(contact?.ContactId, Contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactCtl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}