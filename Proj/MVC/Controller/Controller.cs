using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Intrinsics.X86;
using static Microsoft.Maui.ApplicationModel.Permissions;
using Telpis_221_UP_1.MVC.Model;
using Proj.MVC.Model;
using Microsoft.Maui.Graphics;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proj.MVC.Controller;
public class Controller {

    public static SqlConnection connection;

    public Controller() {
        try {
            string server = "192.168.208.60"; //IPv4  //192.168.208.60 - телефон  172.22.148.26 - работа
            string database = "_Telpis_221_UP1_Cher";
            string username = "dante";
            string password = "1qaz!QAZ";

            string connectionString = $"Data Source={server};Initial Catalog={database};User Id={username};Password={password};";
            connection = new SqlConnection(connectionString);
        }
        catch {
            
        }
    }

    public List<Author> GetAuthors() {

        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Author ";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();
            
            adapter.Fill(DataSet);
            List<Author> ans = DataSet.Tables[0].AsEnumerable().Select(x => new Author(x.ItemArray.ToList())).ToList();

            connection.Close();
            return ans;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public List<Book> GetBooks() {

        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Book ";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            List<Book> ans = DataSet.Tables[0].AsEnumerable().Select(x => new Book(x.ItemArray.ToList())).ToList();

            connection.Close();
            return ans;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public List<Book> GetParametredBooks(
        string? Name,
        int? Year,
        int? PagesFrom,
        int? PagesTo,
        Author? author,
        Genre? genre,
        int? selection
        ) {

        try {
            if(
                (string.IsNullOrEmpty(Name) || Name == null) &&
                Year == null &&
                PagesTo == null &&
                PagesFrom == null &&
                author == null &&
                genre == null &&
                selection == null
                ) {
                return GetBooks();
            }

            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Book " +
            "where " +
            "";

            List<string> parameters = new List<string>();   

            if(Name != null) {
                parameters.Add($"BookName like '{Name}%' ");
            }
            if(Year != null) {
                parameters.Add($"BookYear = {Year}");
            }
            if(PagesFrom != null) {
                parameters.Add($"PagesQuantity > {PagesFrom} ");
            }
            if(PagesTo != null) {
                parameters.Add($"PagesQuantity < {PagesTo} ");
            }
            if(author != null) {
                parameters.Add($"Author = {author.AuthorId} ");
            }
            if(genre != null) {
                parameters.Add($"Id = (select Book from BookGenre where Book = Id and Genre = {genre.Id}) ");
            }
            if(selection != null) {
                parameters.Add($"Id = (select Book from Readers where Book = Id and Reader = {selection})");
            }

            string StrParameters = string.Join(" and ", parameters);
            CommandText += StrParameters;

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            List<Book> ans = DataSet.Tables[0].AsEnumerable().Select(x => new Book(x.ItemArray.ToList())).ToList();

            connection.Close();
            return ans;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public Role GetUserRole(int Id) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Roles " +
            $"Where Id = {Id}";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            Role role = DataSet.Tables[0].AsEnumerable().Select(x => new Role(x.ItemArray.ToList())).ToList().First();

            connection.Close();
            return role;
        }
        catch {
            connection.Close();
            return null;
        }
    }


    public Author GetAuthor(int Id) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Author " +
            $"Where Id = {Id}";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            Author author = DataSet.Tables[0].AsEnumerable().Select(x => new Author(x.ItemArray.ToList())).ToList().First();

            connection.Close();
            return author;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public Genre GetGenre(int Id) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Genre " +
            $"Where Id = {Id}";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            Genre genre = DataSet.Tables[0].AsEnumerable().Select(x => new Genre(x.ItemArray.ToList())).ToList().First();

            connection.Close();
            return genre;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public List<Genre> GetGenres() {

        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Genre ";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            List<Genre> ans = DataSet.Tables[0].AsEnumerable().Select(x => new Genre(x.ItemArray.ToList())).ToList();

            connection.Close();
            return ans;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public bool? IsSelectionExists(Telpis_221_UP_1.MVC.Model.User user, Book book) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Readers " +
            $"where Reader = {user.UserId} and Book = {book.BookId}";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            int ans = DataSet.Tables[0].AsEnumerable().Select(x => x).ToList().Count();


            connection.Close();
            if(ans == 0) return false;
            else return true;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public void AddSelection(Telpis_221_UP_1.MVC.Model.User user, Book book) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "insert into Readers(Reader, Book)" +
            $"values ({user.UserId},{book.BookId})";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        catch {
            connection.Close();
            return;
        }
    }

    public void DeleteSelection(Telpis_221_UP_1.MVC.Model.User user, Book book) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "delete from Readers " +
            $"where Reader = {user.UserId} and Book = {book.BookId}";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        catch {
            connection.Close();
            return;
        }
    }

    public Telpis_221_UP_1.MVC.Model.User GetAuth(string Login, string Password) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select * " +
            "from Users " +
            $"Where UserLogin = '{Login}' and UserPassword = '{Password}'";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            Telpis_221_UP_1.MVC.Model.User user = DataSet.Tables[0].AsEnumerable().Select(x => new Telpis_221_UP_1.MVC.Model.User(x.ItemArray.ToList())).ToList().First();

            connection.Close();
            return user;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public Telpis_221_UP_1.MVC.Model.User RegNewUser(Dictionary<string, string> Data) {
        try {
            string InsertExpression = "insert into Users(UserName, UserSurname, IsMale, UserBirthday, UserLogin, UserPassword, UserRole ";
            string ValuesExpression = $"values(" +
                $"'{Data["UserName"]}', " +
                $"'{Data["UserSurname"]}', " +
                $"{(Data["IsMale"] == "true" ? 1 : 0)}, " +
                $"'{Data["UserBirthday"]}', " +
                $"'{Data["UserLogin"]}', " +
                $"'{Data["UserPassword"]}', " +
                $"1";

            if(Data.ContainsKey("UserSecondName")) {
                InsertExpression += "UserSecondName";
                ValuesExpression += $", '{Data["UserSecondName"]}'";
            }
            if(Data.ContainsKey("UserEmail")) {
                InsertExpression += "UserEmail";
                ValuesExpression += $", '{Data["UserEmail"]}'";
            }
            if(Data.ContainsKey("UserPhone")) {
                InsertExpression += "UserPhone";
                ValuesExpression += $", '{Data["UserPhone"]}'";
            }
            if(Data.ContainsKey("Author")) {
                Author NewAuthor = RegNewAuthor(Data);
                InsertExpression += "Author";
                ValuesExpression += $", {NewAuthor.AuthorId}";
            }

            InsertExpression += ")";
            ValuesExpression += ")";

            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            InsertExpression +
            ValuesExpression;

            SqlCommand cmd  = new SqlCommand();
            cmd.Connection  = connection;
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery();

            connection.Close();

            Telpis_221_UP_1.MVC.Model.User NewUser = GetAuth(Data["UserLogin"], Data["UserPassword"]);
            return NewUser;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public Author RegNewAuthor(Dictionary<string, string> Data) {
        try {
            string InsertExpression = "insert into Author(AuthorName, AuthorSurname, IsMale, AuthorBirthday";
            string ValuesExpression = $"values(" +
                $"'{Data["UserName"]}', " +
                $"'{Data["UserSurname"]}', " +
                $"{(Data["IsMale"] == "true" ? 1 : 0)}, " +
                $"'{Data["UserBirthday"]}'";

            if(Data.ContainsKey("UserSecondName")) {
                InsertExpression += "AuthorSecondName";
                ValuesExpression += $", '{Data["UserSecondName"]}'";
            }
            if(Data.ContainsKey("UserEmail")) {
                InsertExpression += "AuthorEmail";
                ValuesExpression += $", '{Data["UserEmail"]}'";
            }
            if(Data.ContainsKey("UserPhone")) {
                InsertExpression += "AuthorPhone";
                ValuesExpression += $", '{Data["UserPhone"]}'";
            }

            InsertExpression += ")";
            ValuesExpression += ")";

            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            InsertExpression +
            ValuesExpression;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery();

            connection.Close();

            //////////////////////////////////////////////////

            connection.Open();
            CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "SELECT TOP 1 * FROM Author ORDER BY ID DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            Author NewAuthor = DataSet.Tables[0].AsEnumerable().Select(x => new Author(x.ItemArray.ToList())).ToList().First();

            connection.Close();

            return NewAuthor;
        }
        catch {
            connection.Close();
            return null;
        }
    }
    
    public void UpdateUser(Dictionary<string, string> Data) {
        try {
            string ValuesExpression = $"set " +
                $"UserName = '{Data["UserName"]}', " +
                $"UserSurname = '{Data["UserSurname"]}', " +
                $"IsMale = {(Data["IsMale"] == "true" ? 1 : 0)}, " +
                $"UserBirthday = '{Data["UserBirthday"]}' ";
                
            if(Data.ContainsKey("UserSecondName")) ValuesExpression += $", UserSecondName = '{Data["UserSecondName"]}'";
            if(Data.ContainsKey("UserEmail")) ValuesExpression += $", UserEmail = '{Data["UserEmail"]}'";
            if(Data.ContainsKey("UserPhone")) ValuesExpression += $", UserPhone = '{Data["UserPhone"]}'";

            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "update Users " +
            ValuesExpression + 
            $"where Id = {Data["Id"]}";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        catch {
            connection.Close();
            return;
        }
    }

    public void UpdateAuthor(Dictionary<string, string> Data) {
        try {
            string ValuesExpression = $"set " +
                $"UserName = '{Data["UserName"]}', " +
                $"UserSurname = '{Data["UserSurname"]}', " +
                $"IsMale = {(Data["IsMale"] == "true" ? 1 : 0)}, " +
                $"UserBirthday = '{Data["UserBirthday"]}' ";

            if(Data.ContainsKey("UserSecondName")) ValuesExpression += $", UserSecondName = '{Data["UserSecondName"]}'";
            if(Data.ContainsKey("UserEmail")) ValuesExpression += $", UserEmail = '{Data["UserEmail"]}'";
            if(Data.ContainsKey("UserPhone")) ValuesExpression += $", UserPhone = '{Data["UserPhone"]}'";
            if(Data.ContainsKey("Bio")) ValuesExpression += $", Bio = '{Data["Bio"]}'";

            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "update Author " +
            ValuesExpression +
            $"where Id = {Data["Id"]}";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = CommandText;
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        catch {
            connection.Close();
            return;
        }
    }

    public List<string?>? GetFavGenres(int UserId) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select top 2 Genre.GenreName, Count(BookGenre.Book) as GenreCount " +
            "from Readers " +
            "Left join BookGenre on Readers.Book = BookGenre.Book " +
            "Left join Genre on BookGenre.Genre = Genre.Id " +
            $"where Readers.Reader = {UserId} " +
            "group by Readers.Reader, BookGenre.Genre, Genre.GenreName " +
            "order by GenreCount desc";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            List<string?> genres = DataSet.Tables[0].AsEnumerable().Select(x => (string?)(x.ItemArray.ToList()[0])).ToList();

            connection.Close();
            return genres;
        }
        catch {
            connection.Close();
            return null;
        }
    }

    public List<string?>? GetFavAuthors(int UserId) {
        try {
            connection.Open();
            string CommandText = "" +
            "use _Telpis_221_UP1_Cher; " +
            "select top 2 Author.AuthorSurname, Count(AuthorBook.Author) as AuthorCount " +
            "from Readers " +
            "Left join AuthorBook on Readers.Book = AuthorBook.Book " +
            "Left join Author on AuthorBook.Author = Author.Id " +
            $"where Readers.Reader = {UserId} " +
            "group by Readers.Reader, AuthorBook.Author, Author.AuthorSurname  " +
            "order by AuthorCount desc";

            SqlDataAdapter adapter = new SqlDataAdapter(CommandText, connection);
            DataSet DataSet = new DataSet();

            adapter.Fill(DataSet);
            List<string?> authors = DataSet.Tables[0].AsEnumerable().Select(x => (string?)(x.ItemArray.ToList()[0])).ToList();

            connection.Close();
            return authors;
        }
        catch {
            connection.Close();
            return null;
        }
    }
}
