using System;
using System.Data.SqlClient;
using System.Globalization;
internal class Program
{
    static string ConnectionString = "Server=.;Database=Contacts;User Id=sa;Password=sa123456;";
    public struct stContact
    {
        public int ID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }

    }
    static void AddNewContact(stContact Contact)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);
        string quiry = @"INSERT INTO Contacts(FirstName,LastName,Email,Phone,Address,CountryID) 
                       VALUES(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID);
                       select SCOPE_IDENTITY();";
        SqlCommand command = new SqlCommand(quiry, connection);

        command.Parameters.AddWithValue("@FirstName",Contact.FirstName);
        command.Parameters.AddWithValue("@LastName",Contact.LastName);
        command.Parameters.AddWithValue("@Email",Contact.Email);
        command.Parameters.AddWithValue("@Phone",Contact.Phone);
        command.Parameters.AddWithValue("@Address",Contact.Address);
        command.Parameters.AddWithValue("@CountryID",Contact.CountryID);

        try
        {
            connection.Open();
            object Result = command.ExecuteScalar();
            if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
            {
                Console.WriteLine($"Newly Inserted ID = {InsertedID}");
            }
            else
            {
                Console.WriteLine("failed To Retrieve the Inserted ID");

            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
    static void Main(string[] args)
    {
        stContact Contact = new stContact
        {
            FirstName = "ehab",
            LastName = "Elmasry",
            Email = "eslamm32@gmail.com",
            Phone = "2345678",
            Address = "125 behira street",
            CountryID = 3
        };
        AddNewContact(Contact);
    }
}
