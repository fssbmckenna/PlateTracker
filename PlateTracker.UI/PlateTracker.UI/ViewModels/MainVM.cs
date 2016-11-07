using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        ICommand UpdateCommand { get; }
        ICommand CloseCommand { get; }
    }

    public delegate void UpdateOpenGlObject(object sender, OpenGlObjetUpdateEventsArgs e);

    public class OpenGlObjetUpdateEventsArgs : EventArgs
    {
        public string Type { get; set; }
    }

    public class MainVM : ViewModelBase
    {
        //public RelayCommand<Window> CloseWindowCommand { get; set; }
        private BitmapImage _drawImageBackground = null;
        private string _drawImagePath = @"C:\TEMP\DrawBackground.jpg";
        private string _glType = "P";

        public event UpdateOpenGlObject Changed;


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

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(p => UpdatePlate(), p => PlateObject != null);
                }
                return _updateCommand;
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

        private TabItem _selectedTabItem;
        public TabItem SelectedTabItem
        {
            get { return _selectedTabItem;}
            set
            {
                _selectedTabItem = value;
                OnPropertyChanged("SelectedTabItem");
            }
        }

        public IOpenGlTutorialViewModel OpenGlTutorialViewModel { get; private set; }
        public IPolygonDrawViewModel PolygonDrawViewModel { get; private set; }

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

        #region Protected Methods

        protected virtual void OnUpdateGl()
        {
            OpenGlObjetUpdateEventsArgs e = new OpenGlObjetUpdateEventsArgs();
            if (Changed != null)
            {
                if (_glType == "P")
                    _glType = "C";
                else
                {
                    _glType = "P";
                }

                e.Type = _glType;
                Changed(this, e);
            }
        }
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

        private void UpdatePlate()
        {
            var msg = "update Item";
            OnUpdateGl();
        }

        private void CloseView()
        {
            var msg = "close view";

            Application.Current.Windows[0].Close();
        }

        private void CreateOpenGLObject()
        {
            /****************************************************************************************
            https://www.opengl.org/discussion_boards/showthread.php/177839-OpenGL-vertex-arrays-in-C

            There are two major different ways to use OpenGL.The deprecated old way, before OpenGL 3, was the fixed function pipeline. 
            This one is easier to use and understand. You do a glBegin(), define a number of vertices with glVertex() / glNormal() / glTexCoord(), 
            and end it all with glEnd().Using glVertexPointer() is a more efficient way to do this.

            But that was the old ways. If you search for tutorials, you will find a lot that use this old style.The new way(since 2008!),
            is to define all your vertex data in buffers that you transfer to the GPU and then write your own shader.Now, you instead use 
            glBufferData()(for example) to transfer data to the GPU, and glVertexAttribPointer() to define the layout if this data.
            This one takes all information about each vertex at the same time (coordinates, normals, texture coordinates, and anything else
            you like).But that means you have to write your own shader, which is the program that executes on the GPU.That is the program 
            that is going to interpret your data. (It was possible to use your own shader before OpenGL 3).

            Now a little about the stride.Suppose you have, in total, 32 bytes of data for each vertex (called vertex attrib data), in a buffer. 
            If that buffer is packed, which means that there are no extra bytes between one record and the next, then you can either set the stride 
            to 0 or to 32.But if your data is, for example, 31 bytes, it will be organized in memory on a 32 byte boundary, with 1 byte as filler. 
            Now you have to define the stride as 32, even though you only have 31 bytes of actual data for each vertex. When programming in C / C++, 
            it is very easy to have full control and understanding of memory allocation for this type of data.I don't know how to use OpenGL from C#, 
            so this you will have to find elsewhere. Or use a language better adapted for OpenGL.


            For a nice tutorial, that also gives good information about 3D programming, see http://www.arcsynthesis.org/gltut/.
            Quote Originally Posted by fiodis  View Post
            On a slightly related note, the reference pages for OpenGL aren't working for me; they just open a new tab which never loads completely. 
            I'm using IE9, so according to the preface they ought to be compatible. Is there something I'm missing, or is there some other place where
            I might access them?
            
            Try using http://www.opengl.org/wiki/Category:Core_API_Reference instead, but it will not show deprecated functions.

    */
        }
        #endregion
        #endregion

    }
}
