SELECT MAX(e.Salary) as SecondHighestSalary
from Employee e
WHERE SALARY <> (SELECT MAX(SALARY) FROM Employee);