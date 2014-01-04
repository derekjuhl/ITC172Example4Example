This program shows how to use ADO to manage data for a web site. 
The site allows a customer to login or, if new to the site, register.
The password the customer enters is concatinated with a random 7 digit
integer and then hashed with SHA512, the 7 digit seed and the hash
are stored in the database. For ease of teaching the plain text password
is also stored -- something obviously not a best practice.
A customer who logs in successfully is redirected to a welcome
page that greets him or her by name and shows their email.

The database used is AutoMart. A script to create the database
on Sql Server is avaialable at
http://www.spconger.com/school/itc222/Resources.html/automart.txt

In addition you will need to make these changes to the database:
*************************************************************************

Alter table Customer.RegisteredCustomer
Add CustomerPassCode int

Alter table Customer.RegisteredCustomer
Add CustomerHashedPassword varbinary(500)

Create login AutomartLogin with password='P@ssword1'  
Create User AutomartLogin for login AutomartLogin

Grant insert, select on Person to AutomartLogin
Grant  insert, select on customer.RegisteredCustomer to AutomartLogin
Grant insert, select on customer.Vehicle to AutomartLogin

*********************************************************************
You will also need to make sure that the Server is configured
to accept SQL logins as well as Windows Logins