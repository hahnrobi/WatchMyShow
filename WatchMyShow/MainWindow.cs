using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WatchMyShow.DataClasses;

namespace WatchMyShow
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            TvProgram p1 = new TvProgram()
            {
                Title = "Robi a hős",
                AgeLimit = AgeLimit.Above18,
                StartTime = DateTime.Parse("2019.10.27 12:00"),
                EndTime = DateTime.Parse("2019.10.27. 13:00"),
                TvChannel = "M4",
                Genre = TvProgramGenre.Action
            };
            TvProgram p2 = new TvProgram()
            {
                Title = "Hóni a csodás",
                AgeLimit = AgeLimit.Above12,
                StartTime = DateTime.Parse("2019.10.27 13:00"),
                EndTime = DateTime.Parse("2019.10.27. 14:15"),
                TvChannel = "M1",
                Genre = TvProgramGenre.Romantic | TvProgramGenre.Series
            };
            TvProgram p3 = new TvProgram()
            {
                Title = "Elvetemült harcos",
                AgeLimit = AgeLimit.NoLimit,
                StartTime = DateTime.Parse("2019.10.27. 14:15"),
                EndTime = DateTime.Parse("2019.10.27. 18:00"),
                TvChannel = "RTL",
                Genre = TvProgramGenre.Action | TvProgramGenre.Drama
            };
            flowLayoutPanel1.Controls.Add(new TvProgramControl(p1));
            flowLayoutPanel1.Controls.Add(new TvProgramControl(p2));
            flowLayoutPanel1.Controls.Add(new TvProgramControl(p3));
            XmlSerializer ser = new XmlSerializer(typeof(List<TvProgram>));
            List<TvProgram> programs = new List<TvProgram>();
            programs.Add(p1);
            programs.Add(p2);
            programs.Add(p3);
            TextWriter tw = new StreamWriter("teszt.xml");
            ser.Serialize(tw, programs);
            tw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TvProgram p = new TvProgram() { Genre = TvProgramGenre.Action | TvProgramGenre.Documental };
            TvProgramManager.GetGenresAsString(p.Genre);
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<TvProgram>));
            StreamReader sr = new StreamReader("teszt.xml");
            List<TvProgram> a = (List<TvProgram>)ser.Deserialize(sr);
            foreach (var item in a)
            {
                flowLayoutPanel1.Controls.Add(new TvProgramControl(item));
            }
        }
    }
}
