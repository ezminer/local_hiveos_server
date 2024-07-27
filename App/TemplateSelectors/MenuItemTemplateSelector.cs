using System.Windows;
using System.Windows.Controls;

using MahApps.Metro.Controls;

namespace MyApp.TemplateSelectors
{
    /// <summary>
    /// 菜单条目选择器
    /// </summary>
    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// 字形数据模板
        /// </summary>
        public DataTemplate GlyphDataTemplate { get; set; }
        /// <summary>
        /// 图片数据模板
        /// </summary>
        public DataTemplate ImageDataTemplate { get; set; }

        /// <summary>
        /// 选择的数据模板
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is HamburgerMenuGlyphItem)
            {
                return GlyphDataTemplate;
            }

            if (item is HamburgerMenuImageItem)
            {
                return ImageDataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
