using Proj.MVC.Controller;
using Telpis_221_UP_1.MVC.Model;

namespace Telpis_221_UP_1.MVC.View.Pages;

public partial class RegPage : ContentPage
{

    Controller controller = new Controller();
	public RegPage()
	{
		InitializeComponent();
	}

    private void Reg_Clicked(object sender, EventArgs e) {
        Dictionary<string, string> Data = new Dictionary<string, string>();

        if(
            string.IsNullOrEmpty(entSurname.Text) ||
            string.IsNullOrEmpty(entName.Text) ||
            pcrGender.SelectedIndex == -1 ||
            string.IsNullOrEmpty(entLogin.Text) ||
            string.IsNullOrEmpty(entPassword.Text)
            ) {
            DisplayAlert("", "Необходимо заполнить все поля со звёздочкой", "Ок");
            return;
        }

        Data.Add("UserSurname", entSurname.Text);
        Data.Add("UserName", entName.Text);
        Data.Add("IsMale", (string)pcrGender.SelectedItem); // Посмотреть что там в отладке
        Data.Add("UserLogin", entLogin.Text);
        Data.Add("UserPassword", entPassword.Text);

        if(!string.IsNullOrEmpty(entSecondName.Text)) Data.Add("UserSecondName", entSecondName.Text);
        if(!string.IsNullOrEmpty(entEmail.Text)) Data.Add("UserEmail", entEmail.Text);
        if(!string.IsNullOrEmpty(entPhone.Text)) Data.Add("UserPhone", entPhone.Text);
        if(pcrIsAuthor.SelectedIndex != -1) Data.Add("Author", (string)pcrIsAuthor.SelectedItem);

        User NewUser = controller.RegNewUser(Data);
        Navigation.PushAsync(new MainPage(NewUser));
    }        

    private void Back_Clicked(object sender, EventArgs e) {
        Navigation.PushAsync(new AuthPage());
    }
}