using System.Collections.Generic;

namespace Pronia_start.Models
{
    public class AnotherSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public List<SocialMedia> SocialMedias{ get; set; }
    }
}
