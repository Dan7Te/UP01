//using Android.Health.Connect.DataTypes;
//using Android.Media.Audiofx;
//using Google.Android.Material.Color.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Google.ErrorProne.Annotations;
//using static Java.Interop.JniEnvironment;

namespace Telpis_221_UP_1.MVC.Model;
public class Author {
    public int AuthorId { get; set; }
    public string AuthorName {  get; set; }
    public string AuthorSurname { get; set; }
    public string? AuthorSecondName { get; set; }
    public string? AuthorEmail { get; set; }
    public string? AuthorPhone { get; set; }
    public DateTime AuthorBirthday { get; set; }
    public DateTime? AuthorDeathday { get; set; }
    public bool IsMale { get; set; }
    public string? Bio { get; set; }
    public string? AuthorPhotoLink { get; set; }
    public string? AuthorBackPhotoLink { get; set; }
    
    public Author(
        int AuthorId,
        string AuthorName,
        string AuthorSurname,
        DateTime AuthorBirthday,
        DateTime AuthorDeathday,
        bool IsMale,
        string? AuthorSecondName = null,
        string? AuthorEmail = null,
        string? AuthorPhone = null,
        string? Bio =  null,
        string? AuthorPhotoLink = null,
        string? AuthorBackPhotoLink = null
        ) {

        this.AuthorId            = AuthorId;
        this.AuthorName          = AuthorName;
        this.AuthorSurname       = AuthorSurname;
        this.AuthorBirthday      = AuthorBirthday;
        this.AuthorDeathday      = AuthorDeathday;
        this.IsMale              = IsMale;
        this.AuthorSecondName    = AuthorSecondName;
        this.AuthorEmail         = AuthorEmail;
        this.AuthorPhone         = AuthorPhone;
        this.Bio                 = Bio;
        this.AuthorPhotoLink     = AuthorPhotoLink;
        this.AuthorBackPhotoLink = AuthorBackPhotoLink;

    }

    public Author(List<object>? Data) {
        this.AuthorId            = (int)Data[0];
        this.AuthorName          = (string)Data[1];
        this.AuthorSurname       = (string)Data[2];
        this.AuthorSecondName    = (string)Data[3];
        this.AuthorEmail         = (string)Data[4];
        this.AuthorPhone         = (string)Data[5];
        this.AuthorBirthday      = (DateTime)Data[6];
        this.AuthorDeathday      = (DateTime)Data[7];
        this.IsMale              = (bool)Data[8];
        this.Bio                 = (string)Data[9];
        this.AuthorPhotoLink     = (string)Data[10];
        this.AuthorBackPhotoLink = (string)Data[11];
    }
}
