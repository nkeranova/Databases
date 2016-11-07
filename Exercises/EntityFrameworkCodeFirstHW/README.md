## Entity Framework Code First

### _Homework_

1. Using code first approach, create database for student system with the following tables:
    * `Students` (with Id, Name, Number, etc.)
    * `Courses` (Name, Description, Materials, etc.)
    * `StudentsInCourses` (many-to-many relationship)
    * `Homework` (one-to-many relationship with students and courses), fields: Content, TimeSent
    * Annotate the data models with the appropriate attributes and enable code first migrations
1. Write a console application that uses the data.
1. Seed the data with random values.