namespace OnionLibrary.WebApi.ResponseModels.BookResponseModel
{
    public class BookResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
