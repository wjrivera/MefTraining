/*using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ExtensionExports;

namespace MefTraining
{
    public class ExportMetadataClass
    {
        [ImportMany(typeof(IExports))] 
        public List<Lazy<IExports, IExportMetadata>> List;

        public void Init()
        {
            var directoryCatalog = new DirectoryCatalog(".");
            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(assemblyCatalog);
            catalog.Catalogs.Add(directoryCatalog);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var exports in List)
            {
                Console.WriteLine(exports.Value.Message);
                Console.WriteLine(exports.Metadata.Uppercase);
            }
        }
    }
}*/