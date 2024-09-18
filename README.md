
# Authorization workshop

Imagine you are working on the back-end for a news site. The site contains news articles written by journalists. The site have editors which can correct factual mistakes in articles and remove hateful comments.

The business model rely on subscription fees and advertising. Subscribers can, for a small monthly fee access a version of the site without adds. Guests can still read articles published on the site, but will be presented with ads.

(Implementing ads are NOT part of this assignment)

# Policy
Your task is to implement authorization as a proof-of-concept that enforces the following policy.

**Editor** can:
> - Edit, and delete articles.
> - Edit and delete user comments.

**Writer / Journalist** can:
> - Create and edit their own articles.

**Subscriber / Registered User** can:
> - Comment on articles.

**Guest / Public User** can:
> - Read articles.

# Solution
To complete this workshop, we have implemented a customized version of ASP.NET Core [`IdentityUser`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identityuser?view=aspnetcore-1.1) for authentication and ASP.NET Core [`IdentityRole`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identityrole?view=aspnetcore-1.1) for authorization. Additionally, all data is stored in a [`SQLite`](https://www.sqlite.org/) database

### Getting started
* Go to the root of the project and copy or write the following command:  
```
docker compose up --build
```
* Go to localhost:7085/ or use an API Platform (such as Postman)

### Endpoints
#### User
```
GET api/News/user (Get all users)
GET api/News/user/{userId} (Get user by id)
PUT api/News/user/{userId} (Update an user)
DELETE api/News/user/{userId} (Delete an user)
GET api/News/user/roles (Get all roles)
GET api/News/user/role/{userId} (Get User role/s)
```
#### Articles
```
GET api/News/article (Get all articles)
GET api/News/article/{articleId} (Get article by id)
```
#### Comments
```
GET api/News/comment (Get all comments)
GET api/News/comment/{commentId} (Get comment by id)
PUT api/News/comment/{commentId} (Update a comment)
```
### Protected Endpoints
#### Roles: (Admin, Editor, Writer, Subscriber)
```
POST api/News/Rebuild (Rebuilds the db) (Admin)
POST api/News/article (Create an articles) (Admin, Writer)
PUT api/News/article/{articleId} (Update an article) (Admin, Writer, Editor)
DELETE api/News/article/{articleId} (Delete an article) (Admin, Editor)
POST api/News/comment (Create comment) (Admin, Subscriber)
DELETE api/News/comment/{commentId} (Admin, Editor)
```

## :computer: Technologies
[![SQLite](https://img.shields.io/badge/SQLite-%2307405e.svg?logo=sqlite&logoColor=white)](#)
[![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff)](#)
[![C#](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)
[![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=fff)](#)
[![NuGet](https://img.shields.io/badge/NuGet-004880?logo=nuget&logoColor=fff)](#)



## :pencil2: Authors

* [@Andylaa10](https://github.com/Andylaa10/)
* [@Nicklas0110](https://github.com/nicklas0110/)
