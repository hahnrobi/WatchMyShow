using System;
using System.Linq;
using System.Windows.Forms;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Forms
{
    public partial class RoomBrowser : Form
    {
        public RoomBrowser()
        {
            InitializeComponent();
            UpdateRoomsList();
        }
        public Room Room { get; private set; }

        private Room[] rooms;
        private void UpdateRoomsList()
        {
            using (TvContext context = new TvContext())
            {
                rooms = context.Rooms.ToArray();
                listView1.Items.Clear();
                foreach (Room room in rooms)
                {
                    listView1.Items.Add(room.RoomId.ToString());
                }
            }
        }
        private void RoomBrowser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                Room = rooms[listView1.SelectedIndices[0]];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Válasszon ki egy szobát.", "Nincs szoba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
    }
}
