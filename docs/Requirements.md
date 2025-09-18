# Academic Management System

## Project Overview
This project is designed to manage academic operations including departments, instructors, students, courses, sections, schedules, and rooms. It aims to simplify academic administration by providing role-based access for **Admin**, **Instructor**, and **Student**.

---

## Requirements

### 1. Department Management
- Add, update, find, and delete departments.  
- Each department contains:
  - **Instructors** that work in it.
  - **Courses** that are taught in it.
  - **Intakes** that study under it.
- Provide **statistics** for each department (e.g., number of instructors, students, and courses).

---

### 2. Instructor Management
- CRUD operations for instructors.  
- Manage sections (create, update, assign to courses).  
- Instructors can:
  - View their **sections**, schedules, and assigned rooms.
  - Mark **attendance** for each section.
- Instructors are restricted to teaching only the courses offered by their department.

---

### 3. Course Management
- Courses must belong to a department.  
- Provide course-related statistics:
  - Number of students enrolled.
  - Student progress and performance.  

---

### 4. Student Management
- Students can:
  - Enroll in courses.
  - View their **courses**, sections, schedules, and assigned rooms.
- Students must belong to an **intake**.
- An intake can:
  - Be part of a **full diploma program** (study all courses of a specific department).
  - Or allow students to **enroll in selected courses** from any department.

---

### 5. Intake Management
- Intakes are linked to a specific department.  
- Organize students into groups by academic term.  
- Define whether the intake follows a **diploma track** or **custom course selection**.

---

### 6. Room & Schedule Management
- Manage academic rooms.  
- Room types:
  - Lecture Hall
  - Lab
  - Event Hall
  - Office
- Assign schedules to rooms.  
- Ability to check **free schedules** and avoid conflicts.  

---

## User Roles
- **Admin**
  - Full system access.
  - Manage departments, courses, instructors, students, and rooms.
- **Instructor**
  - Restricted to their department courses.
  - Manage sections, schedules, and attendance.
- **Student**
  - Enroll in courses.
  - View assigned courses, sections, and schedules.

---
