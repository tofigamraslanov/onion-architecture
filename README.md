# Onion Architecture In ASP.NET Core With CQRS and Mediatr Pattern

The onion architecture, introduced by Jeffrey Palermo, overcomes the issues of the layered architecture with great ease. With Onion Architecture, the game changer is that the Domain Layer (Entities and Validation Rules that are common to the business case ) is at the Core of the Entire Application. This means higher flexbility and lesser coupling. In this approach, we can see that all the Layers are dependent only on the Core Layers.

## Overview
<img src="https://camo.githubusercontent.com/d88eef2ea43d225d301654686174fff7e07b1a7aa97d5f2f003e1003feea624a/68747470733a2f2f7777772e636f6465776974686d756b6573682e636f6d2f77702d636f6e74656e742f75706c6f6164732f323032302f30362f4f6e696f6e2d4172636869746563747572652d496e2d4153502e4e45542d436f72652e706e67" height="500"/>

<b>Domain and Application Layer</b> will be at the center of the design. We can refer to these layers as the Core Layers. These layers will not depend on any other layers. Domain Layer usually contains enterprise logic and entities. Application Layer would have Interfaces and types. The main difference is that The Domain Layer will have the types that are common to the entire enterprise, hence can be shared across other solutions as well. But the Application Layer has Application-specific types and interfaces. As mentioned earlier, the Core Layers will never depend on any other layer. Therefore what we do is that we create interfaces in the Application Layer and these interfaces get implemented in the external layers. This is also known as DIP or Dependency Inversion Principle. For example, If your application want’s to send a mail, We define an IMailService in the Application Layer and Implement it outside the Core Layers. Using DIP, it is easily possible to switch the implementations. This helps build scalable applications.

<b>The Presentation layer</b> is where you would Ideally want to put the Project that the User can Access. This can be a WebApi, Mvc Project, etc.

<b>The Infrastructure layer</b> is a bit more tricky. It is where you would want to add your Infrastructure. Infrastructure can be anything. Maybe an Entity Framework Core Layer for Accessing the DB, a Layer specifically made to generate JWT Tokens for Authentication or even a Hangfire Layer. You will understand more when we start Implementing Onion Architecture in ASP.NET Core WebApi Project.

## Features and Tech Stack used in this project
<ul>
  <li>Onion Architecture</li>
  <li>Entity Framework Core</li>
  <li>.NET 6.0 Class Library / ASP.NET Core 6.0 WebApi</li>
  <li>Swagger</li>
  <li>CQRS / Mediator Pattern using MediatR Library</li>
  <li>CRUD Operations</li>
  <li>Inverted Dependencies</li>
  <li>API Versioning</li>
</ul>







