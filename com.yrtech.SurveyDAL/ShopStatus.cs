//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Purchase.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShopStatus
    {
        public int ShopStatusId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> ShopId { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public string InUserId { get; set; }
        public Nullable<System.DateTime> InDateTime { get; set; }
    }
}
