using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Document;

namespace PlateTracker.ViewModels
{
    public interface IOpenGlTutorialViewModel
    {
        
    }
    public class OpenGlTutorialViewModel : ViewModelBase, IOpenGlTutorialViewModel
    {

        public OpenGlTutorialViewModel()
        {
            
        }

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
    }
}
