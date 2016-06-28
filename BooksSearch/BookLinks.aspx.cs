using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BooksSearch
{
    public partial class BookLinks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BookSQL books = new BookSQL();
            DataTable bookData = new DataTable();
            bookData = books.Select1();            
            string[] alphabets = new string[26]{"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            DataRow[] foundRows;            
            for(int i = 0; i<26;i++)             {
                foundRows = bookData.Select("Letter = '" + alphabets[i] + "'");
                 if (foundRows.Count() != 0)
                 {                    
                     HtmlGenericControl anchor = new HtmlGenericControl("a");
                     anchor.Attributes.Add("href", "#"+alphabets[i]);
                     //anchor.Attributes.Add("style", "width:15px");
                     anchor.InnerText = alphabets[i];
                     divS.Controls.Add(anchor);
                     HtmlGenericControl ul = new HtmlGenericControl("ul");
                     ul.Attributes.Add("id", alphabets[i]);
                     ul.InnerText = alphabets[i];
                     divH.Controls.Add(ul);
                     foreach (DataRow row in foundRows)
                     {
                         HtmlGenericControl li = new HtmlGenericControl("li");
                         li.Attributes.Add("id", "li" + alphabets[i]);
                         li.Style.Add("list-style", "none");
                         ul.Controls.Add(li);
                         HtmlGenericControl anchorli = new HtmlGenericControl("a");                      
                         NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                         queryString["title"] = row["Title"].ToString();
                         queryString["desc"] = row["Description"].ToString();
                         string url = "BookDesc.aspx?" + queryString.ToString();
                         anchorli.Attributes.Add("href",url);
                         anchorli.InnerText = row["Title"].ToString();
                         li.Controls.Add(anchorli);
                     }               
                  }
                 else
                   {
                        HtmlGenericControl label = new HtmlGenericControl("label");
                        label.Attributes.Add("style", "width:15px");
                        label.InnerText = alphabets[i];
                        divS.Controls.Add(label);
                   }
             }

        }
    }
}