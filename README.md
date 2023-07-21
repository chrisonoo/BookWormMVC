<div align="center">
    <h1>Book Worm MVC</h1>
    <h3>
        <a href="#installation">
            Demo
        </a>
        <span> | </span>
        <a href="https://github.com/chrisonoo/BookWormMVC">
            GitHub
        </a>
    </h3>
    <p> Simple manager for handling a list of books</p>
    <p><b>Status:</b> Project completed</p>
    <br>
    <p>Technologies and tools:</p>
    <p>
        <img src="docs/img/logos/dotnet.svg" width="40" height="40" alt="dotnet"/>
        <img src="docs/img/logos/csharp.svg" width="40" height="40" alt="csharp"/>
        <img src="docs/img/logos/sqlserver.svg" width="40" height="40" alt="sqlserver"/>
        <img src="docs/img/logos/html5.svg" width="40" height="40" alt="html"/>
        <img src="docs/img/logos/css3.svg" width="40" height="40" alt="css"/>
        <img src="docs/img/logos/jquery.svg" width="40" height="40" alt="css"/>
        <img src="docs/img/logos/js.svg" width="40" height="40" alt="javascript"/>
        <img src="docs/img/logos/md.svg" width="40" height="40" alt="markdown"/>
        <img src="docs/img/logos/git.svg" width="40" height="40" alt="git"/>
        <img src="docs/img/logos/github.svg" width="40" height="40" alt="github"/>
        <img src="docs/img/logos/vs.svg" width="40" height="40" alt="visualstudio2022"/>
    </p>
</div>
<br>

## Description

BookWormMVC is an educational project created using **ASP.NET Core 6 MVC** and **C# 10**. The main goal of the project was to understand and practically use the handling of `one-to-many` and `many-to-many` relationships in the database.

## Functionality

`BookWormMVC` is a simple book registration management system that allows for **CRUD** operations on a database created using the **code-first** approach. The application generates a database with appropriate relationships, and then through forms allows interaction with this database. Each table has dedicated controllers and views: Index, Edit, Details, Create, Delete.

In the application, a **soft delete** approach is used for deleting data in the Publishers, Contributor Roles, and Contributors tables. Thanks to this, no records are cascade deleted from the database. The application comes with a set of data that is added to the database during the first migration. This allows to test the application immediately after launch.

The main emphasis was placed on backend development, the frontend is the default ASP.NET template with minor CSS improvements and the implementation of bolding the active tab (controller) in the menu.

## Technologies, Tools, Strategies and Programming Techniques

- ASP.NET Core 6 MVC
- C# 10
- Entity Framework (utilizing both **Annotations** and **Fluent API**)
- Code First
- Soft Delete

## Dependencies

The project uses standard dependencies for **ASP.NET Core 6 MVC**:

- ASP.NET Core 6.0
- Microsoft.EntityFrameworkCore.SqlServer 7.0.9
- Microsoft.EntityFrameworkCore.Tools 7.0.9
- Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.15

## Installation

1. Open a terminal on your computer and navigate to the location where you want to download the application.
2. Run the command `git clone https://github.com/chrisonoo/BookWormMVC.git` and clone the application repository to the chosen folder on your disk.
3. Open the solution in Visual Studio 2022 and run <kbd>Build > Build Solution</kbd>.
4. Set the project **BookWorm.MVC** as the Startup Project.
5. Open <kbd>Tools > NuGet Package Manager > Package Manager Console</kbd>.
6. In the Package Manager Console, set <kbd>Default project: BookWorm.MVC</kbd>.
7. Type the command `add-migration Initial` in the Package Manager Console and execute it. This command will create a database migration file and perform seeding.
8. Type the command `upgrade database` in the Package Manager Console and execute it. This command will create a database and upload sample data into the local database.

## Feature List

### Features for books:

<div align="center">
<img src="./docs/img/books-index.jpeg" width="150">
<img src="./docs/img/books-create.jpeg" width="150">
<img src="./docs/img/books-edit.jpeg" width="150">
<img src="./docs/img/books-details.jpeg" width="150">
<img src="./docs/img/books-delete.jpeg" width="150">
</div>

- Displaying a list of books
- Creating, editing, displaying details, deleting a single book

### Features for publishers:

- Displaying a list of publishers
- Creating, editing, displaying details, deleting a single publisher
- Preview of the list of books published by the publisher

### Features for contributors:

