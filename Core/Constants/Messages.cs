using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    // Bu class, yalnızca Northwind projesinin mesajları olduğu için Business katmanı içerisinde Contants(Araçlar) kalsöründe tanımlandı.
    public static class Messages
    {
        public static string Listed = "Listed!";
        public static string Added = "Added!";
        public static string Updated = "Updated!";
        public static string Deleted = "Deleted!";
        public static string NotListed = "Not Listed!";
        public static string NotAdded = "Not Added!";
        public static string NotUpdated = "Not Updated!";
        public static string NotDeleted = "Not deleted!";
        public static string NameInvalid = "Invalid Name";
        public static string MaintenanceTime = "Maintenance Time";
        public static string InvalidEntry = "Invalid Entry";
        public static string NotAvailable = "Not Available";
    }
}