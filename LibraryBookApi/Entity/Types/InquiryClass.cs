using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookApi.Entity.Types
{
    public class InquiryClass
    {
        public enum status_inquiry : sbyte
        {
            rejected,
            in_processing,
            done
        };

        [Key]
        public int id { get; set; }
        [Required, Column(TypeName ="Date"), DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int classTrainess { get; set; }
        [Required, MaxLength(32)]
        public string firstName { get; set; }
        [Required, MaxLength(32)]
        public string lastName { get; set; }
        [MaxLength(32)]
        public string middleName { get; set; }
        
        [Required, MaxLength(1024)]
        public string inquiry { get; set; }
        [Required]
        public status_inquiry status { get; set; }
    }
}
