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
using System.Threading;

namespace DmScreenV2.forms.tools
{
    /// <summary>
    /// Interaction logic for BattleMap.xaml
    /// </summary>
    public partial class BattleMap : Window
    {
        private bool isMouseDown = false;
        private Nullable<Point> dragStart = null;
        private Rectangle selectedRect;

        public BattleMap()
        {
            InitializeComponent();

        }

        private void RectTest_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectedRect = (Rectangle)sender;
            dragStart = e.GetPosition(selectedRect);
            gridBattleMapSpace.CaptureMouse();
            isMouseDown = true;
            Console.WriteLine("mouse down");
            Console.WriteLine(selectedRect.Margin + "");

        }

        private void RectTest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //SnapToGrid(selectedRect);
            dragStart = null;
            gridBattleMapSpace.ReleaseMouseCapture();
            isMouseDown = false;
            Console.WriteLine("mouse up");
            Console.WriteLine(selectedRect.Margin + "");
        }

        private void RectTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStart != null && isMouseDown == true)
            {
                //Rectangle selectedRect = (Rectangle)sender;
                //rectTest.Margin = new Thickness(e.GetPosition(gridBattleMapSpace).X - dragStart.Value.X,
                //    e.GetPosition(gridBattleMapSpace).Y - dragStart.Value.Y, 0, 0);
                Canvas.SetLeft(selectedRect, e.GetPosition(gridBattleMapSpace).X);
                Canvas.SetLeft(selectedRect, e.GetPosition(gridBattleMapSpace).Y);
                Console.WriteLine("inside if block for mouse move");
                Console.WriteLine(e.GetPosition(gridBattleMapSpace).X + ", " + e.GetPosition(gridBattleMapSpace).Y);
            }
        }



        private void SnapToGrid(Rectangle selectedRect)
        {
            Thickness rectPosition = selectedRect.Margin;
            int rectWidth = Convert.ToInt16(selectedRect.Width); //lol rectWidth
            int currentXPos = Convert.ToInt16(rectPosition.Left);
            int currentYPos = Convert.ToInt16(rectPosition.Top);

            int remainderX = currentXPos % rectWidth;
            int remainderY = currentYPos % rectWidth;
            int remainingDistanceX = rectWidth - remainderX;
            int remainingDistanceY = rectWidth - remainderY;

            //resolve x snapping
            if (remainderX > rectWidth/2)
            {
                //snap to the right
                currentXPos -= remainingDistanceX;
                selectedRect.Margin = new Thickness(currentXPos, currentYPos, 0 , 0);
            }
            else
            {
                //snap to the left
                currentXPos += remainingDistanceX;
                selectedRect.Margin = new Thickness(currentXPos, currentYPos, 0, 0);
            }


            //resolve y snapping
            if (remainderY > rectWidth / 2)
            {
                //snap to the bottom
                currentYPos -= remainingDistanceY;
                selectedRect.Margin = new Thickness(currentXPos, currentYPos, 0, 0);
            }
            else
            {
                //snap to the top
                currentYPos += remainingDistanceY;
                selectedRect.Margin = new Thickness(currentXPos, currentYPos, 0, 0);
            }

        }
    }

}
