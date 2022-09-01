using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class DataSetResponse
    {
        [Required]
        public List<int> sortedValue { get; set; }

        [Required]
        public double timeOfCalculation { get; set; }

    }
}
