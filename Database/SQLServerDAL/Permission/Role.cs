using MicroShop.Database.IDAL.Permission;
using MicroShop.Common.Model.Common.Exception;
using MicroShop.Common.Model.DTO.Permission;
using MicroShop.Common.Model.VO.Permission;
using System.Data.SqlClient;
using MicroShop.Common.Utility;
using System.Data;
using System.Collections.Generic;
using System;
using System.Text;
using MicroShop.Model.Base;

namespace MicroShop.Database.SQLServerDAL.Permission
{
    /// <summary>
    /// Role表数据访问层
    /// </summary>
    public class Role : IRole
    {
        private const string SQL_SELECT_ROLE = "SELECT [id], [name], is_enable, [note], created_at, updated_at FROM [role] WHERE [id]=@id AND [is_deleted]=0";
        private const string SQL_SELECT_ROLE_BY_NAME = "SELECT [id], [name], is_enable, [note], created_at, updated_at FROM [role] WHERE [name]=@name AND [is_deleted]=0";
        private const string SQL_SELECT_ALL_ROLES = "SELECT [id], [name], is_enable, [note], created_at, updated_at FROM [role] WHERE [is_deleted]=0 ORDER BY [id]";
      
        private const string SQL_COUNT_ROLES = "SELECT COUNT([id]) FROM FROM [role] WHERE [is_deleted]=0 {0}";
        private const string SQL_SELECT_PAGED_ROLES = "SELECT [id], [name], is_enable, [note], created_at, updated_at FROM (SELECT ROW_NUMBER() OVER (ORDER BY [id] DESC) AS rowNum, * FROM [role] WHERE [is_deleted]=0 {0}) AS t WHERE rowNum BETWEEN @startIndex AND @endIndex ";
      
        private const string SQL_INSERT_ROLE = "INSERT INTO [role] ([name], is_enable, [note], [is_deleted], created_at, updated_at) VALUES (@name, @isEnable, @note, 0, GETDATE(), GETDATE());SELECT IDENT_CURRENT('role')";
        private const string SQL_UPDATE_ROLE = "UPDATE [role] SET [name]=@name, is_enable=@isEnable, [note]=@note, updated_at=GETDATE() WHERE [id]=@id";
        private const string SQL_UPDATE_ROLE_ENABLE = "UPDATE [role] SET [is_enable]=@isEnable WHERE [id]=@id";
        private const string SQL_DELETE_ROLE = "UPDATE [role] SET [is_deleted]=1 WHERE [id]=@id";

        private const string PARM_ID = "@id";
        private const string PARM_NAME = "@name";
        private const string PARM_IS_ENABLE = "@isEnable";
        private const string PARM_NOTE = "@note";
        
        #region Private Methods

