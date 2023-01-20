using System;
using GISApps.Assets;
using GISApps.UI;

namespace GISApps.Models
{
    public class Samples
    {
        public static List<Sample> All { get; private set; }

        static Samples()
        {
            All = new List<Sample>();

            // Add all samples below:
            AddPage(Category.UI, "Text Button", nameof(TextButtonPage), typeof(TextButtonPage));
        }

        static void AddPage(Category category, string name, string fileName, Type type)
        {
            All.Add(new Sample
            {
                Category = category,
                Name = name,
                FileName = fileName
            });

            Routing.RegisterRoute(fileName, type);
        }
    }
}

