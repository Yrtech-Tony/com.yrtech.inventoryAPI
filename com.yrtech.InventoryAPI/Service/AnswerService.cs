using com.yrtech.InventoryAPI.Common;
using com.yrtech.InventoryAPI.DTO;
using com.yrtech.InventoryDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace com.yrtech.InventoryAPI.Service
{
    public class AnswerService
    {
        Inventory db = new Inventory();
        MasterService masterService = new MasterService();
        AccountService accountService = new AccountService();

        /// <summary>
        /// App端查询清单
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="shopId"></param>
        /// <param name="allChk">Y:N</param>
        /// <param name="addChk">Y:N</param>
        /// <param name="vinCode"></param>
        /// <returns></returns>
        public List<AnswerDto> GetShopAnswerList(string projectId, string shopId,string allChk, string addChk,string vinCode)
        {

            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@ProjectId", projectId),
                                                       new SqlParameter("@ShopId", shopId),
                                                       new SqlParameter("@AllChk", allChk),
                                                       new SqlParameter("@AddChk", addChk),
                                                       new SqlParameter("@VinCode", vinCode)};
            Type t = typeof(AnswerDto);
            string sql = "";
            sql = @"SELECT A.*
                    FROM Answer A 
                    WHERE 1=1 ProjectId = @ProjectId ";
            if (!string.IsNullOrEmpty(shopId))
            {
                sql += " AND ShopId = @ShopId";
            }
            if (allChk=="N") // 不是查询全部的时候，志查询未拍照的清单
            {
                sql += " AND VinPhotoName IS NULL OR VinPhotoName=''";
            }
            if (!string.IsNullOrEmpty(addChk))
            {
                sql += " AND addChk LIKE '%'+@AddChk+'%'";
            }
            if (!string.IsNullOrEmpty(vinCode))
            {
                sql += " AND VinCode LIKE '%'+@VinCode+'%'";
            }
            return db.Database.SqlQuery(t, sql, para).Cast<AnswerDto>().ToList();
        }
         /// <summary>
         /// 添加或者修改清单
         /// </summary>
         /// <param name="answer"></param>
        public void SaveShopAnswer(Answer answer)
        {
            Answer findOne = db.Answer.Where(x => (x.AnswerId== answer.AnswerId)).FirstOrDefault();
            if (findOne == null)
            {
                answer.InDateTime = DateTime.Now;
                answer.ModifyDateTime = DateTime.Now;
                db.Answer.Add(answer);
            }
            else
            {
                findOne.VinPhotoName = answer.VinPhotoName;
                findOne.SaleInvoicePhotoName = answer.SaleInvoicePhotoName;
                findOne.CarBackPhotoName = answer.CarBackPhotoName;
                findOne.Remark = answer.Remark;
                findOne.ModifyDateTime = DateTime.Now;
            }
            db.SaveChanges();
        }
        /// <summary>
        /// 查询经销商盘库状态信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="shopId"></param>
        /// <param name="allChk"></param>
        /// <param name="addChk"></param>
        /// <param name="vinCode"></param>
        /// <returns></returns>
        public List<ShopStatus> GetStatus(string projectId, string shopId,string statusCode) {

            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@ProjectId", projectId),
                                                       new SqlParameter("@ShopId", shopId),
                                                       new SqlParameter("@StatusCode", statusCode)
                                                  };
            Type t = typeof(ShopStatus);
            string sql = "";
            sql = @"SELECT * FROM ShopStatus WHERE ProjectId = @ProjectId";
            if (!string.IsNullOrEmpty(shopId))
            {
                sql += " AND ShopId = @ShopId";
            }
            if (!string.IsNullOrEmpty(statusCode))
            {
                sql += " AND StatusCode = @StatusCode";
            }           
            return db.Database.SqlQuery(t, sql, para).Cast<ShopStatus>().ToList();
        }
        public void SaveShopStatus(ShopStatus status)
        {
            ShopStatus findOne = db.ShopStatus.Where(x => (x.ShopStatusId == status.ShopStatusId)).FirstOrDefault();
            if (findOne == null)
            {
                status.InDateTime = DateTime.Now;
                db.ShopStatus.Add(status);
            }
        }
    }
}