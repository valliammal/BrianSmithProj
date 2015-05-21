using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Address : System.Web.UI.Page
{
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hobbies.aspx");
    }
    protected void bntSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hobbies.aspx");
    }
}