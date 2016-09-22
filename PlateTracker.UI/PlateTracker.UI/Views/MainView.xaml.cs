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
        private bool _drawMode = false;
        private Point _startPoint;
        private Line _activeLine;

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
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _drawMode = true;
                _startPoint = pos;
                _activeLine = new Line();
                _activeLine.StrokeThickness = 2.0;
                _activeLine.Stroke = System.Windows.Media.Brushes.Black;


            }
        }

        private void DrawImage_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_drawMode)
            {
                var curPoint = e.GetPosition(DrawImage); 
                _activeLine.X1 = _startPoint.X;
                _activeLine.Y1 = _startPoint.Y;
                _activeLine.X2 = curPoint.X;
                _activeLine.Y2 = curPoint.Y;


            }
        }

        private void DrawImage_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_drawMode)
            {
                DrawImage.Children.Add(_activeLine);
                _drawMode = false;
                var endPos = e.GetPosition(DrawImage);
                CreateGrabBox(_startPoint);
                CreateGrabBox(endPos);

            }
        }


        private void CreateGrabBox(Point point)
        {
            
            Rectangle rect = new Rectangle
            {
                Stroke = Brushes.LightBlue,
                StrokeThickness = 7
            };
            
            Canvas.SetLeft(rect, point.X -2);
            Canvas.SetTop(rect, point.Y -2);
            DrawImage.Children.Add(rect);

        }
    }
}
