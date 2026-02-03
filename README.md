# MVP E-shop API

Minimalistic REST Web API built with ASP.NET Core (.NET 8).  
This project focuses on a simple product catalog and CRUD operations to establish clean API contracts and a solid foundation for future extensions.

## MVP Scope
- Product catalog CRUD (in-memory storage)
- Swagger/OpenAPI documentation
- Example HTTP requests for quick testing
- Database persistence (planned: MS SQL)
- DTOs design
- Validations and filters

## Business Flow
- Client reads product catalog via API
- Admin/service creates/updates products via API
- API will later persist data in MS SQL and support filtering, validation and auth

### Products
- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

## Next steps
- Validation: FluentValidation / DataAnnotations + consistent ProblemDetails
- Filtering & paging: search, min/max price, isActive, page/pageSize
- Auth via token
- Testing: unit tests for services + integration tests for API