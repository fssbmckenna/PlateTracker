﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
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
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Shaders;
using SharpGL.VertexBuffers;
using ShaderProgram = SharpGL.Shaders.ShaderProgram;

namespace PlateTracker.UI.Views
{

    /*public class Square
    {
        public VertexBufferArray[] Vertices;

        public Square()
        {
            Vertices = new VertexBufferArray[4];
        }
    }
   */
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        /*private bool _drawMode = false;
        private Point _startPoint;
        private Line _activeLine;
        float rotatePyramid = 0;
        float rquad = 0;
        private string _type;
        //private UpdateOpenGlObject _updateOpenGl;
        ShaderProgram program = new ShaderProgram();
        float rotation = 0;*/

        //private MainVM _mainVm;

        public MainView(IMainVM vm)
        {
            this.DataContext = vm;
            //vm.CloseWindowCommand = this.Close();
            
            InitializeComponent();
            // _updateOpenGl = vm.UpdateGl(objec)
            // vm.Changed += new UpdateOpenGlObject(OpenGlControl_Update);
           /* vm.Changed += OpenGlControl_Update;
            _type = string.Empty;*/
        }

        #region DrawImage
        /*private void DrawImage_OnMouseDown(object sender, MouseButtonEventArgs e)
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

        }*/
        #endregion

        #region OpenGL
        /*  private void OpenGLControl_OnOpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            

        }

        private void OpenGLControl_OnResized(object sender, OpenGLEventArgs args)
        {
            // Get the OpenGL instance.
            OpenGL gl = openGLControl.OpenGL;
            // Load and clear the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            // Calculate The Aspect Ratio Of The Window
            gl.Perspective(45.0f, (float)gl.RenderContextProvider.Width / (float)gl.RenderContextProvider.Height,
            0.1f, 100.0f);
            // Load the modelview.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void OpenGlControl_Update(object sender, OpenGlObjetUpdateEventsArgs args)
        {
            var _type = args.Type;
            if (_type == "P")
            {
                //show a pyramid
                //OpenGLControl_DrawPyramid(sender, args);
                OpenGLControl_Triangle(sender, args);
            }
            else
            {
                //show a cube
                OpenGLControl_DrawCube(sender, args);
            }
            
        }

        

        private void OpenGLControl_Triangle(object sender, EventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -6.0f);

            //program.Push(gl, null);
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            Teapot tp = new Teapot();
            tp.Draw(gl, 14, 1, OpenGL.GL_FILL);

            rotation += 3.0f;
            //program.Pop(gl, null);

        }

         private void OpenGLControl_DrawPyramid(object sender, EventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Reset the modelview.
            gl.LoadIdentity();
            //  Move into a more central position.
            gl.Translate(-1.5f, 0.0f, -6.0f);
            //  Rotate the cube.
            gl.Rotate(rotatePyramid, 0.0f, 1.0f, 0.0f);

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.End();

            

            gl.Flush();
            //  Rotate the geometry a bit.
            rotatePyramid += 3.0f;

            rquad -= 3.0f;
        }

        
        private void OpenGLControl_DrawCube(object sender, EventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //  Reset the modelview.
            gl.LoadIdentity();
            //  Move into a more central position.
            gl.Translate(1.5f, 0.0f, -12.0f);
            //  Rotate the cube.
            gl.Rotate(rquad, 1.0f, 1.0f, 1.0f);

            //  Provide the cube colors and geometry.
            gl.Begin(OpenGL.GL_QUADS);
          
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, 1.0f, -1.0f);
            gl.Vertex(-1.0f, 1.0f, -1.0f);
            gl.Vertex(-1.0f, 1.0f, 1.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Color(1.0f, 0.5f, 0.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Vertex(-1.0f, 1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, 1.0f, -1.0f);
            gl.Vertex(1.0f, 1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, 1.0f, 1.0f);
            gl.Vertex(-1.0f, 1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(1.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, 1.0f, -1.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.End();
            //  Flush OpenGL.
            gl.Flush();
            
            //  Rotate the geometry a bit.
            rotatePyramid += 3.0f;
            rquad -= 3.0f;
        }
        private void OpenGLControl_OnOpenGLDraw(object sender, EventArgs args)
        {
            if (_type != string.Empty)
            {
                //  Get the OpenGL instance that's been passed to us.
                OpenGL gl = openGLControl.OpenGL;

                // Clear the color and depth buffers. buffers are things that hold the details of the the triangle and the square that we’re going to be drawing 

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                // Reset the modelview matrix.
                gl.LoadIdentity();
                // Move the geometry into a fairly central position.
                gl.Translate(-1.5f, 0.0f, -6.0f);
                // Draw a pyramid. First, rotate the modelview matrix.
                if (_type == "P")
                {
                    gl.Rotate(rotatePyramid, 0.0f, 1.0f, 0.0f);
                    // Start drawing triangles.
                    gl.Begin(OpenGL.GL_TRIANGLES);

                    gl.Color(1.0f, 0.0f, 0.0f);

                    
                }
                else
                {
                    gl.Rotate(rquad, 1.0f, 1.0f, 1.0f);
                    gl.Begin(OpenGL.GL_QUADS);
                    gl.Color(0.0f, 1.0f, 0.0f);
                }

                gl.Vertex(0.0f, 1.0f, 0.0f);
            }
        }*/

        #endregion
    }
}
