// Readme for Digital Content Reviewer
Project overview
This is a full-stack application designed to manage data, handle user security, and provide an easy-to-use screen for users. 

Technologies Used
1. Backend: C#, .NET Core, Entity Framework Core, Structured Query Language Server
2. Frontend: React, TypeScript, JavaScript, HTML, Cascading Style sheets
3. Database: Structured Query Language Server

Prerequisites
1. .NET Core Software Dev Kit
2. Node.js and Node Package Manager
3. Structured Query Language Server

Setup Instructions
Backend Setup
1. Open command line tool and go to the backend folder (cd backend)
2. Restore required packages (donet restore)
3. update dbase connection string in appsettings.json
4. Run the database migrations to create tables (dotnet ef database update)
5. Start the backend server (donet run)

FrontEnd Setup
1. Open a new command line tool window and go to frontend folder (cd frontend)
2. Install the required packages (npm install)
3. Start the frontend dev server (npm start). Interface will open at http://localhost:3000)

Features
1. User Security: Secure login and role management
2. Data Management: Full ability to create, read, update and delete records
3. File Storage: Upload files and save their paths in the database
