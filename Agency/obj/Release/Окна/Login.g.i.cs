﻿#pragma checksum "..\..\..\Окна\Login.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7D0A70EB55FE4CF63C7036B81C9F9D892996D1003FAF158308A030852F947B91"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Agency.Окна;
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


namespace Agency.Окна {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\..\Окна\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginIN;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Окна\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordIN;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Окна\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AuthorizationButt;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Окна\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistrationButt;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\Окна\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuestButt;
        
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
            System.Uri resourceLocater = new System.Uri("/Agency;component/%d0%9e%d0%ba%d0%bd%d0%b0/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Окна\Login.xaml"
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
            this.LoginIN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PasswordIN = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AuthorizationButt = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\Окна\Login.xaml"
            this.AuthorizationButt.Click += new System.Windows.RoutedEventHandler(this.AuthorizationButt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RegistrationButt = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\..\Окна\Login.xaml"
            this.RegistrationButt.Click += new System.Windows.RoutedEventHandler(this.GoToRegistr);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GuestButt = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\..\Окна\Login.xaml"
            this.GuestButt.Click += new System.Windows.RoutedEventHandler(this.GuestButt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

