use Company_2;
select * from TaskTechnology;
select * from EmployeeTask;
select * from StatusMaster;
select * from Project;
select * from Employee;
select * from Client;
insert into StatusMaster (StatusID, StatusName)
values(1,'Active'),(2,'Assigned'),(3,'NotAssigned'),(4,'Delayed');