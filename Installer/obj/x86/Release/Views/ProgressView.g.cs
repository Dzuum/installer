﻿#pragma checksum "..\..\..\..\Views\ProgressView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2F2157D1DA8DD3E834A54A73063E8517"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.2012
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Installer.Views {
    
    
    /// <summary>
    /// ProgressView
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class ProgressView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Views\ProgressView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Views\ProgressView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox currentOperation;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Views\ProgressView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progress;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\ProgressView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer detailsScroll;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Views\ProgressView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock details;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Asennus;component/views/progressview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ProgressView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nextButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Views\ProgressView.xaml"
            this.nextButton.Click += new System.Windows.RoutedEventHandler(this.NextClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.currentOperation = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.progress = ((System.Windows.Controls.ProgressBar)(target));
            
            #line 72 "..\..\..\..\Views\ProgressView.xaml"
            this.progress.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ProgressValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.detailsScroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.details = ((System.Windows.Controls.TextBlock)(target));
            
            #line 87 "..\..\..\..\Views\ProgressView.xaml"
            this.details.SizeChanged += new System.Windows.SizeChangedEventHandler(this.DetailsSizeChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

