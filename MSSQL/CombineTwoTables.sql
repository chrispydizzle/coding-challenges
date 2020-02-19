/* Write your T-SQL query statement below */
select p.FirstName, p.LastName, a.City, a.State
from Person p
left outer join Address a on a.PersonId = p.PersonId