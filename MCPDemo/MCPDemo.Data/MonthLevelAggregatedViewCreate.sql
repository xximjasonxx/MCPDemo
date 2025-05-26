CREATE VIEW [dbo].[MonthYearAggregatedCaseInfo]
WITH SCHEMABINDING
AS
SELECT
  -- Use a deterministic representation for the month-year.
  -- CONVERT(NVARCHAR(7), [Date], 120) gives 'YYYY-MM' (e.g., '2020-01').
  -- This is deterministic and suitable for an indexed view.
  CONVERT(NVARCHAR(7), [Date], 120) AS TimePeriod,
  -- Ensure LocationKey is NOT NULL if it's part of the index key.
  -- If LocationKey can be NULL in the base table, you might need COALESCE:
  -- COALESCE(LocationKey, 'N/A') AS LocationKey,
  LocationKey,
  SUM(ISNULL(NewConfirmedCases, 0)) AS NewConfirmedCases,
  SUM(ISNULL(NewDeceasedCases, 0)) AS NewDeceasedCases,
  SUM(ISNULL(NewRecoveredCases, 0)) AS NewRecoveredCases,
  COUNT_BIG(*) AS TotalRecordsInGroup
FROM [dbo].[DateLocationCaseInfo]
-- Group by the deterministic components used in SELECT
GROUP BY
  CONVERT(NVARCHAR(7), [Date], 120),
  LocationKey
GO



CREATE UNIQUE CLUSTERED INDEX [IX_MonthYearAggregatedCaseInfo]
ON [dbo].[MonthYearAggregatedCaseInfo] ([TimePeriod], [LocationKey]);
GO