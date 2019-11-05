using System.Collections.Generic;

namespace PetShop.Core.DomainService.Filter
{
    public class FilteredList<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}