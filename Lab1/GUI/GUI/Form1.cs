namespace GUI;
using Lab1;
public partial class Form1 : Form
{
    public int Seed, MaxN, Capacity;
    public Form1()
    {
        InitializeComponent();
    }

    // Obsluga kliknięcia przycisku uruchomienia problemu plecakowego
    private void runButton_Click(object sender, EventArgs e)
    {
        // Try/catch do łapania błędów wpisania tesktu zamiast liczb
        try
        {
            // Sprawdzenie ilosci przedmiotow
            if (itemsBox.Text.Length == 0 || int.Parse(itemsBox.Text) < 0)
            {
                MessageBox.Show("Niepoprawna liczba przedmiotow", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Sprawdzenie ziarna mieszania
            else if (seedBox.Text.Length == 0)
            {
                MessageBox.Show("Podaj ziarno mieszania", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Sprawdzenie pojemnosci plecaka
            else if (capacityBox.Text.Length == 0 || int.Parse(capacityBox.Text) < 0)
            {
                MessageBox.Show("Niepoprawna pojemnosc plecaka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    
    // nie mogę skasowac 
    private void label1_Click(object sender, EventArgs e)
    {
     
    }
}
