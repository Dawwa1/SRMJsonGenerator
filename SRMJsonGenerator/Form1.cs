using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SRMJsonGenerator
{

    public partial class Form1 : Form
    {

        public List<string> paths = new List<string>();
        private ContextMenuStrip listboxContextMenu;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //assign a contextmenustrip
            listboxContextMenu = new ContextMenuStrip();
            listboxContextMenu.Opening += new CancelEventHandler(listboxContextMenu_Opening);

            listBox1.ContextMenuStrip = listboxContextMenu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Filter = "Executables (*.exe)|*.exe";
            ofd.Multiselect = false;

            string[] name_split = ofd.FileName.Split("\\");
            string name = "../" + name_split[name_split.Length - 2] + "/" + name_split[name_split.Length - 1];

            listBox1.Items.Add(name);
            paths.Add(ofd.FileName);
        }

        private void generate_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // Default user folder | Windows: C:/Users/{user} Linux: /home/{user}
                string json_folder_path = path + "\\manifests";
                if (!Directory.Exists(json_folder_path)) { Directory.CreateDirectory(json_folder_path); }

                foreach (var file in Directory.GetFiles(json_folder_path)) // Delete all previous json files
                {
                    File.Delete(file);
                }

                int c = 1;
                foreach (string filename in listBox1.Items)
                {
                    string name = filename.Split("/")[1];

                    var entry = new JsonObject() // JSON obj. for each game
                    {
                        ["title"] = name,
                        ["target"] = get_Path(name),
                        ["startIn"] = Path.GetDirectoryName(get_Path(name)),
                        ["launchOptions"] = "" // Not customizable yet..
                    };
                    var jOptions = new JsonSerializerOptions() { WriteIndented = true };
                    var jString = entry.ToJsonString(jOptions);

                    File.WriteAllText(json_folder_path + "\\manifest" + c.ToString() + ".json", jString);
                    c += 1;
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(Application.ExecutablePath, ex.ToString()); // not tested bc my program is perfect
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //select the item under the mouse pointer
                listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                if (listBox1.SelectedIndex != -1)
                {
                    listboxContextMenu.Show();
                }
            }
        }

        private void listboxContextMenu_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;

            if (menuItem.Name == "Delete")
            {
                paths.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listboxContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //clear the menu and add custom item
            listboxContextMenu.Items.Clear();
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Delete");
            menuItem.Click += new EventHandler(listboxContextMenu_Click);
            menuItem.Name = "Delete";

            listboxContextMenu.Items.Add(menuItem);
        }

        private string get_Path(string name)
        {
            foreach (string filepath in paths)
            {
                if (filepath.Contains(name))
                {
                    return filepath;
                }
            }

            return "";
        }
    }
}