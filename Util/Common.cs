namespace Util
{
    /// <summary>
    /// 普通工具方法
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 数字格式化输出
        /// </summary>
        /// <param name="number">输入数字</param>
        /// <param name="format">格式</param>
        /// <returns>格式化输出字符串</returns>
        public static string NumberFormatOutputToString(double number, string format) {
            return string.Format("{0:F2}", number);   //25.00;
        }
    }
}
