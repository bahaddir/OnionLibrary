using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //relations
        public virtual ICollection<Book> Books { get; set; }

    }

    
}
