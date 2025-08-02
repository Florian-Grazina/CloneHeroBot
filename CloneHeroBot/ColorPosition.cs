using CommunityToolkit.Mvvm.ComponentModel;
using System.Drawing;

namespace CloneHeroBot
{
    public partial class ColorPositionVM : ObservableObject
    {
        private readonly ColorsEnum _color;
        public Point Point { get; set; }

        [ObservableProperty]
        private Brush backgroundColor;

        public event EventHandler<PointEventArgs>? SaveCoordinatesRequested;

        public ColorPositionVM(ColorsEnum color)
        {
            _color = color;
            BackgroundColor = GetColorBackground();
        }

        public void SaveCoordonates()
        {
            SaveCoordinatesRequested?.Invoke(this, new PointEventArgs(Point));
        }

        private Brush GetColorBackground()
        {
            return _color switch
            {
                ColorsEnum.Green => Brushes.Green,
                ColorsEnum.Red => Brushes.Red,
                ColorsEnum.Blue => Brushes.Blue,
                ColorsEnum.Yellow => Brushes.Yellow,
                ColorsEnum.Orange => Brushes.Orange,
                _ => Brushes.Transparent
            };
        }

        internal ColorsEnum GetColor() => _color;
    }
}
