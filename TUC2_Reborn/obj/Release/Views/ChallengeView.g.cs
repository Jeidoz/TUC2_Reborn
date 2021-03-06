﻿#pragma checksum "..\..\..\Views\ChallengeView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5B99B57BE22E8CAD985ADD99C8A97C15C7A38ABA2BFDB7DF76F3858349FAC40B"
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
    /// ChallengeView
    /// </summary>
    public partial class ChallengeView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 35 "..\..\..\Views\ChallengeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ChallengeNamesList;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\ChallengeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewChallenge;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\ChallengeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ItemsControl;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\Views\ChallengeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\Views\ChallengeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;
        
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
            System.Uri resourceLocater = new System.Uri("/TUC2_Reborn;component/views/challengeview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ChallengeView.xaml"
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
            this.ChallengeNamesList = ((System.Windows.Controls.ListView)(target));
            
            #line 38 "..\..\..\Views\ChallengeView.xaml"
            this.ChallengeNamesList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ChallengeNamesList_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddNewChallenge = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Views\ChallengeView.xaml"
            this.AddNewChallenge.Click += new System.Windows.RoutedEventHandler(this.AddNewChallenge_OnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ItemsControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 5:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 159 "..\..\..\Views\ChallengeView.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Remove = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\..\Views\ChallengeView.xaml"
            this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 140 "..\..\..\Views\ChallengeView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditTests_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

