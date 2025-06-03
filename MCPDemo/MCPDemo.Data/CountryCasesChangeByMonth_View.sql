DROP VIEW [dbo].[CountryCasesChangeByMonth]
GO

CREATE VIEW [dbo].[CountryCasesChangeByMonth]
WITH SCHEMABINDING
AS
SELECT
  c.CountryCode,
  c.CountryName,
  c.LocationKey,
  c.CurrentTimePeriod,
  ((c.CurrentNewConfirmedCases - c.PreviousNewConfirmedCases) * 100.0 / NULLIF(c.PreviousNewConfirmedCases, 0)) AS NewCasesPercentageChange,
  ((c.CurrentNewDeceasedCases - c.PreviousNewDeceasedCases) * 100.0 / NULLIF(c.PreviousNewDeceasedCases, 0)) AS NewDeceasedPercentageChange,
  ((c.CurrentNewRecoveredCases - c.PreviousNewRecoveredCases) * 100.0 / NULLIF(c.PreviousNewRecoveredCases, 0)) AS NewRecoveredPercentageChange
FROM (
  SELECT
    l.CountryCode,
    l.CountryName,
    tx.LocationKey,
    tx.Actual as CurrentTimePeriod,
    tx.Previous as PreviousTimePeriod,
    tx.NewConfirmedCases as CurrentNewConfirmedCases,
    tx2.NewConfirmedCases as PreviousNewConfirmedCases,

    tx.NewDeceasedCases as CurrentNewDeceasedCases,
    tx2.NewDeceasedCases as PreviousNewDeceasedCases,

    tx.NewRecoveredCases as CurrentNewRecoveredCases,
    tx2.NewRecoveredCases as PreviousNewRecoveredCases
  FROM (
    SELECT
      tt.TimePeriod as Actual,
      CONVERT(NVARCHAR(7), DATEADD(MONTH, -1, CAST(tt.TimePeriod + '-01' AS DATETIME2)), 120) as Previous,
      tt.LocationKey,
      tt.NewConfirmedCases,
      tt.NewDeceasedCases,
      tt.NewRecoveredCases
    FROM
      [dbo].[MonthYearAggregatedCaseInfo] tt
    WHERE
      LEN(tt.LocationKey) = 2
  ) tx LEFT JOIN [dbo].[MonthYearAggregatedCaseInfo] tx2 on tx.LocationKey = tx2.LocationKey
      AND tx2.TimePeriod = tx.Previous
    INNER JOIN [dbo].[Locations] l ON tx.LocationKey = l.LocationKey
) c
GO
