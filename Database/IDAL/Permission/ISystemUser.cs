using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using MicroShop.Model.Base;

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
        /// <returns>MicroShop.Common.Model.VO.Permission.SystemUserVO</returns>
        SystemUserVO Create(CreateSystemUserReqDTO req);

        /// <summary>
        /// 新增系统用户
        /// </summary>
        /// <param name="req">保存用户请求</param>
        /// <returns>MicroShop.Common.Model.VO.Permission.SystemUserVO</returns>
        SystemUserVO Modify(ModifySystemUserReqDTO req);

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="passowrd">新密码（明文）</param>
        /// <param name="userId">用户Id</param>       
        void ModifyLoginPassword(string passowrd, long userId);

        /// <summary>
        /// 根据UserId获取系统用户基本信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        SystemUserVO GetSystemUser(long userId);

        /// <summary>
        /// 根据用户Id删除用户记录，同时删除操作日志表里的所有数据
        /// </summary>
        /// <param name="userId">用户Id</param>    
        void Delete(long userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        void SetLoginStatus(long userId);

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
        PageResult<SystemUserVO> GetPageResult(SystemUserPageReqDTO req);
    }
}
