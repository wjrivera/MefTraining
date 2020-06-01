using System;
using System.ComponentModel.Composition;

namespace ExtensionExports
{
    public interface IExportMetadata
    {
        public string Uppercase { get; }
    }
    
    public interface IExports
    {
        public string Message { get; set; }
    }

    [InheritedExport]
    public interface IInheritedExports
    {
        public string Message { get; set; }
    }
    
    [Export(typeof(IExports))]
    [ExportMetadata("Uppercase", "X")]
    public class ExtensionExportingClass : IExports
    {
        public string Message { get; set; }

        public ExtensionExportingClass()
        {
            Message = "Inner Message 1";
        }
    }
    
    [Export(typeof(IExports))]
    [ExportMetadata("Uppercase", "Y")]
    public class ExtensionExportingClassTwo : IExports
    {
        public string Message { get; set; }

        public ExtensionExportingClassTwo()
        {
            Message = "Inner Message 2";
        }
    }
    
    //[ExportMetadata("Uppercase", "1")]
    public class InheritedExtensionExportingClassOne : IInheritedExports
    {
        public string Message { get; set; }

        public InheritedExtensionExportingClassOne()
        {
            Message = "Inherited Inner Message 1";
        }
    }
    
    //[ExportMetadata("Uppercase", "2")]
    public class InheritedExtensionExportingClassTwo : IInheritedExports
    {
        public string Message { get; set; }

        public InheritedExtensionExportingClassTwo()
        {
            Message = "Inherited Inner Message 2";
        }
    }
}