namespace System.Windows.Controls
{
    /// <summary>
    /// Frame扩展类
    /// </summary>
    public static class FrameExtensions
    {
        /// <summary>
        /// 获取框架子控件的数据上下文
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public static object GetDataContext(this Frame frame)
        {
            if (frame.Content is FrameworkElement element)
            {
                return element.DataContext;
            }

            return null;
        }
        /// <summary>
        /// 移除可以回滚的导航导航
        /// </summary>
        /// <param name="frame"></param>
        public static void CleanNavigation(this Frame frame)
        {
            while (frame.CanGoBack)
            {
                
                frame.RemoveBackEntry();
            }
        }
    }
}
