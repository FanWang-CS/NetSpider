using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCollection
{
    class ImageHelper
    {
        public Image getImage(int step)
        {
            Image image = Properties.Resources.step1;
            switch (step)
            {
                case 0: image = Properties.Resources.step1; break;
                case 1: image = Properties.Resources.step2; break;
                case 2: image = Properties.Resources.step3; break;
                case 3: image = Properties.Resources.step4; break;
                case 4: image = Properties.Resources.step5; break;
                case 5: image = Properties.Resources.step6; break;
            }
            return image;
        }
    }
}
