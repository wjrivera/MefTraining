/*using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ExtensionExports;

namespace MefTraining
{
    public class AggregateCatalogClass
    {
        [Import(typeof(IExports))] public IExports Import;

        public void Init()
        {
            //var assemblyCatalog = new AssemblyCatalog(typeof(IExports).Assembly);
            var directoryCatalog = new DirectoryCatalog(".");
            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(assemblyCatalog);
            catalog.Catalogs.Add(directoryCatalog);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            Console.WriteLine(Import.Message);
        }
    }
}*/