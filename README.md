# Job Application Tracker

A full-stack ASP.NET Core MVC application for organizing job applications and tracking progress throughout the hiring process.

This project was built to strengthen my experience with C#, MVC architecture, relational databases, server-side validation, and responsive web design.

## Live Demo

A public demonstration version is currently being prepared.

The demo will contain fictional, shared data that may reset periodically.

## Features

- Create, view, edit, and delete job applications
- Track the furthest hiring stage reached
- Record interview rounds and final outcomes
- Search by company or position
- Filter applications by stage and outcome
- Sort by application date or company name
- View dashboard statistics and hiring-funnel analytics
- Validate related application-progress fields
- Display success notifications after changes
- Use the application across desktop and mobile screen sizes

## Application Data

Each job application can include:

- Company name
- Position title
- Location
- Application date
- Furthest hiring stage reached
- Furthest interview round reached
- Current outcome
- Job-posting URL
- Follow-up date
- Notes

## Dashboard

The dashboard summarizes the current job search with:

- Total applications
- Interview rate
- Offer rate
- Accepted offers
- Applications advancing beyond the initial stage
- Applications reaching multiple interview rounds

## Technologies

- C#
- .NET 10
- ASP.NET Core MVC
- Entity Framework Core 10
- SQLite
- Razor
- HTML and CSS
- Bootstrap
- Git and GitHub

## Project Structure

```text
Controllers/    Handles application requests and database operations
Data/           Contains the Entity Framework database context
Migrations/     Stores database schema changes
Models/         Contains application data models and view models
Views/          Contains Razor pages for the user interface
wwwroot/        Contains CSS, JavaScript, and static assets
