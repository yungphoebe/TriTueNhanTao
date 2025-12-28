#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
ĐỒ ÁN TRÍ TUỆ NHÂN TẠO
Thuật toán Di truyền (Genetic Algorithm) giải bài toán TSP
(Travelling Salesman Problem - Người bán hàng)

Tác giả: Đồ án TTNT
Ngày: 2024
"""

import random
import matplotlib.pyplot as plt
import numpy as np
from typing import List, Tuple

# Đặt seed để kết quả có thể tái lập
random.seed(42)
np.random.seed(42)

# ============================================================================
# CLASS CITY - ĐẠI DIỆN THÀNH PHỐ
# ============================================================================

class City:
    """Lớp đại diện cho một thành phố với tọa độ x, y"""
    
    def __init__(self, ten: str, x: float, y: float):
        """
        Khởi tạo thành phố
        
        Args:
            ten: Tên thành phố
            x: Tọa độ x
            y: Tọa độ y
        """
        self.ten = ten
        self.x = x
        self.y = y
    
    def khoang_cach_den(self, city_khac) -> float:
        """
        Tính khoảng cách Euclidean đến thành phố khác
        
        Args:
            city_khac: Thành phố đích
            
        Returns:
            Khoảng cách giữa 2 thành phố
        """
        dx = self.x - city_khac.x
        dy = self.y - city_khac.y
        return np.sqrt(dx**2 + dy**2)
    
    def __repr__(self):
        return f"{self.ten}({self.x:.1f},{self.y:.1f})"


# ============================================================================
# CÁC HÀM TÍNH TOÁN CƠ BẢN
# ============================================================================

def tinh_khoang_cach_tong(route: List[City]) -> float:
    """
    Tính tổng khoảng cách của một lộ trình
    
    Args:
        route: Danh sách các thành phố theo thứ tự
        
    Returns:
        Tổng khoảng cách của lộ trình (bao gồm quay về điểm xuất phát)
    """
    tong_khoang_cach = 0.0
    
    # Tính khoảng cách giữa các thành phố liên tiếp
    for i in range(len(route)):
        city_hien_tai = route[i]
        city_tiep_theo = route[(i + 1) % len(route)]  # % để quay về điểm đầu
        tong_khoang_cach += city_hien_tai.khoang_cach_den(city_tiep_theo)
    
    return tong_khoang_cach


def tinh_fitness(route: List[City]) -> float:
    """
    Tính độ thích nghi (fitness) của một lộ trình
    Fitness = 1 / khoảng_cách (càng ngắn càng tốt)
    
    Args:
        route: Danh sách các thành phố theo thứ tự
        
    Returns:
        Độ thích nghi (số càng lớn càng tốt)
    """
    khoang_cach = tinh_khoang_cach_tong(route)
    return 1.0 / khoang_cach if khoang_cach > 0 else 0.0


# ============================================================================
# CÁC HÀM THUẬT TOÁN DI TRUYỀN
# ============================================================================

def tao_route_ngau_nhien(danh_sach_city: List[City]) -> List[City]:
    """
    Tạo một lộ trình ngẫu nhiên từ danh sách thành phố
    
    Args:
        danh_sach_city: Danh sách các thành phố
        
    Returns:
        Lộ trình ngẫu nhiên (một hoán vị của danh sách thành phố)
    """
    route = danh_sach_city.copy()
    random.shuffle(route)
    return route


def chon_loc(population: List[List[City]], so_luong_chon: int) -> List[List[City]]:
    """
    Chọn lọc các cá thể tốt nhất theo fitness
    Sử dụng phương pháp Elite Selection (chọn các cá thể tốt nhất)
    
    Args:
        population: Quần thể hiện tại
        so_luong_chon: Số lượng cá thể cần chọn
        
    Returns:
        Danh sách các cá thể được chọn
    """
    # Tính fitness cho toàn bộ quần thể
    fitness_scores = [(route, tinh_fitness(route)) for route in population]
    
    # Sắp xếp theo fitness giảm dần (fitness cao = tốt)
    fitness_scores.sort(key=lambda x: x[1], reverse=True)
    
    # Chọn các cá thể tốt nhất
    selected = [route for route, fitness in fitness_scores[:so_luong_chon]]
    
    return selected


def lai_ghep_OX(cha: List[City], me: List[City]) -> Tuple[List[City], List[City]]:
    """
    Order Crossover (OX) - Lai ghép theo thứ tự
    Đây là phương pháp lai ghép phổ biến cho bài toán TSP
    
    Args:
        cha: Lộ trình của cha
        me: Lộ trình của mẹ
        
    Returns:
        Tuple gồm 2 con (con1, con2)
    """
    size = len(cha)
    
    # Chọn 2 điểm cắt ngẫu nhiên
    diem1, diem2 = sorted(random.sample(range(size), 2))
    
    # Tạo con 1 từ cha và mẹ
    con1 = [None] * size
    con1[diem1:diem2] = cha[diem1:diem2]  # Copy đoạn từ cha
    
    # Điền các thành phố còn lại từ mẹ (theo thứ tự)
    vi_tri_con1 = diem2
    for city in me[diem2:] + me[:diem2]:  # Duyệt từ diem2 theo vòng tròn
        if city not in con1:
            if vi_tri_con1 >= size:
                vi_tri_con1 = 0
            con1[vi_tri_con1] = city
            vi_tri_con1 += 1
    
    # Tạo con 2 từ mẹ và cha (tương tự)
    con2 = [None] * size
    con2[diem1:diem2] = me[diem1:diem2]  # Copy đoạn từ mẹ
    
    vi_tri_con2 = diem2
    for city in cha[diem2:] + cha[:diem2]:
        if city not in con2:
            if vi_tri_con2 >= size:
                vi_tri_con2 = 0
            con2[vi_tri_con2] = city
            vi_tri_con2 += 1
    
    return con1, con2


def dot_bien(route: List[City], ty_le_dot_bien: float) -> List[City]:
    """
    Swap Mutation - Đột biến bằng cách hoán đổi 2 thành phố
    
    Args:
        route: Lộ trình cần đột biến
        ty_le_dot_bien: Xác suất đột biến (0.0 - 1.0)
        
    Returns:
        Lộ trình sau khi đột biến
    """
    route_moi = route.copy()
    
    # Quyết định có đột biến hay không
    if random.random() < ty_le_dot_bien:
        # Chọn 2 vị trí ngẫu nhiên và hoán đổi
        i, j = random.sample(range(len(route_moi)), 2)
        route_moi[i], route_moi[j] = route_moi[j], route_moi[i]
    
    return route_moi


def thuat_toan_di_truyen(
    danh_sach_city: List[City],
    kich_thuoc_quan_the: int = 50,
    so_the_he: int = 100,
    so_luong_elite: int = 10,
    ty_le_dot_bien: float = 0.01
) -> Tuple[List[City], List[float]]:
    """
    Thuật toán Di truyền (Genetic Algorithm) chính
    
    Args:
        danh_sach_city: Danh sách các thành phố
        kich_thuoc_quan_the: Kích thước quần thể
        so_the_he: Số thế hệ tiến hóa
        so_luong_elite: Số lượng cá thể ưu tú giữ lại
        ty_le_dot_bien: Tỷ lệ đột biến
        
    Returns:
        Tuple (route tốt nhất, lịch sử khoảng cách theo thế hệ)
    """
    print("🧬 BẮT ĐẦU THUẬT TOÁN DI TRUYỀN")
    print("=" * 60)
    print(f"📊 Tham số:")
    print(f"   - Kích thước quần thể: {kich_thuoc_quan_the}")
    print(f"   - Số thế hệ: {so_the_he}")
    print(f"   - Số lượng Elite: {so_luong_elite}")
    print(f"   - Tỷ lệ đột biến: {ty_le_dot_bien}")
    print("=" * 60)
    
    # Khởi tạo quần thể ban đầu
    population = [tao_route_ngau_nhien(danh_sach_city) for _ in range(kich_thuoc_quan_the)]
    
    # Lưu lịch sử khoảng cách tốt nhất qua các thế hệ
    lich_su_khoang_cach = []
    
    # Tiến hóa qua các thế hệ
    for the_he in range(so_the_he):
        # Đánh giá fitness toàn bộ quần thể
        fitness_scores = [(route, tinh_fitness(route)) for route in population]
        fitness_scores.sort(key=lambda x: x[1], reverse=True)
        
        # Lưu khoảng cách của cá thể tốt nhất
        route_tot_nhat = fitness_scores[0][0]
        khoang_cach_tot_nhat = tinh_khoang_cach_tong(route_tot_nhat)
        lich_su_khoang_cach.append(khoang_cach_tot_nhat)
        
        # In thông tin mỗi 10 thế hệ
        if the_he % 10 == 0 or the_he == so_the_he - 1:
            print(f"⚡ Thế hệ {the_he:3d}: Khoảng cách tốt nhất = {khoang_cach_tot_nhat:.2f}")
        
        # Tạo thế hệ mới
        population_moi = []
        
        # 1. Giữ lại các cá thể Elite (tốt nhất)
        elite = [route for route, _ in fitness_scores[:so_luong_elite]]
        population_moi.extend(elite)
        
        # 2. Tạo các cá thể con từ lai ghép và đột biến
        while len(population_moi) < kich_thuoc_quan_the:
            # Chọn 2 cha mẹ từ nửa tốt hơn của quần thể
            cha = random.choice(fitness_scores[:kich_thuoc_quan_the // 2])[0]
            me = random.choice(fitness_scores[:kich_thuoc_quan_the // 2])[0]
            
            # Lai ghép
            con1, con2 = lai_ghep_OX(cha, me)
            
            # Đột biến
            con1 = dot_bien(con1, ty_le_dot_bien)
            con2 = dot_bien(con2, ty_le_dot_bien)
            
            # Thêm vào quần thể mới
            population_moi.append(con1)
            if len(population_moi) < kich_thuoc_quan_the:
                population_moi.append(con2)
        
        # Cập nhật quần thể
        population = population_moi
    
    # Tìm route tốt nhất trong thế hệ cuối cùng
    fitness_scores = [(route, tinh_fitness(route)) for route in population]
    fitness_scores.sort(key=lambda x: x[1], reverse=True)
    route_tot_nhat = fitness_scores[0][0]
    
    print("=" * 60)
    print("✅ HOÀN THÀNH THUẬT TOÁN DI TRUYỀN")
    print(f"🏆 Khoảng cách cuối cùng: {tinh_khoang_cach_tong(route_tot_nhat):.2f}")
    print("=" * 60)
    
    return route_tot_nhat, lich_su_khoang_cach


# ============================================================================
# CÁC HÀM VẼ BIỂU ĐỒ
# ============================================================================

def ve_route(route: List[City], title: str = "Lộ trình TSP"):
    """
    Vẽ bản đồ lộ trình
    
    Args:
        route: Lộ trình cần vẽ
        title: Tiêu đề của biểu đồ
    """
    plt.figure(figsize=(10, 8))
    
    # Vẽ các thành phố
    x_coords = [city.x for city in route]
    y_coords = [city.y for city in route]
    
    # Vẽ đường đi
    x_coords.append(route[0].x)  # Quay về điểm xuất phát
    y_coords.append(route[0].y)
    plt.plot(x_coords, y_coords, 'b-o', linewidth=2, markersize=10, label='Lộ trình')
    
    # Đánh dấu điểm xuất phát
    plt.plot(route[0].x, route[0].y, 'go', markersize=15, label='Điểm xuất phát')
    
    # Ghi tên thành phố
    for i, city in enumerate(route):
        plt.annotate(
            f"{i+1}. {city.ten}",
            (city.x, city.y),
            xytext=(10, 10),
            textcoords='offset points',
            fontsize=9,
            bbox=dict(boxstyle='round,pad=0.5', facecolor='yellow', alpha=0.7)
        )
    
    # Tính và hiển thị khoảng cách
    khoang_cach = tinh_khoang_cach_tong(route)
    plt.title(f"{title}\nTổng khoảng cách: {khoang_cach:.2f}", fontsize=14, fontweight='bold')
    plt.xlabel("Tọa độ X", fontsize=12)
    plt.ylabel("Tọa độ Y", fontsize=12)
    plt.legend()
    plt.grid(True, alpha=0.3)
    plt.tight_layout()


def ve_tien_hoa(lich_su_khoang_cach: List[float]):
    """
    Vẽ đồ thị tiến hóa (khoảng cách qua các thế hệ)
    
    Args:
        lich_su_khoang_cach: Danh sách khoảng cách theo thế hệ
    """
    plt.figure(figsize=(10, 6))
    
    the_he = list(range(len(lich_su_khoang_cach)))
    plt.plot(the_he, lich_su_khoang_cach, 'r-', linewidth=2, label='Khoảng cách tốt nhất')
    
    # Đánh dấu điểm đầu và cuối
    plt.plot(0, lich_su_khoang_cach[0], 'go', markersize=10, label='Ban đầu')
    plt.plot(len(the_he)-1, lich_su_khoang_cach[-1], 'bo', markersize=10, label='Cuối cùng')
    
    plt.title("Tiến hóa Thuật toán Di truyền", fontsize=14, fontweight='bold')
    plt.xlabel("Thế hệ", fontsize=12)
    plt.ylabel("Khoảng cách", fontsize=12)
    plt.legend()
    plt.grid(True, alpha=0.3)
    plt.tight_layout()


def ve_giai_thich_OX():
    """
    Vẽ hình minh họa Order Crossover (OX)
    """
    fig, ax = plt.subplots(figsize=(12, 8))
    ax.axis('off')
    
    # Tiêu đề
    ax.text(0.5, 0.95, "Order Crossover (OX) - Lai ghép theo thứ tự", 
            ha='center', fontsize=16, fontweight='bold')
    
    # Ví dụ minh họa
    cha = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H']
    me = ['C', 'D', 'A', 'B', 'F', 'H', 'E', 'G']
    
    # Chọn đoạn từ vị trí 2 đến 5
    diem1, diem2 = 2, 5
    
    # Vẽ cha
    y_pos = 0.80
    ax.text(0.05, y_pos, "Cha:", fontsize=12, fontweight='bold')
    for i, gene in enumerate(cha):
        color = 'lightblue' if diem1 <= i < diem2 else 'lightgray'
        rect = plt.Rectangle((0.15 + i*0.08, y_pos-0.02), 0.07, 0.04, 
                             facecolor=color, edgecolor='black', linewidth=2)
        ax.add_patch(rect)
        ax.text(0.185 + i*0.08, y_pos, gene, ha='center', va='center', fontsize=11)
    
    # Vẽ mẹ
    y_pos = 0.70
    ax.text(0.05, y_pos, "Mẹ:", fontsize=12, fontweight='bold')
    for i, gene in enumerate(me):
        color = 'lightcoral' if diem1 <= i < diem2 else 'lightgray'
        rect = plt.Rectangle((0.15 + i*0.08, y_pos-0.02), 0.07, 0.04, 
                             facecolor=color, edgecolor='black', linewidth=2)
        ax.add_patch(rect)
        ax.text(0.185 + i*0.08, y_pos, gene, ha='center', va='center', fontsize=11)
    
    # Vẽ điểm cắt
    ax.plot([0.15 + diem1*0.08, 0.15 + diem1*0.08], [0.65, 0.84], 
           'g--', linewidth=2, label='Điểm cắt')
    ax.plot([0.15 + diem2*0.08, 0.15 + diem2*0.08], [0.65, 0.84], 
           'g--', linewidth=2)
    
    # Giải thích bước 1
    y_pos = 0.55
    ax.text(0.05, y_pos, "Bước 1: Copy đoạn từ Cha (vị trí 2-5)", 
           fontsize=11, style='italic')
    con1_step1 = [None, None, 'C', 'D', 'E', None, None, None]
    for i, gene in enumerate(con1_step1):
        color = 'lightblue' if gene is not None else 'white'
        rect = plt.Rectangle((0.15 + i*0.08, y_pos-0.05), 0.07, 0.04, 
                             facecolor=color, edgecolor='black', linewidth=1)
        ax.add_patch(rect)
        if gene:
            ax.text(0.185 + i*0.08, y_pos-0.03, gene, ha='center', va='center', fontsize=11)
    
    # Giải thích bước 2
    y_pos = 0.43
    ax.text(0.05, y_pos, "Bước 2: Điền các thành phố còn lại từ Mẹ", 
           fontsize=11, style='italic')
    ax.text(0.05, y_pos-0.05, "(theo thứ tự, bỏ qua các thành phố đã có)", 
           fontsize=10, style='italic', color='gray')
    
    # Giải thích thứ tự lấy từ mẹ
    y_pos = 0.32
    me_order = me[diem2:] + me[:diem2]  # ['F', 'H', 'E', 'G', 'C', 'D', 'A', 'B']
    ax.text(0.05, y_pos, f"Thứ tự từ Mẹ (từ vị trí {diem2}): {' → '.join(me_order)}", 
           fontsize=10, color='darkred')
    ax.text(0.05, y_pos-0.05, "Giữ lại: F, H, G, A, B (bỏ C, D, E vì đã có)", 
           fontsize=10, color='darkgreen')
    
    # Con 1 hoàn chỉnh
    y_pos = 0.20
    ax.text(0.05, y_pos, "Con 1:", fontsize=12, fontweight='bold', color='darkblue')
    con1 = ['F', 'H', 'C', 'D', 'E', 'G', 'A', 'B']
    for i, gene in enumerate(con1):
        color = 'lightblue' if diem1 <= i < diem2 else 'lightyellow'
        rect = plt.Rectangle((0.15 + i*0.08, y_pos-0.02), 0.07, 0.04, 
                             facecolor=color, edgecolor='black', linewidth=2)
        ax.add_patch(rect)
        ax.text(0.185 + i*0.08, y_pos, gene, ha='center', va='center', 
               fontsize=11, fontweight='bold')
    
    # Ghi chú
    y_pos = 0.05
    ax.text(0.5, y_pos, "✓ OX đảm bảo không có thành phố trùng lặp", 
           ha='center', fontsize=11, color='darkgreen', fontweight='bold',
           bbox=dict(boxstyle='round,pad=0.5', facecolor='lightgreen', alpha=0.3))
    
    plt.tight_layout()


# ============================================================================
# HÀM MAIN - CHƯƠNG TRÌNH CHÍNH
# ============================================================================

def main():
    """
    Hàm chính - Chạy chương trình
    """
    print("\n" + "🌟" * 30)
    print("   ĐỒ ÁN TRÍ TUỆ NHÂN TẠO")
    print("   THUẬT TOÁN DI TRUYỀN (GA) CHO BÀI TOÁN TSP")
    print("🌟" * 30 + "\n")
    
    # ========================================================================
    # BƯỚC 1: Tạo danh sách thành phố Việt Nam
    # ========================================================================
    print("📍 BƯỚC 1: TẠO DANH SÁCH THÀNH PHỐ VIỆT NAM")
    print("-" * 60)
    
    danh_sach_city = [
        City("HN", 105.8, 21.0),      # Hà Nội
        City("HCM", 106.7, 10.8),     # Hồ Chí Minh
        City("DN", 108.2, 16.1),      # Đà Nẵng
        City("HP", 106.1, 20.9),      # Hải Phòng
        City("CT", 105.8, 10.0),      # Cần Thơ
        City("NT", 109.2, 12.3),      # Nha Trang
        City("HUE", 107.6, 16.5),     # Huế
        City("VT", 108.0, 14.4),      # Quy Nhơn (Bình Định)
        City("DL", 108.4, 11.9),      # Đà Lạt
        City("VL", 105.6, 18.7),      # Vinh
    ]
    
    print(f"✅ Đã tạo {len(danh_sach_city)} thành phố:")
    for i, city in enumerate(danh_sach_city, 1):
        print(f"   {i:2d}. {city}")
    print()
    
    # ========================================================================
    # BƯỚC 2: Tạo lộ trình ngẫu nhiên để so sánh
    # ========================================================================
    print("🎲 BƯỚC 2: TẠO LỘ TRÌNH NGẪU NHIÊN (ĐỂ SO SÁNH)")
    print("-" * 60)
    
    route_ngau_nhien = tao_route_ngau_nhien(danh_sach_city)
    khoang_cach_ngau_nhien = tinh_khoang_cach_tong(route_ngau_nhien)
    
    print(f"📏 Khoảng cách lộ trình ngẫu nhiên: {khoang_cach_ngau_nhien:.2f}")
    print(f"🗺️  Lộ trình: {' → '.join([c.ten for c in route_ngau_nhien])} → {route_ngau_nhien[0].ten}")
    print()
    
    # ========================================================================
    # BƯỚC 3: Chạy thuật toán di truyền
    # ========================================================================
    print("🧬 BƯỚC 3: CHẠY THUẬT TOÁN DI TRUYỀN")
    print("-" * 60)
    
    route_tot_nhat, lich_su_khoang_cach = thuat_toan_di_truyen(
        danh_sach_city=danh_sach_city,
        kich_thuoc_quan_the=50,
        so_the_he=100,
        so_luong_elite=10,
        ty_le_dot_bien=0.01
    )
    
    khoang_cach_tot_nhat = tinh_khoang_cach_tong(route_tot_nhat)
    print()
    
    # ========================================================================
    # BƯỚC 4: So sánh kết quả
    # ========================================================================
    print("📊 BƯỚC 4: SO SÁNH KẾT QUẢ")
    print("=" * 60)
    print(f"🎲 Lộ trình ngẫu nhiên: {khoang_cach_ngau_nhien:.2f}")
    print(f"🧬 Lộ trình GA tốt nhất: {khoang_cach_tot_nhat:.2f}")
    
    # Tính phần trăm cải thiện
    cai_thien = ((khoang_cach_ngau_nhien - khoang_cach_tot_nhat) / khoang_cach_ngau_nhien) * 100
    print(f"✨ Cải thiện: {cai_thien:.2f}%")
    
    if cai_thien >= 30:
        print("✅ GA cải thiện ≥ 30% - ĐẠT YÊU CẦU!")
    else:
        print("⚠️  GA cải thiện < 30% - Có thể cần điều chỉnh tham số")
    
    print("=" * 60)
    print()
    
    print(f"🗺️  Lộ trình tốt nhất: {' → '.join([c.ten for c in route_tot_nhat])} → {route_tot_nhat[0].ten}")
    print()
    
    # ========================================================================
    # BƯỚC 5: Vẽ các biểu đồ
    # ========================================================================
    print("📈 BƯỚC 5: VẼ CÁC BIỂU ĐỒ")
    print("-" * 60)
    print("⏳ Đang vẽ biểu đồ...")
    
    # Hình 1: Giải thích OX Crossover
    ve_giai_thich_OX()
    print("   ✅ Hình 1: OX Crossover - Hoàn thành")
    
    # Hình 2: Lộ trình tốt nhất
    ve_route(route_tot_nhat, "Lộ trình tốt nhất (GA)")
    print("   ✅ Hình 2: Lộ trình tốt nhất - Hoàn thành")
    
    # Hình 3: Đồ thị tiến hóa
    ve_tien_hoa(lich_su_khoang_cach)
    print("   ✅ Hình 3: Đồ thị tiến hóa - Hoàn thành")
    
    print("-" * 60)
    print()
    
    # ========================================================================
    # HIỂN THỊ TẤT CẢ CÁC HÌNH
    # ========================================================================
    print("🎨 Hiển thị tất cả biểu đồ...")
    plt.show()
    
    print("\n" + "🌟" * 30)
    print("   ✅ CHƯƠNG TRÌNH HOÀN THÀNH")
    print("🌟" * 30 + "\n")


# ============================================================================
# CHẠY CHƯƠNG TRÌNH
# ============================================================================

if __name__ == "__main__":
    main()
