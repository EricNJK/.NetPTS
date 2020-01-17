--USE ifpwafcad
--SELECT * FROM Project WHERE ProjectId = (SELECT ProjectId FROM Task WHERE TeamId = 3)
--SELECT * FROM Subject WHERE counselor_idfk = (SELECT counselor_id FROM Counselor WHERE counselor_id = '1')
USE wm75
SELECT * FROM Project WHERE CustomerId = '2'
