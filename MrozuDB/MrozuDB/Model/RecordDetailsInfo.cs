using System;
using System.Collections.Generic;
using System.Text;

namespace MrozuDB.Model
{
    public class RecordDetailsInfo
    {
        public struct Layout
        {
            public int Id { get; set; }
            public string ExtendedImage { get; set; }
            public string rec_title { get; set; }
            public string release_date { get; set; }
        };

        public struct listView
        {
            public int Id { get; set; }
            public string number { get; set; }
            public string song_title { get; set; }
            public string duration { get; set; }
            public string Number
            {
                get
                {
                    if (number.Length == 1) number += "    ";
                    else if (number.Length == 2) number += "  ";
                    return number;
                }
            }
        }
        
    }
}
