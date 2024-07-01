using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MicroShop.Enums.Permission;
using MicroShop.Model.VO.Common;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Utility.Enums;

namespace MicroShop.BLL.Common
{
    public class BEnum : Singleton<BEnum>
    {
        private const string LoginStatusCacheKey = "login-status-list";

        private const string SystemUserActionTypeCacheKey = "sys-user-action=list";

        #region public List<KeyValueVO<int>> GetLoginStatusList()
        /// <summary>
        /// 获取登录状态列表
        /// </summary>
        /// <returns>List of KeyValueVO</returns>
        public List<KeyValueVO<int>> GetLoginStatusList()
        {
           
            if(MemcacheClient.isExist(LoginStatusCacheKey))
            {
                return MemcacheClient.GetValue<List<KeyValueVO<int>>>(LoginStatusCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach(LoginStatusEnum loginStatus in Enum.GetValues(typeof(LoginStatusEnum)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)loginStatus, Value = loginStatus.GetDescription() });
            }
            //设置缓存
            MemcacheClient.SetValue(LoginStatusCacheKey, keyValues);
            return keyValues;
        }
        #endregion public List<KeyValueVO<int>> GetLoginStatusList()


        public List<KeyValueVO<int>> GetSystemUserActionTypeList()
        {
            if (MemcacheClient.isExist(SystemUserActionTypeCacheKey))
            {
                return MemcacheClient.GetValue<List<KeyValueVO<int>>>(SystemUserActionTypeCacheKey);
            }
            List<KeyValueVO<int>> keyValues = new List<KeyValueVO<int>>();

            foreach (ActionTypeEnum actionType in Enum.GetValues(typeof(ActionTypeEnum)))
            {
                keyValues.Add(new KeyValueVO<int> { Key = (int)actionType, Value = actionType.GetDescription() });
            }
            //设置缓存
            MemcacheClient.SetValue(SystemUserActionTypeCacheKey, keyValues);
            return keyValues;
        }

    }
}
