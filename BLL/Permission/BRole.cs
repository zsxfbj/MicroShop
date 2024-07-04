using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.Utility.Common;

namespace MicroShop.BLL.Permission
{
    /// <summary>
    /// Role业务逻辑类
    /// </summary>
    public class BRole
    {
        /// <summary>
        /// 获取DAL访问的实例
        /// </summary>
        private readonly static IRole dal = RoleFactory.Create();

        #region public static RoleVO Create(CreateRoleReqDTO req)
        /// <summary>
        /// 创建角色记录
        /// </summary>
        /// <param name="req">创建角色请求的内容</param>
        /// <returns>the object of RoleVO</returns>
        /// <exception cref="ServiceException">业务逻辑或者数据库访问异常</exception>
        public static RoleVO Create(CreateRoleReqDTO req)
        {
            RoleVO? check = null;
            try
            {
                check = dal.GetRole(req.RoleName.Trim());
            }
            catch (Exception ex) 
            {
                LogHelper.Error("BRole.Create:" + ex.Message);
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "创建角色比对角色名时，数据库访问异常！" };
            }
            
            if(check != null)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NameIsExist, ErrorMessage = string.Format("名称为【{0}】的角色记录已存在，请修改后再提交。", req.RoleName) };
            }
            try
            {
                return dal.Create(req);
            }
            catch (Exception ex)
            {
                LogHelper.Error("BRole.Create:" + ex.Message);
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "创建角色记录保存时，数据库访问异常！" };
            }           
        }
        #endregion public static RoleVO Create(CreateRoleReqDTO req)

        #region public static RoleVO Modify(ModifyRoleReqDTO req)
        /// <summary>
        /// 修改角色记录
        /// </summary>
        /// <param name="req">修改角色请求</param>
        /// <returns>the object of RoleVO</returns>
        /// <exception cref="ServiceException">业务逻辑或者数据库访问异常</exception>
        public static RoleVO Modify(ModifyRoleReqDTO req)
        {
            RoleVO? check = null;
            try
            {
                check = dal.GetRole(req.RoleName.Trim());
            }
            catch (Exception ex)
            {
                LogHelper.Error("BRole.Modify:" + ex.Message);
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "修改角色比对角色名时，数据库访问异常！" };
            }
            if(check != null && check.RoleId != req.RoleId)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NameIsExist, ErrorMessage = string.Format("名称为【{0}】的角色记录已存在，请修改后再提交。", req.RoleName) };
            }
            try
            {
                return dal.Modify(req);
            }
            catch (Exception ex)
            {
                LogHelper.Error("BRole.Modify:" + ex.Message);
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.DatabaseAccessError, ErrorMessage = "修改角色记录保存时，数据库访问异常！" };
            }           
        }
        #endregion public static RoleVO Modify(ModifyRoleReqDTO req)

        public static void Delete(int roleId)
        {
            dal.Delete(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static RoleVO GetRole(int roleId)
        {
            return dal.GetRole(roleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        {
            return dal.GetPageResult(req);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<RoleVO> GetRoles() { return dal.GetRoles(); }
    }
}
