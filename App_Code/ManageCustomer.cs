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
        string sqlPerson = "Insert into Person(LastName, FirstName) Values(@lastName, @FirstName)";
        SqlCommand personCmd = new SqlCommand(sqlPerson, connect);
        personCmd.Parameters.AddWithValue("@LastName", d.LastName);
        personCmd.Parameters.AddWithValue("@FirstName", d.FirstName);

        return personCmd;
    }

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

    private SqlCommand WriteRegisteredDonor(Donor d)
    {
        string sqlRegisteredDonor = "Insert into Donor.RegisteredDonor(Email, DonorPasscode, "
            + "DonorPassword, DonorHashedPassword, PersonKey)"
            + "Values(@Email, @Passcode, @password, @hashedpass, ident_Current('Person'))";

        PasscodeGenerator pg = new PasscodeGenerator();
        PasswordHash ph = new PasswordHash();
        int Passcode = pg.GetPasscode();

        SqlCommand regDonorCmd = new SqlCommand(sqlRegisteredDonor, connect);
        regDonorCmd.Parameters.AddWithValue("@Email", d.Email);
        regDonorCmd.Parameters.AddWithValue("@Passcode", Passcode);
        regDonorCmd.Parameters.AddWithValue("@password", d.PlainPassword);
        regDonorCmd.Parameters.AddWithValue("@hashedPass", ph.HashIt(d.PlainPassword.ToString(), Passcode.ToString()));

        return regDonorCmd;

    }

    public void WriteDonor(Donor d)
    {
        this.d = d;

        SqlTransaction tran = null;

        SqlCommand pCmd = WritePerson();
        //SqlCommand vCmd = WriteVehicle();
        SqlCommand rCmd = WriteRegisteredDonor(d);

        connect.Open();
        try
        {
            tran = connect.BeginTransaction();
            pCmd.Transaction = tran;
            //vCmd.Transaction = tran;
            rCmd.Transaction = tran;
            pCmd.ExecuteNonQuery();
            //vCmd.ExecuteNonQuery();
            rCmd.ExecuteNonQuery();
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