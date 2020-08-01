# About
Asp.Net MVC 5 Server architecture of Classic Raider V2. Hosted at [vps.classicraider.com](http://vps.classicraider.com/)

Once development is at a finished stage we will push vps.classicraider.com to "classicraider.com"
In Classic Raider V2 we try to keep a basic, clean, globalized and S.O.L.I.D software architecture.

# Minimum Requirements
Windows 10+ machine
Visual Studio 2017 Community v15.8.3+ or other edition of your choice
SQL Server Express LocalDB or other edition of your choice.

## Default Credentials
Default Credentials for the initial user- 
* username: **admin**
* password: **password**

## Running Locally

* Open a new ´cmd´ or ´powershell´ console window.
* Navigate to the project root folder (where it was extracted or cloned).
* Execute the following command to setup the app: app install or ./app install.
    * The command above will perform the the following tasks:
        * Check for compatible PowerShell and .NET Framework versions.
        * Restore both server and client side dependent libraries (from Nuget and LibMan).
        * Compile the application after all required dependencies are properly restored.
        * Create the **ClassicRaiderDev** database on your LocalDB instance.
* If necessary, change the **web.config** connection string to point to your desired SQL Server edition.
* Open the **classicraider.sln** solution file under the sources folder.
* If necessary, set App.UI.Mvc5 as the startup project.
* Hit F5 to start the application.

Check our online docs at https://mvc5-starter-template.readthedocs.org.

# Features Overview

- Bootstrap 4 based layout.
- Realtime ready with SignalR.
- Asp.Net Identity with role permissions.
- Dependency injection with SimpleInjector.
- Out of the box mailing system with support for native SMTP and MailGun Api.
- Out of the box dynamic image thumb generation with ImageResizer and Cloudinary.
- Client side libraries managed by the new Visual Studio Library Manager (LibMan).
- Globalization ready and by-user language, region and timezone definition.
- Error logging with Serilog.

## Solution Details
Detailed information about the solution architecture, conventions, design choices and used tech.

### Projects
| Solution Folder / Project |  Description                                                                   |
| ------------------------- |:------------------------------------------------------------------------------:|
| Solution Items            | This folder contains globally available scripts, docs and configuration files. |
| Shared Libs               | This folder contains projects that are independent from the main model and could be event converted to nuget packages to be used in another projects. These projects provide several functionality such as email and sms messaging, storage, image processing and helful extensions. |
| Domain                    | This folder contains the projects that can be considered the core of the onion architecture concept. This will contain the main code for the problem your project is solving.  |
| Data                      | This folder contains the projects that will handle the data your application will produce and/or consume.      |
| App.Identity              | This is the project that will handle the ASP.Net Identity functionality for the users. It should be self contained and has its own repository and services to handle the app identities.      |
| App.UI.Mvc5	            | This is the main User Interface project and will be the project that your end users will do most of their interaction with.      |

### Architecture
The solution was built following the **Onion Architecture** concept.

The overall philosophy of the Onion Architecture is to keep your business logic and model in the middle (Core) of your application and push your dependencies as far outward as possible.

Basically, it states that code from inner layers should not depend on code from outer layers. It is very simple and help keeping things organized.

This is pictured in the image below
![Overview](/trunk/ss1.png?raw=true "Overview")

### Areas
Each area can be considered a ‘mini mvc’ website inside the main app and need just a few adjustments to get up and running:
* Area name and namespaces
* Area controllers
* Views and models
* Client side scripts

The easiest way to create a new area is copying the `Blank area` and renaming the required classes as needed.

Areas must have their own base controller that inherits from the main base controller (`__BaseController.cs`). For convention, the area base controller is named `__AreaBaseController.cs`.




