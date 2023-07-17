using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using LinqToExcel.Attributes;

namespace TestNunit.TestDataAccess
{

    public class UserData
    {
        [ExcelColumn("Key")]
        public string Key { get; set; }

        [ExcelColumn("Username")]
        public string Username { get; set; }

        [ExcelColumn("Password")]
        public string Password { get; set; }
        [ExcelColumn("AppName")]
        public string AppName { get; set; }

        [ExcelColumn("Sequence")]
        public string Sequence { get; set; }

        [ExcelColumn("NodeName")]
        public string NodeName { get; set; }
    }

}
