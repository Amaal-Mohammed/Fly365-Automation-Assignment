using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Testdata
{
    class ReadData
    {
        public static String Origin;
        public static String Origintown;
        public static String Destination;
        public static String Destinationtown;
        public static String depday;
        public static String returnday;
        public static String Expectedeesult;
        public static String fnametxt;
        public static String familynametxt;
        public static String Password;

        public static void setData(String P)
        {
            String path =P+"\\"+Constants.filename;
            List<String> data = ExcelRead.ReadExcel(path, Constants.Sheet);
            Origin = data[0];
            Origintown = data[1];
            Destination = data[2];
            Destinationtown = data[3];
            depday=data[4];
            returnday = data[5];
            Expectedeesult = data[6];
            fnametxt = data[7];
            familynametxt = data[8];
            Password = data[9];



        }

    }
}
