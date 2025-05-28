CREATE VIEW [dbo].[FinalCasesByCountry]
WITH SCHEMABINDING
AS
SELECT
  l.CountryCode,
  l.CountryName,
  MAX(ISNULL(CumulativeConfirmedCases, 0)) as FinalConfirmedCases,
  MAX(ISNULL(CumulativeDeceasedCases, 0)) as FinalDeceasedCases,
  MAX(ISNULL(CumulativeRecoveredCases, 0)) as FinalRecoveredCases,
  MAX(ISNULL(CumulativeTestsConducted, 0)) as FinalTestsConducted,
  COUNT_BIG(*) AS TotalRecordsInGroup
FROM [dbo].[DateLocationCaseInfo] dlci
  INNER JOIN [dbo].[Locations] l ON dlci.LocationKey = l.LocationKey
GROUP BY
  l.CountryCode,
  l.CountryName
GO