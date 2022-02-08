using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler
{
    public class Settings
    {
        public Connection Connection { get; set; }
    }

    public class Connection
    {
        public List<string> Urls { get; set; }
    }
}
