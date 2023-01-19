using System;
using GISApps.Assets;
using GISApps.UI;

namespace GISApps.Models
{
    public class Samples
    {
        public static List<Sample> All { get; set; }

        static Samples()
        {
            All = new List<Sample>();

            // Add all samples below:
            All.Add(new Sample
            {
                Category = Category.UI,
                Name = "Text Button",
                FileName = nameof(TextButtonPage)
            });
        }
    }
}

