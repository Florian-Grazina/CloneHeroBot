using System.Windows;
using System.Windows.Input;

namespace CloneHeroBot
{
    public partial class ColorPickerWindow : Window
    {
        #region fiels
        private readonly ColorPositionVM _colorPosition;
        #endregion

        #region constructor
        public ColorPickerWindow(ColorPositionVM colorPosition)
        {
            InitializeComponent();

            _colorPosition = colorPosition;
            DataContext = _colorPosition;
            _colorPosition.SaveCoordinatesRequested += SaveCoordnates;

            SetPosition();
            Focus();
        }
        #endregion

        #region private methods
        private void SaveCoordnates(object? sender, PointEventArgs e)
        {
            var screenX = (int)(Left + Width / 2);
            var screenY = (int)(Top + Height / 2);

            _colorPosition.Point = new System.Drawing.Point(screenX, screenY);

            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SetPosition()
        {
            Left = _colorPosition.Point.X - Width / 2;
            Top = _colorPosition.Point.Y - Height / 2;
        }

        #endregion
    }
}
