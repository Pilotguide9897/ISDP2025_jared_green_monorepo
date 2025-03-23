using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class ImagePath
{
    public int ItemImagePathID { get; set; }
    public int ItemID { get; set; }

    public int ImageID { get; set; }

    public virtual Item Item { get; set; } = null;

    public virtual Image Image { get; set; } = null!;
}
