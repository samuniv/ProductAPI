# **ProductAPI - .NET 7 with Entity Framework Core and Docker**

This project is a RESTful API for managing products, built using **ASP.NET Core 7** and **Entity Framework Core**. It utilizes **SQL Server** as the database, and the entire environment is containerized using **Docker** and **Docker Compose**.

## **Features**

-   CRUD operations (Create, Read, Update, Delete) for products
-   Entity Framework Core for data access with automatic migrations
-   SQL Server containerized using Docker
-   Docker Compose for multi-container orchestration

## **Technologies Used**

-   **ASP.NET Core 7** - Web API framework
-   **Entity Framework Core** - ORM for database interaction
-   **SQL Server** - Database
-   **Docker** - Containerization
-   **Docker Compose** - Orchestration of API and SQL Server containers

## **Getting Started**

### **Prerequisites**

To run this project, you'll need:

-   **Docker** and **Docker Compose** installed on your machine
-   **.NET SDK 7** (for local development)

### **Running the Application with Docker**

1. **Clone the repository:**

    ```bash
    git clone https://github.com/your-username/ProductAPI.git
    cd ProductAPI
    ```

2. **Build and start the application:**
   Use Docker Compose to build and start the application along with the SQL Server database.

    ```bash
    docker-compose up --build
    ```

3. **Access the API:**
   Once the application is running, the API will be accessible at:
   http://localhost:8080/api/products

4. **View the Database (optional):**
   You can connect to the SQL Server database using any SQL client (e.g., SQL Server Management Studio or Azure Data Studio) with the following credentials:

    - **Server**: `localhost,1433`
    - **User**: `sa`
    - **Password**: `YourStrong!Password`
    - **Database**: `ProductDb`

### **Local Development (without Docker)**

1. **Update your appsettings.json** with the correct connection string for your local SQL Server instance:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=ProductDb;User Id=sa;Password=YourStrong!Password;TrustServerCertificate=True;"
    }
    ```

2. **Run the application locally:**

    - Ensure that SQL Server is running.
    - Execute the following command to run the API:

    ```bash
    dotnet run
    ```

    - Access the API at: http://localhost:5000/api/products.

## **Database Migrations**

Migrations are applied automatically at startup using the following code:

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
```

To add a new migration manually, use:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update

```

Ensure you have the EF Core CLI tools installed.

## **API Endpoints**

### **Products**

-   **GET /api/products** - Retrieve all products
-   **GET /api/products/{id}** - Retrieve a product by ID
-   **POST /api/products** - Create a new product
-   **PUT /api/products/{id}** - Update an existing product
-   **DELETE /api/products/{id}** - Delete a product

## **Contributing**

Contributions are welcome! If you'd like to contribute to this project, please follow these guidelines:

1. **Fork the repository**: Click on the "Fork" button at the top right corner of the page to create your copy of the repository.

2. **Create a new branch**: Before making changes, create a new branch for your feature or bug fix:

    ```bash
    git checkout -b feature/YourFeatureName
    ```

## **License**

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
