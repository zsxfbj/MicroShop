﻿using MicroShop.IDAL.Permission;
using MicroShop.Model.Common.Exception;
using MicroShop.Model.DTO.Permission;
using MicroShop.Model.VO.Permission;
using MicroShop.Model.VO.Web;
using MicroShop.SQLServerDAL.Entity;

namespace MicroShop.SQLServerDAL.Permission
{
    /// <summary>
    /// Role表数据访问层
    /// </summary>
    public class RoleDAL : IRole
    {
        #region Private Methods

        #region private static void ToEntity(CreateRoleReqDTO req, Role role)
        /// <summary>
        /// 外部数据赋值到实体类
        /// </summary>
        /// <param name="req">请求保存的数据对象</param>
        /// <param name="role">实体对象</param>
        private static void ToEntity(CreateRoleReqDTO req, Role role)
        {
            role.RoleName = req.RoleName;
            role.IsEnable = req.IsEnable;
            role.Note = req.Note;
        }
        #endregion private static void ToEntity(CreateRoleReqDTO req, Role role)

        #region private ToVO ToVO(Role role)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private static RoleVO ToVO(Role role)
        {
            return new RoleVO
            {
                RoleId = role.RoleId,
                RoleName = string.IsNullOrEmpty(role.RoleName) ? "" : role.RoleName.Trim(),
                Note = string.IsNullOrEmpty(role.Note) ? "" : role.Note.Trim(),
                IsEnable = role.IsEnable,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            };
        }
        #endregion private ToVO ToVO(Role role)

        #endregion Private Methods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public RoleVO Create(CreateRoleReqDTO req)
        {           
            Role role = new Role();
            ToEntity(req, role);
            using (var context = new MicroShopContext())
            {               
                context.Roles.Add(role);
                context.SaveChanges();
            }
            return ToVO(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <exception cref="ServiceException"></exception>
        public void Delete(int roleId)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }
                context.Roles.Remove(role);

                List<RoleMenuRelation> roleMenus = context.RoleMenuRelations.Where(x => x.RoleId == roleId).ToList();
                if(roleMenus.Count > 0)
                {
                    context.RoleMenuRelations.RemoveRange(roleMenus);
                }               
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        {
            PageResultVO<RoleVO> pageResult = new PageResultVO<RoleVO>
            {
                PageIndex = req.PageIndex,
                PageSize = req.PageSize,
                RecordCount = 0,
                Data = new List<RoleVO>()
            };

            using (var context = new MicroShopContext())
            {
                IQueryable<Role>? query = null;
                if (string.IsNullOrWhiteSpace(req.RoleName))
                {
                    query = context.Roles.Where(x => x.RoleName.Contains(req.RoleName.Trim()));
                }
                if(req.IsEnable != null)
                {
                    if(query == null)
                    {
                        query = context.Roles.Where(x => x.IsEnable == req.IsEnable.Value);
                    }
                    else
                    {
                        query = query.Where(x => x.IsEnable == req.IsEnable.Value);
                    }
                }
                if(query == null)
                {
                    pageResult.RecordCount = context.Roles.Count();
                    pageResult.Data = context.Roles.OrderByDescending(x => x.RoleId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToVO(entity)).ToList();

                }
                else
                {
                    pageResult.RecordCount = query.Count();
                    pageResult.Data = query.OrderByDescending(x => x.RoleId).Skip((pageResult.PageIndex - 1) * pageResult.PageSize).Take(pageResult.PageSize).Select(entity => ToVO(entity)).ToList();

                }
            }
            return pageResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleVO GetRole(int roleId)
        {
            using(var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == roleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }
                return ToVO(role);
            }           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RoleVO> GetRoles()
        {
            using (var context = new MicroShopContext())
            {
                return context.Roles.Where(x => x.IsEnable == true).OrderByDescending(x => x.RoleId).Select(entity => ToVO(entity)).ToList();
            }
        }

        #region public RoleVO Modify(ModifyRoleReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleVO Modify(ModifyRoleReqDTO req)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleId == req.RoleId);
                if (role == null)
                {
                    throw new ServiceException { ErrorCode = Enums.Web.RequestResultCodeEnum.NotFound, ErrorMessage = "角色记录不存在" };
                }
                ToEntity(req, role);
                role.UpdatedAt = DateTime.Now;
                context.Roles.Update(role);
                context.SaveChanges();
                return ToVO(role);
            }
        }
        #endregion public RoleVO Modify(ModifyRoleReqDTO req)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RoleVO? GetRole(string roleName)
        {
            using (var context = new MicroShopContext())
            {
                Role? role = context.Roles.FirstOrDefault(x => x.RoleName == roleName.Trim());
                if(role != null)
                {
                    return ToVO(role);
                }
                return null;
            }            
        }

    }
}
