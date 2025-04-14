# Medical Coding Assistant – Blazor Server UI

This is the Blazor Server frontend for the **AI-Powered Medical Coding Assistant**. It allows users to enter clinical descriptions and receive suggested ICD-10-CM codes using AI (powered by Azure OpenAI) and a backend API.

## Tech Stack

- **Blazor Server (.NET 8)**
- **C#**
- **Azure App Service** (for deployment)
- **Azure OpenAI** (via the backend API)
- **HTTP API Integration** with secure API key

## Features

- Responsive UI built in Blazor Server
- Input form for diagnosis descriptions
- Results rendered dynamically from the backend
- API key authorization handled securely on the server
- Clean design with optional MudBlazor integration

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Backend API running locally or deployed to Azure
