# Thuật toán Di truyền (Genetic Algorithm) cho bài toán TSP

## 📚 Giới thiệu Đồ án

Đây là đồ án môn **Trí tuệ Nhân tạo** về **Thuật toán Di truyền (Genetic Algorithm - GA)** ứng dụng vào giải quyết bài toán **Người bán hàng (Travelling Salesman Problem - TSP)**.

### 🎯 Mục tiêu

- Hiểu và cài đặt thuật toán Di truyền cơ bản
- Áp dụng GA vào bài toán tối ưu tổ hợp (TSP)
- So sánh hiệu quả của GA với phương pháp ngẫu nhiên
- Trực quan hóa quá trình tiến hóa và kết quả

### 🌟 Đặc điểm nổi bật

- ✅ Code Python đơn giản, dễ hiểu
- ✅ Comment tiếng Việt chi tiết
- ✅ Chạy được ngay, không cần cấu hình phức tạp
- ✅ 3 biểu đồ trực quan (OX Crossover, Lộ trình, Tiến hóa)
- ✅ So sánh với lộ trình ngẫu nhiên
- ✅ Tính % cải thiện tự động

---

## 🔧 Cài đặt

### Yêu cầu hệ thống

- Python 3.7 trở lên
- pip (Python package manager)

### Bước 1: Clone repository

```bash
git clone https://github.com/yungphoebe/TriTueNhanTao.git
cd TriTueNhanTao/GA-TSP
```

### Bước 2: Cài đặt thư viện

```bash
pip install -r requirements.txt
```

Hoặc cài đặt trực tiếp:

```bash
pip install matplotlib==3.7.1 numpy==1.24.3
```

---

## 🚀 Hướng dẫn chạy

### Chạy chương trình

```bash
python ga_tsp_simple.py
```

hoặc

```bash
python3 ga_tsp_simple.py
```

### Kết quả mong đợi

Chương trình sẽ:

1. **Tạo 10 thành phố Việt Nam** với tọa độ ngẫu nhiên
2. **Chạy thuật toán GA** với các tham số mặc định:
   - Kích thước quần thể: 50
   - Số thế hệ: 100
   - Số lượng Elite: 10
   - Tỷ lệ đột biến: 0.01 (1%)
3. **Hiển thị 3 biểu đồ**:
   - Hình 1: Minh họa OX Crossover
   - Hình 2: Lộ trình tốt nhất
   - Hình 3: Đồ thị tiến hóa
4. **In kết quả** ra console với format đẹp

---

## 📖 Cấu trúc Code

### Class và Hàm chính

```
ga_tsp_simple.py
├── Class City                      # Đại diện thành phố
│   ├── __init__()                  # Khởi tạo với tên, x, y
│   ├── khoang_cach_den()          # Tính khoảng cách đến thành phố khác
│   └── __repr__()                 # Hiển thị thông tin
│
├── Hàm tính toán
│   ├── tinh_khoang_cach_tong()    # Tính tổng khoảng cách lộ trình
│   └── tinh_fitness()             # Tính độ thích nghi (1/khoảng_cách)
│
├── Hàm thuật toán GA
│   ├── tao_route_ngau_nhien()     # Tạo lộ trình ngẫu nhiên
│   ├── chon_loc()                 # Chọn lọc theo fitness
│   ├── lai_ghep_OX()              # Order Crossover (OX)
│   ├── dot_bien()                 # Swap Mutation
│   └── thuat_toan_di_truyen()     # Thuật toán GA chính
│
├── Hàm visualization
│   ├── ve_route()                 # Vẽ bản đồ lộ trình
│   ├── ve_tien_hoa()              # Vẽ đồ thị tiến hóa
│   └── ve_giai_thich_OX()         # Vẽ minh họa OX Crossover
│
└── main()                          # Hàm chính
```

### Giải thích các thành phần

#### 1. Class City
Đại diện cho một thành phố với:
- `ten`: Tên thành phố (VD: "HN", "HCM")
- `x, y`: Tọa độ trên bản đồ
- Method `khoang_cach_den()`: Tính khoảng cách Euclidean

#### 2. Các hàm GA cốt lõi

**Order Crossover (OX)**:
- Là toán tử lai ghép phổ biến cho TSP
- Copy một đoạn từ cha, điền phần còn lại từ mẹ theo thứ tự
- Đảm bảo không có thành phố trùng lặp

**Swap Mutation**:
- Hoán đổi vị trí 2 thành phố ngẫu nhiên
- Xác suất đột biến thấp (1%) để không phá hỏng cá thể tốt

**Selection (Chọn lọc)**:
- Chọn các cá thể tốt nhất (có fitness cao)
- Elite: giữ lại top cá thể tốt nhất qua các thế hệ

#### 3. Thuật toán GA chính

```
1. Khởi tạo quần thể ngẫu nhiên
2. Lặp qua các thế hệ:
   a. Đánh giá fitness toàn bộ quần thể
   b. Chọn các cá thể Elite
   c. Lai ghép (Crossover) tạo cá thể mới
   d. Đột biến (Mutation) với xác suất thấp
   e. Thay thế quần thể cũ bằng quần thể mới
3. Trả về cá thể tốt nhất
```

---

## 📊 Kết quả mẫu

### Console Output

