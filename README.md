# Task_Tracker_CLI
📌 Task Tracker – Console App (C# / .NET)

A simple Task Tracking Console Application built in C# that allows you to:

✔ Add tasks
✔ View all tasks
✔ Update existing tasks
✔ Delete tasks
✔ Change task status (Todo, InProgress, Done)
✔ Filter tasks by status
✔ Save and load tasks from a JSON file

This project is perfect for beginners who want to learn C#, File Handling, JSON Serialization, and Console UI development.

🚀 Features
✅ Add Task

Create new tasks with:

Description

Unique ID (GUID)

Status

Created date

✅ Update Task

Edit a task's description and automatically update updatedAt.

✅ Delete Task

Remove tasks permanently from the JSON file.

✅ Mark Task Status

Change status between:

Todo

InProgress

Done

✅ View Tasks

Display all tasks or filter by status.

✅ JSON Storage

All tasks are stored locally in SaveTasks.json.

🧠 Project Structure
/TaskTracker
│── Program.cs
│── Menu.cs
│── CRUD.cs
│── TaskTracker.cs
│── Status.cs
│── SaveTasks.json   (auto-generated)
│── README.md

🛠️ Technologies Used

C#

.NET Console Application

System.Text.Json for serialization

File I/O

Object-Oriented Programming

📦 How It Works
▶️ Run the App
dotnet run

📄 Menu Options
============== Task Tracker ==============
1) Add Task
2) View All Tasks
3) Update Task
4) Delete Task
5) Mark Task Status
6) View Tasks by Status
0) Exit
==========================================

🔧 Classes Overview
🔹 TaskTracker

Represents a single task with:

id

description

status

createdAt

updatedAt

🔹 CRUD

Handles:

AddTask

UpdateTask

DeleteTask

MarkIn (status updates)

GetAllTasks

GetAllTasksStatus

🔹 Menu

Handles all user interactions through the console.

🔹 Program

Entry point of the application.

📝 Example JSON Output
[
  {
    "id": "e3e1f1c4-2d59-4f06-8e37-4f8ac2b213d1",
    "description": "Learn C#",
    "status": 1,
    "createdAt": "2025-02-01T12:00:00Z",
    "updatedAt": null
  }
]