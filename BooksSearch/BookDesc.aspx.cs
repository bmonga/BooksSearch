using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksSearch
{
    public partial class BookDesc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbltitle.InnerText = Request.QueryString["title"].ToString();
            lblDesc.InnerText = Request.QueryString["desc"].ToString();
        }
    }
}