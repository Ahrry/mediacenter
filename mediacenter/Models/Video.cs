using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mediacenter
{
    public partial class Video
    {
        public Uri Uri
        {
            get 
            { 
                if(this.FileName != null)
                    return new Uri(this.FileName);
                return null;
            }
        }
    }
}
