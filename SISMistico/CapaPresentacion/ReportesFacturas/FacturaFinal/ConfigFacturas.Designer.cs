﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaPresentacion.ReportesFacturas.FacturaFinal {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
    internal sealed partial class ConfigFacturas : global::System.Configuration.ApplicationSettingsBase {
        
        private static ConfigFacturas defaultInstance = ((ConfigFacturas)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ConfigFacturas())));
        
        public static ConfigFacturas Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Fecha {
            get {
                return ((string)(this["Fecha"]));
            }
            set {
                this["Fecha"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int NumFactura {
            get {
                return ((int)(this["NumFactura"]));
            }
            set {
                this["NumFactura"] = value;
            }
        }
    }
}
