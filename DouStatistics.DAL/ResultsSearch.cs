//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DouStatistics.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResultsSearch
    {
        public int Id { get; set; }
        public int KeyWordId { get; set; }
        public int Amount { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual KeyWords KeyWords { get; set; }
    }
}