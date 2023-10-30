namespace Dys_The_Game.Utils
{
    public static class RichText
    {
        public static string Bold(this string text)
        {
            return $"<b>{text}</b>";
        }
        
        public static string Italic(this string text)
        {
            return $"<i>{text}</i>";
        }
        
        public static string Color(this string text, string color)
        {
            return $"<color={color}>{text}</color>";
        }
        
        public static string Size(this string text, int size)
        {
            return $"<size={size}>{text}</size>";
        }
    }

    public static class TextColor
    {
        public static string Black = "black";
        public static string Blue = "blue";
        public static string Cyan = "cyan";
        public static string Gray = "gray";
        public static string Green = "green";
        public static string Magenta = "magenta";
        public static string Red = "red";
        public static string White = "white";
        public static string Yellow = "yellow";
    }
}