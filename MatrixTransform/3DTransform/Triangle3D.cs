using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DTransform
{
    class Triangle3D
    {
        public Vector4 A, B, C;

        public Triangle3D()
        {
            
        }

        public Triangle3D(Vector4 a,Vector4 b,Vector4 c)
        {
            this.A = new Vector4(a);
            this.B = new Vector4(b);
            this.C = new Vector4(c);
        }
    }
}
