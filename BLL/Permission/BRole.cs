using MicroShop.DALFactory.Permission;
using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        private static RoleDTO InitData(CreateRoleReqDTO req)
        {
            RoleDTO role = new RoleDTO
            {
                RoleName = req.RoleName.Trim(),
                Note = string.IsNullOrEmpty(req.Note) ? "" : req.Note.Trim(),
                IsEnable = req.IsEnable
            };
            return role;
        }

        #region public static RoleVO Create(CreateRoleReqDTO req)
        /// <summary>
        /// 创建角色记录
        /// </summary>
        /// <param name="req">创建角色请求的内容</param>
        /// <returns>the object of RoleVO</returns>
        /// <exception cref="ServiceException">业务逻辑或者数据库访问异常</exception>
        public static RoleVO Create(CreateRoleReqDTO req)
        {
            RoleDTO role =  InitData(req);
            role.RoleId = 0;

            RoleVO? check = dal.GetRole(role.RoleName);            
            if(check != null)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NameIsExist, ErrorMessage = string.Format("名称为【{0}】的角色记录已存在，请修改后再提交。", req.RoleName) };
            }
            return dal.Save(role);
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
            RoleDTO role = InitData(req);
            role.RoleId = req.RoleId;

            RoleVO? check = dal.GetRole(req.RoleName.Trim());
            
            if(check != null && check.RoleId != req.RoleId)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NameIsExist, ErrorMessage = string.Format("名称为【{0}】的角色记录已存在，请修改后再提交。", req.RoleName) };
            }
            return dal.Save(role);
        }
        #endregion public static RoleVO Modify(ModifyRoleReqDTO req)

        #region public static void Delete(int roleId)
        /// <summary>
        /// 根据角色Id删除记录
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <exception cref="ServiceException"></exception>
        public static void Delete(int roleId)
        {
            if(roleId < 1)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "参数值错误" };
            }
            dal.Delete(roleId);
        }
        #endregion public static void Delete(int roleId)

        #region public static RoleVO GetRole(int roleId)
        /// <summary>
        /// 根据角色Id读取角色详细信息
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <returns>RoleVO</returns>
        public static RoleVO GetRole(int roleId)
        {
            if (roleId < 1)
            {
                throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.RequestParameterError, ErrorMessage = "参数值错误" };
            }
            return dal.GetRole(roleId);
        }
        #endregion public static RoleVO GetRole(int roleId)

        #region public static PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        /// <summary>
        /// 角色分页查询方法
        /// </summary>
        /// <param name="req">分页查询请求内容</param>
        /// <returns>PageResultVO about RoleVO</returns>
        public static PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        {
            req.InitData();
            return dal.GetPageResult(req);
        }
        #endregion public static PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)

        #region public static List<RoleVO> GetRoles()
        /// <summary>
        /// 获取可用的角色列表
        /// </summary>
        /// <returns>List of RoleVO</returns>
        public static List<RoleVO> GetRoles() { return dal.GetRoles(); }

        #endregion public static List<RoleVO> GetRoles()

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool HasPermission(int roleId,string permission)
        {
            if (string.IsNullOrEmpty(permission))
            {
                return true;
            }
            //返回是否有权限
            return dal.HasPermission(roleId, permission.Trim());
        }
    }
}
