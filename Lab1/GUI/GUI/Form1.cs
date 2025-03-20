namespace GUI;
using Lab1;
public partial class Form1 : Form
{
    public int Seed, MaxN, Capacity;
    public Form1()
    {
        InitializeComponent();
    }

    private void runButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (itemsBox.Text.Length == 0 || int.Parse(itemsBox.Text) < 0)
            {
                MessageBox.Show("Niepoprawna liczba przedmiotów", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (seedBox.Text.Length == 0)
            {
                MessageBox.Show("Podaj ziarno mieszania", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (capacityBox.Text.Length == 0 || int.Parse(capacityBox.Text) < 0)
            {
                MessageBox.Show("Niepoprawna pojemność plecaka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MaxN = int.Parse(itemsBox.Text);
            Seed = int.Parse(seedBox.Text);
            Capacity = int.Parse(capacityBox.Text);
        }
        catch
        {
            return;
        }
        
        Problem problem = new Problem(MaxN, Seed);
        
        instanceBox.Text = problem.ToString();
        resultsBox.Text = problem.Solve(Capacity).ToString();
    }

    private void label1_Click(object sender, EventArgs e)
    {
     
    }
}