```
🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟
   ĐỒ ÁN TRÍ TUỆ NHÂN TẠO
   THUẬT TOÁN DI TRUYỀN (GA) CHO BÀI TOÁN TSP
🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟🌟

📍 BƯỚC 1: TẠO DANH SÁCH THÀNH PHỐ VIỆT NAM
------------------------------------------------------------
✅ Đã tạo 10 thành phố:
    1. HN(105.8,21.0)
    2. HCM(106.7,10.8)
   ...

🎲 BƯỚC 2: TẠO LỘ TRÌNH NGẪU NHIÊN (ĐỂ SO SÁNH)
------------------------------------------------------------
📏 Khoảng cách lộ trình ngẫu nhiên: 45.67

🧬 BƯỚC 3: CHẠY THUẬT TOÁN DI TRUYỀN
------------------------------------------------------------
⚡ Thế hệ   0: Khoảng cách tốt nhất = 42.15
⚡ Thế hệ  10: Khoảng cách tốt nhất = 38.92
⚡ Thế hệ  20: Khoảng cách tốt nhất = 36.45
...
⚡ Thế hệ  99: Khoảng cách tốt nhất = 28.73

📊 BƯỚC 4: SO SÁNH KẾT QUẢ
============================================================
🎲 Lộ trình ngẫu nhiên: 45.67
🧬 Lộ trình GA tốt nhất: 28.73
✨ Cải thiện: 37.09%
✅ GA cải thiện ≥ 30% - ĐẠT YÊU CẦU!
============================================================
```

### Biểu đồ

1. **OX Crossover**: Minh họa chi tiết cách Order Crossover hoạt động
2. **Lộ trình tốt nhất**: Bản đồ với các thành phố và đường đi
3. **Đồ thị tiến hóa**: Cho thấy khoảng cách giảm dần qua các thế hệ

*(Chạy chương trình để xem các biểu đồ chi tiết)*

---

## 🎓 Kiến thức liên quan

### Bài toán TSP

**Travelling Salesman Problem (TSP)** là bài toán tối ưu tổ hợp kinh điển:
- Cho n thành phố
- Tìm lộ trình ngắn nhất đi qua tất cả các thành phố đúng 1 lần
- Quay về thành phố xuất phát

### Thuật toán Di truyền (GA)

**Genetic Algorithm** là thuật toán tối ưu hóa dựa trên nguyên lý tiến hóa tự nhiên:

1. **Representation (Biểu diễn)**: Mỗi lộ trình là một cá thể (chromosome)
2. **Fitness**: Độ thích nghi = 1/khoảng_cách
3. **Selection**: Chọn cá thể tốt để sinh sản
4. **Crossover**: Lai ghép tạo cá thể mới
5. **Mutation**: Đột biến để tăng đa dạng
6. **Replacement**: Thay thế quần thể cũ

### Order Crossover (OX)

OX là toán tử crossover đặc biệt cho bài toán hoán vị (như TSP):
- Copy một đoạn từ parent 1
- Điền phần còn lại từ parent 2 theo thứ tự
- Bỏ qua các phần tử đã có

---

## ⚙️ Tham số và Tùy chỉnh

Bạn có thể điều chỉnh các tham số trong hàm `main()`:

```python
route_tot_nhat, lich_su_khoang_cach = thuat_toan_di_truyen(
    danh_sach_city=danh_sach_city,
    kich_thuoc_quan_the=50,      # Số cá thể trong quần thể
    so_the_he=100,                # Số thế hệ tiến hóa
    so_luong_elite=10,            # Số cá thể elite giữ lại
    ty_le_dot_bien=0.01           # Tỷ lệ đột biến (0.0 - 1.0)
)
```

### Gợi ý điều chỉnh

- **Tăng `kich_thuoc_quan_the`**: Tìm kiếm rộng hơn, nhưng chậm hơn
- **Tăng `so_the_he`**: Cho GA nhiều thời gian tiến hóa hơn
- **Tăng `so_luong_elite`**: Giữ nhiều cá thể tốt hơn
- **Tăng `ty_le_dot_bien`**: Tăng khám phá, nhưng có thể mất ổn định

---

## 🐛 Xử lý lỗi

### Lỗi import matplotlib

```bash
pip install --upgrade matplotlib
```

### Lỗi không hiển thị biểu đồ

Trên một số hệ thống Linux, cần cài đặt thêm:

```bash
sudo apt-get install python3-tk
```

### Lỗi encoding (Windows)

Chạy với:

```bash
chcp 65001
python ga_tsp_simple.py
```

---

## 📝 Tài liệu tham khảo

- [Genetic Algorithms - Wikipedia](https://en.wikipedia.org/wiki/Genetic_algorithm)
- [TSP - Wikipedia](https://en.wikipedia.org/wiki/Travelling_salesman_problem)
- [Order Crossover](https://en.wikipedia.org/wiki/Crossover_(genetic_algorithm)#Order_crossover_(OX1))

---

## 👨‍💻 Tác giả

**Đồ án Trí tuệ Nhân tạo**
- Repository: [yungphoebe/TriTueNhanTao](https://github.com/yungphoebe/TriTueNhanTao)
- Năm: 2024

---

## 📄 License

Đồ án này được sử dụng cho mục đích học tập và nghiên cứu.

---

## 🙏 Lời cảm ơn

Cảm ơn giảng viên và các bạn sinh viên đã hỗ trợ trong quá trình thực hiện đồ án.

---

**Happy Coding! 🚀**
