using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WPF_Brickstore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<Piece> pieces = new();
        public MainWindow()
        {
            InitializeComponent();
            loadFiles();
        }

        public void loadFiles()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    XDocument bsx = XDocument.Load(openFileDialog.FileName);
                    foreach (var elem in bsx.Descendants("Item"))
                    {
                        string id = elem.Element("ItemID").Value;
                        string name = elem.Element("ItemName").Value;
                        string category = elem.Element("CategoryName").Value;
                        string color = elem.Element("ColorName").Value;
                        int quantity = Convert.ToInt32(elem.Element("Qty").Value);
                        Piece newPiece = new Piece(id, name, category, color, quantity);
                        pieces.Add(newPiece);
                    }
                    dgDisplay.ItemsSource = pieces;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private void txtSearchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearchbar.Text != "")
            {
                ObservableCollection<Piece> searchedPieces = new();
                dgDisplay.ItemsSource = searchedPieces;
                if (Char.IsLetter(txtSearchbar.Text[0]))
                {
                    foreach (var item in pieces)
                    {
                        if (item.Name.ToLower().Contains(txtSearchbar.Text.ToLower()) || item.Category.ToLower().Contains(txtSearchbar.Text.ToLower()))
                        {
                            searchedPieces.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in pieces)
                    {
                        if (item.Id.ToLower().Contains(txtSearchbar.Text.ToLower()))
                        {
                            searchedPieces.Add(item);
                        }
                    }
                }
            }
            else
            {
                dgDisplay.ItemsSource = pieces;
            }
        }
    }
}