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
    
    public partial class LogException
    {
        public int Id { get; set; }
        public Nullable<int> KeyWordId { get; set; }
        public string ExceptionMesage { get; set; }
        public string InerExceptionMesage { get; set; }
        public string StackTraceException { get; set; }
        public System.DateTime Date { get; set; }
    }
}
