
namespace ATMTECH.Common.Utils
{
    /// <summary>
    /// Provides methods for generating random texts.
    /// </summary>
    public static class RandomText
    {
        /// <summary>
        /// Generates an 4 letter random text.
        /// </summary>
        public static string Generate()
        {
            // Generate random text
            string s = "";
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            int index;
            int lenght = RandomNumberStrong.Next(4, 6);
            for (int i = 0; i < lenght; i++)
            {
                index = RandomNumberStrong.Next(chars.Length - 1);
                s += chars[index].ToString();
            }
            return s;
        }
    }
}