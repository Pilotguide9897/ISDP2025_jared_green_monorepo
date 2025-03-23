using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class Image
{
    public int ImageID { get; set; }
    public string ImageName { get; set; } = null!;
        
    public string ImagePath { get; set; } = null!;

    public virtual ICollection<ImagePath> ImagePaths { get; set; } = new List<ImagePath>();

}
