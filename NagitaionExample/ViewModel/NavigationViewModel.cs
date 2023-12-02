using NavigationExample.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NavigationExample.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private static NavigationViewModel _instanse;

        private Page _currentPage;

        private Page _mainPage = new View.MainPage();
        private Page _gridPage = new View.GridPage();
        private Page _tablePage = new View.TablePage();

        private NavigationViewModel()
        {
            CurrentPage = _mainPage;
        }

        public static NavigationViewModel Instanse
        {
            get
            {
                if (_instanse == null)
                {
                    _instanse = new NavigationViewModel();
                }

                return _instanse;
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }

        public RelayCommand ShowMainPage
        {
            get
            {
                return new RelayCommand((o) => CurrentPage = _mainPage);
            }
        }

        public RelayCommand ShowGridPage
        {
            get
            {
                return new RelayCommand((o) => CurrentPage = _gridPage);
            }
        }

        public RelayCommand ShowTablePage
        {
            get
            {
                return new RelayCommand((o) => CurrentPage = _tablePage);
            }
        }
    }
}
