using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//libraries required for this class
using System.Data; //general data
using System.Data.SqlClient; //sql server
using System.Configuration; //to get access to the web config file

/// <summary>
/// Summary description for Registration
/// This class takes a customer and vehicle object
/// extracts the properties from them
/// and writes them to the automart database
/// </summary>
public class Registration
{
    Customer c;
    Vehicle v;
    SqlConnection connect;

	public Registration(Customer cust, Vehicle veh)
	{
        c = cust;
        v = veh;
        //get the connection string from the web config file
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["AutomartConnectionString"].ConnectionString);
        //call the WriteToDatabase() method
        //it needs to be in a try catch because as the calling method
        //this is where the thrown method would be caught
        //we need to rethrow it so it makes it out
        //to the web form
        try
        {
            WriteToDatabase();
        }
        catch (Exception ex)
        {
            throw ex;
        }
	}

    private void WriteToDatabase()
    {
        //set up the sql strings for each table
        string sqlPerson = "Insert into person(LastName, FirstName)"
            + " Values(@lastName, @firstname)";
        string sqlCustomer = "Insert into Customer.RegisteredCustomer"
            + "(PersonKey, Email, CustomerPassword, CustomerPasscode, CustomerHashedPassword)"
            + " Values(Ident_current('Person'), @email, @password, @passcode, @hashed)";
        string sqlVehicle = "insert into Customer.Vehicle(personkey,LicenseNumber, Vehiclemake, VehicleYear)"
            + " Values(Ident_current('Person' ),@License, @make, @year)";

        //create a command for each sqlstring and provide values
        //for the parameters
        SqlCommand cmdPerson = new SqlCommand(sqlPerson, connect);
        cmdPerson.Parameters.AddWithValue("@LastName", c.LastName);
        cmdPerson.Parameters.AddWithValue("@FirstName", c.FirstName);

        SqlCommand cmdCustomer = new SqlCommand(sqlCustomer, connect);
        cmdCustomer.Parameters.AddWithValue("@Email", c.email);
        cmdCustomer.Parameters.AddWithValue("@password", c.password);
        cmdCustomer.Parameters.AddWithValue("@Passcode", c.passcode);
        cmdCustomer.Parameters.AddWithValue("@hashed", c.PasswordHash);

        SqlCommand cmdVehicle = new SqlCommand(sqlVehicle, connect);
        cmdVehicle.Parameters.AddWithValue("@License", v.License);
        cmdVehicle.Parameters.AddWithValue("@make", v.Make);
        cmdVehicle.Parameters.AddWithValue("@year", v.Year);

        //create a transaction object
        SqlTransaction tran=null;

      
      
        //open the connection
        connect.Open();
        //start the transaction
        tran=connect.BeginTransaction();

        //try the inserts, if all are successful
        //commit the transaction
        try
        {
            //assign all the commands to the same transaction
            cmdPerson.Transaction = tran;
            cmdCustomer.Transaction = tran;
            cmdVehicle.Transaction = tran;

            cmdPerson.ExecuteNonQuery();
            cmdCustomer.ExecuteNonQuery();
            cmdVehicle.ExecuteNonQuery();

            tran.Commit();
        }
        catch (Exception ex)
        {
            //if there are any errors
            //roll back the transaction 
            //and throw the error
            tran.Rollback();
            throw ex;
        }
        finally //no matter what
        {
            connect.Close();
        }



    }
}