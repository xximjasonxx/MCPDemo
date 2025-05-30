SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FinalCasesByCountryRegionSubRegion]
WITH SCHEMABINDING
AS
SELECT
  l.CountryCode,
  l.SubRegion1Code,
  l.SubRegion2Code,
  l.SubRegion2Name,
  MAX(ISNULL(CumulativeConfirmedCases, 0)) AS CumulativeConfirmedCases,
  MAX(ISNULL(CumulativeDeceasedCases, 0)) AS CumulativeDeceasedCases,
  MAX(ISNULL(CumulativeRecoveredCases, 0)) AS CumulativeRecoveredCases,
  MAX(ISNULL(CumulativeTestsConducted, 0)) AS CumulativeTestsConducted
FROM [dbo].[DateLocationCaseInfo] dlci
  INNER JOIN [dbo].[Locations] l ON dlci.LocationKey = l.LocationKey AND l.SubRegion1Code IS NOT NULL
WHERE
  l.SubRegion2Code IS NOT NULL
GROUP BY
  l.CountryCode,
  l.SubRegion1Code,
  l.SubRegion2Code,
  l.SubRegion2Name
GO
