using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab2._2
{
    public partial class MainWindow : Window
    {
        string OutputFile = "./output.txt";

        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveToFile, CanSaveToFile));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, Clean));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenFile));
        }

        void PasteFromClipboard(object sender, ExecutedRoutedEventArgs e)
        {
            MainTextBox.Text += Clipboard.GetText();
        }
        void Clean(object sender, ExecutedRoutedEventArgs e)
        {
            MainTextBox.Text = "";
        }

        void OpenFile(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
                MainTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
        }

        void CanSaveToFile(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = MainTextBox.Text.Length > 0;
        }

        void SaveToFile(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText(System.IO.Path.GetFullPath(OutputFile), MainTextBox.Text);
        }
    }

}
