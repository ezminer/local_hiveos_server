// Updated by XamlIntelliSenseFileGenerator 2022/2/13 21:29:42
#pragma checksum "..\..\..\..\..\Views\模板配置\矿机列表页.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "546CA4FFF7D019101793D309F0425A09DA142448"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFTemple.Converters;
using WPFTemple.Properties;
using WPFTemple.ViewModels;


namespace WPFTemple.Views
{


    /// <summary>
    /// 矿机列表页
    /// </summary>
    public partial class 矿机列表页 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    {

#line default
#line hidden


#line 27 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;

#line default
#line hidden


#line 54 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SelectAllCheckBox1;

#line default
#line hidden


#line 70 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView datalist;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFTemple;V1.0.0.0;component/views/%e6%a8%a1%e6%9d%bf%e9%85%8d%e7%bd%ae/%e7%9f%b" +
                    "f%e6%9c%ba%e5%88%97%e8%a1%a8%e9%a1%b5.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.view = ((WPFTemple.Views.矿机列表页)(target));
                    return;
                case 2:
                    this.grid1 = ((System.Windows.Controls.Grid)(target));
                    return;
                case 3:
                    this.SelectAllCheckBox1 = ((System.Windows.Controls.CheckBox)(target));

#line 54 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
                    this.SelectAllCheckBox1.Click += new System.Windows.RoutedEventHandler(this.CheckBox_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.datalist = ((System.Windows.Controls.ListView)(target));
                    return;
                case 5:

#line 100 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
                    ((System.Windows.Controls.ContextMenu)(target)).Opened += new System.Windows.RoutedEventHandler(this.ContextMenu_Opened);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 6:

#line 122 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
                    ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);

#line default
#line hidden

#line 123 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
                    ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);

#line default
#line hidden
                    break;
                case 7:

#line 126 "..\..\..\..\..\Views\模板配置\矿机列表页.xaml"
                    ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDoubleClick);

#line default
#line hidden
                    break;
            }
        }

        internal System.Windows.Controls.Page view;
    }
}

