using System.Web.Http;
using com.yrtech.InventoryAPI.Service;
using com.yrtech.InventoryAPI.Common;
using System.Collections.Generic;
using System;
using com.yrtech.InventoryAPI.DTO;
using System.Threading;
using com.yrtech.InventoryDAL;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace com.yrtech.InventoryAPI.Controllers
{
    [RoutePrefix("inventory/api")]
    public class MasterController : ApiController
    {
        AnswerService answerService = new AnswerService();
        MasterService masterService = new MasterService();
        
        /// <summary>
        /// 根据租户信息查询品牌信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Master/GetBrand")]
        public APIResult GetBrand(string tenantId, string brandId)
        {
            try
            {
                List<Brand> brandList = masterService.GetBrand(tenantId, "", brandId);
                return new APIResult() { Status = true, Body = CommonHelper.Encode(brandList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }

        }
        /// <summary>
        /// 获取品牌下的账号信息
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Master/GetUserInfoByBrandId")]
        public APIResult GetUserInfoByBrandId(string brandId)
        {
            try
            {
                //List<UserInfo> userInfoBrandList = masterService.GetUserInfoByBrandId(brandId);
                return new APIResult() { Status = true, Body = CommonHelper.Encode("") };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }

        }
        /// <summary>
        /// 获取品牌下期号的信息，也可以获取单个期号的信息
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Master/GetProject")]
        public APIResult GetProject(string brandId,string projectId)
        {
            try
            {
                List<Projects> projectList = masterService.GetProject("",brandId,projectId);
                return new APIResult() { Status = true, Body = CommonHelper.Encode(projectList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }

        }
        [HttpGet]
        [Route("Master/GetCarType")]
        public APIResult GetCarType(string projectId)
        {
            try
            {
                List<CarType> carTypeList = masterService.GetCarType(projectId);
                return new APIResult() { Status = true, Body = CommonHelper.Encode(carTypeList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }

        }
        [HttpGet]
        [Route("Master/GetNote")]
        public APIResult GetNote(string projectId,string noteType)
        {
            try
            {
                List<Note> noteList = masterService.GetNote(projectId,noteType);
                return new APIResult() { Status = true, Body = CommonHelper.Encode(noteList) };
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }

        }
    }
}
