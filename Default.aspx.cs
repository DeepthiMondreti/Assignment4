using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //on the button click we make an instance of our donor
        //class and then write the values in the text boxes
        //to the class properties
        Donor donor = new Donor();
        donor.FirstName = txtFirstName.Text;
        donor.LastName = txtLastName.Text;
        donor.Phone = txtPhone.Text;
        donor.Email = txtEmail.Text;
        donor.PlainPassword = txtPassword.Text;
        donor.Donation = double.Parse(txtDonation.Text);

        //we create a session variable to store our class
        //with all the values in it
        //so we can access it on other pages
        Session["donation"] = donor;
        //then we redirect to the second page
        Response.Redirect("LoginForm.aspx");
    }
}