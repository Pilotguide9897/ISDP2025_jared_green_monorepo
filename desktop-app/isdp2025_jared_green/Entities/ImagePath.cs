using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idsp2025_jared_green.Entities
{
    public partial class ImagePath
    {
        public int ItemImagePathID { get; set; }
        public int ItemID { get; set; }

        public int ImageID { get; set; }

        public virtual Item Item { get; set; } = null;

        public virtual Image Image { get; set; } = null!;
    }
}
