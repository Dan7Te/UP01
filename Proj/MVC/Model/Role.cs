using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.MVC.Model;
public class Role {

    public int Id { get; set; }
    public string RoleName { get; set; }

    public Role(
        int Id,
        string RoleName
        ) {
        this.Id = Id;
        this.RoleName = RoleName;
    }

    public Role(List<object> Data) {
        this.Id       = (int)Data[0];
        this.RoleName = (string)Data[1];
    }
}
