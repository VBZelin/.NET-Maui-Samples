using System;
using GISApps.Assets;
using GISApps.UI;
using GISApps.Framework;

namespace GISApps.Models
{
    public class Samples
    {
        public static List<Sample> All { get; private set; }

        static Samples()
        {
            All = new List<Sample>();

            // Add UI samples below:
            AddPage(Category.UI, "Custom image", "Custom image control with loading indicator", nameof(CustomImagePage), typeof(CustomImagePage));

            // Add ArcGIS Runtime samples below:

            // Add Framework samples below:
            AddPage(Category.Framework, "Secure storage", "Secure storage", nameof(SecureStoragePage), typeof(SecureStoragePage));
        }

        static void AddPage(Category category, string name, string detail, string fileName, Type type)
        {
            All.Add(new Sample
            {
                Category = category,
                Name = name,
                Detail = detail,
                FileName = fileName
            });

            Routing.RegisterRoute(fileName, type);
        }
    }
}

