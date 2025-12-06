namespace Domain.Entities
{
    public class  Tag:BaseEntity
    {
        public string TagName { get; set; }
        //relations
        public virtual ICollection<BookTag> BookTags { get; set; }
    }
}
