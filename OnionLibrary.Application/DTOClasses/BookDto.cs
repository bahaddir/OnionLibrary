namespace OnionLibrary.Application.DTOClasses
{
    public class  BookDto:BaseDTO
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }

}
