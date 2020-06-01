using System.ComponentModel.Composition;

namespace ExtensionExports
{
    public interface IOtherExportingClass
    {
        public string Name { get; set; }
        
    }
 
    //singleton pattern
    [Export(typeof(IOtherExportingClass)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SharedCreationExportClass : IOtherExportingClass
    {
        public string Name { get; set; }

        public SharedCreationExportClass()
        {
            Name = "Shared name";
        }
    }
    
    //created every time
    [Export(typeof(IOtherExportingClass)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class NonSharedCreationExportClass : IOtherExportingClass
    {
        public string Name { get; set; }

        public NonSharedCreationExportClass()
        {
            Name = "NonShared name";
        }
    }
    
    //default shared, otherwise whatever is specified
    [Export(typeof(IOtherExportingClass)), PartCreationPolicy(CreationPolicy.Any)]
    public class AnyCreationExportClass : IOtherExportingClass
    {
        public string Name { get; set; }

        public AnyCreationExportClass()
        {
            Name = "Any name";
        }
    }
}