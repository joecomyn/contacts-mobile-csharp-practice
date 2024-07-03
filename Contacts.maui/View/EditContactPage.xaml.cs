namespace Contacts.maui.View;

public partial class EditContactPage : ContentPage
{
    public EditContactPage() => InitializeComponent();

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}