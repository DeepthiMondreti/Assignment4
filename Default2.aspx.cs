using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //first we check to make sure the session exists
        //if not we redirect them back to the form
        //so they can fill it in
        if (Session["donation"] != null)
        {
            //case the session variable from "object"
            //to the type of object it is
            //in this case "Donor"
            Donor donor = (Donor)Session["donation"];
            //assign the values from the fields in the class
            //to the labels
            lblFirstName.Text = donor.FirstName;
            lblLastName.Text = donor.LastName;
            lblPhone.Text = donor.Phone;
            lblEmail.Text = donor.Email;
            lblDonation.Text = donor.Donation.ToString("c");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        //if the user clicks yes, we go to the final thanky you page
        //in this case the redirect passes the first name and lastname
        //in an http Get to the next page
        //that is it passes the values in the actual URL
        Response.Redirect("Default3.aspx?first="+ lblFirstName.Text + "&last=" + lblLastName.Text);
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        //this returns you to the form page, but you will
        //note that the form is empty
        //all the values are gone. If you want to have 
        //it populate you will have to access the session
        //variable again in the Page Load event
        //and populate the textboxes from the class
        Response.Redirect("Default.aspx");
    }
}