using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DTransform
{
    public partial class Form1 : Form
    {
        private int a;
        private Triangle3D t;
        //缩放矩阵
        private Matrix4x4 m_Scale;
        private Matrix4x4 m_rotation;
        private Matrix4x4 m_view;
        private Matrix4x4 m_Projection;

        public Form1()
        {
            InitializeComponent();
            m_Scale = new Matrix4x4();
            m_Scale[1, 1] = 250;
            m_Scale[2, 2] = 250;
            m_Scale[3, 3] = 250;
            m_Scale[4, 4] = 1;

            m_view = new Matrix4x4();
            m_view[1, 1] = 1;
            m_view[2, 2] = 1;
            m_view[3, 3] = 1;
            m_view[4, 3] = 250;
            m_view[4, 4] = 1;

            m_Projection = new Matrix4x4();
            m_Projection[1, 1] = 1;
            m_Projection[2, 2] = 1;
            m_Projection[3, 3] = 1;
            m_Projection[3, 4] = 1.0/250;

            m_rotation = new Matrix4x4();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Y方向是相反的
            Vector4 a = new Vector4(0, -0.5, 0, 1);
            Vector4 b = new Vector4(0.5, 0.5, 0, 1);
            Vector4 c = new Vector4(-0.5, 0.5, 0, 1);
            t = new Triangle3D(a, b, c);
            t.Transform(m_Scale);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            t.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a += 2 % 360;
            double angle = a/360.0*Math.PI;
            m_rotation[1, 1] = Math.Cos(angle);
            m_rotation[1, 3] = Math.Sin(angle);
            m_rotation[2, 2] = 1;
            m_rotation[3, 1] = -Math.Sin(angle);
            m_rotation[3, 3] = Math.Cos(angle);
            m_rotation[4, 4] = 1;
            //模型到世界
            Matrix4x4 m = m_Scale.Mul(m_rotation);
            //模型到摄像机
            m = m.Mul(m_view);
            //摄像机到投影
            m = m.Mul(m_Projection);
            t.Transform(m);
            this.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            m_view[4, 3] = (sender as TrackBar).Value;
        }
    }
}
