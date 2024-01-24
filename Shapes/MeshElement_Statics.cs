

using System;
using System.Collections.Generic;
using OpenTK;
namespace OpenTKTut.Shapes
{
    partial class MeshElement
    {
        private static double  _converter_factor = Math.PI / 180;
        
        public static MeshElement[] Sphere(double radius)
        {
            List<MeshElement> res = new List<MeshElement>();
            
            int dlta = 10;
            float s = 36;
            float t = 0;
            float s_factor = (dlta/10) / 36f;
            float t_factor = (dlta/10) / 18f;
            
            for (int phi = 0; phi <= 180 - dlta; phi += dlta )//t
            {
                for (int theta = 0; theta <= 360 - dlta; theta += dlta)//s
                {
                    Vector3 _1 = GetCartezianOf(radius, phi, theta);
                    Vector2 _1tex = new Vector2(s * s_factor,t * t_factor);

                    Vector3 _2 = GetCartezianOf(radius, phi + dlta, theta);
                    Vector2 _2tex = new Vector2(s * s_factor,(t+1) * t_factor);

                    Vector3 _3 = GetCartezianOf(radius, phi + dlta, theta + dlta);
                    Vector2 _3tex = new Vector2((s-1) * s_factor,(t+1) * t_factor);

                    Vector3 _4 = GetCartezianOf(radius, phi, theta + dlta);
                    Vector2 _4tex = new Vector2((s-1) * s_factor, t * t_factor);

                    Vector3[] vertices = { _1, _2, _3, _4 };
                    Vector2[] texcoord = { _1tex, _2tex, _3tex, _4tex };
                    res.Add(new MeshElement(vertices, texcoord));
                    s--;
                }
                t++;
            }
            return res.ToArray();
        }

        private static Vector3 GetCartezianOf(double radius, int theta, int phi)
        {
            double th = Convert.ToDouble(theta) * _converter_factor;
            double ph = Convert.ToDouble(phi) * _converter_factor;
            float x = Convert.ToSingle(radius * Math.Sin(th) * Math.Cos(ph));
            float z = Convert.ToSingle(radius * Math.Sin(th) * Math.Sin(ph));
            float y = Convert.ToSingle(radius * Math.Cos(th));
            Vector3 _1 = new Vector3(x, y, z);
            return _1;
        }
    }
}
