# Reporting Web Application

This repository holds the code for a reporting system that was part of the a University assignment which I worked on with a fellow student.  The technologies used are ASP.Net Core MVC, EF Core and SQL Server.


## Project Description
This app serves as a reporting portal for near miss accidents at the University of Malta campus.  There are two types of users: reporters and investigators.  Reporters can create a near-miss report while investigators are responsible to review these reports and eventually add an investigation entry to each individual report before closing the case. There can only be one investigation for each report. Reporters will be able to create reports, edit/delete their own reports and browse all near-miss entries (and associated investigation, if any) created by themselves and others. Reporters may also upvote other people’s reports. Apart from the above operations, investigators are also able to add and edit investigations for individual reports.

Beyond the specifications of this project, we also added an upload photo feature and Google Maps integration to each report. Moreover, investigators were notified by email when a report is assigned to them. A restriction was placed at the SSO such that only account a University of Malta could access the app.  This part of the code is in startup.cs and has been commented out so that anyone with a Google account can access the app.


## How to run the code
1. Go to appsettings.json and change the query string to connect to your own database.

2. Go to Tools > NuGet Package Manager > Package Manager Console, and write Update-database.

3. Run the application by going to debug > start without debugging.


Please note that when users log in for the first time, the role is set to reporter by default. You must set an admin from the code and then you can change each user's role from the admin account.  To do this go to SQL Server management studio and run the following query at the database: "UPDATE dbo.Users SET Role = 2 WHERE UserId = <enterUserIdHere>"
