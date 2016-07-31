using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int? id = 1, string title = null)
        {
            //用户
            Model.User User = new Model.User();
            User.UserID = 1;
            User.UserName = "mvc技术交流(群号：384185065)";
            //信息列表(此处使用分页控件提出数据)
            int totalCount = 0;
            int pageIndex = id ?? 1;
            int pageSize = 2;
            PagedList<Model.Info> InfoPager = DAL.Info.GetInfos(title, pageSize, (pageIndex - 1) * 2, out totalCount).AsQueryable().ToPagedList(pageIndex, pageSize);
            InfoPager.TotalItemCount = totalCount;
            InfoPager.CurrentPageIndex = (int)(id ?? 1);
            //数据组装到viewModel
            Models.Home.Index index = new Models.Home.Index();
            index.BlogURL = "http://www.cnblogs.com/iamlilinfeng/archive/2013/04/01/2992432.html";
            index.User = User;
            index.Infos = InfoPager;
            //------------------使用ViewBig变量传递数据---------------//
            //ViewBag.PagerData = InfoPager;
            return View(index);
        }
    }
}

