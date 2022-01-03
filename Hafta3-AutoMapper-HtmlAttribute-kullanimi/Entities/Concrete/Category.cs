using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{     /// <summary>
     /// Veri tabınındaki Categories tablosunda bulunan değerlerin kod karşılıkları
     /// </summary>
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idate { get; set; }
        public DateTime Udate { get; set; }
        public int Iuser { get; set; }
        public int Uuser { get; set; }
    }
}
