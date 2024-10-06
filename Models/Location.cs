namespace Invantory.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();

    }
}
