using System.Windows;

namespace OCSelectedItemWpfDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new MainWindowViewModel();
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Select last item
        listBox1.SelectedItem = listBox1.Items.OfType<object>().Last();
        listBox2.SelectedItem = listBox2.Items.OfType<object>().Last();
    }
}