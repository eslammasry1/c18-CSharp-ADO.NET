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
    static void DeleteContact(int ContactId)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);

        string query = @"delete Contacts
                         where ContactId = @ContactId";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ContactId", ContactId);
        try
        {
            connection.Open();
            int RowsAffected = command.ExecuteNonQuery();
            if (RowsAffected > 0)
            {
                Console.WriteLine("Record Deleted Successfully");
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
        DeleteContact(23);
    }
}
