using System.ComponentModel.DataAnnotations;

namespace WebCoreTest.Models
{
    public class VersionInfo
    {
        [Key]
        public long Id { get; set; }
        public long Version { get; set; }
        public DateTime AppliedOn { get; set; }
        public string Description { get; set; }
    }
}
