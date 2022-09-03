declare @fn varchar(2)
select @fn = FirstName
from Employees
where id = 2
select @fn