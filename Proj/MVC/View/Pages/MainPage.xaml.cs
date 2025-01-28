using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls;
using Proj.MVC.View.Views;
using System.Xml.Linq;
using Telpis_221_UP_1.MVC.Model;

namespace Telpis_221_UP_1.MVC.View.Pages;

public partial class MainPage :ContentPage {

    User user;

    public MainPage(User user, bool FilteredSearch, Dictionary<string, string> Parameters) {
        InitializeComponent();
        this.user = user;
        if(!FilteredSearch) {
            MainFrame.Content = new ProfileView(user);
        }
        else {
            if(Parameters == null) {
                MainFrame.Content = new SearchView(user);
                btnFilters.IsVisible = true;
            }
            else {
                MainFrame.Content = new SearchView(user, Parameters);
                btnFilters.IsVisible = true;
            }
        }
    }

    public MainPage(User user, bool FilteredSearch) {
        InitializeComponent();
        this.user = user;
        if(FilteredSearch) {
            MainFrame.Content = new SearchView(user);
            btnFilters.IsVisible = true;
        }
    }

    public MainPage(User user) {
        InitializeComponent();
        this.user = user;
        MainFrame.Content = new ProfileView(user);
    }

    public MainPage() {
        InitializeComponent();
    }

    public bool FiltersIsCllicked = false;

    private void btnHome_Clicked(object sender, EventArgs e) {
        MainFrame.Content = new HomeView(user);
        btnFilters.IsVisible = false;
    }

    private void btnSearch_Clicked(object sender, EventArgs e) {
        MainFrame.Content = new SearchView(user);
        btnFilters.IsVisible = true;
    }

    private void btnProfile_Clicked(object sender, EventArgs e) {
        MainFrame.Content = new ProfileView(user);
        btnFilters.IsVisible = false;
    }

    private void btnFilters_Clicked(object sender, EventArgs e) {
        MainFrame.Content = new FiltersView(user);
        btnFilters.IsVisible = false;

    }
}