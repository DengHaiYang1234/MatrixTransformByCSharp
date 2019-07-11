using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DTransform
{
    class Matrix4x4
    {
        private double[,] pts;

        public Matrix4x4()
        {
            pts = new double[4, 4];
        }

        public double this[int i, int j]
        {
            get { return pts[i-1, j-1]; }
            set { pts[i - 1, j - 1] = value; }
        }

        public Matrix4x4 Mul(Matrix4x4 m)
        {
            Matrix4x4 newM = new Matrix4x4();
            for (int w = 1; w <= 4; w++)
            {
                for (int h = 1; h <= 4; h++)
                {
                    for (int n = 1; n <= 4; n++)
                    {
                        newM[w, h] = this[w, n]*m[n, h];
                    }
                }
            }

            return newM;
        }


        //需要修改  应该是矩阵*向量
        public Vector4 Mul(Vector4 v)
        {
            double[] newArr = new double[4];
            double[] vArr = v.ToArr();
            for (int c = 1; c <= 4; c++)
            {
                for (int h = 1; h <= 4; h++)
                {
                    newArr[c] += vArr[h]*this[c, h];
                }
            }

            Vector4 newV = new Vector4(newArr);

            return newV;
        }
    }
}
