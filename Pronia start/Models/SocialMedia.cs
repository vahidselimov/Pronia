namespace Pronia_start.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int SettingId { get; set; }
        public Setting Settings { get; set; }
        public AnotherSetting AnotherSetting { get; set; }
        public int? AnotherSettingId { get; set; }
    }
}
