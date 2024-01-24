
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTKTut.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace OpenTKTut
{
    partial class Viewport : Program
    {

        static Vector3 linearMotionDirection = new Vector3(0.0f, 0.25f, 1.0f); // Движение вдоль оси Z
        static float linearMotionSpeed = 3.0f; // Скорость 10 единиц в секунду

        Shapes.Sphere Sun = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), true, 5, true,false,false, 1, 0, 0, 0,  0, 1); 

        Shapes.Sphere mercury = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, .488, true,true,false, 1, 6, 1.5f, 0, 0, 2);          
        Shapes.Sphere venus = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 1, true, true, false, 2, 11, 1.3f, 0, 0, 3); 
        Shapes.Sphere earth = new Shapes.Sphere(new Vector3( 0.0f,0.0f,43.0f), false, 1.3, true, true, false, 3, 15, 1.1f, 0, 0, 4);
        Shapes.Sphere moon_earth = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 0.7, true, true, true, 1, 15, 1.1f, 1.5f, 2f, 5);     
        Shapes.Sphere mars = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 0.88, true, true, false, 1, 23, .9f, 0, 0, 6); 
        Shapes.Sphere mars_moon = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 0.4f, true, true, true, 1, 23, .9f, 1f, 2f, 5);    
        Shapes.Sphere jupiter = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 2.5, true, true, false, 1, 30, .6f, 0, 0, 7);       
        Shapes.Sphere saturn = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 2, true, true, false, 1, 35, .5f, 0, 0, 8); 
        Shapes.Sphere uranus = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 1.5, true, true, false, 1, 40, .3f, 0, 0, 9); 
        Shapes.Sphere neptune = new Shapes.Sphere(new Vector3(0.0f, 0.0f, 43.0f), false, 1.3, true, true, false, 1, 45, .2f, 0, 0, 10); 
        Shapes.Sphere Comet = new Shapes.Sphere(new Vector3(5f, 15f, 0.0f), true, 2, true, true, false, 1, 50, .4f, 0, 0, 12, true, linearMotionDirection, linearMotionSpeed);

        private List<OGLShape> _drawList;

        public Key _keyPressed;
        int  texture1, texture2, texture3, texture4, texture5, texture6, texture7, texture8, texture9, texture10, texture11,texture12,texture13;

        private void InitializeObjects()
        {
               _drawList = new List<OGLShape>();
               _drawList.Add(earth);
               _drawList.Add(Sun);
               _drawList.Add(mercury);
               _drawList.Add(venus);
               _drawList.Add(moon_earth);
               _drawList.Add(mars);
               _drawList.Add(mars_moon);
               _drawList.Add(jupiter);
               _drawList.Add(uranus);
               _drawList.Add(neptune);
               _drawList.Add(saturn);
               _drawList.Add(Comet);
        }
        
        private void SetEvents()
        {
               
            _window.RenderFrame += _window_RenderFrame;
            _window.Resize += _window_Resize;
            _window.Load += _window_Load;
                              
        }

        private void _window_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            
            //Textures
            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1, out texture1);
            GL.GenTextures(1, out texture2);
            GL.GenTextures(1, out texture3);
            GL.GenTextures(1, out texture4);
            GL.GenTextures(1, out texture5);
            GL.GenTextures(1, out texture6);
            GL.GenTextures(1, out texture7);
            GL.GenTextures(1, out texture8);
            GL.GenTextures(1, out texture9);
            GL.GenTextures(1, out texture10);
            GL.GenTextures(1, out texture11);
            GL.GenTextures(1, out texture12);
            GL.GenTextures(1, out texture13);


            GL.BindTexture(TextureTarget.Texture2D, 1);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData1.Width, texData1.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData1.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 2);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData2.Width, texData2.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData2.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 3);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData3.Width, texData3.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData3.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 4);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData4.Width, texData4.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData4.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 5);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData5.Width, texData5.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData5.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 6);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData6.Width, texData6.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData6.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 7);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData7.Width, texData7.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData7.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 8);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData8.Width, texData8.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData8.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 9);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData9.Width, texData9.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData9.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 10);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData10.Width, texData10.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData10.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, 11);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData11.Width, texData11.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData11.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            
            GL.BindTexture(TextureTarget.Texture2D, 12);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData12.Width, texData12.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData12.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);


            GL.BindTexture(TextureTarget.Texture2D, 13);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData13.Width, texData13.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData13.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();


            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
        }

        private void _window_Resize(object sender, EventArgs e)
        {
            if (_window.Height != 0)
            { 
                GL.Viewport(0, 0, _window.Width, _window.Height);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();         
                Matrix4 prespective = Matrix4.CreatePerspectiveFieldOfView(45f * 3.14f / 180.0f, _window.Width / _window.Height, 0.10f, 150.0f);             
                GL.LoadMatrix(ref prespective);
                GL.MatrixMode(MatrixMode.Modelview);               
            }
        }

        private void _window_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Comet.MoveLinearMotion((float)e.Time);

            Comet.MoveLinearMotion((float)e.Time);

            foreach (var shape in _drawList)
            {
                shape.Draw();
            }

            _window.SwapBuffers();
        }
    }
}
