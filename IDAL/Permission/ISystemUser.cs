using MicroShop.Model.Permission;
using MicroShop.Model.Web;

namespace MicroShop.IDAL.Permission
{
    public interface ISystemUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        SystemUserDTO Create(CreateSystemUserReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        SystemUserDTO Modify(ModifySystemUserReqDTO req);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        SystemUserDTO GetSystemUserDTO(int userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        void SetLoginStatus(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        SystemUserDTO GetSystemUserDTO(string loginName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        PageResultDTO<SystemUserDTO> GetPageResult(SystemUserPageReqDTO req);
    }
}
