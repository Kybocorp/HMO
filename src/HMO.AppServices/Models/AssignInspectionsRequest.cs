using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMO.AppServices.Models
{
    public class AssignInspectionsRequest
    {
        [Required]
        public int OfficerId { get; set; }
        [Required]
        public int AssignedById { get; set; }
        [Required]
        public IEnumerable<int> InspectionIds { get; set; }
    }
}
