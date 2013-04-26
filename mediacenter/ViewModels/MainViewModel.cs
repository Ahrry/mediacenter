using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Controls;
using mediacenter.DataAccess;
using mediacenter.UserControls;
using mediacenter.Views;
using System.Windows.Input;

namespace mediacenter.ViewModels
{
    public class MainViewModel : WorkspaceViewModel
    {
        #region Champs

        readonly TypeRepository _typeRepository;

        #endregion

        #region Properties

        private Collection<TabItem> tabItems;

        public Collection<TabItem> TabItems
        {
            get { return tabItems; }
            set
            {
                tabItems = value;
                base.OnPropertyChanged("TabItems");
            }
        } 

        #endregion

        #region DataContext

        private void LoadCatégories()
        {
            TabItems = new Collection<TabItem>();
            foreach (Type type in _typeRepository.GetBaseCategories())
            {
                TabItems.Add(new MCTabItem(new Layout(type) ) { Header = type.Libelle });
            }
        }

        #endregion

        #region Constructeur

        public MainViewModel()
        {
            _typeRepository = new TypeRepository();
            LoadCatégories();
        } 

        #endregion

        #region Commands        

        #endregion
    }
}
