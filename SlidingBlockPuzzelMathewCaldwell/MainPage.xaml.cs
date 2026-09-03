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
            MoveImage("Left", image);
        }

        private void SwipeRight(object sender, SwipedEventArgs e)
        {
            Image image = (Image)sender;
            MoveImage("Right", image);
        }

        private void SwipeUp(object sender, SwipedEventArgs e)
        {
            Image image = (Image)sender;
            MoveImage("Up", image);
        }

        private void SwipeDown(object sender, SwipedEventArgs e)
        {
            Image image = (Image)sender;
            MoveImage("Down", image);
        }

        void MoveImage(string direction, Image image)
        {
            if(CanMoveUpOrDown(direction, image))
            {
                Debug.WriteLine("a");
                return;
            }

            Image white = new Image();
            white.Source = ImageSource.FromFile("white_background.png");
            if (!IsWhitePNG(image, white))
            {
                Debug.WriteLine("b");
                return;
            }

            var gridArray = ImageGrid.Children;   
            int index = gridArray.IndexOf(image);

            int nextImageIndex = 0;

            switch (direction)
            {
                case "Up":
                    nextImageIndex = index - 3;
                    break;
                case "Down":
                    nextImageIndex = index + 3;
                    break;
                case "Left":
                    nextImageIndex = index - 1;
                    break;
                case "Right":
                    nextImageIndex = index + 1;
                    break;
            }
            
            Image nextImage = (Image)gridArray[nextImageIndex];
            image.Source = nextImage.Source;
            nextImage.Source = ImageSource.FromFile("white_background.png");
        }

        void Randomize()
        {            
            string[] directionArray = ["Up", "Down", "Left", "Right"];
            for (int i = 0; i < 100; i++)
            {
                var gridArray = ImageGrid.Children;
                int imageIndex = 0;
                foreach(var item in gridArray)
                {
                    Image temp = (Image)item;
                    Image white = new Image();
                    white.Source = ImageSource.FromFile("white_background.png");                    
                    if(IsWhitePNG(temp, white))
                    {
                        imageIndex = gridArray.IndexOf(item);
                    }
                }
                
                Image image = (Image)gridArray[imageIndex];
                string direction = directionArray[new Random().Next(0, 4)];
                while (CanMoveUpOrDown(direction, image))
                {
                    direction = directionArray[new Random().Next(0, 4)];
                }
                MoveImage(direction, image);
            }
        }

        bool CanMoveUpOrDown(string direction, Image image)
        {
            return image.StyleId.Contains("Top") && direction == "Up"
                || image.StyleId.Contains("Bottom") && direction == "Down"
                || image.StyleId.Contains(direction);
        }

        bool IsWhitePNG(Image image1, Image image2)
        {
            if(image1.Source is FileImageSource file1 &&  image2.Source is FileImageSource file2)
            {
                return file1.File == file2.File;
            }
            return false;
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            Randomize();
        }
    }
}
