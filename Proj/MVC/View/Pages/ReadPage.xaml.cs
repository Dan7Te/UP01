using Telpis_221_UP_1.MVC.Model;
using Microsoft.Maui.Controls;
using Proj.MVC.View.Views;
using System.Xml.Linq;
using Proj.MVC.Controller;

namespace Telpis_221_UP_1.MVC.View.Pages;

public partial class ReadPage : ContentPage
{
    User user;
    Book book;
    Controller controller = new Controller();
    bool? IsSelected;

    public ReadPage(User user, Book book) {
        InitializeComponent();
        this.user = user;
        this.book = book;

        lblAuthor.Text      = book.Author.AuthorSurname;
        lblBookName.Text    = book.BookName;
        imgBook.Source      = book.Photo;
        lblDescription.Text = book.BookDescription;

        IsSelected = controller.IsSelectionExists(user, book);
        if(IsSelected == false) btnSelection.Text = "Добавить в избранное";
        else if(IsSelected == true) btnSelection.Text = "Удалить из избранного";
    }

    public ReadPage() {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e) {
        if(IsSelected == false) {
            controller.AddSelection(user, book);
            IsSelected = true;
            btnSelection.Text = "Удалить из избранного";
        }
        else if(IsSelected == true) {
            controller.DeleteSelection(user, book);
            IsSelected = false;
            btnSelection.Text = "Добавить в избранное";
        } 
    }
}