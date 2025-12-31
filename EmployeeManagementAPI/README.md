SQL Server connection string `appsettings.json`  setup:

```json
"Server=localhost\\SQLEXPRESS;Database=EmployeeManagementDB;Trusted_Connection=True;..."
```

After EF migrations to create the database:
```bash
dotnet ef database update
```

Start the app:
```bash
dotnet run
```

API should be running on http://localhost:5194

Main APIs

Auth:
 POST `/api/Auth/login` - Login endpoint. Use username: `admin` and password: `admin123`

Employee Operations:
 PUT `/api/Employees/{id}` - Update employee info
 GET `/api/Employees/nth-highest-salary/{rank}` - Find employee by salary rank (1 = highest)
 GET `/api/Employees/high-earners?minSalary=50000` - List high earners with good attendance
 GET `/api/Employees/{id}/hierarchy` - Get the full supervisor chain for an employee

Attendance:
 GET `/api/Attendance/monthly-report?month=6&year=2023` - Monthly attendance summary

Built With

 .NET 8
 Entity Framework Core 8
 SQL Server
 JWT for auth

