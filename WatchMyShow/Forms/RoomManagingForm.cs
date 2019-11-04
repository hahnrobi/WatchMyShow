using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchMyShow.DataClasses;

namespace WatchMyShow.Forms
{
    public partial class RoomManagingForm : Form
    {
        public RoomManagingForm()
        {
            InitializeComponent();
        }

        private void RoomManagingForm_Load(object sender, EventArgs e)
        {
            UpdateRoomsList();
        }
        private void UpdateRoomsList()
        {
            using (TvContext context = new TvContext())
            {
                Room[] rooms = context.Rooms.ToArray();
                this.listView1.Items.Clear();
                foreach (Room room in rooms)
                {
                    this.listView1.Items.Add(room.RoomId.ToString());
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBoxPopup tbp = new TextBoxPopup("Adjon meg egy szobaszámot:");
            if (tbp.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int roomNum = int.Parse(tbp.Input);
                    using(TvContext context = new TvContext())
                    {
                        if(context.Rooms.Find(roomNum) == null)
                        {
                            context.Rooms.Add(new Room() { RoomId = roomNum });
                            context.SaveChanges();
                            UpdateRoomsList();
                        }
                        else
                        {
                            MessageBox.Show("A szoba már létezik.", "Létező szoba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("A beírt érték nem szám. A szobaszám csak szám lehet.", "Hibás érték", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
