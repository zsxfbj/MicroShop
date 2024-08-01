/*******   *********/
USE [micro_shop]
GO

/****** Object:  Table [dbo].[role]    Script Date: 2024/8/1 14:49:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[role](
	[role_id] [bigint] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](32) NOT NULL,
	[note] [nvarchar](256) NULL,
	[is_enable] [bit] NOT NULL,
	[is_deleted] [bit] NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF__role__note__3C69FB99]  DEFAULT (N'') FOR [note]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF_role_is_enable]  DEFAULT ((1)) FOR [is_enable]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF_role_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF__role__created_at__3D5E1FD2]  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF__role__updated_at__3E52440B]  DEFAULT (getdate()) FOR [updated_at]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'role_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'role_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'note'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'is_enable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'is_deleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'created_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'updated_at'
GO



/****** Object:  Table [dbo].[menu]    Script Date: 2024/8/1 14:50:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[menu](
	[menu_id] [bigint] IDENTITY(1,1) NOT NULL,
	[parent_id] [bigint] NOT NULL,
	[menu_name] [nvarchar](32) NOT NULL,
	[menu_type] [int] NULL,
	[path] [varchar](256) NULL,
	[icon] [varchar](256) NULL,
	[component_name] [varchar](64) NULL,
	[component_config] [varchar](256) NULL,
	[permission] [varchar](256) NULL,
	[is_enable] [bit] NULL,
	[hidden] [bit] NULL,
	[order_value] [int] NOT NULL,
	[note] [nvarchar](256) NULL,
	[is_deleted] [bit] NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_parent_id]  DEFAULT ((0)) FOR [parent_id]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_menu_type]  DEFAULT ((1)) FOR [menu_type]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_is_enable]  DEFAULT ((1)) FOR [is_enable]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_hidden]  DEFAULT ((0)) FOR [hidden]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_order_value]  DEFAULT ((1)) FOR [order_value]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_created_at]  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'menu_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级菜单地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'parent_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'menu_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'menu_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'path'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'component_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组件配置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'component_config'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'permission'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'is_enable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否隐藏' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'hidden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'order_value'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'note'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'is_deleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'created_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'menu', @level2type=N'COLUMN',@level2name=N'updated_at'
GO



/****** Object:  Table [dbo].[role_menu_relation]    Script Date: 2024/8/1 14:51:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[role_menu_relation](
	[role_id] [bigint] NOT NULL,
	[menu_id] [bigint] NOT NULL,
	[permission] [varchar](256) NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_role_menu_relation] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[system_user]    Script Date: 2024/8/1 14:51:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[system_user](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[role_id] [bigint] NULL,
	[login_name] [nvarchar](32) NOT NULL,
	[salt] [varchar](32) NULL,
	[login_password] [varchar](512) NULL,
	[user_name] [nvarchar](64) NULL,
	[mobile] [varchar](64) NULL,
	[email] [varchar](256) NULL,
	[is_admin] [bit] NULL,
	[login_status] [int] NULL,
	[login_count] [int] NULL,
	[is_deleted] [bit] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[last_login] [datetime] NULL,
 CONSTRAINT [PK_system_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_role_id]  DEFAULT ((0)) FOR [role_id]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_is_admin]  DEFAULT ((0)) FOR [is_admin]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_login_status]  DEFAULT ((0)) FOR [login_status]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_login_count]  DEFAULT ((0)) FOR [login_count]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_created_at]  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[system_user] ADD  CONSTRAINT [DF_system_user_updated_at]  DEFAULT (getdate()) FOR [updated_at]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'role_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'login_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'login_password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'user_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'mobile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'is_admin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录状态：0-禁止；1-允许' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'login_status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'login_count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'is_deleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'created_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'updated_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最新登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user', @level2type=N'COLUMN',@level2name=N'last_login'
GO


/****** Object:  Table [dbo].[system_user_action_log]    Script Date: 2024/8/1 14:52:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[system_user_action_log](
	[log_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[user_name] [nvarchar](32) NULL,
	[access_token] [varchar](512) NULL,
	[action_type] [int] NULL,
	[remote_ip] [varchar](128) NULL,
	[user_agent] [varchar](512) NULL,
	[request_url] [varchar](512) NULL,
	[operate_content] [ntext] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [PK_system_user_action_log] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[system_user_action_log] ADD  CONSTRAINT [DF_system_user_action_log_user_id]  DEFAULT ((0)) FOR [user_id]
GO

ALTER TABLE [dbo].[system_user_action_log] ADD  CONSTRAINT [DF_system_user_action_log_action_type]  DEFAULT ((0)) FOR [action_type]
GO

ALTER TABLE [dbo].[system_user_action_log] ADD  CONSTRAINT [DF_system_user_action_log_created_at]  DEFAULT (getdate()) FOR [created_at]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'增值流水号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'log_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'user_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'user_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问令牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'access_token'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'action_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'远程访问的ip' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'remote_ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户端类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'user_agent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求接口地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'request_url'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提交的内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'operate_content'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'记录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'system_user_action_log', @level2type=N'COLUMN',@level2name=N'created_at'
GO

