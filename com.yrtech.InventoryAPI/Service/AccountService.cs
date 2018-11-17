using com.yrtech.InventoryAPI.Common;
using com.yrtech.InventoryAPI.DTO;
using com.yrtech.InventoryAPI.DTO.Account;
using com.yrtech.InventoryDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace com.yrtech.InventoryAPI.Service
{
    public class AccountService
    {
        Inventory db = new Inventory();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<ShopDto> LoginForMobile(string accountId, string password)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@AccountId", accountId),
                                                       new SqlParameter("@Password",password)};
            Type t = typeof(ShopDto);
            string sql = @"SELECT D.TenantId,D.TenantCode,D.TenantName,C.BrandId,C.BrandCode,C.BrandName,B.ProjectId,B.ProjectCode,B.ProjectName,
                                    A.UserId,A.ShopCode,A.ShopName,A.ExpirTime
                            FROM Shop A INNER JOIN Projects B ON A.ProjectId = B.ProjectId
			                INNER JOIN Brand C ON B.BrandId = C.BrandID
			                INNER JOIN Tenant D ON C.TenantId = D.TenantId
                            WHERE UserId = @AccountId AND Password = @Password AND A.ExpirTime>getdate()";
            return db.Database.SqlQuery(t, sql, para).Cast<ShopDto>().ToList();
        }
        /// <summary>
        /// 登录成功后获取登录的信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<AccountDto> GetLoginInfo(string accountId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@AccountId", accountId) };
            Type t = typeof(AccountDto);
            string sql = @"SELECT A.TenantId,C.BrandId,B.TenantCode,B.TenantName,D.BrandName,C.UserId,AccountId,AccountName,[Password],
                            ISNULL(UseChk,0) AS UseChk,A.TelNO,A.Email,A.HeadPicUrl
                            FROM UserInfo A INNER JOIN Tenant B ON A.TenantId = B.TenantId
                                            INNER JOIN UserInfoBrand C ON A.Id = C.UserId
                                            INNER JOIN Brand D ON C.BrandId = D.BrandId AND B.TenantId = D.TenantId
                            WHERE AccountId = @AccountId 
                            AND UseChk = 1";
            return db.Database.SqlQuery(t, sql, para).Cast<AccountDto>().ToList();

        }
        public List<UserInfo> GetUserInfo(string userId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            Type t = typeof(UserInfo);
            string sql = @"SELECT * FROM [UserInfo]
                    WHERE Id = @UserId";
            return db.Database.SqlQuery(t, sql, para).Cast<UserInfo>().ToList();
        }
        public List<UserInfoBrand> GetUserInfoBrand(string userId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@UserId", userId) };
            Type t = typeof(UserInfoBrand);
            string sql = @"SELECT [Id]
                          ,[UserId]
                          ,[BrandId]
                          ,[InUserId]
                          ,[InDateTime]
                          ,[ModifyUserId]
                          ,[ModifyDateTime]
                      FROM [UserInfoBrand]
                    WHERE UserId = @UserId";
            return db.Database.SqlQuery(t, sql, para).Cast<UserInfoBrand>().ToList();
        }

    }
}