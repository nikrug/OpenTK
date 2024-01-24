
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace OpenTKTut.Shapes
{
    class Sphere : OGLShape
    {
        public Sphere(Vector3 center, bool isStar, double radius, bool AutoRotate,bool orbiting ,bool moon ,float rotatingSpeed, float RotatingRadius , float orbitingSpeed, float moonorbit , float moonSpeed, int textype, bool isLinearMotion = false, Vector3? linearMotionDirection = null, float linearMotionSpeed = 0)
        {
            _Center = center;
            Radius = radius;
            MeshPolygons = MeshElement.Sphere(Radius); 
            EnableAutoRotate = AutoRotate;
            Orbiting = orbiting;
            Moon = moon;
            RotatingSpeed = rotatingSpeed;
            Rotatingradius = RotatingRadius;
            OrbitingSpeed = orbitingSpeed;
            MoonOrbit = moonorbit;
            MoonSpeed = moonSpeed;
            Textype = textype;
            IsStar = isStar;
            IsLinearMotion = isLinearMotion;
            LinearMotionDirection = linearMotionDirection;
            LinearMotionSpeed = linearMotionSpeed;
        }

        public bool IsLinearMotion { get; set; }
        public Vector3? LinearMotionDirection { get; set; }
        public float LinearMotionSpeed { get; set; }
        public bool IsStar { get; set; } = false;
        public Vector3 EmissionColor { get; set; }
        public double Radius { get; set; }
        public int Textype;

        public void MoveLinearMotion(float deltaTime)
        {
            if (IsLinearMotion && LinearMotionDirection != null)
            {
                _Center += LinearMotionDirection.Value * LinearMotionSpeed * deltaTime;
            }
        }

        protected override void ShapeDrawing()
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            if (IsStar)
            {
                // Включение света для звезды
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);

                float[] lightPosition = { 1f, 1f, 1f, 1f }; // Теперь свет типа точечного
                float[] lightColor = { 0.0f, 2.2f, 0.0f, 1.0f };

                GL.Light(LightName.Light0, LightParameter.Position, lightPosition);
                GL.Light(LightName.Light0, LightParameter.Diffuse, lightColor);
                GL.Light(LightName.Light0, LightParameter.Specular, lightColor);

                // Установка интенсивности света
                float[] lightAmbient = { 1.0f, 0.2f, 0.2f, 100.0f };
                GL.Light(LightName.Light0, LightParameter.Ambient, lightAmbient);

                // Звезда имеет эмиссию
                float[] emission = { 1.0f, 1.0f, 1.0f, 1.0f };
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, emission);
            }
            else
            {
                // Включение освещения и установка параметров материала (пример)
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);

                float[] ambient = { 0.05f, 0.05f, 0.05f, 1f };
                float[] diffuse = { 1f, 1f, 1f, 1f };
                float[] specular = { 1f, 1f, 1f, 1f };

                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, ambient);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, diffuse);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, specular);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, 1f);

                // Отключение эмиссии для других объектов
                float[] noEmission = { 0.1f, 0.1f, 0.1f, 1.0f };
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, noEmission);
            }

            // Установка глобальной интенсивности света
            float[] lightModelAmbient = { 1f, 1, 1f, 0.5f };
            GL.LightModel(LightModelParameter.LightModelAmbient, lightModelAmbient);

            GL.BindTexture(TextureTarget.Texture2D, Textype);

            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < MeshPolygons.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Vector3 normal = MeshPolygons[i].Vertices[j].Normalized(); // Нормализация нормали
                    GL.Normal3(normal);
                    GL.TexCoord2(MeshPolygons[i].Texcoord[j]);
                    GL.Vertex3(MeshPolygons[i].Vertices[j]);
                }
            }
            GL.End();
        }
    }
}
