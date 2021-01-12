use Company;
select * from TaskTechnology;
select * from Technology;
select * from EmployeeTask;
select * from StatusMaster;
select * from Project;
select * from ProjectTechnology;
select * from ProjectTask;
select * from Employee;
select * from Client;
insert into StatusMaster (StatusID, StatusName)
values(1,'Active'),(2,'Assigned'),(3,'NotAssigned'),(4,'Delayed');
delete from TaskTechnology where TaskID = 1 and TechnologyID = 2;
insert into TaskTechnology (TaskID,TechnologyID) values(1,2);