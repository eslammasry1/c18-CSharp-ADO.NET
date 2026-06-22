using System;
using System.Data.SqlClient;
internal class Program
{
static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
static void PrintAllContacts()
{
SqlConnection Connection = new SqlConnection(ConnectionString);
string Query = "select * from Contacts";
SqlCommand Command = new SqlCommand(Query, Connection);
try
{
Connection.Open();
SqlDataReader Reader = Command.ExecuteReader();
while (Reader.Read())
{
int ContactID = (int)Reader["ContactID"];
string FirstName = (string)Reader["FirstName"];
string LastName = (string)Reader["LastName"];
string Email = (string)Reader["Email"];
string Phone = (string)Reader["Phone"];
string Address = (string)Reader["Address"];
int CountryID = (int)Reader["CountryID"];
Console.WriteLine($"Contact ID: {ContactID}");
Console.WriteLine($"First Name: {FirstName}");
Console.WriteLine($"Last Name: {LastName}");
Console.WriteLine($"Email: {Email}");
Console.WriteLine($"Phone: {Phone}");
Console.WriteLine($"Address: {Address}");
Console.WriteLine($"Country ID: {CountryID}");
Console.WriteLine();
}
Reader.Close();
Connection.Close();
}
catch (Exception ex)
{
Console.WriteLine(ex.Message);
}
}
static void Main(string[] args)
{
PrintAllContacts();
Console.ReadLine();
}
}
