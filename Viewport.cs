
using System;
using OpenTK;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTut
{
    partial class Viewport
    {
        GameWindow _window { get; set; }
        public Viewport(BitmapData TextureData1, BitmapData TextureData2, BitmapData TextureData3, BitmapData TextureData4, BitmapData TextureData5, BitmapData TextureData6, BitmapData TextureData7, BitmapData TextureData8, BitmapData TextureData9, BitmapData TextureData10,BitmapData TextureData11, BitmapData TextureData12, BitmapData TextureData13)
        {
            _window = new GameWindow(920, 920);
            InitializeObjects();
            SetEvents();
            texData1 = TextureData1;
            texData2 = TextureData2;
            texData3 = TextureData3;
            texData4 = TextureData4;
            texData5 = TextureData5;
            texData6 = TextureData6;
            texData7 = TextureData7;
            texData8 = TextureData8;
            texData9 = TextureData9;
            texData10 = TextureData10;
            texData11 = TextureData11;
            texData12 = TextureData12;
            texData13 = TextureData13;

            for (int i = 0; i < 1000; i++)
            {
                starposition[i].X = R1.Next(-70, 70);
                starposition[i].Y = R2.Next(-80, 80);
                starposition[i].Z = R3.Next(-80, 50);
            }
        }

        public BitmapData texData1;
        public BitmapData texData2;
        public BitmapData texData3;
        public BitmapData texData4;
        public BitmapData texData5;
        public BitmapData texData6;
        public BitmapData texData7;
        public BitmapData texData8;
        public BitmapData texData9;
        public BitmapData texData10;
        public BitmapData texData11;
        public BitmapData texData12;
        public BitmapData texData13;

        Random R1 = new Random(4);
        Random R2 = new Random(19);
        Random R3 = new Random(25);

        public Vector3[] starposition = new Vector3[1000];
        
        public void Start()
        {
            _window.Run(60.0);
        }

        public void AddShape(Shapes.OGLShape oGLShape)
        {
            _drawList.Add(oGLShape);
        }
    }
}
