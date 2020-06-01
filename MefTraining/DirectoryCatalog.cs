using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ExtensionExports;

namespace MefTraining
{
    public class DirectoryCatalog
    {
        [Import(typeof(IExports))] public IExports Import;

        public void Init()
        {
            var catalogTypeOf = new System.ComponentModel.Composition.Hosting.DirectoryCatalog(".");
            var container = new CompositionContainer(catalogTypeOf);
            container.ComposeParts(this);
            Console.WriteLine(Import.Message);
        }
    }
}