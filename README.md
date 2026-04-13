
---

```markdown
# 📦 ASP.NET Core JWT Authentication & Product API

This project is a **secure REST API** built with ASP.NET Core that demonstrates:

- JWT Authentication
- Protected APIs using `[Authorize]`
- CRUD operations for Products
- Clean controller-service architecture
- Docker-based deployment

---

## 🚀 Features

- 🔐 User login with JWT token generation
- 🛡️ Secured endpoints using Bearer Token
- 📦 Product management (CRUD)
- ⚙️ Config-based JWT setup
- 🧱 Scalable layered architecture
- 🐳 Dockerized application with SQL Server

---

## 🛠️ Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- JWT (JSON Web Token)
- Docker & Docker Compose

---

## 📁 Project Structure

```

API/
Controllers/
AuthController.cs
ProductController.cs

Application/
Services/

Infrastructure/
Data/
Repositories/

Domain/
Entities/

ProductSolution.slnx
docker-compose.yml
Dockerfile

````

---

## 🔑 Authentication Flow

1. User sends login request  
2. Server validates credentials  
3. JWT token is generated  
4. Token is used to access protected APIs  

---

## ⚙️ Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=sqlserver,1433;Database=ProductDb;User=sa;Password=YourStrong@Pass123;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "your_secret_key_here",
    "Issuer": "ProductAPI",
    "Audience": "ProductAPI"
  }
}
````

---

## 🔐 Auth API

### 🔸 Login

**Endpoint:**

```
POST /api/auth/login
```

**Request:**

```
username=admin
password=123
```

**Response:**

```json
{
  "token": "your_jwt_token"
}
```

---

## 📦 Product APIs (Protected)

⚠️ All endpoints require JWT token in header:

```
Authorization: Bearer <your_token>
```

---

### 🔸 Get All Products

```
GET /api/product
```

---

### 🔸 Get Product by ID

```
GET /api/product/{id}
```

---

### 🔸 Create Product

```
POST /api/product
```

**Body:**

```json
{
  "id": 0,
  "productName": "string",
  "createdBy": "string",
  "createdOn": "2026-04-13T16:38:13.310Z",
  "modifiedBy": "string",
  "modifiedOn": "2026-04-13T16:38:13.310Z"
}
```

---

### 🔸 Update Product

```
PUT /api/product
```

---

### 🔸 Delete Product

```
DELETE /api/product/{id}
```

---

## 🧠 JWT Details

* Algorithm: HmacSha256
* Token Expiry: 1 hour
* Claims:

  * Username

---

## ▶️ Running the Project (Without Docker)

1. Clone the repository
2. Open in Visual Studio / VS Code
3. Configure `appsettings.json`
4. Run:

```bash
dotnet run
```

5. Test using Swagger or Postman

---

## 🐳 Docker Setup

This project is fully containerized and can be run with a single command.

---

### 🔹 Prerequisites

* Docker Desktop installed and running

---

### 🔹 Run Application

```bash
docker-compose up --build
```

---

### 🔹 Services

* API → [http://localhost:5000](http://localhost:5000)
* Swagger UI → [http://localhost:5000/swagger](http://localhost:5000/swagger)
* SQL Server → localhost:1433

---

### 🔹 Environment Variables

Configured inside `docker-compose.yml`:

* `ASPNETCORE_ENVIRONMENT`
* `ASPNETCORE_URLS`
* `ConnectionStrings__DefaultConnection`
* `Jwt__Key`
* `Jwt__Issuer`
* `Jwt__Audience`

---

### 🔹 Database

* SQL Server runs inside Docker container
* Database is auto-created using EF Core migrations
* Data is persisted using Docker volume

---

### 🔹 Stop Containers

```bash
docker-compose down
```

---

## 🧪 Testing Steps

1. Call `/api/auth/login`
2. Copy token from response
3. Add header:

```
Authorization: Bearer <token>
```

4. Access Product APIs

---

## ⚠️ Notes

* Dummy credentials:

  ```
  username: admin
  password: 123
  ```
* Replace with database authentication in production
* Store JWT secret securely

---

## 🔮 Future Improvements

* Role-based authorization
* Refresh tokens
* Logging & exception handling
* Swagger authentication UI enhancement
* Production deployment (Nginx / Kubernetes)

---

## 👨‍💻 Author

**Snehal Mankar**

