USE wm75
--SELECT DISTINCT Person.Name, UserId, TeamId FROM Person INNER JOIN Team ON (Team.TeamLeaderId = Person.UserId)
SELECT DISTINCT * FROM Project INNER JOIN Task ON (Task.ProjectId = Project.ProjectId) WHERE TeamId = 1