﻿using System;
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
using System.Windows.Shapes;
using PlateTracker.ViewModels;

namespace PlateTracker.Views
{
    /// <summary>
    /// Interaction logic for OpenGlTutorialView.xaml
    /// </summary>
    public partial class OpenGlTutorialView : UserControl
    { 
        public OpenGlTutorialView()
        {
            InitializeComponent();
            var vm = new OpenGlTutorialViewModel();
            this.DataContext = vm;
            var test = this.DataContext.GetType();
        }

        public OpenGlTutorialView(IOpenGlTutorialViewModel viewModel)
        {
            this.DataContext = viewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           
            throw new NotImplementedException();
        }
    }
}
