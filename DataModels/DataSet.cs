using System.ComponentModel.DataAnnotations;

namespace DataModels
{
    public class DataSet
    {
        [Required]
        public List<int> values { get; set; }
    }
}
