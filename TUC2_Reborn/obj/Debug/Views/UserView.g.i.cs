﻿#pragma checksum "..\..\..\Views\UserView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF7E861DE3D664E3933E6AB3BE63E5B7FEC6CA44964EEAB60C0B45D6CD05F5CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using TUC2_Reborn.ViewModels;
using TUC2_Reborn.Views;


namespace TUC2_Reborn.Views {
    
    
    /// <summary>
    /// UserView
    /// </summary>
    public partial class UserView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Views\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Users;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewUser;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ItemControl;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Views\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveUser;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Views\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveUser;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TUC2_Reborn;component/views/userview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Users = ((System.Windows.Controls.ListView)(target));
            
            #line 24 "..\..\..\Views\UserView.xaml"
            this.Users.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Users_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NewUser = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Views\UserView.xaml"
            this.NewUser.Click += new System.Windows.RoutedEventHandler(this.NewUser_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ItemControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 4:
            this.SaveUser = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\Views\UserView.xaml"
            this.SaveUser.Click += new System.Windows.RoutedEventHandler(this.SaveUser_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RemoveUser = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\Views\UserView.xaml"
            this.RemoveUser.Click += new System.Windows.RoutedEventHandler(this.RemoveUser_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

