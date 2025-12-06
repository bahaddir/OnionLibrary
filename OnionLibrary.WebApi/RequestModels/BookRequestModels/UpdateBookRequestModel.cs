namespace OnionLibrary.WebApi.RequestModels.BookRequestModels
{
    public class UpdateBookRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
