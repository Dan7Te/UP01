using Microsoft.Maui.Platform;
using Proj.MVC.Controller;
using Proj.MVC.Model;
using Telpis_221_UP_1.MVC.Model;
using Telpis_221_UP_1.MVC.View.Pages;

namespace Proj.MVC.View.Views;

public partial class SearchView : Microsoft.Maui.Controls.ContentView
{
    Controller.Controller controller = new Controller.Controller();

    List<Book> Sourse;
    User user;

    public SearchView(User user, Dictionary<string, string> Parameters){
		InitializeComponent();
        this.user = user;

        Author? author  = Parameters.ContainsKey("Author") ? controller.GetAuthor(int.Parse(Parameters["Author"])) : null;
        int? Year       = Parameters.ContainsKey("Year") ? int.Parse(Parameters["Year"]) : null;
        int? PagesStart = Parameters.ContainsKey("PagesStart") ? int.Parse(Parameters["PagesStart"]) : null;
        int? PagesEnd   = Parameters.ContainsKey("PagesEnd") ? int.Parse(Parameters["PagesEnd"]) : null;
        Genre? genre    = Parameters.ContainsKey("Genre") ? controller.GetGenre(int.Parse(Parameters["Genre"])) : null;

        lvBooks.ItemsSource = controller.GetParametredBooks(
            null,
            Year,
            PagesStart,
            PagesEnd,
            author,
            genre,
            null
            );

        Sourse = (List<Book>)lvBooks.ItemsSource;
    }

    public SearchView(User user) {
        InitializeComponent();
        this.user = user;
        lvBooks.ItemsSource = controller.GetBooks();
        Sourse = (List<Book>)lvBooks.ItemsSource;
    }

    private void entSearch_TextChanged(object sender, TextChangedEventArgs e) {
        lvBooks.ItemsSource = Sourse.Where(x => x.BookName.StartsWith(entSearch.Text)).ToList();
        
        if(string.IsNullOrEmpty(entSearch.Text)) {
            lvBooks.ItemsSource = Sourse;
        }
    }

    private void lvBooks_ItemTapped(object sender, ItemTappedEventArgs e) {
        Navigation.PushAsync(new ReadPage(user, (Book)lvBooks.SelectedItem));
    }
}