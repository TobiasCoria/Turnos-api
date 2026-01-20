Appointment Management System – Full Stack Project

This project is a full stack appointment (turnos) management system developed from scratch as part of my learning and practice in web and backend development.

It covers the complete flow of a real-world system: frontend interface, backend API, business logic, persistence, validation, error handling, and deployment.

Features

Create new appointments

List all appointments

Filter appointments by date

Change appointment status (Pending / Confirmed / Cancelled)

Delete appointments

Proper validation and structured error handling

RESTful API design

Full separation between frontend and backend

Tech Stack
Frontend

HTML

CSS

Vanilla JavaScript

Fetch API for HTTP communication

Deployed using GitHub Pages

Backend

C#

ASP.NET Core Web API

Entity Framework Core

MySQL

REST architecture

DTOs for clean data transfer

Centralized exception middleware

Deployed using Render

 Project Structure

The repository is divided into two main parts:

/frontend
  ├── index.html
  ├── styles.css
  └── app.js

/backend
  ├── Controllers
  ├── Services
  ├── DTOs
  ├── Data
  ├── Middlewares
  ├── Program.cs
  └── Turnos.API.csproj


  API Endpoints (Backend)

| Method | Endpoint                   | Description               |
| ------ | -------------------------- | ------------------------- |
| GET    | `/api/turnos`              | Get all appointments      |
| GET    | `/api/turnos/{id}`         | Get appointment by ID     |
| GET    | `/api/turnos/fecha/{date}` | Get appointments by date  |
| POST   | `/api/turnos`              | Create a new appointment  |
| PUT    | `/api/turnos/{id}/estado`  | Change appointment status |
| DELETE | `/api/turnos/{id}`         | Delete appointment        |


Backend Architecture Highlights

Service layer to isolate business logic

DTOs to avoid exposing entities directly

Enum-based appointment status

Model validation using ASP.NET Core

Custom exception middleware for clean error responses

Entity Framework Core with MySQL


 Deployment Status

Frontend:
Deployed on GitHub Pages and publicly accessible.

Backend API:
Deployed on Render.

Database:
The system uses MySQL. The API works correctly in local development.
In production, the database connection requires environment-specific configuration, which is pending. The backend structure and logic are complete and functional.

This reflects a real deployment scenario where infrastructure configuration is separated from application logic.

 Purpose of the Project

The goal of this project was to:

Build a complete full stack system from zero

Practice clean architecture and separation of concerns

Work with real backend technologies (C#, EF Core, SQL)

Understand deployment workflows (GitHub + Render)

Handle real-world problems such as validation, errors, and environment configuration

Notes

This project is not a tutorial or template.
It was fully implemented, debugged, and deployed step by step, including:

Backend errors and validation fixes

JSON serialization issues

Enum binding problems

CORS configuration

Deployment troubleshooting

