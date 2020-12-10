using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ContainerLoading.Utilities
{
    public class MyUtilities
    {
        public static string Guid
        {
            get { return DateTime.UtcNow.ToString("yyyyMMddHHmmssff"); }
        }

        public static string ServicePath
        {
            get { return Properties.Resources.ServerService_Root + Properties.Resources.ServerService_Package; }
        }

        public static string ServerCabPath
        {
            get { return Properties.Resources.ServerService_Root + Properties.Resources.ServerCab_Package; }
        }
    }
}
