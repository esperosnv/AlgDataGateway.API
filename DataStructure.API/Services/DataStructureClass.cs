using System.ComponentModel.DataAnnotations;

namespace DataStructure.API.Services
{
    public class DataStructureClass
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BigONotationValue { get; set; }

        public DataStructureClass(string name, string description, string bigONotation)
        {
            Name = name;
            Description = description;
            BigONotationValue = bigONotation;
        }
    }
}
