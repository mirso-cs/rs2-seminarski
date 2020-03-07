using Source.net.desktop.Auth;
using Source.net.desktop.Post;
using Source.net.desktop.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.net.desktop.Shared
{
    public partial class Index : Form
    {
        private int childFormNumber = 0;

        public Index()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var usersForm = new UsersForm();
            usersForm.MdiParent = this;
            usersForm.WindowState = FormWindowState.Maximized;
            usersForm.Show();
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var postsForm = new PostsForm();
            postsForm.MdiParent = this;
            postsForm.WindowState = FormWindowState.Maximized;
            postsForm.Show();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            TriggerLogin();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TriggerLogin();
        }

        private void TriggerLogin()
        {
            var login = new Login();
            login.MdiParent = this;
            login.FormClosed += new FormClosedEventHandler(PostLogin);
            login.Show();
        }

        private void PostLogin(object sender, EventArgs e)
        {
            bool showTabs = HttpClient.RoleId != infrastructure.Enums.Role.USER;
            userToolStripMenuItem.Visible = showTabs;
            tagsToolStripMenuItem.Visible = showTabs;
            categoriesToolStripMenuItem.Visible = showTabs;
        }
    }
}
