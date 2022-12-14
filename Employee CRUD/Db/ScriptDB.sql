USE [Maqta]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[JobName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NULL,
	[Email] [nvarchar](50) NULL,
	[Tel] [nvarchar](15) NULL,
	[Address] [nvarchar](50) NULL,
	[JobId] [int] NULL,
	[DepartmentId] [int] NULL,
	[JoinedDate] [date] NULL,
	[UserId] [int] NULL,
	[TransDate] [datetime] NULL,
 CONSTRAINT [PK_Emp] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewEmployee]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewEmployee]
AS
SELECT dbo.Employee.EmpId, dbo.Employee.FullName, dbo.Employee.Email, dbo.Employee.Tel, dbo.Employee.Address, dbo.Employee.JoinedDate, dbo.Jobs.JobName, dbo.Departments.DepartmentName, dbo.Jobs.JobId, 
                  dbo.Departments.DepartmentId
FROM     dbo.Employee INNER JOIN
                  dbo.Jobs ON dbo.Jobs.JobId = dbo.Employee.JobId INNER JOIN
                  dbo.Departments ON dbo.Departments.DepartmentId = dbo.Employee.DepartmentId
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (1, N'IT')
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (2, N'Sales')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmpId], [FullName], [Email], [Tel], [Address], [JobId], [DepartmentId], [JoinedDate], [UserId], [TransDate]) VALUES (3, N'ahmed salah up', N'mail@mail.com', N'925620212', N'sudan', 1, 1, CAST(N'2022-08-20' AS Date), 0, CAST(N'2022-08-20T11:33:54.737' AS DateTime))
INSERT [dbo].[Employee] ([EmpId], [FullName], [Email], [Tel], [Address], [JobId], [DepartmentId], [JoinedDate], [UserId], [TransDate]) VALUES (5, N'khaled hassan', N'test@m.co', N'5555', N'east', 2, 2, CAST(N'2022-09-01' AS Date), 0, CAST(N'2022-08-20T11:44:44.483' AS DateTime))
INSERT [dbo].[Employee] ([EmpId], [FullName], [Email], [Tel], [Address], [JobId], [DepartmentId], [JoinedDate], [UserId], [TransDate]) VALUES (7, N'sara ali', N'sara@mail.com', N'99999', N'sudan', 2, 2, CAST(N'2022-08-09' AS Date), 0, CAST(N'2022-08-20T15:37:03.143' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Jobs] ON 

INSERT [dbo].[Jobs] ([JobId], [JobName]) VALUES (2, N'Accounting')
INSERT [dbo].[Jobs] ([JobId], [JobName]) VALUES (1, N'Developer')
SET IDENTITY_INSERT [dbo].[Jobs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertDepartment]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertDepartment]
@DepartmentId int,
@DepartmentName nvarchar(150)
as
if @DepartmentId >0
	Begin
	update Departments set DepartmentName=DepartmentName where DepartmentId=@DepartmentId
	End
		else
			Begin
			insert Departments (DepartmentName)values (@DepartmentName)
			End
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertEmployee]
@EmpId int,
@FullName nvarchar(150),
@Email nvarchar(50),
@Tel nvarchar(15),
@Address  nvarchar(50),
@JobId int,
@DepartmentId int,
@JoinedDate date,
@UserId int
as
-- this proc for insert and update (single proc> multi operation),
if @EmpId>0
	Begin
	update Employee set FullName=@FullName,Email=@Email,Tel=@Tel,Address=@Address,JobId=@JobId,JoinedDate=@JoinedDate,
	DepartmentId=@DepartmentId
	where EmpId=@EmpId
	End
		else
			Begin
				insert Employee (FullName,Email,Tel,[Address],JobId,DepartmentId,JoinedDate,UserId,TransDate)values
				(@FullName,@Email,@Tel,@Address,@JobId,@DepartmentId,@JoinedDate,@UserId,GETDATE())
			End
GO
/****** Object:  StoredProcedure [dbo].[InsertJob]    Script Date: 8/20/2022 6:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertJob]
@JobId int,
@JobName nvarchar(50)
as
if @JobId >0
	Begin
		update Jobs set JobName=@JobName where JobId=@JobId
	End
		else
			Begin
			insert Jobs (JobName)values (@JobName)
			End
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employee"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 310
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Jobs"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Departments"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 126
               Right = 747
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewEmployee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewEmployee'
GO
