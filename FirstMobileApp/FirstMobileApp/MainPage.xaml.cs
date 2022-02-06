using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        private static List<Color> colors = new List<Color>() 
        {
            Color.Green, Color.Red, Color.Blue, Color.Yellow, Color.Orange, Color.Orchid,
            Color.Honeydew,Color.AliceBlue,Color.Chocolate,Color.White,
        };
        private int currentColor = colors.Count/2;

        public MainPage()
        {
            InitializeComponent();

            SubscribeSwipeGestures();
        }

        private void SubscribeSwipeGestures()
        {
            var leftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            leftSwipeGesture.Swiped += OnSwiped;
            var rightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            rightSwipeGesture.Swiped += OnSwiped;

            this.GridContainer.GestureRecognizers.Add(leftSwipeGesture);
            this.GridContainer.GestureRecognizers.Add(rightSwipeGesture);
            this.ZoomContainer.GestureRecognizers.Add(leftSwipeGesture);
            this.ZoomContainer.GestureRecognizers.Add(rightSwipeGesture);

        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    LeftSwipeHandler();
                    break;

                case SwipeDirection.Right:
                    RightSwipeHandler();
                    break ;
            }
        }

        private void RightSwipeHandler()
        {
            if( this.currentColor == 0)
            {
                this.currentColor = MainPage.colors.Count-1;
            }
            else
            {
                this.currentColor = --this.currentColor;
            }
            this.GridContainer.BackgroundColor = MainPage.colors[this.currentColor];
            this.ZoomContainer.BackgroundColor = MainPage.colors[this.currentColor];

        }

        private void LeftSwipeHandler()
        {
            if (this.currentColor == MainPage.colors.Count - 1)
            {
                this.currentColor = 0;
            }
            else
            {
                this.currentColor = ++this.currentColor;
            }
            this.GridContainer.BackgroundColor = MainPage.colors[this.currentColor];
            this.ZoomContainer.BackgroundColor = MainPage.colors[this.currentColor];
        }
    }
}
