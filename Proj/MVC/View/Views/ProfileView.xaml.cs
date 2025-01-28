using Telpis_221_UP_1.MVC.Model;
using Proj.MVC.Controller;
using Telpis_221_UP_1.MVC.View.Pages;

namespace Proj.MVC.View.Views;

public partial class ProfileView : ContentView
{
    User user;
    bool IsAuthor;
    Proj.MVC.Controller.Controller controller = new Proj.MVC.Controller.Controller();
    

	public ProfileView(User user)
	{
		InitializeComponent();
        this.user = user;

        if(user.Author != null) {
            lblBIO.IsVisible = true;
            entBIO.IsVisible = true;  
        }

        entSurname.Text = user.UserSurname;
        entName.Text = user.UserName;   
        entSecondName.Text = user.UserSecondName;
        entEmail.Text = user.UserEmail;
        pcrIsMale.SelectedIndex = user.IsMale ? 1 : 0;
        dpBirthday.Date = (DateTime)user.UserBirthday;
        entPhone.Text = user.UserPhone;
        if(user.Author != null) entBIO.Text = user.Author.Bio;

    }

    private void Change_Clicked(object sender, EventArgs e) {
        entSurname.IsEnabled = true;
        entName.IsEnabled = true;
        entSecondName.IsEnabled = true;
        entEmail.IsEnabled = true;
        entPhone.IsEnabled = true;
        pcrIsMale.IsEnabled = true;
        dpBirthday.IsEnabled = true;
        if(IsAuthor) entBIO.IsEnabled = true;

        btnChange.IsEnabled = false;
        btnSave.IsEnabled = true;
    }

    private void Save_Clicked(object sender, EventArgs e) {
        Dictionary<string, string> Data = new Dictionary<string, string>();
        if(
            string.IsNullOrEmpty(entSurname.Text) ||
            string.IsNullOrEmpty(entName.Text) ||
            pcrIsMale.SelectedIndex == -1 
            ) {
            //придумать обработку
            return;
        }

        Data.Add("UserSurname", entSurname.Text);
        Data.Add("UserName", entName.Text);
        Data.Add("IsMale", (string)pcrIsMale.SelectedItem); // ѕосмотреть что там в отладке
        Data.Add("UserBirthday", dpBirthday.Date.ToString());
        Data.Add("Id", user.UserId.ToString());

        if(!string.IsNullOrEmpty(entSecondName.Text)) Data.Add("UserSecondName", entSecondName.Text);
        if(!string.IsNullOrEmpty(entEmail.Text)) Data.Add("UserEmail", entEmail.Text);
        if(!string.IsNullOrEmpty(entPhone.Text)) Data.Add("UserPhone", entPhone.Text);

        controller.UpdateUser(Data);
        if(IsAuthor) {
            if(!string.IsNullOrEmpty(entBIO.Text)) Data.Add("Bio", entBIO.Text);
            controller.UpdateAuthor(Data);
        }

        btnChange.IsEnabled = true;
        btnSave.IsEnabled = false;
        Navigation.PushAsync(new MainPage(controller.GetAuth(user.UserLogin, user.UserPassword)));
    }

}