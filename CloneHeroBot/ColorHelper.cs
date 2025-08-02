
namespace CloneHeroBot
{
    internal static class ColorHelper
    {
        public static System.Windows.Media.Color ToMediaColor(System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static System.Drawing.Color ToDrawingColor(System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static System.Windows.Media.SolidColorBrush ToBrush(System.Drawing.Color color)
        {
            return new System.Windows.Media.SolidColorBrush(ToMediaColor(color));
        }

        public static System.Windows.Media.SolidColorBrush ToBrush(System.Windows.Media.Color color)
        {
            return new System.Windows.Media.SolidColorBrush(color);
        }
    }
}
