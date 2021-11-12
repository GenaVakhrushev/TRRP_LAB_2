using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ServerSocket
{
    [Serializable]
    public class Record
    {
        int apteka_id, item_id, title_id, group_id, pack_size, country_code, pack_count;
        string apteka_name, apteka_adress, apteka_phone, title, group_name, form, dose, country_name, sell_date;
        float pack_price;

        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "postgres";
        private static string Password = "postgres";
        private static string Port = "5432";

        string connString =
                string.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);

        public Record(IDataReader sqlReader)
        {
            apteka_id = int.Parse(sqlReader[0].ToString());
            apteka_name = sqlReader[1].ToString();
            apteka_adress = sqlReader[2].ToString();
            apteka_phone = sqlReader[3].ToString();
            item_id = int.Parse(sqlReader[4].ToString());
            title_id = int.Parse(sqlReader[5].ToString());
            title = sqlReader[6].ToString();
            group_id = int.Parse(sqlReader[7].ToString());
            group_name = sqlReader[8].ToString();
            form = sqlReader[9].ToString();
            dose = sqlReader[10].ToString();
            pack_size = int.Parse(sqlReader[11].ToString());
            country_code = int.Parse(sqlReader[12].ToString());
            country_name = sqlReader[13].ToString();
            pack_price = float.Parse(sqlReader[14].ToString());
            pack_count = int.Parse(sqlReader[15].ToString());
            sell_date = sqlReader[16].ToString();
        }

        public void WriteToNormalizeDb()
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                int count = 0;

                conn.Open();

                //add apteka
                using(NpgsqlCommand command= new NpgsqlCommand("select count(*) from apteka where id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", apteka_id);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    count = reader.GetInt32(0);
                    reader.Close();
                }

                if(count == 0)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("insert into apteka values (@id, @name, @adress, @phone)", conn))
                    {
                        command.Parameters.AddWithValue("id", apteka_id);
                        command.Parameters.AddWithValue("name", apteka_name);
                        command.Parameters.AddWithValue("adress", apteka_adress);
                        command.Parameters.AddWithValue("phone", apteka_phone);
                        command.ExecuteNonQuery();
                    }
                }

                //add country
                using (NpgsqlCommand command = new NpgsqlCommand("select count(*) from country where id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", country_code);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    count = reader.GetInt32(0);
                    reader.Close();
                }

                if (count == 0)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("insert into country values (@id, @name)", conn))
                    {
                        command.Parameters.AddWithValue("id", country_code);
                        command.Parameters.AddWithValue("name", country_name);
                        command.ExecuteNonQuery();
                    }
                }

                //add group
                using (NpgsqlCommand command = new NpgsqlCommand("select count(*) from \"group\" where id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", group_id);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    count = reader.GetInt32(0);
                    reader.Close();
                }

                if (count == 0)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("insert into \"group\" values (@id, @name)", conn))
                    {
                        command.Parameters.AddWithValue("id", group_id);
                        command.Parameters.AddWithValue("name", group_name);
                        command.ExecuteNonQuery();
                    }
                }

                //add title
                using (NpgsqlCommand command = new NpgsqlCommand("select count(*) from title where id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", title_id);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    count = reader.GetInt32(0);
                    reader.Close();
                }

                if (count == 0)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("insert into title values (@id, @name, @group_id)", conn))
                    {
                        command.Parameters.AddWithValue("id", title_id);
                        command.Parameters.AddWithValue("name", title);
                        command.Parameters.AddWithValue("group_id", group_id);
                        command.ExecuteNonQuery();
                    }
                }

                //add item
                using (NpgsqlCommand command = new NpgsqlCommand("select count(*) from item where id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", item_id);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    count = reader.GetInt32(0);
                    reader.Close();
                }

                if (count == 0)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("insert into item values (@id, @title_id, @form, @dose, @pack_size, @country_code)", conn))
                    {
                        command.Parameters.AddWithValue("id", item_id);
                        command.Parameters.AddWithValue("title_id", title_id);
                        command.Parameters.AddWithValue("form", form);
                        command.Parameters.AddWithValue("dose", dose);
                        command.Parameters.AddWithValue("pack_size", pack_size);
                        command.Parameters.AddWithValue("country_code", country_code);
                        command.ExecuteNonQuery();
                    }
                }

                //add sale
                using (NpgsqlCommand command = new NpgsqlCommand("select count(*) from sale where apteka_id = @apteka_id and item_id = @item_id and sell_date = @sell_date", conn))
                {
                    command.Parameters.AddWithValue("apteka_id", apteka_id);
                    command.Parameters.AddWithValue("item_id", item_id);
                    command.Parameters.AddWithValue("sell_date", sell_date);
                    var reader = command.ExecuteReader();
                    reader.Read();
                    count = reader.GetInt32(0);
                    reader.Close();
                }

                if (count == 0)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand("insert into sale values (@apteka_id, @item_id, @sell_date, @price, @pack_count)", conn))
                    {
                        command.Parameters.AddWithValue("apteka_id", apteka_id);
                        command.Parameters.AddWithValue("item_id", item_id);
                        command.Parameters.AddWithValue("sell_date", sell_date);
                        command.Parameters.AddWithValue("price", pack_price);
                        command.Parameters.AddWithValue("pack_count", pack_count);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
