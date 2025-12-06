namespace Domain.Entities
{
    public class Category: BaseEntity
    {
        public string CategoryName { get; set; }

        //relations
        public virtual ICollection<Book> Books { get; set; }
    }
}
