using MicroShop.Permission.Model.Request;
using MicroShop.Permission.Model.Response;
using MicroShop.Utility.Common;
using MicroShop.Web.Common;

namespace MicroShop.Permission.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class BSystemUser : Singleton<BSystemUser>
    {

         

        #region public LoginResultDTO Login(SystemUserLoginDTO systemUserLogin, RequestHeaderDTO requestHeader)
        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <param name="systemUserLogin"></param>
        /// <param name="requestHeader"></param>
        /// <returns></returns>
        public LoginResultDTO Login(SystemUserLoginDTO systemUserLogin, RequestHeaderDTO requestHeader)
        {
            

            LoginResultDTO loginResult = new LoginResultDTO();

            //访问令牌
            if (string.IsNullOrEmpty(requestHeader.AccessToken))
            {
                requestHeader.AccessToken = StringHelper.GetGuid();
            }

            loginResult.AccessToken = requestHeader.AccessToken;
            return loginResult;
        }
        #endregion public LoginResultDTO Login(SystemUserLoginDTO systemUserLogin, RequestHeaderDTO requestHeader)
    }
}
