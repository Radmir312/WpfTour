//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfTour
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelImage
    {
        public int Id { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string ImageSource { get; set; }
    
        public virtual Hotel Hotel { get; set; }
    }
}
