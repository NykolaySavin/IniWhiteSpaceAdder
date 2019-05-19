using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IniSpaceAdder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string directoryPath = "";
        private string directoryResultPath = "";
        private string getDirectory()
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // Open document 
                    return dialog.SelectedPath;
                }
                return "";
            }
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (directoryPath != null)
            {
                string[] fileArray = Directory.GetFiles(directoryPath);
                foreach (var item in fileArray)
                {
                    List<int> indexes = new List<int>();
                    string text = readFile(item);
                    for (int i = 0; i < text.Length; i++)
                    {
                        int res=0;
                        if(Int32.TryParse(text[i].ToString(),out res)||text[i]== '１' || text[i] == '２' || text[i] == '３' || text[i] == '４' || text[i] == '５' || text[i] == '６' || text[i] == '７' || text[i] == '８' || text[i] == '９' || text[i] == '０')
                        {
                            if(i!=0)
                            {
                                int j = 1;
                                if(!(text[i - j] == '.' || text[i - j] == '+' || text[i - j] == '%' || text[i - j] == '€' || text[i - j] == '$' || text[i - j] == 'x' || text[i - j] == '~' || text[i - j] == '-' || text[i - j] == ',' || text[i - j] == '(' || text[i - j] == ')' || text[i - j] == '…' || text[i - j] == '/' ||  text[i-j]==' '||text[i-j]=='\n'||text[i-j]=='\r'))
                                {
                                    indexes.Add(i);
                                }
                            }
                            while(i<text.Length&&( (Int32.TryParse(text[i].ToString(), out res)) || text[i] == '１' || text[i] == '２' || text[i] == '３' || text[i] == '４' || text[i] == '５' || text[i] == '６' || text[i] == '７' || text[i] == '８' || text[i] == '９' || text[i] == '０'))
                            {
                                i++;
                            }
                            if(i < text.Length && !(text[i]==' '|| text[i] == '.' || text[i] == '+' || text[i] == '%' || text[i] == '€' || text[i] == '$' || text[i] == 'x' || text[i] == '~' || text[i] == '-' || text[i] == ',' || text[i] == '(' || text[i] == ')' || text[i] == '…' || text[i] == '/' || text[i] == '\n' || text[i] == '\r'))
                            {
                                indexes.Add(i);
                            }
                        }
                    }
                    indexes.Sort();
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (indexes.Contains(i))
                        {
                            builder.Append(' ');
                        }
                        builder.Append(text[i]);
                    }
                    var temp = new FileInfo(item).Name;
                    File.WriteAllText(directoryResultPath + "\\" + temp,builder.ToString(), Encoding.GetEncoding("big5"));
                }
            }
            
        }
        private string readFile(string filename)
        {
            string text = File.ReadAllText(filename, Encoding.GetEncoding("big5"));
            return text;
        }
        private void btnCDirectory_Click(object sender, RoutedEventArgs e)
        {
            directoryPath = getDirectory();
            textBoxC.Text = directoryPath;
        }

        private void btnResultDirectory_Click(object sender, RoutedEventArgs e)
        {
            directoryResultPath = getDirectory();
            textBoxResult.Text = directoryResultPath;
        }
    
}
}
