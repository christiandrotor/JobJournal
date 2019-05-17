# Job Journal
The Job Journal project was suggested by Emily Gamiel to keep up with jobs that have already been applied to, Mindy Magrath suggested to show my skills on a GitHub project, Molly Snyder helped me find a reputable candidate company to investigate. Thank you for the help.

The application itself is simple but showcases a basic understanding and ability to write a WPF application. At the same time it is useful to keep a log of companies for people who are searching for a job.

## Architecture

This is GitHub project of a WPF application that is coded in XAML in the front end, controlled by C#, and communicates to a backend Microsoft SQL Server Compact Edition database using the Microsoft Entity Framework.

### Reasoning
I decided to use SQL CE because I wanted:
 * Database native to the .Net Framework
 * Embedded database integrated with the software (simple and easy to use)

Choosing the database came down to 2 choices with this criteria. 
1) SQL CE
2) SQLite

While SQLite had the ability to hold up to 140Tb of data I thought that the 4Gb allocated to a SQL CE  was fine enough for a application of this size especially since the database was client-side. When looking over Erik's [article](http://erikej.blogspot.com/2011/01/comparison-of-sql-server-compact-4-and.html), the ADO.NET provider for SQL CE fully supported Entity Framework (EF) 6 where SQLite partially supported EF 6.

Before I was tempted to use just the ADO.NET provider to make a factory for the connection to the database to perform transactions. After reading I found that modeling an ORM was a better choice because it led to fewer mistakes, was easier to use, and added a boundary between the flow of data.

The drawbacks, in retrospect, I realized was SQL CE cannot be run on mobile devices and there will not be a further release. However, there will be support until 2021.

## Contact Info

If you would like to contact me to find out more or have suggestions of what to add, feel free to email me a cndrotor(at)gmail.com

# Thank you :smile:
