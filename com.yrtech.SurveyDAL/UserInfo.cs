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
    
    public partial class UserInfo
    {
        public int Id { get; set; }
        public Nullable<int> TenantId { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string RoleType { get; set; }
        public Nullable<bool> UseChk { get; set; }
        public string Email { get; set; }
        public string TelNO { get; set; }
        public string HeadPicUrl { get; set; }
        public Nullable<int> InUserId { get; set; }
        public Nullable<System.DateTime> InDateTime { get; set; }
        public Nullable<int> ModifyUserId { get; set; }
        public Nullable<System.DateTime> ModifyDateTime { get; set; }
    }
}
