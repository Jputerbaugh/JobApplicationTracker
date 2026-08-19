# Job Application Tracker

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)
![Platform](https://img.shields.io/badge/platform-Windows-0078D4)
![Release](https://img.shields.io/github/v/release/Jputerbaugh/JobApplicationTracker)

A local-first ASP.NET Core MVC application for recording job applications, tracking hiring progress, and organizing follow-ups.

[Try the live demo](https://job-application-tracker-demo.onrender.com) · [Download the Windows release](https://github.com/Jputerbaugh/JobApplicationTracker/releases/latest)

## Features

* Create, edit, review, and delete job applications
* Track companies, positions, locations, application dates, and job-posting links
* Record application stages, interview rounds, outcomes, follow-up dates, and notes
* Search, filter, and sort saved applications
* View interview, offer, and acceptance statistics
* Monitor upcoming follow-ups and recently added applications
* Responsive dark interface for desktop and mobile
* Persistent local SQLite storage
* Resettable shared demonstration mode

## Windows Release

The self-contained Windows release does not require a separate .NET installation.

1. Open the [latest release](https://github.com/Jputerbaugh/JobApplicationTracker/releases/latest).
2. Download the `win-x64` ZIP.
3. Extract the ZIP into a folder.
4. Run `JobApplicationTracker.exe`.
5. The application will open automatically in your default browser.

Keep the terminal window open while using the application. Press `Ctrl+C` in that window to shut it down.

Windows SmartScreen may appear because the executable is independently distributed and is not digitally signed.

### Local data

The Windows release stores application data at:

```text
%LocalAppData%\JobApplicationTracker\jobapplications.db
```

The database remains available when the extracted application folder is replaced or updated.

## Live Demo

The hosted demo runs in a Docker container on Render:

https://job-application-tracker-demo.onrender.com

All applications in the demo are fictional. Changes are shared between visitors and may reset periodically. The demo includes a reset control for restoring the original sample records.

Because the demo uses Render's free service tier, the first request after a period of inactivity may take additional time to load.

## Technology

| Area                 | Technology                       |
| -------------------- | -------------------------------- |
| Application          | ASP.NET Core MVC                 |
| Language             | C#                               |
| Framework            | .NET 10                          |
| Data access          | Entity Framework Core            |
| Database             | SQLite                           |
| Interface            | Razor, Bootstrap, custom CSS     |
| Deployment           | Docker and Render                |
| Windows distribution | Self-contained `win-x64` publish |

## Local Development

### Requirements

* .NET 10 SDK
* Git

### Setup

Clone the repository:

```bash
git clone https://github.com/Jputerbaugh/JobApplicationTracker.git
cd JobApplicationTracker
```

Restore dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

Open the localhost address displayed in the terminal.

The application automatically creates the required SQLite database tables when it starts.

## Building the Windows Release

The repository includes a Windows publish profile. Create the release build with:

```bash
dotnet publish -p:PublishProfile=WindowsExe
```

Generated files are written to:

```text
publish/windows
```

The publish output is intentionally excluded from Git. Compiled downloads are distributed through the repository's Releases page.

## Project Goals

This project was built to practice and demonstrate:

* ASP.NET Core MVC application structure
* CRUD operations and server-side validation
* Entity Framework Core and relational data modeling
* Responsive interface design
* Environment-specific configuration
* Docker deployment
* Self-contained Windows distribution
* Persistent local application storage

## Roadmap

Potential future additions include:

* Importing and exporting application data
* Contact and recruiter tracking
* Job-search API integration
* Saving selected job-search results directly into the tracker
