﻿#pragma checksum "..\..\..\comicbook.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C92B5972087F1AEBC69BA3F094F64F5C63D46F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Great_Archive;
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


namespace Great_Archive {
    
    
    /// <summary>
    /// comicbook
    /// </summary>
    public partial class comicbook : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 25 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock comicbook_name;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label average_rate;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button writer_button;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pencil_button;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ink_button;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button color_button;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid tags_grid;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock description;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\comicbook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button publicher_name_button;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Great Archive;component/comicbook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\comicbook.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Publishers);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Titles);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Volumes);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Comics);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 19 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Tags);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 20 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Authors);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 21 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UserPage);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 22 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 9:
            this.comicbook_name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.average_rate = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.writer_button = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\comicbook.xaml"
            this.writer_button.Click += new System.Windows.RoutedEventHandler(this.AuthorRedirect);
            
            #line default
            #line hidden
            return;
            case 12:
            this.pencil_button = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\comicbook.xaml"
            this.pencil_button.Click += new System.Windows.RoutedEventHandler(this.AuthorRedirect);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ink_button = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\comicbook.xaml"
            this.ink_button.Click += new System.Windows.RoutedEventHandler(this.AuthorRedirect);
            
            #line default
            #line hidden
            return;
            case 14:
            this.color_button = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\comicbook.xaml"
            this.color_button.Click += new System.Windows.RoutedEventHandler(this.AuthorRedirect);
            
            #line default
            #line hidden
            return;
            case 15:
            this.tags_grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 17:
            
            #line 57 "..\..\..\comicbook.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReaderRedirect);
            
            #line default
            #line hidden
            return;
            case 18:
            this.description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 19:
            this.publicher_name_button = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\comicbook.xaml"
            this.publicher_name_button.Click += new System.Windows.RoutedEventHandler(this.PublisherRedirect);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 16:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 51 "..\..\..\comicbook.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.TagRedirect);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

