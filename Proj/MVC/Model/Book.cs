using Proj.MVC.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telpis_221_UP_1.MVC.Model;
public class Book {

    public Controller controller = new Controller();

    public int BookId { get; set; }
    public string BookName { get; set; }
    public string? BookDescription { get; set; }
    public int BookYear { get; set; }
    public int PagesQuantity { get; set; }
    public string BookLink { get; set; }
    public string? Photo { get; set; }
    public int Mark { get; set; }
    public Author Author { get; set; }
    
    //public int Author { get; set; }

    public Book(
        int BookId,
        string BookName,
        int BookYear,
        int PagesQuantity,
        string BookLink,
        int Mark,
        int Author,
        string BookDescription = null,
        string Photo = null
        ) {

        this.BookId = BookId;
        this.BookName = BookName;
        this.BookYear = BookYear;
        this.PagesQuantity = PagesQuantity;
        this.BookLink = BookLink;
        this.Mark = Mark;
        this.Author = controller.GetAuthor(Author);
        this.BookDescription = BookDescription;
        this.Photo = Photo;

    }

    public Book(List<object>? Data) {
        this.BookId = (int)Data[0];
        this.BookName = (string)Data[1];
        this.BookYear = (int)Data[3];
        this.PagesQuantity = (int)Data[4];
        this.BookLink = (string)Data[5];
        this.Mark = (int)Data[7];
        this.Author = controller.GetAuthor((int)Data[8]);
        this.BookDescription = (string)Data[2];
        this.Photo = (string)Data[6];
    }

}
