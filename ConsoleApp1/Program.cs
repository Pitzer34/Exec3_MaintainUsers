using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //fgegwegw
        //2516511
        static void Main(string[] args)
        {
        }

        public void Insert()
        {
            string Name = "tt";
            string Account = "xxx";
            string Password = "www";
            DateTime DateOfBirth = new DateTime(2000,01,01);
            int Height = 100;

            string sql = $"INSERT INTO Users_table(Name, Account, Password, DateOfBirth, Height)" +
                $"VALUES('{Name}','{Account}','{Password}','{DateOfBirth}','{Height}')";
        }

        public void Update()
        {
            string sql = @"UPDATE Users_table 
	                       SET Title = @Title, Account = @Account, Password = @Password 
                           WHERE Id = @Id";

            var dbHelper = new SqlDbHelper("default");
            try
            {
                var parameters = new SqlParameterBuilder()
                    .AddNVarchar("title", 50, "dsdasf")
                    .AddNVarchar("Account", 3000, "dasfdsf")
                    .AddNVarchar("Password", 3000, "grgre")
                    .AddNInt("id", 2)
                    .Build();

                dbHelper.ExecuteNonQuery(sql, parameters);

                Console.WriteLine("記錄已 update");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗, 原因 :{ex.Message}");
            }
        }

        public void Delete()
        {
            string sql = @"DELETE FROM Users_table 
                           WHERE Id=@Id";

            var dbHelper = new SqlDbHelper("default");
            try
            {
                var parameters = new SqlParameterBuilder()
                    .AddNInt("id", 2)
                    .Build();

                dbHelper.ExecuteNonQuery(sql, parameters);

                Console.WriteLine("記錄已 delete");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"操作失敗, 原因 :{ex.Message}");
            }
        }

        public void Select()
        {
            var dbHelper = new SqlDbHelper("default");
            string sql = @"SELECT Id, Name, Height
                           FROM Users_table 
                           WHERE Id> @Id  ORDER BY Id ASC";
            try
            {
                var parameters = new SqlParameterBuilder().AddNInt("id", 0).Build();
                DataTable news = dbHelper.Select(sql, parameters);
                foreach (DataRow row in news.Rows)
                {
                    int id = row.Field<int>("id");
                    string Name = row.Field<string>("Name");
                    int Height = row.Field<int>("Height");
                    Console.WriteLine($"Id={id}, Name={Name}, Height={Height}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"連線失敗, 原因 :{ex.Message}");
            }
        }
    }
}
