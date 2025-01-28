using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.MVC.Model;
public class Genre {
    public int Id { get; set; } 

    public string GenreName { get; set; }

    public Genre(
        int Id,
        string GenreName
        ) {

        this.Id        = Id;
        this.GenreName = GenreName;
    }

    public Genre(List<object>? Data) {
        this.Id        = (int)Data[0];
        this.GenreName = (string)Data[1];

    }
}
