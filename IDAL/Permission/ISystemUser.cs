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
        /// <param name="req">保存用户请求</param>
        /// <returns>MicroShop.Model.VO.Permission.SystemUserVO</returns>
        SystemUserVO Save(SystemUserDTO systemUser);
             
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
        /// 根据登录名查询系统用户记录
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        SystemUserVO? GetSystemUser(string loginName);

        /// <summary>
        /// 根据查询条件，对系统用户进行分页查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        PageResultVO<SystemUserVO> GetPageResult(SystemUserPageReqDTO req);
    }
}
