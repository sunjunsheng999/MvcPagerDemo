using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace MvcApplication.Models.Home
{
    public class Index
    {
        public string BlogURL { get; set; }
        //当前用户
        public Model.User User { get; set; }
        //信息列表
        public PagedList<Model.Info> Infos { get; set; }
    }
}