using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;

namespace CloneHeroBot
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        #region colors
        private readonly IList<ColorPositionVM> _colorPositions;
        private bool _isPickingColors = false;
        #endregion

        public MainWindow()
        {
            _colorPositions =
            [
                new (ColorsEnum.Green) ,
                new (ColorsEnum.Red) ,
                new (ColorsEnum.Blue) ,
                new (ColorsEnum.Yellow) ,
                new (ColorsEnum.Orange)
            ];

            InitializeComponent();
        }

        private void Open_Colors_Picker_Click(object sender, RoutedEventArgs e)
        {
            if (_isPickingColors)
            {
                foreach (ColorPositionVM colorPos in _colorPositions)
                {
                    colorPos.SaveCoordonates();
                }
                _isPickingColors = false;
            }
            else
            {
                foreach (ColorPositionVM colorPos in _colorPositions)
                {
                    var picker = new ColorPickerWindow(colorPos);
                    picker.Show();
                }
                _isPickingColors = true;
            }
        }

        private void Validat_Colors_Picker_Click(object sender, RoutedEventArgs e)
        {
            UpdateColorDebug();
        }

        private void UpdateColorDebug()
        {
            ColorPositionVM colorPosition = _colorPositions
                .FirstOrDefault(c => c.GetColor() == ColorsEnum.Green)
                ?? throw new Exception("Color not found");

            ColorDebug.Background = ColorHelper.ToBrush(GetPixelColorAtCenter(colorPosition));
        }

        private Color GetPixelColorAtCenter(ColorPositionVM colorPosition)
        {
            int x = colorPosition.Point.X;
            int y = colorPosition.Point.Y;

            using var bmp = new Bitmap(1, 1);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(1, 1));
            }
            return bmp.GetPixel(0, 0);
        }
    }
}