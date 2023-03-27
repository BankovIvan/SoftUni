use FootballersExam
SELECT
	t.Name AS [Name]
	, f.Name AS [FootballerName]
	, f.ContractStartDate AS [ContractStartDate]
	, f.ContractEndDate AS [ContractEndDate]
	, f.BestSkillType AS [BestSkillType]
	, f.PositionType AS [PositionType]
FROM
	Teams AS t
	JOIN TeamsFootballers AS tf
	ON t.Id = tf.TeamId
	JOIN Footballers AS f
	ON tf.FootballerId = f.Id
ORDER BY
	t.Name
	, f.Name