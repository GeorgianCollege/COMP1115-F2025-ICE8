using System;

namespace ICE8
{
    enum Career
    {
        Army,
        Psion,
        Rogue,
        Telepath
    }

    public partial class SelectionForm : Form
    {
        // Class Variables
        Random random = new Random();

        string[] Careers = Enum.GetNames<Career>();

        int[][] CareerStats =
        [
            [35, 35, 30, 30, 25, 25], // Army
            [30, 35, 30, 25, 35, 25], // Psion
            [35, 30, 30, 35, 25, 25], // Rogue
            [25, 30, 30, 35, 25, 35]  // Telepath
        ];

        // Declaring Primary Stat TetBox Array
        TextBox[] PrimaryStatTextBoxes;

        // Declaring Secondary Stat TextBox Array
        TextBox[] SecondaryStatTextBoxes;

        /// <summary>
        /// The Constructor for SelectionForm
        /// </summary>
        public SelectionForm()
        {
            InitializeComponent();

            // Populate the ComboBox with career options
            ComboBox_Career.Items.Clear();
            ComboBox_Career.Items.AddRange(Careers);

            // Initialize Primary Stat TextBox Array
            PrimaryStatTextBoxes =
            [
                TextBox_AGL,
                TextBox_STR,
                TextBox_VGR,
                TextBox_PER,
                TextBox_INT,
                TextBox_WIL
            ];

            // Initialize Secondary Stat TextBox Array
            SecondaryStatTextBoxes =
            [
                TextBox_AWA,
                TextBox_TOU,
                TextBox_RES
            ];

        }

        private void Button_Random_Click(object sender, EventArgs e)
        {
            foreach (TextBox stat in PrimaryStatTextBoxes)
            {
                stat.Text = Roll5d10().ToString();
            }

            ComputeSecondaryAttributes();
        }

        private void ComputeSecondaryAttributes()
        {
            TextBox_AWA.Text = (Convert.ToInt32(TextBox_AGL.Text) + Convert.ToInt32(TextBox_PER.Text)).ToString();
            TextBox_TOU.Text = (Convert.ToInt32(TextBox_STR.Text) + Convert.ToInt32(TextBox_VGR.Text)).ToString();
            TextBox_RES.Text = (Convert.ToInt32(TextBox_INT.Text) + Convert.ToInt32(TextBox_WIL.Text)).ToString();
        }

        private void ComboBox_Career_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the ComboBox has been cleared, then return
            if (ComboBox_Career.SelectedIndex < 0) { return; }

            for (int attribute = 0; attribute < PrimaryStatTextBoxes.Length; attribute++)
            {
                PrimaryStatTextBoxes[attribute].Text = CareerStats[ComboBox_Career.SelectedIndex][attribute].ToString();
            }

            ComputeSecondaryAttributes();
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
