
# Internship platform - Mistral

Welcome to our project readme file!

This project was made during a 4-week Internship at Mistral (Maestral Solutions).

The whole project took 2 work weeks to finish.

## Project summary

Note: This summary is very brief and consists of far more details but it will help you understand the basics of the project.

The project consists of 3 parts, applications, selections, and users.
Application is a part where applicants can apply for internships with their data which
will be stored in a database with added status "applied".

The selections part is for admin/user roles only and no one else can access it.
Selections are created by the user/admin which includes applicants who pass the expectations.
After an applicant is moved to status "in-selection" he/she will receive an email "Welcome to Internship".

There are 2 roles for users:

    1. Administrator
    2. Editor

The users part is only accessible to the admin who can add new users who will be able to see applications and selections.


## Installation

Before going into installation you need to have installed:

Angular CLI :
```bash
   npm install -g @angular/cli
```
Node.js: https://nodejs.org/en/

Dotnet:
```bash
    dotnet tool install --global dotnet-ef
```
Now we can move on to frontend installation.
After cloning the repository with

(Note: Be in empty folder while doing cloning or remove the ".")
```bash
  git clone https://github.com/MahirPrcanovic/InternApp.git .
```
you are ready to begin the next stage.

```bash
  cd client
  npm install --legacy-peer-deps
```
aaand your frontend is ready!

```bash
  ng serve
```
to start the frontend and you should see a landing page!

First of backend you will need to run 

```bash
  dotnet ef migrations add MyMigration
```

```bash
  dotnet ef database update
```
to create database on your machine and load it up with default data.

Before startin your backend, you will need to setup few environment variables


## Environment Variables

To run this project, you will need to add the following environment variables to your project.

```bash
  dotnet user-secrets set SendGridApiKey [YOUR_SENDGRID_API_KEY]
```

```bash
  setx ASPNETCORE_JwtConfig__secret "Your secret token key"
```
Note: In file EmailService.cs (line 23) you will need to put your sengrid email and name which you configured on their website since it won't work with ours.

And that should be it!

You can now start your backend and frontend and try it out!


## API Reference

### Login
```http
  POST /auth/login
```

| Body | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `userName` | `string` | **Required**. |
| `password` | `string` | **Required**. |
| `rememberMe` | `boolean` | **Required**. |


### Applications
Every request for /api/ApplicationForm/* you will need:

| Header | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Authorization` | `string` | **Required**. "Bearer + yourToken" |

#### Get all applications 
```http
  GET /api/ApplicationForm
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `page` | `integer` | Page number (default = 1)|
| `pageSize` | `integer` | Page size (default = 10)|
| `sortBy` | `string` | Sort by (default = 'name')|
| `filterType` | `string` | Filter by (default = 'name')|
| `filter` | `string` | Filter Value |


#### Add an application

```http
  POST /api/ApplicationForm
```

| Body | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `firstName`      | `string` | **Required**. |
| `lastName`      | `string` | **Required**. |
| `email`      | `string` | **Required**.  |
| `educationLevel`      | `string` | **Required**. |
| `coverLetter`      | `string` | **Required**. |
| `cv`      | `string` | **Required**. |

#### Get item

```http
  GET /api/ApplicationForm/{id}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**.|

#### Update applicant's status

```http
  PUT /api/ApplicationForm/{id}
```

| Header | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Authorization` | `string` | **Required**. Your token |


#### Add a comment to application

```http
  POST /api/ApplicationForm/{id}
```

| Body | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `commentText` | `string` | **Required**. Your comment |


### Selections
Every request for /api/Selections/* you will need:

| Header | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Authorization` | `string` | **Required**. "Bearer + yourToken" |

#### Get all Selections

```http
  GET /api/Selections/GetAll
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `pageNumber` | `integer` | Page number (default = 1)|
| `pageSize` | `integer` | Page size (default = 5)|
| `sort` | `string` | Sort by|
| `filterBy` | `string` | Filter by|

#### Get single selection

```http
  GET /api/Selections/GetSelectionsById/{id}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**|

#### Add new selection

```http
  POST /api/Selections/AddNewSelection
```
| Body | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name` | `string` | **Required**|
| `startDate` | `Date` | **Required**|
| `endDate` | `Date` | **Required**|
| `description` | `string` | **Required**|

#### Update selection

```http
  PUT /api/Selections/EditSelection/{id}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**|



#### Delete applicant from selection

```http
  DELETE /api/Selections/DeleteApplicants/{selectionId}/{applicationId}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `selectionId` | `string` | **Required**|
| `applicationId` | `string` | **Required**|

#### Add new applicant to selection

```http
  POST /api/Selections/AddNewApplicantToSelection/{selectionId}/{applicationId}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `selectionId` | `string` | **Required**|
| `applicationId` | `string` | **Required**|


#### Add new comment to selection

```http
  POST /api/Selections/AddNewCommentToSelection/{selectionId}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `selectionId` | `string` | **Required**|

### Users

Every request for /api/Selections/* you will need:

| Header | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Authorization` | `string` | **Required**. "Bearer + yourToken" |

On top of Authorization, you have to have Administrator role to access this endpoint.

#### Get all users
```http
  GET /api/Users
```

#### Delete user
```http
  DELETE /api/Users/{id}
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `string` | **Required**|

#### Add new user
```http
  POST /api/Users/addNewUser
```
| Body | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `userName` | `string` | **Required**|
| `password` | `string` | **Required**|
| `email` | `string` | **Required**|

## Tech Stack

**Client:** Angular 14, Bootstrap 5, AOS

**Server:** ASP.NET Core 6, Entity Framework Core, Identity, MSSQL, SendGrid


## Feedback

If you have any feedback, please reach out to mahirprcanovic@gmail.com

