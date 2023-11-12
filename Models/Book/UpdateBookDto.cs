namespace AliBookStoreApi.Models
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}