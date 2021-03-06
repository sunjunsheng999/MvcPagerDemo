

CREATE TABLE [dbo].[Info](
	[InfoID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NULL,
	[Content] [varchar](8000) NULL,
 CONSTRAINT [PK_Info] PRIMARY KEY CLUSTERED 
(
	[InfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题2'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题2'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题3'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题3'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题1'
           ,'内容1')
GO
INSERT INTO [dbo].[Info]
           ([Title]
           ,[Content])
     VALUES
           ('标题3'
           ,'内容1')
GO



CREATE PROCEDURE [dbo].[prPager]
	@PageSize INT, ----每页记录数
	@CurrentCount INT, ----当前记录数量（页码*每页记录数）
	@TableName NVARCHAR(200), ----表名称
	@Where NVARCHAR(800), ----查询条件
	@Order NVARCHAR(800),----排序条件
	@TotalCount INT OUTPUT ----记录总数
AS
	DECLARE @sqlSelect    NVARCHAR(2000) ----局部变量（sql语句），查询记录集
	DECLARE @sqlGetCount  NVARCHAR(2000) ----局部变量（sql语句），取出记录集总数
	
	
	SET @sqlSelect = 'SELECT * FROM  ' 
	    + '    (SELECT ROW_NUMBER()  OVER( ORDER BY ' + @Order +
	    ' ) AS RowNumber,* '
	    + '        FROM ' + @TableName 
	    + '        WHERE ' + @Where 
	    + '     ) as  T2 ' 
	    + ' WHERE T2.RowNumber<= ' + STR(@CurrentCount + @PageSize) +
	    ' AND T2.RowNumber>' + STR(@CurrentCount) 
	
	SET @sqlGetCount = 'SELECT @TotalCount = COUNT(*) FROM ' + @TableName 
	    + ' WHERE ' + @Where
	
	
	EXEC (@sqlSelect) 
	EXEC SP_EXECUTESQL @sqlGetCount,
	     N'@TotalCount INT OUTPUT',
	     @TotalCount OUTPUT


GO





