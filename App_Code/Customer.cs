using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public string LastName { set; get; }
    public string FirstName { set; get; }
    public string email { set; get; }
    public string password { set; get; }
    public int passcode { set; get; }
    public Byte[] PasswordHash { set; get; }
}