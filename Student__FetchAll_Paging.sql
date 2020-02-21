CREATE PROCEDURE Student__FetchAll_Paging
(
	@SearchValue NVARCHAR(50) = NULL,
	@PageNo INT = 1,
	@PageSize INT = 10,
	@SortColumn NVARCHAR(20) = 'StudentName',
	@SortOrder NVARCHAR(20) = 'ASC'
)
 AS BEGIN
 SET NOCOUNT ON;

 SET @SearchValue = LTRIM(RTRIM(@SearchValue))

 ; WITH CTE_Results AS 
(
    SELECT StudentId, StudentName, StudentRollNumber from StudentInformation 
	WHERE (@SearchValue IS NULL OR StudentName LIKE '%' + @SearchValue + '%') 
	 	    ORDER BY
   	 CASE WHEN (@SortColumn = 'StudentName' AND @SortOrder='ASC')
                    THEN StudentName
        END ASC,
        CASE WHEN (@SortColumn = 'StudentName' AND @SortOrder='DESC')
                   THEN StudentName
		END DESC,
	 CASE WHEN (@SortColumn = 'StudentRollNumber' AND @SortOrder='ASC')
                    THEN StudentRollNumber
        END ASC,
        CASE WHEN (@SortColumn = 'StudentRollNumber' AND @SortOrder='DESC')
                   THEN StudentRollNumber
		END DESC 
      OFFSET @PageSize * (@PageNo - 1) ROWS
      FETCH NEXT @PageSize ROWS ONLY
	),
CTE_TotalRows AS 
(
 select count(StudentId) as MaxRows from StudentInformation WHERE (@SearchValue IS NULL OR StudentName LIKE '%' + @SearchValue + '%')
)
   Select MaxRows, t.StudentId, t.StudentName, t.StudentRollNumber from dbo.StudentInformation as t, CTE_TotalRows 
   WHERE EXISTS (SELECT 1 FROM CTE_Results WHERE CTE_Results.StudentId = t.StudentId)
   OPTION (RECOMPILE)
   END
GO