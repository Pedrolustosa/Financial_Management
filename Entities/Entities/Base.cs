using Entities.Notification;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Base : Notifications
    {
        [Display(Name = "Code")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }
    }
}
