using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;

namespace TTAP.Classfiles
{
    public class DataRetrivalClass
    {
        string connStrTSIPASS = ConfigurationManager.ConnectionStrings["TSIPASS"].ConnectionString;
        //string connStrTSIPASS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        string connStrTTAP = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;

        public string Encrypt(string strPassword, string EncKey)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(strPassword);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(EncKey,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);

        }

        private byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        public string Decrypt(string strPassword, string EncKey)
        {

            byte[] cipherBytes = Convert.FromBase64String(strPassword);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(EncKey,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            byte[] decryptedData = Decrypt(cipherBytes,
                pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);

        }

        private byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        public DataSet GenericFillDs(string procedurename, SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(connStrTSIPASS);
            con.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(procedurename, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddRange(sp);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        //public DataSet GenericFillDs(string procedurename)
        //{
        //    SqlConnection con = new SqlConnection(str);
        //    con.Open();

        //    SqlDataAdapter da;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        da = new SqlDataAdapter(procedurename, con);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //}
        public DataSet ValidateLoginNew(string UserID, string Password, string Encpassword, string CreateBy, string Role, string User_level,
                           string Fromname, string DistrictID,string User_Type)//,string Dept
        {
            DataSet ds = new DataSet();
            SqlConnection Scon = new SqlConnection(connStrTTAP);
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter("sp_ValidUser", Scon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (UserID.ToString() == "")
                {
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = UserID.ToString();
                }
                if (Password.ToString() == "")
                {
                    da.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    da.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = Password.ToString();
                }
                if (Encpassword.ToString() == "")
                {
                    da.SelectCommand.Parameters.Add("@Encpassword", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    da.SelectCommand.Parameters.Add("@Encpassword", SqlDbType.VarChar).Value = Encpassword.ToString();
                }
                if (CreateBy != null)
                {
                    da.SelectCommand.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy.ToString();
                    da.SelectCommand.Parameters.Add("@User_name", SqlDbType.VarChar).Value = Role.ToString();
                    da.SelectCommand.Parameters.Add("@User_level", SqlDbType.VarChar).Value = User_level.ToString();
                    da.SelectCommand.Parameters.Add("@User_type", SqlDbType.VarChar).Value = User_Type.ToString();
                    da.SelectCommand.Parameters.Add("@Fromname", SqlDbType.VarChar).Value = Fromname.ToString();
                }
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }

        public string UpdatePasswordAfterLogin(string strPassword, string UserName, string Name)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(connStrTTAP);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[Usp_UpdateUserPassword_AfterLogin]";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@UserName", UserName);
                com.Parameters.AddWithValue("@Password", strPassword);
                com.Parameters.AddWithValue("@Name", Name);

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }   
    }
}