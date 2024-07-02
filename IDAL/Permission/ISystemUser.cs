using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;

namespace MicroShop.IDAL.Permission
{
    /// <summary>
    /// 系统用户相关接口
    /// </summary>
    public interface ISystemUser
    {
        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        SystemUserVO Create(CreateSystemUserReqDTO req);

        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        SystemUserVO Modify(ModifySystemUserReqDTO req);

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="passowrd">新密码（明文）</param>
        /// <param name="userId">用户Id</param>       
        void ModifyLoginPassword(string passowrd, int userId);

        /// <summary>
        /// 根据UserId获取系统用户基本信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        SystemUserVO GetSystemUser(int userId);

        /// <summary>
        /// 根据用户Id删除用户记录，同时删除操作日志表里的所有数据
        /// </summary>
        /// <param name="userId">用户Id</param>    
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
        SystemUserVO GetSystemUser(string loginName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req);
    }
}
