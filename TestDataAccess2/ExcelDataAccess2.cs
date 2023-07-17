using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;

namespace TestNunit.TestDataAccess2
{
    class ExcelDataAccess2
    {
        public static string TestDataFileConnection()
        {
            var fileName = @"C:\Users\vbui22\Documents\TestData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static UserData2 GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<UserData2>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
