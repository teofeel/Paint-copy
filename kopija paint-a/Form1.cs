using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace kopija_paint_a
{
    public partial class Form1 : Form
    {
        //kopija paint-a
        Point trenutna_pozicija = new Point();
        Point stara_pozicija = new Point();
        Graphics g;
        Pen p = new Pen(Color.Black, 1);
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            p.SetLineCap(LineCap.ArrowAnchor, LineCap.Flat, DashCap.Flat);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            stara_pozicija = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                draw_line(e);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                set_brush_size(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                set_brush_size(5);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                set_brush_size(10);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                set_brush_size(20);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            choose_color();
        }

        void draw_line(MouseEventArgs e)
        {
            trenutna_pozicija = e.Location;
            g.DrawLine(p, stara_pozicija, trenutna_pozicija);
            stara_pozicija = trenutna_pozicija;
        }

        void set_brush_size(int n)
        {
            switch (n)
            {
                case 1:
                    p.Width = 1;
                    break;
                case 5:
                    p.Width = 5;
                    break;
                case 10:
                    p.Width = 10;
                    break;
                case 20:
                    p.Width = 20;
                    break;
                default:
                    break;
            }

        }
        void choose_color()
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                p.Color = cd.Color;
            }
        }
    }
}
