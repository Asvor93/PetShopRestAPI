using System.Collections.Generic;

namespace PetShop.Core.Entity
{
    public class Color
    {
        public int ColorId { get; set; }
        public List<PetColor> PetList { get; set; }
        public string PetColor { get; set; }
    }
}