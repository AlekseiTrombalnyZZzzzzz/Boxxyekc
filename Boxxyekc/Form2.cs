using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boxxyekc
{
    public partial class Form2 : Form
    {
        List<Comands> cmds = new List<Comands>() { };
        public Form2(List<Comands> cmds)
        {
            InitializeComponent();
            this.cmds = cmds;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new(Color.Black);
            int x = 200;
            int y = 200;
            float angle = 0;

            for (int i = 0; i < cmds.Count; i++)
            {
                Point point1 = new(x, y);
                if (cmds[i].key == "right")
                    angle += float.Parse(cmds[i].value);
                if (cmds[i].key == "left")
                    angle -= float.Parse(cmds[i].value);
                if (cmds[i].key == "forward")
                {
                    y += (int)(Math.Sin(angle/180 * Math.PI) * float.Parse(cmds[i].value));
                    x += (int)(Math.Cos(angle / 180 * Math.PI) * float.Parse(cmds[i].value)); ;
                }
                
                Point point2 = new(x, y);
                e.Graphics.DrawLine(pen, point1, point2);
            }
        }
    }
}
