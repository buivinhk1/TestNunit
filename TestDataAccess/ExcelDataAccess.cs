using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using Dapper;
using FsCheck;
using LinqToExcel;

namespace TestNunit.TestDataAccess
{
    public class ExcelDataAccess
    {
        public DataTable ReadData()
        {
            string fileName = @"C:\Users\vbui22\Documents\TestData.xlsx";// going to location file
            string extd = Path.GetExtension(fileName);// take extension file
            DataTable dt = new DataTable();//initializes a new table data
            if (extd.ToLower() == ".xls" || extd.ToLower().Equals(".xlsx"))
            {
                var excel =new ExcelQueryFactory(fileName);
                var User = from user in excel.Worksheet<UserData>("DataSet")
                           select user;
                //using linq to get data excel into UserData
                //generate table data
                dt.Columns.Add("Key");      
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");
                dt.Columns.Add("AppName");
                dt.Columns.Add("Sequence");
                dt.Columns.Add("NodeName");
                foreach(var item in User)
                {
                    dt.Rows.Add(item.Key, item.Username,item.Password,item.AppName,item.Sequence,item.NodeName); //using for to add into columns
                }
                dt.AcceptChanges();
            }
            return dt;
        }
    }
}
