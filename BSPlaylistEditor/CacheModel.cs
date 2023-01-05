using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPlaylistEditor
{
    public class CacheModel
    {
        public int directoryHash { get; set; } = 0;
        public string sha1 { get; set; }
        public float songDuration { get; set; }
    }
}
