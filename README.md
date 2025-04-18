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

### Bảng Products (Đồng hồ)

- Id (PK)
- Name (tên đồng hồ)
- Brand (thương hiệu)
- Model (mã model)
- Description (mô tả chi tiết)
- Price (giá bán)
- ImageUrl (đường dẫn hình ảnh)
- Status (trạng thái: có sẵn/cần đặt hàng)
- DeliveryTime (thời gian giao hàng dự kiến nếu cần đặt hàng)
- CreatedAt
- UpdatedAt

### Bảng Brands (Thương hiệu)

- Id (PK)
- Name (tên thương hiệu)
- Description (mô tả)
- ImageUrl (logo thương hiệu)
- Status (Active/Inactive)

## Công nghệ sử dụng

- .NET Core 8.0
- Entity Framework Core
- SQL Server
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
- GET /api/brands/{id} - Lấy chi tiết thương hiệu

## Hướng dẫn cài đặt

(Sẽ được cập nhật sau khi hoàn thành dự án)

## Tác giả

(Thông tin tác giả)
