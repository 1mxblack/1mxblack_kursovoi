using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace _1mxblack
{
    class ClassCar
    {
        public static Frame MainFrame { get; set; }
        public static SqlConnection connection { get; set; }
        public static int myId { get; set; }
    }
}
