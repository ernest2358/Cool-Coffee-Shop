using System;
using System.Collections.Generic;
using System.Text;

namespace Cool_Coffee_Shop
{
    public class HeaderBar
    {
        public int HeaderWidth { get; set; }

        public HeaderBar(int width)
        {
            HeaderWidth = width;
        }

        public void DrawHeader()
        {
            var name = "Cool Coffee Shop";
            Console.WriteLine($"+{new String('-', HeaderWidth - 2)}+");
            Console.WriteLine($"|{new String(' ', (HeaderWidth - name.Length) / 2 - 1)}{name}{new String(' ', (HeaderWidth - name.Length) / 2 - 1)}|");
            Console.WriteLine($"+{new String('-',HeaderWidth-2)}+");


        }
    }
}
