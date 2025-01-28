namespace Telpis_221_UP_1.MVC.View.Pages;
using Telpis_221_UP_1.MVC.Model;
using Proj.MVC.Controller;

public partial class AuthPage : ContentPage
{
    Controller controller = new Controller();
	public AuthPage()
	{
		InitializeComponent();
	}

    //private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {
    //    Navigation.PushAsync(new RegPage());
    //}

    private void Button_Clicked(object sender, EventArgs e) {
        if(
            string.IsNullOrEmpty(entLogin.Text) ||
            string.IsNullOrEmpty(entPassword.Text)
            ) {
            DisplayAlert("", "Необходимо заполнить оба поля", "Ок");
            entPassword.Text = "";
            return;
        }

        User user = controller.GetAuth(entLogin.Text, entPassword.Text);
        if(user != null) {
            Navigation.PushAsync(new MainPage(user));
        }
        else {
            DisplayAlert("", "Пользователя с таким логином и паролем не существует", "Ок");
            entPassword.Text = "";
            return;
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e) {
        Navigation.PushAsync(new RegPage());
    }
}