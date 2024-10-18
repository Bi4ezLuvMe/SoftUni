using Homies.Common;
using System.ComponentModel.DataAnnotations;

namespace Homies.ViewModels
{
    public class EventAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ModelConstants.Event.NameRequiredError)]
        [MinLength(ModelConstants.Event.NameMinLength)]
        [MaxLength(ModelConstants.Event.NameMaxLength)]
        public string Name { get; set; } = String.Empty;
        [Required(ErrorMessage = ModelConstants.Event.DescriptionRequiredError)]
        [MinLength(ModelConstants.Event.DescriptionMinLength)]
        [MaxLength(ModelConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; } = String.Empty;
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }
        [Required(ErrorMessage =ModelConstants.Event.TypeRequiredError)]
        public int TypeId { get; set; }
        public IList<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
