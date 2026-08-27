using System.Diagnostics;

namespace SlidingBlockPuzzelMathewCaldwell
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void SwipeLeft(object sender, SwipedEventArgs e)
        {
            Image image = (Image)sender;  
            Debug.WriteLine($"Left");
        }

        private void SwipeRight(object sender, SwipedEventArgs e)
        {
            Debug.WriteLine("Right");
        }

        private void SwipeUp(object sender, SwipedEventArgs e)
        {
            Debug.WriteLine("Up");
        }

        private void SwipeDown(object sender, SwipedEventArgs e)
        {
            Debug.WriteLine("Down");
        }
    }
}
