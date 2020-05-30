using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MefTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            var partOne = new PartOne();
            Console.WriteLine(partOne.Init());

            Console.ReadLine();
        }

        
    }
    public class PartOne
    {
        //ExportedMessage(string) => Message(string)
        [Export] public string ExportedMessage = "Exported Message";
        [Import] public string Message;

        public string Init()
        {
            var section = "Part - 1: ";
            var catalogTypeOf = new AssemblyCatalog(typeof(Program).Assembly);
            //var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalogTypeOf);
            var p = new PartOne();
            container.ComposeParts(p);
            return $"{section}{p.Message}";
        }
    }
}
