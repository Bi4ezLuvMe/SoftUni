using Homies.Common;
using System.ComponentModel.DataAnnotations;

namespace Homies.ViewModels
{
    public class EventEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ModelConstants.Event.NameRequiredError)]
        [MinLength(ModelConstants.Event.NameMinLength)]
        [MaxLength(ModelConstants.Event.NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = ModelConstants.Event.DescriptionRequiredError)]
        [MinLength(ModelConstants.Event.DescriptionMinLength)]
        [MaxLength(ModelConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        public string Start { get; set; } = null!;
        public string End { get; set; } = null!;
        [Required(ErrorMessage = ModelConstants.Event.TypeRequiredError)]
        public int TypeId { get; set; }
        public IList<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
