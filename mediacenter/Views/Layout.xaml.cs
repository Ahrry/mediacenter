using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mediacenter.ViewModels;

namespace mediacenter.Views
{
    /// <summary>
    /// Logique d'interaction pour Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        private LayoutViewModel _viewModel;

        public LayoutViewModel ViewModel
        {
            get { return _viewModel; }
            set 
            { 
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        public Layout(Type type)
        {
            InitializeComponent();

            ViewModel = new LayoutViewModel();
            ViewModel.Type = type;
        }
    }
}
