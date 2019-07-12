# Book.DB.ADO.Net
USE [BookDB]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 7/12/2019 7:06:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 7/12/2019 7:06:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[author]    Script Date: 7/12/2019 7:06:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[author](
	[Id] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Country_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[book]    Script Date: 7/12/2019 7:06:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Author_Id] [int] NOT NULL,
	[Genre_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ClassicView]    Script Date: 7/12/2019 7:06:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClassicView]
AS
SELECT        dbo.book.Name, dbo.author.FullName, dbo.country.Name AS Country, dbo.genre.Name AS Genre
FROM            dbo.author INNER JOIN
                         dbo.book ON dbo.author.Id = dbo.book.Author_Id INNER JOIN
                         dbo.country ON dbo.author.Country_Id = dbo.country.Id INNER JOIN
                         dbo.genre ON dbo.book.Genre_Id = dbo.genre.Id
GO
ALTER TABLE [dbo].[author]  WITH CHECK ADD FOREIGN KEY([Country_Id])
REFERENCES [dbo].[country] ([Id])
GO
ALTER TABLE [dbo].[book]  WITH CHECK ADD FOREIGN KEY([Author_Id])
REFERENCES [dbo].[author] ([Id])
GO
ALTER TABLE [dbo].[book]  WITH CHECK ADD FOREIGN KEY([Genre_Id])
REFERENCES [dbo].[genre] ([Id])
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
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4[30] 2[40] 3) )"
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
         Begin Table = "author"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "book"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "country"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 102
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "genre"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 102
               Right = 832
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassicView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassicView'
GO
INSERT INTO genre VALUES(1,'Classic'),(2,'Fantasy'),(3,'Romance'),(4,'Fairy Tale'),(5,'Historical Fiction'),(6,'Horror'),
(7,'Magical Realism'),(8,'Crime and Detective'),(9,'Drama'),(10,'Humor');
INSERT INTO [country] VALUES(1,'United Kingdom'),(2,'United States of America'),(3,'Colombia'),(4,'Germany'),(5,'Italy'),
(6,'Russia'),(7,'Greece'),(8,'China'),(9,'Armenia');
INSERT INTO author VALUES(1,'Gabriel Garcia Marquez',3),(2,'William Shakespeare',1),(3,'Oscar Wilde',1),(4,'John Tolkien',1),
(5,'Fyodor Mikhailovich Dostoevsky',6),(6,'Mikhail Bulgakov',6),(7,'Dante Alighieri',5),(8,'Joanne Rowling',2),(9,'Alexander Shirvanzade',9),
(10,'Jane Austen',1);
INSERT INTO book VALUES('Pride and Prejudice',10,1),('Antony and Cleopatra',2,1),('Macbeth',2,1),('Hamlet',2,1),
('The Master and Margarita',6,2),('The Lord of the Rings',4,2),('Harry Potter and thePhilosophers Stone',8,2),
('Harry Potter and the Chamber of Secrets',8,2),('Harry Potter and thePrisoner of Azkaban',8,2),
('Harry Potter and the Goblet of Fire',8,2),('Harry Potter and the Order of the Phoenix',8,2),
('Harry Potter and the Half-Blood Prince',8,2),('Harry Potter and the Deathly Hallows',8,2),('One Hundred Years of Solitude',1,7);

