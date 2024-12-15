# In my Closet Project

## Description
The in my Closet Project is an innovative application designed to promote sustainable fashion choices by helping users manage their wardrobe efficiently. The application allows users to track their clothing items, make informed decisions about their purchases, and reduce waste by promoting a circular economy. By leveraging modern technologies, we aim to create a user-friendly platform that encourages sustainable practices in fashion.

## Features
- **Wardrobe Management**: Users can add, edit, and remove clothing items from their virtual closet.
- **Sustainability Insights**: The app provides insights into the sustainability of clothing items, helping users make eco-friendly choices.
- **Community Sharing**: Users can share clothing items with others, promoting reuse and reducing waste.

## Technologies Used

### Backend
- **.NET Core**: The application is built using .NET Core, a cross-platform framework for building modern, cloud-based, and internet-connected applications.
- **Entity Framework Core**: An ORM (Object-Relational Mapper) for .NET, used to interact with the database in an object-oriented way.
- **Swagger/OpenAPI**: API documentation and testing tool integrated into the project for easy endpoint exploration and testing.

### Database
- **Supabase (PostgreSQL)**: A hosted backend service that provides a PostgreSQL database with additional features like authentication and real-time capabilities.

### Frontend
- **React**: A JavaScript library for building user interfaces, used for the frontend of the application.

## Major Dependencies
To get started with the project, ensure you have the following dependencies installed:

### .NET Core
- Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0) installed.

### Entity Framework Core
To install Entity Framework Core, run the following commands:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Supabase Client
To interact with Supabase, install the Supabase client library:
```bash
dotnet add package Supabase
```

### API Documentation Tools
To enable Swagger documentation, install the following package:
```bash
dotnet add package Swashbuckle.AspNetCore
```

## Getting Started
1. Clone the repository:https://github.com/fac30/TFB_BackEnd_Margaux.git
   ```bash
   git clone 
   cd in my closet 
   ```

2. Set up your Supabase project and configure the database.

3. Update the connection string in your `appsettings.json` file.

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the Swagger documentation:
   - Navigate to `https://localhost:<port>/swagger` in your web browser
   - Use the interactive UI to explore and test API endpoints
   - API documentation is automatically generated from your controller annotations
# In my Closet Project

## Description
The in my Closet Project is an innovative application designed to promote sustainable fashion choices by helping users manage their wardrobe efficiently. The application allows users to track their clothing items, make informed decisions about their purchases, and reduce waste by promoting a circular economy. By leveraging modern technologies, we aim to create a user-friendly platform that encourages sustainable practices in fashion.

## Features
- **Wardrobe Management**: Users can add, edit, and remove clothing items from their virtual closet.
- **Sustainability Insights**: The app provides insights into the sustainability of clothing items, helping users make eco-friendly choices.
- **Community Sharing**: Users can share clothing items with others, promoting reuse and reducing waste.

## Technologies Used

### Backend
- **.NET Core**: The application is built using .NET Core, a cross-platform framework for building modern, cloud-based, and internet-connected applications.
- **Entity Framework Core**: An ORM (Object-Relational Mapper) for .NET, used to interact with the database in an object-oriented way.
- **Swagger/OpenAPI**: API documentation and testing tool integrated into the project for easy endpoint exploration and testing.

### Database
- **Supabase (PostgreSQL)**: A hosted backend service that provides a PostgreSQL database with additional features like authentication and real-time capabilities.

### Frontend
- **React**: A JavaScript library for building user interfaces, used for the frontend of the application.

## Major Dependencies
To get started with the project, ensure you have the following dependencies installed:

### .NET Core
- Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0) installed.

### Entity Framework Core
To install Entity Framework Core, run the following commands:
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Supabase Client
To interact with Supabase, install the Supabase client library:
```bash
dotnet add package Supabase
```

### API Documentation Tools
To enable Swagger documentation, install the following package:
```bash
dotnet add package Swashbuckle.AspNetCore
```

## Getting Started
1. Clone the repository:https://github.com/fac30/TFB_BackEnd_Margaux.git
   ```bash
   git clone 
   cd in my closet 
   ```

2. Set up your Supabase project and configure the database.

3. Update the connection string in your `appsettings.json` file.

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the Swagger documentation:
   - Navigate to `https://localhost:<port>/swagger` in your web browser
   - Use the interactive UI to explore and test API endpoints
   - API documentation is automatically generated from your controller annotations

## Chatbot Configuration and Setup

### Overview
The application includes an AI-powered chatbot specifically designed to provide guidance on sustainable fashion. The chatbot is configured to assist with eco-friendly fashion choices, including clothing swaps, upcycling, thrifting, and local sustainable fashion events.

### Technical Setup Requirements

1. **CORS Configuration**
   - Update the CORS settings in `Program.cs` (line 65) to allow requests from your production frontend URL
   - Current default: `http://localhost:5174`

2. **Environment Variables**
   - Create a `.env` file in the root directory
   - Add your OpenAI API key:
     ```
     OPENAI_API_KEY=your_api_key_here
     ```
   - Note: Before handover, ensure the API key is updated to the product owner's key

3. **Chatbot Personality**
   - The chatbot's behaviour is controlled by a predefined prompt in `Controllers/ChatController.cs`
   - This prompt ensures the bot:
     - Focuses solely on sustainable fashion topics
     - Provides guidance on clothing swaps, upcycling, thrifting, and eco-friendly events
     - Redirects off-topic conversations back to sustainable fashion
     - Prioritises environmentally conscious solutions

### Important Notes
- The predefined prompt is crucial for maintaining the chatbot's focus and preventing off-topic responses
- The longer and more descriptive this prompt is, the more accurate the chatbot's responses will be
- Any modifications to the prompt should maintain the eco-friendly fashion focus
- The system is designed to reject empty messages and handle errors appropriately
