namespace Population0506.Data.Models
{
    public class Region
    {
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
