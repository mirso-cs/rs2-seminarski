namespace Source.net.infrastructure.Views
{
    public class CategoryView
    {
        public int id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
