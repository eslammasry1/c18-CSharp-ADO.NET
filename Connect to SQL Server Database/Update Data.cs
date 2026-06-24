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
    static void UpdateContact(int ContactID, stContact Contact)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);

        string query = @"Update Contacts
                                    set FirstName =@FirstName,
                                        LastName =@LastName,
                                        Email =@Email,
                                        Phone =@Phone,
                                        Address = @Address,
                                        CountryID = @CountryID
                                        where ContactId = @ContactID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ContactID", ContactID);
        command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
        command.Parameters.AddWithValue("@LastName", Contact.LastName);
        command.Parameters.AddWithValue("@Email", Contact.Email);
        command.Parameters.AddWithValue("@Phone", Contact.Phone);
        command.Parameters.AddWithValue("@Address", Contact.Address);
        command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
        try
        {
            connection.Open();
            int RowsAffected = command.ExecuteNonQuery();
            if (RowsAffected > 0)
            {
                Console.WriteLine("Record Updated Successfully");
            }
            else
            {
                Console.WriteLine("Failed ");
            }

        }
        catch (Exception ex)
        { Console.WriteLine(ex.ToString()); }

    }

    static void Main(string[] args)
    {
        stContact Contact = new stContact
        {
            FirstName = "Mohamed",
            LastName = "Elmasry",
            Email = "eslamm32@gmail.com",
            Phone = "2345678",
            Address = "125 behira street",
            CountryID = 3
        };
        UpdateContact(21,Contact);
    }
}
