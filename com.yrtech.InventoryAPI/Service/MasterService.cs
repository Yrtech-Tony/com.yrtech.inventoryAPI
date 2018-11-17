using com.yrtech.InventoryAPI.Common;
using com.yrtech.InventoryAPI.DTO;
using com.yrtech.InventoryDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace com.yrtech.InventoryAPI.Service
{
    public class MasterService
    {
        Inventory db = new Inventory();
        /// <summary>
        /// 查询租户信息
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public List<Tenant> GetTenant(string tenantId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TenantId", tenantId) };
            Type t = typeof(Tenant);
            string sql = "";

            sql = @"SELECT TenantId,TenantName,TenantCode,Email,TelNo,InUserid,InDateTime,ModifyUserId,ModifyDateTime
	                    FROM Tenant WHERE 1=1 ";
            if (!string.IsNullOrEmpty(tenantId))
            {
                sql += " AND TenantId = @TenantId";
            }
            return db.Database.SqlQuery(t, sql, para).Cast<Tenant>().ToList();

        }
        /// <summary>
        /// 查询品牌信息
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Brand> GetBrand(string tenantId, string userId, string brandId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TenantId", tenantId),
                                                       new SqlParameter("@UserId", userId),
                                                        new SqlParameter("@BrandId", brandId)};
            Type t = typeof(Brand);
            string sql = "";

            sql = @"SELECT A.BrandId,A.TenantId,A.BrandName,A.BrandCode,A.Remark,A.InUserId,A.InDateTime,A.ModifyUserId,A.ModifyDateTime
                    FROM Brand A INNER JOIN UserInfoBrand B ON A.BrandId = B.BrandId
                    WHERE 1=1 AND A.TenantId = @TenantId ";
            if (!string.IsNullOrEmpty(userId))
            {
                sql += " AND B.UserId = @UserId";
            }
            if (!string.IsNullOrEmpty(brandId))
            {
                sql += " AND A.BrandId = @BrandId";
            }
            return db.Database.SqlQuery(t, sql, para).Cast<Brand>().ToList();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="brandId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Projects> GetProject(string tenantId, string brandId, string projectId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TenantId", tenantId),
                                                        new SqlParameter("@BrandId", brandId),
                                                       new SqlParameter("@ProjectId", projectId)};
            Type t = typeof(Projects);
            string sql = "";
            sql = @"SELECT [ProjectId]
                          ,[TenantId]
                          ,[BrandId]
                          ,[ProjectCode]
                          ,[ProjectName]
                          ,[Year]
                          ,[Quarter]
                          ,[OrderNO]
                          ,[InUserId]
                          ,[InDateTime]
                          ,[ModifyUserId]
                          ,[ModifyDateTime]
                    FROM [Project]
                    WHERE 1=1   
                    ";
            if (!string.IsNullOrEmpty(tenantId))
            {
                sql += " AND TenantId = @TenantId";
            }
            if (!string.IsNullOrEmpty(brandId))
            {
                sql += " AND BrandId = @BrandId";
            }
            if (!string.IsNullOrEmpty(projectId))
            {
                sql += " AND ProjectId = @ProjectId";
            }
            return db.Database.SqlQuery(t, sql, para).Cast<Projects>().ToList();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="brandId"></param>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public List<Shop> GetShop(string tenantId, string brandId, string shopId)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TenantId", tenantId),
                                                        new SqlParameter("@BrandId", brandId),
                                                       new SqlParameter("@ShopId", shopId)};
            Type t = typeof(Shop);
            string sql = "";
            sql = @"SELECT [ShopId]
                          ,[TenantId]
                          ,[BrandId]
                          ,[ShopCode]
                          ,[ShopName]
                          ,[ShopShortName]
                          ,[Province]
                          ,[City]
                          ,[UseChk]
                          ,[InUserId]
                          ,[InDateTime]
                          ,[ModifyUserId]
                          ,[ModifyDateTime]
                      FROM [Shop]
                    WHERE  1=1 
                    ";
            if (!string.IsNullOrEmpty(tenantId))
            {
                sql += " AND TenantId = @TenantId";
            }
            if (!string.IsNullOrEmpty(brandId))
            {
                sql += " AND BrandId = @BrandId";
            }
            if (!string.IsNullOrEmpty(shopId))
            {
                sql += " AND ShopId = @ShopId";
            }
            return db.Database.SqlQuery(t, sql, para).Cast<Shop>().ToList();
        }
        public List<CarType> GetCarType(string projectId)
        {
            int sql_projectId = Convert.ToInt32(projectId);
            return db.CarType.Where(x => (x.ProjectId == sql_projectId)).ToList();
        }
        public List<Note> GetNote(string projectId,string noteType)
        {
            int sql_projectId = Convert.ToInt32(projectId);
            if (string.IsNullOrEmpty(noteType))
            {
                return db.Note.Where(x => (x.ProjectId == sql_projectId)).ToList();
            }
            else {
                return db.Note.Where(x => (x.ProjectId == sql_projectId && x.Type==noteType)).ToList();
            }
        }
    }
}