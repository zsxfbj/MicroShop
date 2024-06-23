using System.Collections.Generic;
using MicroShop.Permission.Enums;
using MicroShop.Utility.Cache;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.Permission.BLL
{
    public class BCommon : Singleton<BCommon>
    {
        /// <summary>
        /// 系统用户登录状态缓存Key
        /// </summary>
        private const string SystemUserLoginStatusCacheKey = "SystemUser-LoginStatusList";

        /// <summary>
        /// 
        /// </summary>
        private const string SystemUserActionTypesCacheKey = "SystemUser-ActionTypeList";

        #region public List<KeyValueDTO> GetLoginStatusList()
        /// <summary>
        /// 获取登录状态列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<Int32, string> GetLoginStatusList()
        {
            if (RedisClient.KeyExists(SystemUserLoginStatusCacheKey))
            {
                return RedisClient.StringGet<Dictionary<Int32, string>>(SystemUserLoginStatusCacheKey);
            }

            Dictionary<Int32, string> dicts = new Dictionary<int, string>();

            foreach (LoginStatusEnum status in Enum.GetValues(typeof(LoginStatusEnum)))
            {
                dicts.Add((int)status, status.GetDescription());
            }
            RedisClient.StringSet(SystemUserLoginStatusCacheKey, dicts, TimeSpan.FromDays(Constants.FIFTEEN));
            return dicts;
        }
        #endregion public List<KeyValueDTO>? GetLoginStatusList()

        #region public List<KeyValueDTO>? GetActionTypes()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<KeyValueDTO<Int32>> GetActionTypes()
        {
            if (RedisClient.KeyExists(SystemUserActionTypesCacheKey))
            {
                List<KeyValueDTO<Int32>> keyValueDTOs = RedisClient.StringGet<List<KeyValueDTO<Int32>>>(SystemUserActionTypesCacheKey);
                if(keyValueDTOs == null)
                {
                    keyValueDTOs = new List<KeyValueDTO<int>>();
                }
                return keyValueDTOs;
            }

            List<KeyValueDTO<Int32>> keyValues = new List<KeyValueDTO<Int32>>();

            foreach (ActionTypeEnum actionType in Enum.GetValues(typeof(ActionTypeEnum)))
            {
                keyValues.Add(new KeyValueDTO<Int32> { Key = ((Int32)actionType), Value = actionType.GetDescription() });
            }
            RedisClient.StringSet(SystemUserActionTypesCacheKey, keyValues, TimeSpan.FromDays(Constants.FIFTEEN));
            return keyValues;          
        }
        #endregion public List<KeyValueDTO> GetActionTypes()


    }
}
