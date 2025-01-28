using Proj.MVC.Controller;
using Proj.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telpis_221_UP_1.MVC.Model;
public class User {

    public Controller controller = new Controller();

    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string? UserSecondName { get; set; }
    public string? UserEmail { get; set; }
    public string? UserPhone { get; set; }
    public bool IsMale { get; set; }
    public DateTime UserBirthday { get; set; }
    public string UserLogin { get; set; }
    public string UserPassword { get; set; }
    public Author? Author { get; set; }

    public Role UserRole { get; set; } 

    public User(
        int UserId,
        string UserName,
        string UserSurname,
        string UserSecondName,
        string UserEmail,
        string UserPhone,
        DateTime UserBirthday,
        bool IsMale,
        Role UserRole,
        string UserLogin = null,
        string UserPassword = null,
        Author Author = null
        ) {

        this.UserId         = UserId;
        this.UserName       = UserName;
        this.UserSurname    = UserSurname;
        this.UserSecondName = UserSecondName;
        this.UserEmail      = UserEmail;
        this.UserPhone      = UserPhone;
        this.UserBirthday   = UserBirthday;
        this.IsMale         = IsMale;
        this.UserLogin      = UserLogin;
        this.UserPassword   = UserPassword;
        this.Author         = Author;
        this.UserRole       = UserRole;   

    }

    public User(List<object>? Data) {
        this.UserId         = (int)Data[0];
        this.UserName       = (string)Data[1];
        this.UserSurname    = (string)Data[2];
        this.UserSecondName = Data[3] == null ? null : (string)Data[3];
        this.UserEmail      = Data[4] == null ? null : (string)Data[4];
        this.UserPhone      = Data[5] == null ? null : (string)Data[5];
        this.IsMale         = (bool)Data[6];
        this.UserBirthday   = (DateTime)Data[7];
        this.UserLogin      = (string)Data[8];
        this.UserPassword   = (string)Data[9];
        this.Author = int.TryParse(Data[10].ToString(), out _) ? controller.GetAuthor((int)Data[10]) : null;
        this.UserRole       = controller.GetUserRole((int)Data[11]);
    }
}
