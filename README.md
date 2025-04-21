# Watch Store - Website Bán Đồng Hồ Xách Tay

## Giới thiệu

Website bán đồng hồ xách tay được xây dựng bằng .NET Core, cung cấp các chức năng cơ bản để hiển thị và quản lý sản phẩm đồng hồ.

## Chức năng chính

1. Hiển thị danh sách đồng hồ

   - Phân trang danh sách sản phẩm
   - Lọc theo thương hiệu
   - Sắp xếp theo giá

2. Hiển thị chi tiết sản phẩm
   - Thông tin cơ bản: tên, thương hiệu, model
   - Mô tả chi tiết sản phẩm
   - Hình ảnh sản phẩm
   - Giá bán
3. Trạng thái sản phẩm
   - Có sẵn: giao hàng ngay
   - Cần đặt hàng: thời gian chờ 15-30 ngày

## Cấu trúc dự án

```
WatchStore/
├── src/
│   ├── WatchStore.API/           # API Layer
│   ├── WatchStore.Core/          # Domain & Application Layer
│   ├── WatchStore.Infrastructure/# Infrastructure Layer
│   └── WatchStore.Tests/         # Test Projects
├── docs/                         # Documentation
└── README.md
```

## Cấu trúc cơ sở dữ liệu

### Bảng Products (products)

- Id (PK)
- Name (VARCHAR(200), NOT NULL) - tên đồng hồ
- BrandId (FK) - khóa ngoại tới bảng brands
- Model (VARCHAR(100), NOT NULL) - mã model
- Description (VARCHAR(2000)) - mô tả chi tiết
- Price (DECIMAL(18,2)) - giá bán
- ImageUrl (VARCHAR(500)) - đường dẫn hình ảnh
- Status (ENUM: Available/PreOrder) - trạng thái
- DeliveryTime (INTEGER) - số ngày giao hàng dự kiến
- CreatedAt (TIMESTAMP)
- UpdatedAt (TIMESTAMP)

### Bảng Brands (brands)

- Id (PK)
- Name (VARCHAR(100), NOT NULL, UNIQUE) - tên thương hiệu
- Description (VARCHAR(500)) - mô tả
- ImageUrl (VARCHAR(500)) - logo thương hiệu
- Status (BOOLEAN) - trạng thái hoạt động
- CreatedAt (TIMESTAMP)
- UpdatedAt (TIMESTAMP)

### Relationships

- Một Brand có nhiều Product (one-to-many)
- Product phải thuộc về một Brand (required relationship)
- Không cho phép xóa Brand khi còn Product liên kết (ON DELETE RESTRICT)

## Công nghệ sử dụng

- .NET Core 9.0
- Entity Framework Core 9.0
- PostgreSQL
- Clean Architecture
- REST API
- Swagger/OpenAPI

## API Endpoints

### Products

- GET /api/products - Lấy danh sách sản phẩm (có phân trang)
- GET /api/products/{id} - Lấy chi tiết sản phẩm
- GET /api/products/by-brand/{brandId} - Lọc sản phẩm theo thương hiệu

### Brands

- GET /api/brands - Lấy danh sách thương hiệu
- GET /api/brands/{id} - Lấy chi tiết thương hiệu và sản phẩm

## Hướng dẫn cài đặt

1. Yêu cầu hệ thống:
   - .NET SDK 9.0
   - PostgreSQL 15 trở lên
   - Visual Studio 2022 hoặc VS Code

2. Cài đặt PostgreSQL:
   ```bash
   # Tạo database
   createdb watchstore

   # Hoặc sử dụng pgAdmin để tạo database
   ```

3. Cấu hình connection string:
   - Mở file `src/WatchStore.API/appsettings.json`
   - Cập nhật connection string phù hợp với môi trường

4. Chạy migration:
   ```bash
   cd src/WatchStore.API
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Chạy ứng dụng:
   ```bash
   dotnet run
   ```

6. Truy cập Swagger UI:
   - http://localhost:5000/swagger

## Tác giả

(Thông tin tác giả)
