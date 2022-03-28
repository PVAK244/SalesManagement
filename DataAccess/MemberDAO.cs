using BusinessObject;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccess
{
    public class MemberDAO : DatabaseAcess
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();

        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<MemberObject> GetMemberList()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new("SELECT MemberId, Email, CompanyName, " +
                "City, Country, [Password] FROM Member", conn);
                SqlDataReader reader = command.ExecuteReader();
                var members = new List<MemberObject>();
                while (reader.Read())
                {
                    members.Add(new MemberObject
                    {
                        MemberID = reader.GetInt32(0),
                        Email = reader.GetString(1),
                        CompanyName = reader.GetString(2),
                        City = reader.GetString(3),
                        Country = reader.GetString(4),
                        Password = reader.GetString(5)
                    });
                }
                return members;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public MemberObject GetMemberByID(int memberId)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new("SELECT MemberId, Email, CompanyName, " +
                    $"City, Country, [Password] FROM Member WHERE MemberId = {memberId}", conn);
                SqlDataReader reader = command.ExecuteReader();
                MemberObject member = null;
                if (reader.Read())
                {
                    member = new MemberObject
                    {
                        MemberID = reader.GetInt32(0),
                        Email = reader.GetString(1),
                        CompanyName = reader.GetString(2),
                        City = reader.GetString(3),
                        Country = reader.GetString(4),
                        Password = reader.GetString(5)
                    };
                }
                return member;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void AddNew(MemberObject member)
        {
            try
            {
                OpenConnection();
                string sql = $"INSERT into Member VALUES ('{member.Email}', '{member.CompanyName}', '{member.City}', '{member.Country}', '{member.Password}')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(MemberObject member)
        {
            try
            {
                OpenConnection();
                string sql = $"UPDATE Member SET Email = '{member.Email}', CompanyName = '{member.CompanyName}', City = '{member.City}', " +
                        $"Country = '{member.Country}', Password = '{member.Password}' WHERE MemberId = {member.MemberID}";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int memberId)
        {
            try
            {
                OpenConnection();
                string sql = $"DELETE Member WHERE MemberId = {memberId}";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public MemberObject LogIn(string email, string password)
        {
            try
            {
                var member = GetMemberList().FirstOrDefault(x => x.Email == email && x.Password == password);
                return member;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
