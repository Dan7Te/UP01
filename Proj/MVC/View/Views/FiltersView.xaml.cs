using Telpis_221_UP_1.MVC.View.Pages;
using Proj.MVC.Model;
using Telpis_221_UP_1.MVC.Model;
using Proj.MVC.Controller;

namespace Proj.MVC.View.Views;

public partial class FiltersView : ContentView
{
    User user;
    Controller.Controller controller = new Controller.Controller();
    public FiltersView(User user)
	{
		InitializeComponent();
        this.user = user;
        pcrAuthor.ItemsSource = controller.GetAuthors();
        pcrGenre.ItemsSource = controller.GetGenres();
	}

    private void btnFilters_Clicked(object sender, EventArgs e) {
		if(
            pcrAuthor.SelectedIndex == -1 &&
			pcrGenre.SelectedIndex == -1 &&
            string.IsNullOrEmpty(entYear.Text) &&
            string.IsNullOrEmpty(entPagesStart.Text) &&
            string.IsNullOrEmpty(entPagesEnd.Text)
			) {
            Navigation.PushAsync(new MainPage(user, true));
		}
		else {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            
            if(pcrAuthor.SelectedIndex != -1) {
                Parameters.Add("Author", $"{((Author)pcrAuthor.SelectedItem).AuthorId}");
            }
            if(pcrGenre.SelectedIndex != -1) {
                Parameters.Add("Genre", $"{((Genre)pcrGenre.SelectedItem).Id}");
            }
            if(!string.IsNullOrEmpty(entYear.Text)) {
                Parameters.Add("Year", $"{entYear.Text}");
            }
            if(!string.IsNullOrEmpty(entPagesStart.Text)) {
                Parameters.Add("PagesStart", $"{entPagesStart.Text}");
            }
            if(!string.IsNullOrEmpty(entPagesEnd.Text)) {
                Parameters.Add("PagesEnd", $"{entPagesEnd.Text}");
            }

            Navigation.PushAsync(new MainPage(user, true, Parameters));
        }
    }
}