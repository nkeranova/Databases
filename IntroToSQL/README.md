# Intro to SQL

### _Homework_

1.	What is SQL? What is DML? What is DDL? Recite the most important SQL commands (explanation below).
1.	What is Transact-SQL a.k.a. T-SQL (explanation below)?
1.	Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
1.	Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
1.	Write a SQL query to find all department names.
1.	Write a SQL query to find the salary of each employee.
1.	Write a SQL to find the full name of each employee.
1.	Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
1.	Write a SQL query to find all different employee salaries.
1.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
1.	Write a SQL query to find the names of all employees whose first name starts with "SA".
1.	Write a SQL query to find the names of all employees whose last name contains "ei".
1.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
1.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
1.	Write a SQL query to find all employees that do not have manager.
1.	Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
1.	Write a SQL query to find the top 5 best paid employees.
1.	Write a SQL query to find all employees along with their address. Use inner join with `ON` clause.
1.	Write a SQL query to find all employees and their address. Use equijoins (conditions in the `WHERE` clause).
1.	Write a SQL query to find all employees along with their manager.
1.	Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: `Employees e`, `Employees m` and `Addresses a`.
1.	Write a SQL query to find all departments and all town names as a single list. Use `UNION`.
1.	Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join.
1.	Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

## _Solutions_
#### 1.  _What is SQL? What is DML? What is DDL? Recite the most important SQL commands._

##### **_What is SQL_**
 - SQL stands for Structured Query Language. SQL is used to communicate with a database. It is standard language for relational database management systems developed by Microsoft. SQL statements are used to perform tasks such as update data on a database, or retrieve data from a database. Some common relational database management systems that use SQL are: Oracle, Sybase, Microsoft SQL Server, Access. Although most database systems use SQL, most of them also have their own additional proprietary extensions that are usually only used on their system. However, the standard SQL commands such as "SELECT", "INSERT", "Update", "DELETE", "CREATE" and "DROP" can be used to accomplish almost everything that one needs to do with a database.
 
##### **_What is DML_**
 - A data manipulation language (DML) is a family of syntax elements similar to a computer programming language used for selecting, inserting, deleting and updating data in a database. Performing read-only queries of data is sometimes also considered a component of DML.
 - Data manipulation language comprises the SQL data change statements, which modify stored data but not the schema or database objects. Manipulation of persistent database objects, tables or stored procedures, via the SQL schema statements, rather than the data stored within them, is considered to be part of a separate data definition language.
 
##### **_What is DDL_** 
 - A data definition language or data description language (DDL) is a syntax similar to a computer programming language for defining data structures, especially database schemas.Main functionalities DDL gives are creating, altering, dropping, granting, revoking.
 
##### **_Most important SQL commands_**
 - `SELECT` - get data from a database table
 - `UPDATE` - change data in a database table
 - `DELETE` - remove data from a database table
 - `INSERT` `INTO` - insert new data in a database table
 - `CREATE` `TABLE` - creates a new database table
 - `ALTER` `TABLE` - alters a database table
 - `DROP` `TABLE` - deletes a database table
 
#### 2.  _What is Transact-SQL (T-SQL)?_

##### **_Definition_**
 - T-SQL (Transact-SQL) is a set of programming extensions from Sybase and Microsoft that add several features to the Structured Query Language (SQL) including transaction control, exception and error handling, row processing, and declared variables. 
 - Keywords for flow control in Transact-SQL include `BEGIN` and `END`, `BREAK`, `CONTINUE`, `GOTO`, `IF` and `ELSE`, `RETURN`, `WAITFOR`, and `WHILE`.