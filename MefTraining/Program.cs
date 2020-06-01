using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using ExtensionExports;

namespace MefTraining
{
    public class Program
    {
        public static void Main()
        {
            //Part 1
            // var helloMef = new HelloMefClass();
            // Console.WriteLine(helloMef.HelloMef().Print(nameof(HelloMefClass)));
            
            // var extensions = new Extensions();
            // Console.WriteLine(extensions.SeparatingExports().Print(nameof(Extensions)));
            
            // var exportTypes = new ExportTypesClass();
            // Console.WriteLine(exportTypes.ExportTypesAndInterfaces().Print(nameof(ExportTypesClass)));
            
            // var extensionImports = new ExtensionImports();
            // extensionImports.Init();
            
            //var extensionImports = new DirectoryCatalog();
            //extensionImports.Init();
            
            //var aggregateImports = new AggregateCatalogClass();
            //aggregateImports.Init();
            
            //var exportMetadataTest = new ExportMetadataClass();
            //exportMetadataTest.Init();
            
            var inheritedExport = new InheritedExportsAndCreationPolicyClass();
            inheritedExport.Init();
            
            
            //Part 2

            //Console.ReadLine();
        }
    }

    public class InheritedExportsAndCreationPolicyClass
    {
        [ImportMany(typeof(IInheritedExports))] 
        public List<Lazy<IInheritedExports>> List;
        
        [ImportMany(typeof(IOtherExportingClass))] 
        public List<Lazy<IOtherExportingClass>> OtherList;

        public void Init()
        {
            var assemblyCatalog = new AssemblyCatalog(typeof(IInheritedExports).Assembly);
            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(assemblyCatalog);
            catalog.Catalogs.Add(assemblyCatalog);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var exports in List)
            {
                Console.WriteLine(exports.Value.Message);
            }
            
            foreach (var exports in OtherList)
            {
                Console.WriteLine(exports.Value.Name);
            }
        }
    }
}
