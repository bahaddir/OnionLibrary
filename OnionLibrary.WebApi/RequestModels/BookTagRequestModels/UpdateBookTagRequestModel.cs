namespace OnionLibrary.WebApi.RequestModels.BookTagRequestModels
{
    public class UpdateBookTagRequestModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }
    }
}
