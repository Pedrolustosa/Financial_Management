using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notification
{
    public class Notifications
    {

        public Notifications()
        {
            Notification = new List<Notifications>();
        }

        [NotMapped]
        public string? NameProperties { get; set; }

        [NotMapped]
        public string? Message { get; set; }

        [NotMapped]
        public List<Notifications>? Notification { get; set; }


        public bool ValidatePropertiesString(string value, string nameProperties)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nameProperties))
            {
                Notification?.Add(new Notifications
                {
                    Message = "Field Required",
                    NameProperties = nameProperties
                });
                return false;
            }
            return true; 
        }

        public bool ValidatePropertiesInt(int value, string nameProperties)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(nameProperties))
            {
                Notification?.Add(new Notifications
                {
                    Message = "Field Required",
                    NameProperties = "nameProperties"
                });
                return false;
            }
            return true;
        }

    }
}
