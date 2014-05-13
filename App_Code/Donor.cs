using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is really just a container for the data
/// contained in the form, by storing it in a class
/// we can pass one thing instead of five seperate 
/// fields. In this version of the class I have 
/// used the shorthand for declaring properties.
/// This form is only good if you are doing nothing 
/// special in the gets and sets, no validation or manipulation
/// of the fields. Properties written in this generate
/// a private instance of the field
/// Steve Conger 4/13/2013
/// </summary>
public class Donor
{
   

    public string FirstName { set; get; }
    public string LastName { set; get; }
    public string Phone { set; get; }
    public string Email { set; get; }
    public string PlainPassword { get; set; }
    public byte[] Password { get; set; }
    public int Passcode { get; set; }
    public double Donation { set; get; }
}