using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefTraining
{
    public class HelloMefClass
    {
        //ExportedMessage(string) => Message(string)
        [Export] public string ExportedMessage = "HelloMef Exported Message";
        [Import] public string Message;
        public string HelloMef()
        {
            //var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            var catalogTypeOf = new AssemblyCatalog(typeof(HelloMefClass).Assembly);
            var container = new CompositionContainer(catalogTypeOf);
            var p = new HelloMefClass();
            container.ComposeParts(p);
            return $"{p.Message}";
        }
    }

    public class Extensions
    {
        [Export]
        public int GetInteger => 100;
        [Import] public int Integer = 10;

        [Export]
        public double GetResult(double a, double b) => a + b;
        [Import]
        public Func<double, double, double> Result { get; set; }
        
        public string SeparatingExports()
        {
            var catalogTypeOf = new AssemblyCatalog(typeof(Extensions).Assembly);
            var container = new CompositionContainer(catalogTypeOf);
            var p = new Extensions();
            container.ComposeParts(p);
            return $"{p.Integer} + {p.Result(2.2, 2.2)}";
        }
    }

    public class ExportTypesClass
    {
        [Export("Value")] public string Message1 = "Hello Mef 1";
        [Export("Result")] public string Message2 = "Hello Mef 2";
        
        [Import("Value")] public string ImportedMessage1;
        [Import("Result")] public string ImportedMessage2;
        
        public string ExportTypesAndInterfaces()
        {
            var catalogTypeOf = new AssemblyCatalog(typeof(ExportTypesClass).Assembly);
            var container = new CompositionContainer(catalogTypeOf);
            var p = new ExportTypesClass();
            container.ComposeParts(p);
            return $"{p.ImportedMessage1} + {p.ImportedMessage2}";
        }
    }
}