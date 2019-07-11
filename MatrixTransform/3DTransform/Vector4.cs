using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DTransform
{
    class Vector4
    {
        public double x, y, z, w;

        public Vector4()
        {
            
        }

        public Vector4(double x,double y,double z,double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }


        public Vector4(Vector4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        public Vector4(double[] v)
        {
            if (v.Length != 4)
            {
                Console.WriteLine("有误！Length为:",v.Length);
                return;
            }

            this.x = v[0];
            this.y = v[1];
            this.z = v[2];
            this.w = v[3];
        }

        public double[] ToArr()
        {
            return new double[]
            {
                this.x,
                this.y,
                this.z,
                this.w
            };
        }
    }
}
