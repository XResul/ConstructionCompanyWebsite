🏗️ ConstructionCompanyWebsite

A modern, dynamic, and enterprise-grade construction company management system built with ASP.NET MVC (C#).
The platform enables companies to showcase projects, manage site content dynamically through a built-in Admin Panel, and maintain a professional client-facing website with responsive design.

🚀 Features
🌍 Public Website

Fully responsive and mobile-friendly layout (Bootstrap + custom CSS)

Dynamic Project Showcase section powered by MSSQL database

Contact Form with validation and message logging

About Us, Services, and Testimonials pages (editable via Admin Panel)

🛠️ Admin Panel

Secure admin authentication

Add / edit / delete projects dynamically

Manage images, descriptions, and metadata

Dashboard for quick insights and content control

Database-driven CMS (no need to rebuild to update content)

🧩 Tech Stack
Layer	Technology
Frontend	HTML5, CSS3, Bootstrap
Backend	ASP.NET MVC (C#)
Database	Microsoft SQL Server (MSSQL)
ORM / Data Layer	Entity Framework
Authentication	ASP.NET Identity
IDE	Visual Studio
Architecture	MVC (Model-View-Controller) Pattern


1-Clone the repository
git clone https://github.com/XResul/ConstructionCompanyWebsite.git

2-Open the project
Open the solution (.sln) file in Visual Studio.

3-Configure database connection
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ConstructionDB;Trusted_Connection=True;"
}


📦 ConstructionCompanyWebsite
 ┣ 📂 Controllers
 ┣ 📂 Models
 ┣ 📂 Views
 ┣ 📂 Areas
 ┃ ┗ 📂 Admin
 ┃    ┣ 📂 Controllers
 ┃    ┣ 📂 Views
 ┣ 📂 Content
 ┃ ┣ 📂 CSS
 ┃ ┣ 📂 Images
 ┃ ┗ 📂 JS
 ┣ 📂 Data
 ┣ 📜 appsettings.json
 ┣ 📜 web.config
 ┗ 📜 Program.cs / Global.asax


Author
Developed by: Resul Binici
Role: Full Stack Developer (C# / ASP.NET MVC / MSSQL)
LinkedIn: https://www.linkedin.com/in/resul-binici-251863247/
