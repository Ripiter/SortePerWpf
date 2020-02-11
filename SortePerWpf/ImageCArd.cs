using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SortePerWpf
{
    class ImageCard : Image
    {
        public ImageCard(Card card)
        {
            //Uri temp = new Uri("/Assets/" + card.Number + ".png", UriKind.Relative );
            string temp = "/Assets/" + card.ToString() + ".png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(temp, UriKind.Relative);
            bitmap.EndInit();

            Source = bitmap;
        }
    }
}
