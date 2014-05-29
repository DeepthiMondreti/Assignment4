using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ManageCustomer
/// </summary>
public class ManageCustomer
{
    SqlConnection connect;
    Donor d;

    public ManageCustomer()
    {
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssist"].ConnectionString);
    }

    private SqlCommand WritePerson()
    {
        string sqlPerson = "Insert into Person(PersonLastName, PersonFirstName, PersonUserName, PersonUserPassword, "
            + "PersonPlainPassword, PersonPassKey)"
            + "Values(@LastName, @FirstName, @Email, @hashedpass, @password, @Passcode)";

        PasscodeGenerator pg = new PasscodeGenerator();
        PasswordHash ph = new PasswordHash();
        int Passcode = pg.GetPasscode();

        SqlCommand personCmd = new SqlCommand(sqlPerson, connect);
        personCmd.Parameters.AddWithValue("@LastName", d.LastName);
        personCmd.Parameters.AddWithValue("@FirstName", d.FirstName);
        personCmd.Parameters.AddWithValue("@Email", d.Email);
        personCmd.Parameters.AddWithValue("@Passcode", Passcode);
        personCmd.Parameters.AddWithValue("@password", d.PlainPassword);
        personCmd.Parameters.AddWithValue("@hashedPass", ph.HashIt(d.PlainPassword.ToString(), Passcode.ToString()));

        return personCmd;
    }

<<<<<<< HEAD
=======
    //private SqlCommand WriteVehicle()
    //{
    //    string sqlVehicle = "Insert into Customer.Vehicle(LicenseNumber, VehicleMake, VehicleYear, PersonKey)" +
    //        "Values(@License, @Make, @Year, ident_Current('Person'))";
    //    SqlCommand vehicleCmd = new SqlCommand(sqlVehicle, connect);
    //    vehicleCmd.Parameters.AddWithValue("@License", c.LicenseNumber);
    //    vehicleCmd.Parameters.AddWithValue("@Make", c.VehicleMake);
    //    vehicleCmd.Parameters.AddWithValue("@Year", c.VehicleYear);

    //    return vehicleCmd;
    //}

    private SqlCommand WriteRegisteredDonor()
    {
        string sqlRegisteredDonor = "Insert into Donor.RegisteredDonor(Email, DonorPasscode, "
            + "DonorPassword, DonorHashedPassword, PersonKey)"
            + "Values(@Email, @Passcode, @password, @hashedpass, ident_Current('Person'))";
>>>>>>> parent of ffbd70d... Not registering


    public void WriteDonor(Donor d)
    {
        this.d = d;

        SqlTransaction tran = null;

        SqlCommand pCmd = WritePerson();
<<<<<<< HEAD
=======
        //SqlCommand vCmd = WriteVehicle();
        SqlCommand rCmd = WriteRegisteredDonor();
>>>>>>> parent of ffbd70d... Not registering

        connect.Open();
        try
        {
            tran = connect.BeginTransaction();
            pCmd.Transaction = tran;
            pCmd.ExecuteNonQuery();
            tran.Commit();
        }
        catch (Exception ex)
        {
            tran.Rollback();
            throw ex;
        }
        finally
        {
            connect.Close();
        }
    }
}