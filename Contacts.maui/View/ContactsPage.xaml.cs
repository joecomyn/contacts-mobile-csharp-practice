using Contacts.maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.maui.Models.Contact;
namespace Contacts.maui.View;

public partial class ContactsPage : ContentPage
{
    public ContactsPage() {

        InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        RenderContacts();
    }
    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void menuDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        if (menuItem != null)
        {
            var contact = menuItem.CommandParameter as Contact;
            ContactRepository.DeleteContact(contact.ContactId);
        }

        RenderContacts();
    }

    private void RenderContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        listContacts.ItemsSource = contacts;
    }
}