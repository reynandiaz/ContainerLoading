﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.9148
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContainerLoading.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ContainerLoading.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ContainerTempData.sdf.
        /// </summary>
        internal static string DatabaseFileName {
            get {
                return ResourceManager.GetString("DatabaseFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 50.
        /// </summary>
        internal static string MaxRows_InOneBatch {
            get {
                return ResourceManager.GetString("MaxRows_InOneBatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data Source=ContainerTempData.sdf;Persist Security Info=False;.
        /// </summary>
        internal static string SDFConnection {
            get {
                return ResourceManager.GetString("SDFConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ContainerCab/index.html.
        /// </summary>
        internal static string ServerCab_Package {
            get {
                return ResourceManager.GetString("ServerCab_Package", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service1.asmx.
        /// </summary>
        internal static string ServerService_Package {
            get {
                return ResourceManager.GetString("ServerService_Package", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://10.11.1.28/ContainerService/.
        /// </summary>
        internal static string ServerService_Root {
            get {
                return ResourceManager.GetString("ServerService_Root", resourceCulture);
            }
        }
    }
}
