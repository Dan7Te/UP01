using Proj.MVC.Controller;
using Telpis_221_UP_1.MVC.Model;
using Telpis_221_UP_1.MVC.View.Pages;

namespace Proj.MVC.View.Views;

public partial class HomeView : ContentView
{
    User user;
    Proj.MVC.Controller.Controller controller = new Proj.MVC.Controller.Controller();

    public HomeView(User user)
	{
		InitializeComponent();
        this.user = user;

        lvBooks.ItemsSource = controller.GetParametredBooks(null, null, null, null, null, null, user.UserId);

        List<string?>? genres = controller.GetFavGenres(user.UserId);
        if(genres != null) lblFavGenres.Text = "Любимые жанры: " + string.Join(", ", genres);
        else lblFavGenres.Text = "Любимые жанры: -";

        List<string?>? authors = controller.GetFavAuthors(user.UserId);
        if(authors != null) lblFavAuthors.Text = "Любимые авторы: " + string.Join(", ", authors);
        else lblFavAuthors.Text = "Любимые авторы: -";


    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {
        Navigation.PushAsync(new ReadPage(user, (Book)e.Parameter));
    }
}