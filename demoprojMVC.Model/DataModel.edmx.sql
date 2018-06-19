
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2018 20:35:31
-- Generated from EDMX file: I:\Project\demoprojMVC2\demoprojMVC.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [hynustuaff];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ActionInfoR_UserInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_ActionInfo] DROP CONSTRAINT [FK_ActionInfoR_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoR_UserInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[R_UserInfo_ActionInfo] DROP CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoUserInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoUserInfo] DROP CONSTRAINT [FK_RoleInfoUserInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoUserInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoUserInfo] DROP CONSTRAINT [FK_RoleInfoUserInfo_UserInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[acts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[acts];
GO
IF OBJECT_ID(N'[dbo].[application_list]', 'U') IS NOT NULL
    DROP TABLE [dbo].[application_list];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[T_App]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_App];
GO
IF OBJECT_ID(N'[dbo].[T_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Roles];
GO
IF OBJECT_ID(N'[dbo].[T_Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Users];
GO
IF OBJECT_ID(N'[dbo].[td_students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[td_students];
GO
IF OBJECT_ID(N'[dbo].[ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[R_UserInfo_ActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[R_UserInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoActionInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoUserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoUserInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'acts'
CREATE TABLE [dbo].[acts] (
    [act_id] int IDENTITY(1,1) NOT NULL,
    [act_tarids] varchar(50)  NULL,
    [act_tartablename] varchar(25)  NULL,
    [act_userIP] varchar(20)  NOT NULL,
    [act_username] varchar(30)  NOT NULL,
    [act_useraction] varchar(30)  NOT NULL,
    [act_sqlstr] varchar(200)  NULL,
    [act_datetime] datetime  NULL,
    [act_deptname] varchar(70)  NOT NULL,
    [act_userrolename] varchar(30)  NOT NULL,
    [act_DETAIL] varchar(max)  NULL
);
GO

-- Creating table 'application_list'
CREATE TABLE [dbo].[application_list] (
    [id] varchar(12)  NOT NULL,
    [application_program] varchar(10)  NULL,
    [school_code] varchar(10)  NULL,
    [school_year] varchar(10)  NULL,
    [application_start_data] datetime  NULL,
    [application_end_data] datetime  NULL,
    [application_status] varchar(10)  NULL,
    [prize_level] varchar(10)  NULL,
    [is_difficult_stu] bit  NULL,
    [score_kao_ping_lowest] varchar(10)  NULL,
    [nianji_score_rank] varchar(10)  NULL,
    [banji_score_rank] varchar(10)  NULL,
    [danke_lowest] varchar(10)  NULL,
    [pinjun_lowest] varchar(10)  NULL,
    [is_fail_a_exam] bit  NULL,
    [is_punishment] bit  NULL,
    [once_is_punishment] bit  NULL,
    [suitable_object] varchar(50)  NULL,
    [project_intro] varchar(max)  NULL,
    [instructor_audit] bit  NULL,
    [instructor] varchar(10)  NULL,
    [xuegong_audit] bit  NULL,
    [xuegong] varchar(10)  NULL,
    [dept_approver] varchar(10)  NULL,
    [dept_audit] bit  NULL,
    [is_instructor_audit] bit  NULL,
    [is_dept_audit] bit  NULL,
    [audit] bit  NOT NULL,
    [lock] bit  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [id] varchar(9)  NOT NULL,
    [dept_name] varchar(50)  NOT NULL,
    [dept_code] varchar(20)  NOT NULL,
    [subject_code] varchar(20)  NOT NULL,
    [connect_user] varchar(20)  NOT NULL,
    [dept_director] varchar(16)  NOT NULL,
    [found_time] datetime  NULL,
    [email] varchar(25)  NULL,
    [tel] varchar(20)  NULL,
    [website] varchar(50)  NULL,
    [introduction] nvarchar(max)  NULL,
    [numofyanjiusheng] int  NULL,
    [numofboshisheng] int  NULL,
    [numofCNBooks] int  NULL,
    [numofFLBooks] int  NULL,
    [numofCNQikan] int  NULL,
    [numofFLQikan] int  NULL,
    [update_time] datetime  NULL,
    [audit] bit  NULL,
    [lock] tinyint  NULL,
    [Lab_equipment_count] int  NULL,
    [address] varchar(30)  NULL,
    [Lab_equipment_property] decimal(19,4)  NULL,
    [admit_unit] varchar(30)  NULL,
    [numstaff] int  NULL,
    [numproject] int  NULL,
    [numarchievement] int  NULL,
    [numaward] int  NULL,
    [numreflection] int  NULL
);
GO

-- Creating table 'T_App'
CREATE TABLE [dbo].[T_App] (
    [ID] varchar(11)  NOT NULL,
    [app_code] varchar(8)  NULL,
    [app_name] nvarchar(30)  NOT NULL,
    [app_nameEn] varchar(50)  NULL,
    [app_type] varchar(4)  NULL,
    [dept_Code] varchar(4)  NOT NULL,
    [proc_name] varchar(30)  NULL,
    [host_url] varchar(50)  NULL,
    [audit] bit  NULL,
    [listorder] int  NULL,
    [parent_appcode] varchar(8)  NULL
);
GO

-- Creating table 'T_Roles'
CREATE TABLE [dbo].[T_Roles] (
    [ID] varchar(12)  NOT NULL,
    [role_name] varchar(50)  NOT NULL,
    [role_AuthorRights] int  NOT NULL,
    [DataScale] varchar(10)  NULL,
    [audit] bit  NULL,
    [ntime] datetime  NULL,
    [sitemap] varchar(30)  NULL
);
GO

-- Creating table 'T_Users'
CREATE TABLE [dbo].[T_Users] (
    [id] varchar(13)  NOT NULL,
    [user_code] varchar(15)  NOT NULL,
    [user_name] varchar(20)  NOT NULL,
    [user_realname] varchar(12)  NULL,
    [user_roles_code] varchar(12)  NOT NULL,
    [user_dept_code] varchar(12)  NOT NULL,
    [user_telphone] varchar(50)  NULL,
    [user_password] varchar(32)  NOT NULL,
    [regdatetime] datetime  NULL,
    [lastApp] varchar(60)  NULL,
    [authApps] varchar(max)  NULL,
    [authRights] varchar(max)  NULL,
    [lastLoginDatetime] datetime  NULL,
    [lastLoginIP] varchar(30)  NULL,
    [useRolesitemap] bit  NULL,
    [lock] smallint  NULL,
    [audit] bit  NULL
);
GO

-- Creating table 'td_students'
CREATE TABLE [dbo].[td_students] (
    [id] varchar(12)  NOT NULL,
    [school_code] varchar(10)  NOT NULL,
    [student_name] varchar(10)  NOT NULL,
    [grade] varchar(10)  NULL,
    [dept] varchar(10)  NULL,
    [major] varchar(10)  NULL,
    [banji] varchar(10)  NULL,
    [gender] varchar(2)  NULL,
    [nation] varchar(10)  NULL,
    [born_date] datetime  NULL,
    [telephone] varchar(14)  NULL,
    [politicstatus] varchar(6)  NULL,
    [ID_card] varchar(18)  NULL,
    [native_place] varchar(20)  NULL,
    [address] varchar(100)  NULL,
    [home_telephone] varchar(14)  NULL,
    [rollin_date] datetime  NULL,
    [dormitory] varchar(10)  NULL,
    [imageurl] varchar(50)  NULL,
    [audit] bit  NULL,
    [lock] bit  NULL
);
GO

-- Creating table 'ActionInfo'
CREATE TABLE [dbo].[ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SubTime] datetime  NOT NULL,
    [ModfiedOn] datetime  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [DelFlag] smallint  NOT NULL,
    [Url] nvarchar(512)  NOT NULL,
    [HttpMethd] nvarchar(32)  NULL,
    [ActionName] nvarchar(32)  NOT NULL,
    [IsMenu] bit  NOT NULL,
    [MenuIcon] nvarchar(512)  NULL,
    [Sort] int  NOT NULL
);
GO

-- Creating table 'R_UserInfo_ActionInfo'
CREATE TABLE [dbo].[R_UserInfo_ActionInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HasPermission] bit  NOT NULL,
    [UserInfoID] int  NOT NULL,
    [ActionInfoID] int  NOT NULL,
    [DelFlag] smallint  NOT NULL
);
GO

-- Creating table 'RoleInfo'
CREATE TABLE [dbo].[RoleInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(32)  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [ModfiedOn] datetime  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [DelFlag] smallint  NOT NULL
);
GO

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NULL,
    [Pwd] nvarchar(32)  NOT NULL,
    [ShowName] nvarchar(64)  NOT NULL,
    [DelFlag] smallint  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [ModfiedOn] datetime  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfoActionInfo_ActionInfo_ID] int  NOT NULL,
    [ActionInfo_ID] int  NOT NULL
);
GO

-- Creating table 'RoleInfoUserInfo'
CREATE TABLE [dbo].[RoleInfoUserInfo] (
    [RoleInfoUserInfo_UserInfo_ID] int  NOT NULL,
    [UserInfo_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [act_id] in table 'acts'
ALTER TABLE [dbo].[acts]
ADD CONSTRAINT [PK_acts]
    PRIMARY KEY CLUSTERED ([act_id] ASC);
GO

-- Creating primary key on [id] in table 'application_list'
ALTER TABLE [dbo].[application_list]
ADD CONSTRAINT [PK_application_list]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'T_App'
ALTER TABLE [dbo].[T_App]
ADD CONSTRAINT [PK_T_App]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'T_Roles'
ALTER TABLE [dbo].[T_Roles]
ADD CONSTRAINT [PK_T_Roles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'T_Users'
ALTER TABLE [dbo].[T_Users]
ADD CONSTRAINT [PK_T_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'td_students'
ALTER TABLE [dbo].[td_students]
ADD CONSTRAINT [PK_td_students]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'ActionInfo'
ALTER TABLE [dbo].[ActionInfo]
ADD CONSTRAINT [PK_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [PK_R_UserInfo_ActionInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RoleInfo'
ALTER TABLE [dbo].[RoleInfo]
ADD CONSTRAINT [PK_RoleInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RoleInfoActionInfo_ActionInfo_ID], [ActionInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY CLUSTERED ([RoleInfoActionInfo_ActionInfo_ID], [ActionInfo_ID] ASC);
GO

-- Creating primary key on [RoleInfoUserInfo_UserInfo_ID], [UserInfo_ID] in table 'RoleInfoUserInfo'
ALTER TABLE [dbo].[RoleInfoUserInfo]
ADD CONSTRAINT [PK_RoleInfoUserInfo]
    PRIMARY KEY CLUSTERED ([RoleInfoUserInfo_UserInfo_ID], [UserInfo_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActionInfoID] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [FK_ActionInfoR_UserInfo_ActionInfo]
    FOREIGN KEY ([ActionInfoID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_UserInfo_ActionInfo'
CREATE INDEX [IX_FK_ActionInfoR_UserInfo_ActionInfo]
ON [dbo].[R_UserInfo_ActionInfo]
    ([ActionInfoID]);
GO

-- Creating foreign key on [UserInfoID] in table 'R_UserInfo_ActionInfo'
ALTER TABLE [dbo].[R_UserInfo_ActionInfo]
ADD CONSTRAINT [FK_UserInfoR_UserInfo_ActionInfo]
    FOREIGN KEY ([UserInfoID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoR_UserInfo_ActionInfo'
CREATE INDEX [IX_FK_UserInfoR_UserInfo_ActionInfo]
ON [dbo].[R_UserInfo_ActionInfo]
    ([UserInfoID]);
GO

-- Creating foreign key on [RoleInfoActionInfo_ActionInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfoActionInfo_ActionInfo_ID])
    REFERENCES [dbo].[RoleInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_ID] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ID])
    REFERENCES [dbo].[ActionInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_ID]);
GO

-- Creating foreign key on [RoleInfoUserInfo_UserInfo_ID] in table 'RoleInfoUserInfo'
ALTER TABLE [dbo].[RoleInfoUserInfo]
ADD CONSTRAINT [FK_RoleInfoUserInfo_RoleInfo]
    FOREIGN KEY ([RoleInfoUserInfo_UserInfo_ID])
    REFERENCES [dbo].[RoleInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserInfo_ID] in table 'RoleInfoUserInfo'
ALTER TABLE [dbo].[RoleInfoUserInfo]
ADD CONSTRAINT [FK_RoleInfoUserInfo_UserInfo]
    FOREIGN KEY ([UserInfo_ID])
    REFERENCES [dbo].[UserInfo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoUserInfo_UserInfo'
CREATE INDEX [IX_FK_RoleInfoUserInfo_UserInfo]
ON [dbo].[RoleInfoUserInfo]
    ([UserInfo_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------