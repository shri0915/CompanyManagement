﻿use Company_2;
select * from TaskTechnology;
select * from EmployeeTask;
select * from StatusMaster;
select * from Project;
insert into StatusMaster (StatusID, StatusName)
values(1,'Active'),(2,'Assigned'),(3,'NotAssigned'),(4,'Delayed');