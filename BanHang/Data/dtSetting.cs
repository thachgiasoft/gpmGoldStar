using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Web;

namespace BanHang.Data
{
    public class dtSetting
    {
        public static string LayIDDonViTinh(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT IDDonViTinh FROM [GPM_HangHoa] WHERE [ID] = " + IDHangHoa;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["IDDonViTinh"].ToString().Trim();
                        return ID;
                    }
                    return null;
                }
            }
        }
        public static string LayMaHang(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT MaHang FROM [GPM_HangHoa] WHERE [ID] = " + IDHangHoa;
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["MaHang"].ToString().Trim();
                        return ID;
                    }
                    return null;
                }
            }
        }
        public static float GiaBan1(string IDHangHoa)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaBan1 FROM [GPM_HangHoa] WHERE [ID] = '" + IDHangHoa + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return float.Parse(dr["GiaBan1"].ToString());
                    }
                    else return -1;
                }
            }
        }
        public static string convertDauSangKhongDau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToUpper();
        } 
        public static string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            byte[] hashData = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data + 123));

            System.Text.StringBuilder returnValue = new System.Text.StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("x"));
            }

            return returnValue.ToString();
        }
    }
}