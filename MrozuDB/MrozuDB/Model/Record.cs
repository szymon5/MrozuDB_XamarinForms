using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MrozuDB.Model
{
    public class Record
    {
        public string rec_id { get; set; }
        public string rec_title { get; set; }
        public string rec_artician { get; set; }
        public string Image { get; set; }
        public string ExtendedImage { get; set; }
    }
}
