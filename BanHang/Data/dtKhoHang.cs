using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BanHang.Data
{
    public class dtKhoHang
    {
        public DataTable LayDanhSachHangTrongKho()
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT [GPM_HangHoaTonKho].*,[GPM_HangHoa].MaHang,[GPM_HangHoa].IDDonViTinh FROM [GPM_HangHoaTonKho],[GPM_HangHoa] WHERE [GPM_HangHoa].ID =  [GPM_HangHoaTonKho].IDHangHoa ";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    return tb;
                }
            }
        }
    }

}