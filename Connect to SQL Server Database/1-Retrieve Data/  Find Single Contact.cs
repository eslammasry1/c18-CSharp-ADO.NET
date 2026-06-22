using System;
using System.Data.SqlClient;
using System.Globalization;
internal class Program
{
    static string ConnectionString = "Server=.;Database=Contacts;User Id=sa;Password=sa123456;";
    static bool FindContactByID(int ContactID, ref stContact contact)
    {
        bool IsFound = false;
        SqlConnection connection = new SqlConnection(ConnectionString);
        string quiry = "select * from contacts where ContactID = @ContactID";
        SqlCommand command = new SqlCommand(quiry, connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                IsFound = true;
                contact.ID        = (int)reader["ContactID"];
                contact.FirstName = (string)reader["FirstName"];
                contact.LastName  = (string)reader["LastName"];
                contact.Email     = (string)reader["Email"];
                contact.Phone     = (string)reader["Phone"];
                contact.Address   = (string)reader["Address"];
                contact.CountryID = (int)reader["CountryID"];
            }
            else
            {
                IsFound = false;
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erorr" + ex.Message);
        }
        return IsFound;
    }
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
    static void Main(string[] args)
    {
        stContact Contact = new stContact();
        if (FindContactByID(1, ref Contact))
        {
            Console.WriteLine($"\nContactID = {Contact.ID}");
            Console.WriteLine($"Name = {Contact.FirstName} {Contact.LastName}");
            Console.WriteLine($"Email = {Contact.Email}");
            Console.WriteLine($"Phone = {Contact.Phone}");
            Console.WriteLine($"Address = {Contact.Address}");
            Console.WriteLine($"CountryID = {Contact.CountryID}");
        }
        else
        {
            Console.WriteLine("Eror");
        }
            Console.ReadLine();
    }
}
