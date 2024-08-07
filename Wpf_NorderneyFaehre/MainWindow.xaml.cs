using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Wpf_NorderneyFaehre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FaehreSuchenViewModel();  
            
        }

        #region Formatierung DataGrid Columns
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateOnly))
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "dd.MM.yyyy";
            }
            else if (e.PropertyType == typeof(TimeOnly))
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "HH:mm";
            }
            else if (e.PropertyName == "Auslastung")
            {
                ((DataGridTextColumn)e.Column).Binding.StringFormat = "00%";
            } 
        }
        #endregion

        
    }
}
