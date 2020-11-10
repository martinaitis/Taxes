using System.Collections.Generic;
using System.Data.SQLite;
using TaxesData.Models;

namespace TaxesData
{
    public class SQLiteSourceProvider : ISourceProvider
    {
        private string _connectionString;
        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Municipality GetMunicipality(string municipalityName)
        {
            using SQLiteConnection conn = new SQLiteConnection(_connectionString);
            using SQLiteCommand command = new SQLiteCommand("SELECT * FROM Municipalities WHERE MunicipalityName = @Municipality", conn);
            conn.Open();
            command.Parameters.AddWithValue("@Municipality", municipalityName);
            using SQLiteDataReader reader = command.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
                return new Municipality(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            else
                return null;
        }
        public List<Tax> GetRuleTaxes(string rule)
        {
            List<Tax> taxes = new List<Tax>();

            using SQLiteConnection conn = new SQLiteConnection(_connectionString);
            using SQLiteCommand command = new SQLiteCommand("SELECT * FROM Taxes WHERE Rule = @Rule", conn);
            conn.Open();
            command.Parameters.AddWithValue("@Rule", rule);
            using SQLiteDataReader reader = command.ExecuteReader();

            while(reader.Read())
                taxes.Add(new Tax(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetDouble(3)));

            return taxes;
        }
        public List<Municipality> GetMunicipalities()
        {
            List<Municipality> municipalities = new List<Municipality>();
            using SQLiteConnection conn = new SQLiteConnection(_connectionString);
            using SQLiteCommand command = new SQLiteCommand("SELECT * FROM Municipalities", conn);
            conn.Open();
            using SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
                municipalities.Add(new Municipality(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));

            return municipalities;
        }
    }
}
