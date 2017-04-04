using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityFrameworkModelFirst
{
    public partial class Default : System.Web.UI.Page
    {

        //In this field the info of the db is saved
        Model1Container dbContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbContext = new Model1Container();
            ListView1.InsertItemPosition = InsertItemPosition.LastItem;
        }
    }
}