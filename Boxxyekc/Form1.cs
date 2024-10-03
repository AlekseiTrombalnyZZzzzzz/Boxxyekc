using System.Security.Cryptography.Xml;

namespace Boxxyekc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Comands> cmds = new List<Comands>() { };

            string text = textBox1.Text + "\n";

            for (; text != "";) 
            {
                string line = text[0..text.IndexOf("\n")];

                try
                {
                    cmds.Add(
                        new(
                        line[0..text.IndexOf("(")],
                        line[(text.IndexOf("(") + 1)..text.IndexOf(")")]
                        )
                    );
                }
                catch (Exception ex) {  }
                
                text = text[(text.IndexOf("\n") + 1)..^0];

                if (cmds[cmds.Count - 1].key == "for")
                {
                    cmds[cmds.Count - 1].value = cmds[cmds.Count - 2].value;

                    string forline = "";

                    for (int i = 0; i < int.Parse(cmds[cmds.Count - 1].value) - 1; i++)
                        forline += text[0..text.IndexOf("}")];

                    text = text.Insert(text.IndexOf("}"), forline);
                }
            }
            Form2 form2 = new Form2(cmds);
            form2.Show();
        }
    }

    public class Comands(string key, string value)
    {
        public string key = key;
        public string value = value;
    }

}
