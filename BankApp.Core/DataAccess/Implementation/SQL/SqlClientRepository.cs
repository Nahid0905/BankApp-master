﻿using BankApp.Core.DataAccess.Abstract;
using BankApp.Core.Domain.Entities;
using BankApp.Core.Extention;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.DataAccess.SQL
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly string connectionString;

        public SqlClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Delete(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Delete from Clients where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public bool Insert(Client client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Insert into Clients values(@Name,@Surname,@FatherName,@FIN,@Seriya,@Phone,@Adress,@IsDeleted,@AccountNumber,@PlaceOfBirth,@Citizenship,@Studies,@Email,@PassportEndTime,@BirthDate,@Country,@City,@AccountingTime,@PassportSubmissionTime,@CardId)";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Surname", client.Surname);
                    cmd.Parameters.AddWithValue("@FatherName", client.FatherName);
                    cmd.Parameters.AddWithValue("@FIN", client.FIN);
                    cmd.Parameters.AddWithValue("@Seriya", client.Seriya);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@Adress", client.Adress);
                    cmd.Parameters.AddWithValue("@IsDeleted", client.IsDeleted);
                    cmd.Parameters.AddWithValue("@AccountNumber", client.AccountNumber);
                    cmd.Parameters.AddWithValue("@PlaceOfBirth", client.PlaceOfBirth);
                    cmd.Parameters.AddWithValue("@Citizenship", client.Citizenship);
                    cmd.Parameters.AddWithValue("@Studies", client.Studies);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@PassportEndTime", client.PassportSubmissionTime);
                    cmd.Parameters.AddWithValue("@BirthDate",client.BirthDate);
                    cmd.Parameters.AddWithValue("@Country", client.Country); 
                    cmd.Parameters.AddWithValue("@City", client.City);
                    cmd.Parameters.AddWithValue("@AccountingTime",DateTime.Now);
                    cmd.Parameters.AddWithValue("@PassportSubmissionTime", client.PassportSubmissionTime);
                    cmd.Parameters.AddWithValue("@CardId", client.CardId);
                    int affectedCount = cmd.ExecuteNonQuery();

                    return affectedCount == 1;
                }
            }
        }


        public List<Client> Get()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select * from Clients where IsDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Client> clients = new List<Client>();

                    while (reader.Read())
                    {
                        Client client = new Client();

                        client.Id = (int)reader["Id"];
                        client.Name = Convert.ToString(reader["Name"]);
                        client.Surname = (string)reader["Surname"];
                        client.FatherName = (string)reader["FatherName"];
                        client.FIN = Convert.ToString(reader["FIN"]);
                        client.Seriya = Convert.ToString(reader["Seriya"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        client.Adress = Convert.ToString(reader["Adress"]);
                        client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        client.AccountNumber = (int)reader["AccountNumber"];
                        client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
                        client.Citizenship = Convert.ToString(reader["Citizenship"]);
                        client.Studies = Convert.ToString(reader["Studies"]);
                        client.Email = Convert.ToString(reader["Email"]);
                        client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
                        client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                        client.Country = Convert.ToString(reader["Country"]);
                        client.City = Convert.ToString(reader["City"]);
                        client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
                        client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);

                        clients.Add(client);
                    }

                    return clients;
                }
            }
        }


        public List<Client> GetRestore()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select* from Clients where IsDeleted = 1";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Client> clients = new List<Client>();

                    while (reader.Read())
                    {
                        Client client = new Client();

                        client.Id = (int)reader["Id"];
                        client.Name = Convert.ToString(reader["Name"]);
                        client.Surname = (string)reader["Surname"];
                        client.FatherName = (string)reader["FatherName"];
                        client.FIN = Convert.ToString(reader["FIN"]);
                        client.Seriya = Convert.ToString(reader["Seriya"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        client.Adress = Convert.ToString(reader["Adress"]);
                        client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        client.AccountNumber = (int)reader["AccountNumber"];
                        client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
                        client.Citizenship = Convert.ToString(reader["Citizenship"]);
                        client.Studies = Convert.ToString(reader["Studies"]);
                        client.Email = Convert.ToString(reader["Email"]);
                        client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
                        client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                        client.Country = Convert.ToString(reader["Country"]);
                        client.City = Convert.ToString(reader["City"]);
                        client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
                        client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
                        clients.Add(client);
                    }

                    return clients;
                }
            }
        }
        public List<Client> GetCard(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Card.Id as CardId,Card.CardNumber,Card.EndDate,Card.TypeCard,Clients.Id,Clients.Name,Clients.Surname,Clients.FatherName,Clients.FIN,Clients.Seriya,Clients.Phone,Clients.Adress,Clients.IsDeleted,Clients.AccountNumber,Clients.PlaceOfBirth,Clients.Citizenship,Clients.Studies,Clients.Email,Clients.PassportEndTime,Clients.BirthDate,Clients.Country,Clients.City,Clients.AccountingTime,Clients.PassportSubmissionTime from Clients inner join Card on Clients.Id = Card.ClientId where clients.IsDeleted = 0 AND card.IsDeleted = 0 AND Clients.Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Client> clients = new List<Client>();


                    while (reader.Read())
                    {
                        Client client = new Client();

                        client.CardId = (int)reader["CardId"];
                        client.Card = new Card()
                        {
                            Id = client.CardId,
                            TypeCard = Convert.ToString(reader["TypeCard"]),
                            CardNumber = Convert.ToString(reader["CardNumber"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"]),
                        };
                        client.Id = (int)reader["Id"];
                        client.Name = Convert.ToString(reader["Name"]);
                        client.Surname = (string)reader["Surname"];
                        client.FatherName = (string)reader["FatherName"];
                        client.FIN = Convert.ToString(reader["FIN"]);
                        client.Seriya = Convert.ToString(reader["Seriya"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        client.Adress = Convert.ToString(reader["Adress"]);
                        client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        client.AccountNumber = (int)reader["AccountNumber"];
                        client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
                        client.Citizenship = Convert.ToString(reader["Citizenship"]);
                        client.Studies = Convert.ToString(reader["Studies"]);
                        client.Email = Convert.ToString(reader["Email"]);
                        client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
                        client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                        client.Country = Convert.ToString(reader["Country"]);
                        client.City = Convert.ToString(reader["City"]);
                        client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
                        client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
                        clients.Add(client);
                    }


                    return clients;
                }
            }
        }

        public Client GetCards(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = "select Card.Id as CardId,Card.CardNumber,Card.EndDate,Card.TypeCard,Clients.Id,Clients.Name,Clients.Surname,Clients.FatherName,Clients.FIN,Clients.Seriya,Clients.Phone,Clients.Adress,Clients.IsDeleted,Clients.AccountNumber,Clients.PlaceOfBirth,Clients.Citizenship,Clients.Studies,Clients.Email,Clients.PassportEndTime,Clients.BirthDate,Clients.Country,Clients.City,Clients.AccountingTime,Clients.PassportSubmissionTime from Clients inner join Card on Clients.Id = Card.ClientId where clients.IsDeleted = 0 AND card.IsDeleted = 0 AND Clients.Id = @Id";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Client client = new Client();

                    while (reader.Read())
                    {
                        client.CardId = (int)reader["CardId"];
                        client.Card = new Card()
                        {
                            Id = client.CardId,
                            CardNumber = Convert.ToString(reader["CardNumber"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"]),
                            TypeCard = Convert.ToString(reader["TypeCard"]),
                        };
                        client.Id = (int)reader["Id"];
                        client.Name = Convert.ToString(reader["Name"]);
                        client.Surname = (string)reader["Surname"];
                        client.FatherName = (string)reader["FatherName"];
                        client.FIN = Convert.ToString(reader["FIN"]);
                        client.Seriya = Convert.ToString(reader["Seriya"]);
                        client.Phone = Convert.ToString(reader["Phone"]);
                        client.Adress = Convert.ToString(reader["Adress"]);
                        client.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                        client.AccountNumber = (int)reader["AccountNumber"];
                        client.PlaceOfBirth = Convert.ToString(reader["PlaceOfBirth"]);
                        client.Citizenship = Convert.ToString(reader["Citizenship"]);
                        client.Studies = Convert.ToString(reader["Studies"]);
                        client.Email = Convert.ToString(reader["Email"]);
                        client.PassportEndTime = Convert.ToDateTime(reader["PassportEndTime"]);
                        client.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                        client.Country = Convert.ToString(reader["Country"]);
                        client.City = Convert.ToString(reader["City"]);
                        client.AccountingTime = Convert.ToDateTime(reader["AccountingTime"]);
                        client.PassportSubmissionTime = Convert.ToDateTime(reader["PassportSubmissionTime"]);
                    }

                    return client;
                }
            }
        }

        public bool Update(Client client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmdText = $"Update Clients set Name = @Name, Surname = @Surname, FatherName = @FatherName, FIN = @FIN, Seriya = @Seriya, Phone = @Phone, Adress = @Adress,AccountNumber=@AccountNumber,PlaceOfBirth=@PlaceOfBirth,Citizenship=@Citizenship,Studies=@Studies,Email=@Email,PassportEndTime=@PassportEndTime,BirthDate=@BirthDate,Country=@Country,City=@City, PassportSubmissionTime=@PassportSubmissionTime, IsDeleted=@IsDeleted where id = @ID";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", client.Id);
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Surname", client.Surname);
                    cmd.Parameters.AddWithValue("@FatherName", client.FatherName);
                    cmd.Parameters.AddWithValue("@FIN", client.FIN);
                    cmd.Parameters.AddWithValue("@Seriya", client.Seriya);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.Parameters.AddWithValue("@Adress", client.Adress);
                    cmd.Parameters.AddWithValue("@AccountNumber", client.AccountNumber);
                    cmd.Parameters.AddWithValue("@PlaceOfBirth", client.PlaceOfBirth);
                    cmd.Parameters.AddWithValue("@Citizenship", client.Citizenship);
                    cmd.Parameters.AddWithValue("@Studies", client.Studies);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@PassportSubmissionTime", client.PassportSubmissionTime);
                    cmd.Parameters.AddWithValue("@PassportEndTime", client.PassportSubmissionTime.AddYears(10));
                    cmd.Parameters.AddWithValue("@BirthDate", client.BirthDate);
                    cmd.Parameters.AddWithValue("@Country", client.Country);
                    cmd.Parameters.AddWithValue("@City", client.City);
                    cmd.Parameters.AddWithValue("@IsDeleted", client.IsDeleted);
                    int affectedCount = cmd.ExecuteNonQuery();


                    return affectedCount == 1;
                }
            }
        }

       


        public Client Get(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Clients where Id= @Id and IsDeleted = 0";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", Id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var bank = GetFromReader(reader);
                    return bank;
                }
                else
                {
                    return null;
                }
            }
        }
        public Client GetRestore(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from Clients where Id= @Id and IsDeleted = 1";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", Id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var bank = GetFromReader(reader);
                    return bank;
                }
                else
                {
                    return null;
                }
            }
        }



        private Client GetFromReader(SqlDataReader reader)
        {
            return new Client
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                Surname = reader.Get<string>("Surname"),
                FatherName = reader.Get<string>("FatherName"),
                FIN = reader.Get<string>("FIN"),
                Seriya = reader.Get<string>("Seriya"),
                Adress = reader.Get<string>("Adress"),
                Phone = reader.Get<string>("Phone"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
                AccountNumber = reader.Get<int>("AccountNumber"),
                PlaceOfBirth = reader.Get<string>("PlaceOfBirth"),
                Citizenship = reader.Get<string>("Citizenship"),
                Studies = reader.Get<string>("Studies"),
                Email = reader.Get<string>("Email"),
                Country = reader.Get<string>("Country"),
                City = reader.Get<string>("City"),
                PassportEndTime = reader.Get<DateTime>("PassportEndTime"),
                PassportSubmissionTime = reader.Get<DateTime>("PassportSubmissionTime"),
                BirthDate = reader.Get<DateTime>("BirthDate"),
                AccountingTime = reader.Get<DateTime>("AccountingTime")
            };
        }

        
    }
}
