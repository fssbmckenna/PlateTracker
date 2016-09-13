using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PlateTracker.ViewModels;

namespace PlateTracker.UI.ViewModels
{
    public interface IMainVM 
    {
        ICommand AddCommand { get; }
        ICommand SaveCommand { get; }
        ICommand CloseCommand { get; }
    }

    public class MainVM : ViewModelBase
    {
        //public RelayCommand<Window> CloseWindowCommand { get; set; }
        private BitmapImage _drawImageBackground = null;
        private string _drawImagePath = @"C:\TEMP\DrawBackground.jpg";

        #region Constructors
        public MainVM()
        {
            PlateObject = new object();
        }

        #endregion

        #region ICommands
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(p => AddPlate(), p => PlateObject != null);
                }
                return _addCommand;
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(p => SavePlate(), p => PlateObject != null);
                }
                return _saveCommand;
            }
        }

        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(p => CloseView(), p => true);
                }
                return _closeCommand;
            }
        }
        #endregion

        #region Properties
        private object _plateObject;
        public object PlateObject
        {
            get { return _plateObject; }
            set
            {
                if (value != _plateObject)
                {
                    _plateObject = value;
                    OnPropertyChanged("PlateObject");
                }
            }
        }

        public BitmapImage DrawImageBackground
        {
            get
            {
                if (_drawImageBackground == null)
                    _drawImageBackground = new BitmapImage();

                if (!string.IsNullOrEmpty(_drawImagePath))
                {
                    _drawImageBackground.BeginInit();
                   // _drawImageBackground.CacheOption = BitmapCacheOption.OnLoad;
                   // _drawImageBackground.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    _drawImageBackground.UriSource = new Uri(_drawImagePath);
                    _drawImageBackground.EndInit();
                }
                return _drawImageBackground;
            }
            set
            {
                if (value != _drawImageBackground)
                {
                    _drawImageBackground = value;
                    OnPropertyChanged("DrawImageBackground");
                }
            }
        }
        #endregion

        #region Methods
        #region Public Methods

        #endregion
        #region Private Methods

        private void AddPlate()
        {
            var msg = "start Add Item";
        }

        private void SavePlate()
        {
            var msg = "save Item";
        }

        private void CloseView()
        {
            var msg = "close view";

            Application.Current.Windows[0].Close();
        }
        #endregion
        #endregion

    }
}
