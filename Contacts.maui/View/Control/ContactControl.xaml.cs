using Kotlin.IO;

namespace Contacts.maui.View.Control;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContactControl()
	{
		InitializeComponent();
	}

	public string Name
	{

		get
		{ 
			return namePlaceHolder.Text;
		}
		set 
		{
			namePlaceHolder.Text = value;
		}

	}

    public string Email
    {

        get
        {
            return emailPlaceHolder.Text;
        }
        set
        {
            emailPlaceHolder.Text = value;
        }

    }

    public string Phone
    {

        get
        {
            return phoneNumPlaceHolder.Text;
        }
        set
        {
            phoneNumPlaceHolder.Text = value;
        }

    }

    public string Address
    {

        get
        {
            return addressPlaceHolder.Text;
        }
        set
        {
            addressPlaceHolder.Text = value;
        }

    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is Required");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;
        }
        OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}