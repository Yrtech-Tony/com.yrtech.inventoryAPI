﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using com.yrtech.InventoryAPI.Common;
using com.yrtech.InventoryAPI.Service;
using com.yrtech.InventoryAPI.DTO;

namespace com.yrtech.InventoryAPI.Controllers
{
    [RoutePrefix("inventory/api")]
    public class AccountController : ApiController
    {
        AccountService accountService = new AccountService();
        MasterService masterService = new MasterService();

        [HttpGet]
        [Route("Account/LoginForMobile")]
        public APIResult LoginForMobile(string accountId, string password)
        {
            try
            {
                List<object> resultList = new List<object>();
                List<ShopDto> accountlist = accountService.LoginForMobile(accountId, password);
                if (accountlist != null && accountlist.Count != 0)
                {
                    resultList.Add(accountlist);
                    string projectId = accountlist[0].ProjectId.ToString();
                    resultList.Add(masterService.GetCarType(projectId));
                    resultList.Add(masterService.GetNote(projectId, ""));
                    return new APIResult() { Status = true, Body = CommonHelper.Encode(resultList) };
                }
                else
                {
                    return new APIResult() { Status = true, Body = "用户不存在密码不匹配或账号已过期" };
                }
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
        [HttpGet]
        [Route("Account/Login")]
        public APIResult Login(string accountId, string password)
        {
            try
            {
                //List<AccountDto> accountlist = accountService.Login(accountId, password);
                //if (accountlist != null && accountlist.Count != 0)
                //{
                //    accountlist = accountService.GetLoginInfo(accountId);
                return new APIResult() { Status = true, Body = CommonHelper.Encode("") };
                //}
                //else
                //{
                //    return new APIResult() { Status = true, Body = "用户不存在或者密码不正确" };
                //}
            }
            catch (Exception ex)
            {
                return new APIResult() { Status = false, Body = ex.Message.ToString() };
            }
        }
    }
}
