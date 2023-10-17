using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SRMJsonGenerator
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> paths = new List<string>();

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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string json_folder_path = path + "\\manifests";
            if (!Directory.Exists(json_folder_path)) { Directory.CreateDirectory(json_folder_path); }

            int c = 1;
            foreach (string filename in listBox1.Items)
            {
                string name = filename.Split("/")[1];

                Debug.WriteLine("here");
                var entry = new JsonObject()
                {
                    ["title"] = name,
                    ["target"] = get_Path(name),
                    ["startIn"] = Path.GetDirectoryName(get_Path(name)),
                    ["launchOptions"] = ""
                };
                var jOptions = new JsonSerializerOptions() { WriteIndented = true };
                var jString = entry.ToJsonString(jOptions);
                
                File.WriteAllText(json_folder_path + "\\manifest" + c.ToString() + ".json", jString);
                c += 1;
            }
        }

        private string get_Path(string name)
        {
            foreach(string filepath in paths)
            {
                if (filepath.Contains(name))
                {
                    return filepath;
                }
            }

            return "";
        }
    }
    public class GameEntry
    {
        public string title { get; set; }
        public string target { get; set; }
        public string startIn { get; set; }
        public string launchOptions { get; set; }
    }
}