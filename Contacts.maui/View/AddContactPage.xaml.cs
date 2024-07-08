using Contacts.maui.Models;

namespace Contacts.maui.View;

public partial class AddContactPage : ContentPage
{
    public AddContactPage() => InitializeComponent();

    private void contactCtl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact 
        {
            Name = contactCtl.Name,
            Email = contactCtl.Email,
            Phone = contactCtl.Phone,
            Address = contactCtl.Address,
        });

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtl_OnError(object sender, string e)
    {
        DisplayAlert("Error: ", e, "Ok");
    }
}