- Displaying a list of contributors
- Creating, editing, displaying details, deleting a single contributor

### Features for contributor roles:

- Displaying a list of contributor roles
- Creating, editing, displaying details, deleting a single contributor role

### Features for book contributors:

- Displaying a list of contributors and their roles in creating a book
- Creating, editing, displaying details, deleting a single book contributor

## Workflow

- [x] Create solution in Visual Studio 2022
- [x] Add project ASP.NET Core 6 MVC to solution
- [x] Database, `code-first` approach
    - [x] Plan the Entity classes, incorporate the `soft-delete` strategy
    - [x] Adď the Entity classes
    - [x] Add Annotations and Fluent API configuration to the Entity classes
    - [x] Add Database configuration
    - [ ] Add demonstration data to the application (seeding). 
    - [x] Add migration
    - [x] Update database
- [x] Add Controllers and Views
- [x] Add links to all controllers to the main menu
- [x] Adjust the Index and Privacy pages
- [x] Highlight active link in the menu
- [x] Correct CSS file with margin-top for primary button
- [x] Adjust the Publishers
    - [x] Change the description of the page from Index to Publishers in the `Publishers > Index` view.
    - [x] Add the display of the number of books published by the Publisher to the `Publishers > Index` view. Create class **PublisherViewModel**.
    - [x] Add the display of active and inactive Publishers in separate sections to the `Publishers > Index` view.
    - [x] Add editing of the IsActive field in the `Publisher > Edit` view.
    - [x] Add the display of the IsActive field in the `Publisher > Details` view.
    - [x] Add the display of books published by the Publisher to the `Publisher > Details` view.
    - [X] Adjust the `PublishersController.Delete` so that clicking <kbd>Delete</kbd> changes the IsActive field to false.
- [x] Adjust the Contributor Roles
    - [ ] Change the description of the page from Index to Contributor Roles in the `Contributor Roles > Index` view.
    - [x] Add a column to display information from the IsActive field in the `Contributor Roles > Index` view.
    - [x] Add editing of the IsActive field in the `Contributor Roles > Edit` view.
    - [x] Add the display of the IsActive field in the `Contributor Roles > Details` view.
    - [X] Adjust the `ContributorRolesController.Delete` so that clicking <kbd>Delete</kbd> changes the IsActive field to false.
- [x] Adjust the Contributors
    - [ ] Change the description of the page from Index to Contributors in the `Contributors > Index` view.
    - [x] Add a column to display information from the IsActive field in the `Contributors > Index` view.
    - [x] Add editing of the IsActive field in the `Contributors > Edit` view.
    - [x] Add the display of the IsActive field in the `Contributors > Details` view.
    - [X] Adjust the `ContributorsController.Delete` so that clicking <kbd>Delete</kbd> changes the IsActive field to false.
- [x] Adjust the Books
    - [ ] Change the description of the page from Index to Books in the `Books > Index` view.
    - [x] Add the display of Publisher (foreign key) to the `Books > Index` view.
    - [x] Add the display of contributors in `Books > Details` view, with a division into Authors and other Contributors (many-to-many relationship).
- [x] Adjust the Book Contributors
    - [ ] Change the description of the page from Index to Book Contributors in the `Book Contributors > Index` view.
    - [ ] Create a filter in the `BookContributorsController` that filters out inactive Contributors in the `Book Contributors > Create` view.
    - [ ] Create a filter in the `BookContributorsController` that filters out inactive Contributor Roles in the `Book Contributors > Create` view.

## Contribution

The project has been completed and will not be further developed, but any suggestions are welcome. Please open issues to share your feedback.

## License

This project is licensed under the MIT license.

</details>

<details>
<summary>Legenda</summary>
<br>
Commit <commit>name of commit[use <commit\>text</commit\>]</commit><br/>
Inline code mark <code>code tag [use \`text\`]</code><br/>
Keyboard shortcut, path mark or command <kbd>kbd tag [use <kbd\>text</kbd\>]</kbd><br/>
Text highlighting mark <mark>mark tag [use <mark\>text</mark\>]</mark><br/>
</details>

<style>
    commit,
    mark {
        display: inline-block;
        border-radius: 3px;
        font-family: Consolas, "Liberation Mono", Courier, monospace;
        font-size: 1em;
        padding: 0 7px;
        margin: 0 5px;
        line-height: 20px;
    }
    commit {
        color: rgb(245, 245, 245);
        background-color: #ff5858;
    }
</style>