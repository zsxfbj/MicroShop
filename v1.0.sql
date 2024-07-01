USE [micro_shop]
GO

/****** Object:  Table [dbo].[role]    Script Date: 2024/7/1 17:20:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](32) NOT NULL,
	[is_enable] [bit] NOT NULL,
	[note] [nvarchar](256) NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF_role_is_enable]  DEFAULT ((0)) FOR [is_enable]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF__role__note__3C69FB99]  DEFAULT (N'') FOR [note]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF__role__created_at__3D5E1FD2]  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[role] ADD  CONSTRAINT [DF__role__updated_at__3E52440B]  DEFAULT (getdate()) FOR [updated_at]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'role_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'role_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'is_enable'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'note'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'created_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'role', @level2type=N'COLUMN',@level2name=N'updated_at'
GO

