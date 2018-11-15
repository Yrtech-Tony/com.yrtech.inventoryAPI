using System.Web.Http;
using com.yrtech.InventoryAPI.Service;
using com.yrtech.InventoryAPI.Common;
using System.Collections.Generic;
using System;
using com.yrtech.InventoryAPI.DTO;
using System.Threading;
using Purchase.DAL;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace com.yrtech.SurveyAPI.Controllers
{

    [RoutePrefix("inventory/api")]
    public class AnswerController : ApiController
    {
        AnswerService answerService = new AnswerService();
        MasterService masterService = new MasterService();
        #region APP端
        /// <summary>
        /// 清单查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Answer/GetShopAnswerList")]
        public APIResult GetShopAnswerList(string projectId, string shopId, string vinCode, string allChk, string addChk)
        {
            try
            {
                List<AnswerDto> shopAnswerList = answerService.GetShopAnswerList(projectId, shopId, allChk, addChk, vinCode);
                return new APIResult() { Status = true, Body = CommonHelper.Encode(shopAnswerList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
        /// <summary>
        /// 获取销售顾问信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="shopId"></param>
        /// <returns></returns>
        [Route("Answer/GetShopShopConsultant")]
        public APIResult GetShopShopConsultant(string projectId, string shopId)
        {
            try
            {
                List<ShopConsultantDto> shopContantList = answerService.GetShopConsultant(projectId, shopId);
                foreach (ShopConsultantDto shopContant in shopContantList)
                {
                    shopContant.ShopConsultantSubjectLinkList = answerService.GetShopConsultantSubjectLink(projectId, shopContant.ConsultantId.ToString());
                }
                return new APIResult() { Status = true, Body = CommonHelper.Encode(shopContantList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
        #endregion
    }
}
