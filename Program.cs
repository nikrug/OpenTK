using OpenTK;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace OpenTKTut
{
    class Program
    {
        static void Main(string[] args)
        {
            string rocket = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\rocket.jpg";
            Bitmap bitmaprocket = new Bitmap(rocket);
            Rectangle rocketrect = new Rectangle(0, 0, bitmaprocket.Width, bitmaprocket.Height);
            BitmapData rocketdata = bitmaprocket.LockBits(rocketrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmaprocket.UnlockBits(rocketdata);
            

            string earth = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\2k_earth_daymap.jpg";
            Bitmap bitmapearth = new Bitmap(earth);
            Rectangle earthrect = new Rectangle(0, 0, bitmapearth.Width, bitmapearth.Height);
            BitmapData earthdata = bitmapearth.LockBits(earthrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapearth.UnlockBits(earthdata);

            string sun = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\Map_of_the_full_sun.jpg";
            Bitmap bitmapsun = new Bitmap(sun);
            Rectangle sunrect = new Rectangle(0, 0, bitmapsun.Width, bitmapsun.Height);
            BitmapData sundata = bitmapsun.LockBits(sunrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapsun.UnlockBits(sundata);
            
            string moon = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\moon.bmp";
            Bitmap bitmapmoon = new Bitmap(moon);
            Rectangle moonrect = new Rectangle(0, 0, bitmapmoon.Width, bitmapmoon.Height);
            BitmapData moondata = bitmapmoon.LockBits(moonrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapmoon.UnlockBits(moondata);
           
            string mercury = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\mercury.jpg";
            Bitmap bitmapmercury = new Bitmap(mercury);
            Rectangle mercuryrect = new Rectangle(0, 0, bitmapmercury.Width, bitmapmercury.Height);
            BitmapData mercurydata = bitmapmercury.LockBits(mercuryrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapmercury.UnlockBits(mercurydata);

            string venus = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\venus1.bmp";
            Bitmap bitmapvenus = new Bitmap(venus);
            Rectangle venusrect = new Rectangle(0, 0, bitmapvenus.Width, bitmapvenus.Height);
            BitmapData venusdata = bitmapvenus.LockBits(venusrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapvenus.UnlockBits(venusdata);

            string mars = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\mars.jpg";
            Bitmap bitmapmars = new Bitmap(mars);
            Rectangle marsrect = new Rectangle(0, 0, bitmapmars.Width, bitmapmars.Height);
            BitmapData marsdata = bitmapmars.LockBits(marsrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapmars.UnlockBits(marsdata);

            string jupiter = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\jupiter.jpg";
            Bitmap bitmapjupiter = new Bitmap(jupiter);
            Rectangle jupiterrect = new Rectangle(0, 0, bitmapjupiter.Width, bitmapjupiter.Height);
            BitmapData jupiterdata = bitmapjupiter.LockBits(jupiterrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapjupiter.UnlockBits(jupiterdata);

            string saturn = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\saturn.jpg";
            Bitmap bitmapsaturn = new Bitmap(saturn);
            Rectangle saturnrect = new Rectangle(0, 0, bitmapsaturn.Width, bitmapsaturn.Height);
            BitmapData saturndata = bitmapsaturn.LockBits(saturnrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapsaturn.UnlockBits(saturndata);

            string uranus = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\uranus.jpg";
            Bitmap bitmapuranus = new Bitmap(uranus);
            Rectangle uranusrect = new Rectangle(0, 0, bitmapuranus.Width, bitmapuranus.Height);
            BitmapData uranusdata = bitmapuranus.LockBits(uranusrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapuranus.UnlockBits(uranusdata);

            string neptune = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\neptune.jpg";
            Bitmap bitmapneptune = new Bitmap(neptune);
            Rectangle neptunerect = new Rectangle(0, 0, bitmapneptune.Width, bitmapneptune.Height);
            BitmapData neptunedata = bitmapneptune.LockBits(neptunerect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapneptune.UnlockBits(neptunedata);


            string pluto = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\pluto.jpg";
            Bitmap bitmappluto = new Bitmap(pluto);
            Rectangle plutorect = new Rectangle(0, 0, bitmappluto.Width, bitmappluto.Height);
            BitmapData plutodata = bitmappluto.LockBits(plutorect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmappluto.UnlockBits(plutodata);


            string saturnrocket = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Textures\texture\saturnrocket.jpeg";
            Bitmap bitmapsaturnrocket = new Bitmap(saturnrocket);
            Rectangle saturnrocketrect = new Rectangle(0, 0, bitmapsaturnrocket.Width, bitmapsaturnrocket.Height);
            BitmapData saturnrocketdata = bitmapsaturnrocket.LockBits(saturnrocketrect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitmapsaturnrocket.UnlockBits(saturnrocketdata);





            Viewport View = new Viewport(sundata, venusdata, marsdata, earthdata, moondata, mercurydata, jupiterdata, saturndata, uranusdata, neptunedata,rocketdata,plutodata,saturnrocketdata);

            for (int i=0;i<100;i++)
            {
                Shapes.Sphere saturn_rocket = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, .07f, true, false, true, 1, 35, .5f, 2.3f, 2+(i*.1f), 13);    //saturn_rocket
                View.AddShape(saturn_rocket);
            }

                     
            View.Start();
        }
    }
}
