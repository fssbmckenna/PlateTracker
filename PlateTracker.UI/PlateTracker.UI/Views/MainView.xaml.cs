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
using PlateTracker.UI.ViewModels;
using PlateTracker.UI.Views;

namespace PlateTracker.UI.Views
{
   
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainVM vm)
        {
            this.DataContext = vm;
            //vm.CloseWindowCommand = this.Close();

            InitializeComponent();
        }

        private void DrawImage_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
            var pos = e.GetPosition(DrawImage);
        }
    }
}
