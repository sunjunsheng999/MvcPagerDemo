using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        [Display(Name = "用户编号")]
        public int UserID { get; set; }

        [Display(Name = "用户名称")]
        public string UserName { get; set; }
    }
}
