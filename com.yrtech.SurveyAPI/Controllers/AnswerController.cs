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
        [HttpGet]
        [Route("Answer/GetShopCheckInfo")]
        public APIResult GetShopCheckInfo(string projectId, string shopId)
        {
            try
            {
                List<ShopStatus> shopStatusList = answerService.GetStatus(projectId, shopId, "S1");
                return new APIResult() { Status = true, Body = CommonHelper.Encode(shopStatusList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uploadData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Answer/SaveShopCheckInfo")]
        public async Task<APIResult> SaveShopCheckInfo([FromBody]UploadData uploadData)
        {
            try
            {
                List<ShopStatus> statusList = CommonHelper.DecodeString<List<ShopStatus>>(uploadData.ListJson);

                foreach (ShopStatus status in statusList)
                {
                    status.StatusCode = "S1";
                    status.StatusName = "签到";
                    answerService.SaveShopStatus(status);
                }
                return new APIResult() { Status = true, Body = "" };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
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
        /// 清单添加或者修改
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="shopId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Answer/SaveShopAnswer")]
        public async Task<APIResult> SaveShopAnswer([FromBody]UploadData uploadData)
        {
            try
            {
                List<Answer> answerList = CommonHelper.DecodeString<List<Answer>>(uploadData.ListJson);

                foreach (Answer answer in answerList)
                {
                    answerService.SaveShopAnswer(answer);
                }
                return new APIResult() { Status = true, Body = "" };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
        #endregion
    }
}
