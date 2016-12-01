using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Document;

namespace PlateTracker.ViewModels
{
    public interface IOpenGlTutorialViewModel
    {

        ICommand CommandRun { get; }


    }
    public class OpenGlTutorialViewModel : ViewModelBase, IOpenGlTutorialViewModel
    {

        public OpenGlTutorialViewModel()
        {
            _codeSample = new TextDocument();
            _commandRun = new RelayCommand(p => DoCommandRun(), p => false);
        }

        #region ICommands

        private ICommand _commandRun;

        public ICommand CommandRun
        {
            get
            {
                if (_commandRun == null)
                {
                    _commandRun = new RelayCommand(p => DoCommandRun(), p => false);
                }
                return _commandRun;
            }
            
        }



        #endregion


        private TextDocument _codeSample;
        public TextDocument CodeSample
        {
            get { return _codeSample; }
            set
            {
                _codeSample = value;
                OnPropertyChanged("CodeSample");
            }
        }

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


        #region Methods
        #region Private Methods

        private void DoCommandRun()
        {
            string msg = "do command run";
        }

        private bool DoCommandRunEnabled()
        {
            return true;
        }

        #endregion
        #endregion

    }
}
