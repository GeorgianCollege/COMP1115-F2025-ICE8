using System;

namespace ICE8
{
    public partial class SelectionForm : Form
    {
        Random random = new Random();
        public SelectionForm()
        {
            InitializeComponent();
        }

        private void Button_Generate_Click(object sender, EventArgs e)
        {
            TextBox_AGL.Text = Roll5d10().ToString();
            TextBox_STR.Text = Roll5d10().ToString();
            TextBox_VGR.Text = Roll5d10().ToString();
            TextBox_PER.Text = Roll5d10().ToString();
            TextBox_INT.Text = Roll5d10().ToString();
            TextBox_WIL.Text = Roll5d10().ToString();
        }

        int Roll5d10()
        {
            int total = 0;
            for (int die = 0; die < 5; die++)
            {
                total += random.Next(1, 11);
            }
            return total;
        }
    }
}
