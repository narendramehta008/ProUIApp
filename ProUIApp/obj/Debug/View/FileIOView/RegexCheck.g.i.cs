﻿#pragma checksum "..\..\..\..\View\FileIOView\RegexCheck.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9C4F83B5FC521CE7D0DFE91800EB3EA3FD1D44CA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProUIApp.View.FileIOView;
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


namespace ProUIApp.View.FileIOView {
    
    
    /// <summary>
    /// RegexCheck
    /// </summary>
    public partial class RegexCheck : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Regex;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Group_1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Submit;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Clear;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFilePath;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Rows;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBrowseFile;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_ExportCSV;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RichTextBox_Source;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox_Result;
        
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
            System.Uri resourceLocater = new System.Uri("/ProUIApp;component/view/fileioview/regexcheck.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
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
            this.TextBox_Regex = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBox_Group_1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Button_Submit = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
            this.Button_Submit.Click += new System.Windows.RoutedEventHandler(this.Submit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Button_Clear = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
            this.Button_Clear.Click += new System.Windows.RoutedEventHandler(this.Button_Clear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxFilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Rows = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ButtonBrowseFile = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
            this.ButtonBrowseFile.Click += new System.Windows.RoutedEventHandler(this.ButtonBrowseFile_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Button_ExportCSV = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\View\FileIOView\RegexCheck.xaml"
            this.Button_ExportCSV.Click += new System.Windows.RoutedEventHandler(this.Button_ExportCSV_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RichTextBox_Source = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.ListBox_Result = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