        #region private static RoleVO ToVO(SqlDataReader rdr)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdr"></param>
        /// <returns></returns>
        private static RoleVO ToVO(SqlDataReader rdr)
        {
            return new RoleVO
            {
                RoleId = rdr.IsDBNull(0) ? 0 : rdr.GetInt64(0),
                RoleName = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1).Trim(),
                IsEnable = rdr.IsDBNull(2) ? false : rdr.GetBoolean(2),
                Note = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3).Trim(),               
                CreatedAt = rdr.IsDBNull(4) ? System.DateTime.Now : rdr.GetDateTime(4),
                UpdatedAt = rdr.IsDBNull(5) ? System.DateTime.Now : rdr.GetDateTime(5)
            };
        }
        #endregion private static RoleVO ToVO(SqlDataReader rdr)

        #endregion Private Methods

        #region Public Methods

        #region public RoleVO Create(CreateRoleReqDTO role)
        /// <summary>
        /// 保存到数据库里
        /// </summary>
        /// <param name="role">角色实体对象</param>
        /// <returns>a value of RoleVO</returns>
        public RoleVO? Create(CreateRoleReqDTO req)
        {
            SqlParameter[] parms = new SqlParameter[]
                    {
                        new SqlParameter(PARM_NAME, SqlDbType.NVarChar, 32),
                        new SqlParameter(PARM_IS_ENABLE, SqlDbType.Bit),
                        new SqlParameter(PARM_NOTE, SqlDbType.NVarChar, 256)
                    };
            parms[0].Value = req.RoleName.Trim();
            parms[1].Value = req.IsEnable ? 1 : 0;
            parms[2].Value = string.IsNullOrWhiteSpace(req.Note) ? "" : req.Note.Trim();

            long roleId = Convert.ToInt64(Database.ExecuteScalar(StaticVariables.SQLConnectionString, CommandType.Text, SQL_INSERT_ROLE, parms).ToString());
            return GetRole(roleId);
        }
        #endregion public RoleVO Create(CreateRoleReqDTO req)

        #region public RoleVO Modify(ModifyRoleReqDTO req)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ServiceException"></exception>
        public RoleVO? Modify(ModifyRoleReqDTO req)
        {
            SqlParameter[] parms = new SqlParameter[]
                  {
                        new SqlParameter(PARM_NAME, SqlDbType.NVarChar, 32),
                        new SqlParameter(PARM_IS_ENABLE, SqlDbType.Bit),
                        new SqlParameter(PARM_NOTE, SqlDbType.NVarChar, 256),
                        new SqlParameter(PARM_ID, SqlDbType.BigInt)
                  };
            parms[0].Value = req.RoleName.Trim();
            parms[1].Value = req.IsEnable ? 1 : 0;
            parms[2].Value = string.IsNullOrWhiteSpace(req.Note) ? "" : req.Note.Trim();
            parms[3].Value = req.RoleId;
            Database.ExecuteNonQuery(StaticVariables.SQLConnectionString, CommandType.Text, SQL_UPDATE_ROLE, parms);

            return GetRole(req.RoleId);
        }
        #endregion public RoleVO Modify(ModifyRoleReqDTO req)

        #region public void Delete(long roleId)
        /// <summary>
        /// 删除角色记录
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <exception cref="ServiceException"></exception>
        public int Delete(long roleId)
        {
            SqlParameter parm = new SqlParameter(PARM_ID, SqlDbType.BigInt);
            parm.Value = roleId;           
            //提交到数据库
            return Database.ExecuteNonQuery(StaticVariables.SQLConnectionString, CommandType.Text, SQL_DELETE_ROLE, parm);
        }
        #endregion public void Delete(int roleId)

        #region public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)
        /// <summary>
        /// 查询角色分页记录
        /// </summary>
        /// <param name="req">分页查询请求内容</param>
        /// <returns>a value of PageResultVO about RoleVO</returns>
        public PageResult<RoleVO> GetPageResult(RolePageReqDTO req)
        {
            PageResult<RoleVO> pageResult = new PageResult<RoleVO>
            {
                PageIndex = req.PageIndex,
                PageSize = req.PageSize,
                RecordCount = 0,
                Data = new List<RoleVO>()
            };

            List<SqlParameter> parms = new List<SqlParameter>();

            StringBuilder whereSql = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(req.RoleName))
            {
                whereSql.Append(" AND [name] LIKE @name");
                SqlParameter parm = new SqlParameter(PARM_NAME, SqlDbType.NVarChar, 32);
                parm.Value = "%" + req.RoleName + "%";
                parms.Add(parm);
            }

            if (req.IsEnable.HasValue)
            {
                whereSql.Append(" AND [is_enable]=@isEnable");
                SqlParameter parm = new SqlParameter(PARM_IS_ENABLE, SqlDbType.Bit);
                parm.Value = req.IsEnable.Value;
                parms.Add(parm);
            }

            using (SqlDataReader rdr = Database.ExecuteReader(StaticVariables.SQLConnectionString, CommandType.Text, string.Format(SQL_COUNT_ROLES, whereSql), parms.ToArray()))
            {
                if (rdr.Read())
                {
                    pageResult.RecordCount = rdr.IsDBNull(0) ? 0 : rdr.GetInt64(0);
                }
            }

            if(pageResult.RecordCount > 0)
            {
                int startIndex = (pageResult.PageIndex - 1) * pageResult.PageSize + 1;
                int endIndex = pageResult.PageIndex * pageResult.PageSize;
                SqlParameter startParm = new SqlParameter(Database.PARM_STARTINDEX, SqlDbType.BigInt)
                {
                    Value = startIndex
                };
                parms.Add(startParm);

                SqlParameter endParm = new SqlParameter(Database.PARM_ENDINDEX, SqlDbType.BigInt)
                {
                    Value = endIndex
                };
                parms.Add(endParm);

                using (SqlDataReader rdr = Database.ExecuteReader(StaticVariables.SQLConnectionString, CommandType.Text, string.Format(SQL_SELECT_PAGED_ROLES, whereSql, startIndex, endIndex), parms.ToArray()))
                {
                    while (rdr.Read())
                    {
                        pageResult.Data.Add(ToVO(rdr));
                    }
                }
            }
            return pageResult;
        }

        #endregion public PageResultVO<RoleVO> GetPageResult(RolePageReqDTO req)

        #region public RoleVO GetRole(int roleId)
        /// <summary>
        /// 根据角色Id获取角色详情
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>       
        public RoleVO? GetRole(long roleId)
        {
            SqlParameter parm = new SqlParameter(PARM_ID, SqlDbType.BigInt);
            parm.Value = roleId;

            using (SqlDataReader rdr = Database.ExecuteReader(StaticVariables.SQLConnectionString, CommandType.Text, SQL_SELECT_ROLE, parm))
            {
                if (rdr.Read()) {
                    return ToVO(rdr);           
                }
                return null;
            }
        }
        #endregion public RoleVO GetRole(int roleId)

        #region public List<RoleVO> GetRoles()
        /// <summary>
        /// 获取全部可用的角色记录
        /// </summary>
        /// <returns>a lList of RoleVO</returns>
        public List<RoleVO> GetRoles()
        {
            List<RoleVO> roles = new List<RoleVO>();
            
            using (SqlDataReader rdr = Database.ExecuteReader(StaticVariables.SQLConnectionString, CommandType.Text, SQL_SELECT_ALL_ROLES))
            {
                while (rdr.Read())
                {
                    roles.Add(ToVO(rdr));
                }               
            }
            return roles;
        }
        #endregion public List<RoleVO> GetRoles()

        #region public RoleVO? GetRole(string name)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RoleVO? GetRole(string name)
        {
            SqlParameter parm = new SqlParameter(PARM_NAME, SqlDbType.NVarChar, 32);
            parm.Value = name.Trim();

            using (SqlDataReader rdr = Database.ExecuteReader(StaticVariables.SQLConnectionString, CommandType.Text, SQL_SELECT_ROLE_BY_NAME, parm))
            {
                if (rdr.Read())
                {
                    return ToVO(rdr);
                }
                return null;
            }
        }
        #endregion public RoleVO? GetRole(string name)

        #endregion Public Methods
    }
}