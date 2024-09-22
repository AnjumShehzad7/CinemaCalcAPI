# CinemaCalcAPI - Backend

## 1. How to run the project **locally**?

To run the project locally, follow these steps:

1. **Clone the Repository:**
   ```
   git clone https://github.com/AnjumShehzad7/CinemaCalcAPI.git
   cd CinemaCalcAPI
   ```
2. **Start MySQL using Docker:**
   ```
   docker-compose up -d
   ```
3. **Restore Dependencies:**
   ```
   dotnet restore
   ```
4. **Apply Migrations:**
   ```
   dotnet ef database update
   ```
5. **Run the API:**
   ```
   dotnet run
   ```
### The API will be available at `http://localhost:port`.

## The code structure is as follows:
- **Controllers:** Contains `ExpenseController.cs` to handle all HTTP requests related to expenses.
- **Data:** `CinemaCalcContext.cs` manages database interactions through Entity Framework.
- **Models:** Defines the `Expense.cs` model.
- **Migrations:** Holds the EF Core migration files for database schema updates.
- **Program.cs:** Main entry point to configure services and middleware.

**State is managed using Entity Framework Core with a MySQL database. This approach provides an 
efficient, scalable solution for persistent storage and allows for easy querying and management 
of data. The use of a relational database ensures that the data integrity is maintained.**

#### The `TotalPrice` is calculated as:
```
public decimal TotalPrice 
{ 
    get 
    { 
        return Price + (Price * PercentageMarkup / 100); 
    }
}
```
This ensures precise financial calculations by applying the percentage markup to the base price.

#### The tasks for this project were broken down as follows:

- **Backend Setup:** Set up the project using .NET 6 and Entity Framework Core.
- **Modeling:** Created the `Expense` model with necessary attributes like `Name`, `Price`, `PercentageMarkup`, and `TotalPrice`.
- **API Endpoints:** Implemented CRUD operations in the `ExpenseController`.
- **Database Setup:** Configured MySQL with Docker and integrated it with Entity Framework.
- **Precise Calculations:** Implemented logic for accurate total price calculation with markup.
- **Testing and Documentation:** Used Swagger for API testing and documentation.

**The development of this backend was driven by a need to manage expenses with simple CRUD 
operations while ensuring precise price calculations. Using .NET Core and MySQL provided 
a robust, scalable solution. Docker allowed for easy database setup, and Swagger made API testing more accessible.**
