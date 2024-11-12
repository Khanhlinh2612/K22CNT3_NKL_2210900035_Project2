create database K22CNT3_NKL_2210900035_Project2
use K22CNT3_NKL_2210900035_Project2
-- Tạo bảng QUAN_TRI
CREATE TABLE QUAN_TRI (
    ma_quan_tri INT PRIMARY KEY,
    mat_khau VARCHAR(255) NOT NULL,
    ten_dang_nhap VARCHAR(255) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE,
    ngay_tao DATETIME NOT NULL,
    trang_thai TINYINT NOT NULL
);

-- Tạo bảng NGUOI_DUNG
CREATE TABLE NGUOI_DUNG (
    ma_nguoi_dung INT PRIMARY KEY IDENTITY(1,1),
    ten_dang_nhap VARCHAR(255) UNIQUE NOT NULL,
    mat_khau VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE,
    ngay_dang_ky DATETIME NOT NULL
);

-- Tạo bảng STORY
CREATE TABLE STORY (
    ma_truyen INT PRIMARY KEY IDENTITY(1,1),
    ten_truyen VARCHAR(255) NOT NULL,
    tac_gia VARCHAR(255),
    the_loai VARCHAR(255),
    mo_ta TEXT,
    ngay_dang DATETIME NOT NULL,
    nguoi_dang INT NOT NULL,
    FOREIGN KEY (nguoi_dang) REFERENCES NGUOI_DUNG(ma_nguoi_dung)
);

-- Tạo bảng CHAPTER
CREATE TABLE CHAPTER (
    ma_chuong INT PRIMARY KEY IDENTITY(1,1),
    so_chuong INT NOT NULL,
    ten_chuong VARCHAR(255),
    noi_dung TEXT,
    ngay_dang DATETIME NOT NULL,
    ma_truyen INT NOT NULL,
    FOREIGN KEY (ma_truyen) REFERENCES STORY(ma_truyen)
);

-- Tạo bảng COMMENT
CREATE TABLE COMMENT (
    ma_binh_luan INT PRIMARY KEY IDENTITY(1,1),
    noi_dung TEXT NOT NULL,
    ngay_binh_luan DATETIME NOT NULL,
    ma_nguoi_dung INT NOT NULL,
    ma_truyen INT NOT NULL,
    FOREIGN KEY (ma_nguoi_dung) REFERENCES NGUOI_DUNG(ma_nguoi_dung),
    FOREIGN KEY (ma_truyen) REFERENCES STORY(ma_truyen)
);

-- Thêm dữ liệu mẫu vào bảng QUAN_TRI
INSERT INTO QUAN_TRI (ma_quan_tri, mat_khau, ten_dang_nhap, email, ngay_tao, trang_thai) VALUES
(1, 'admin123', 'admin_user1', 'admin1@example.com', '2023-01-01 10:00:00', 1),  -- Quản trị viên đang hoạt động
(2, 'admin234', 'admin_user2', 'admin2@example.com', '2023-01-02 11:00:00', 1),  -- Quản trị viên đang hoạt động
(3, 'admin345', 'admin_user3', 'admin3@example.com', '2023-01-03 12:00:00', 1),  -- Quản trị viên đang hoạt động
(4, 'admin456', 'admin_user4', 'admin4@example.com', '2023-01-04 13:00:00', 0),  -- Quản trị viên bị khóa
(5, 'admin567', 'admin_user5', 'admin5@example.com', '2023-01-05 14:00:00', 1);  -- Quản trị viên đang hoạt động


-- Thêm dữ liệu mẫu vào bảng NGUOI_DUNG
INSERT INTO NGUOI_DUNG (ten_dang_nhap, mat_khau, email, ngay_dang_ky) VALUES
('user1', 'userpass1', 'user1@example.com', '2023-02-01 09:00:00'),
('user2', 'userpass2', 'user2@example.com', '2023-02-02 10:00:00'),
('user3', 'userpass3', 'user3@example.com', '2023-02-03 11:00:00'),
('user4', 'userpass4', 'user4@example.com', '2023-02-04 12:00:00'),
('user5', 'userpass5', 'user5@example.com', '2023-02-05 13:00:00');

-- Thêm dữ liệu mẫu vào bảng STORY
INSERT INTO STORY (ten_truyen, tac_gia, the_loai, mo_ta, ngay_dang, nguoi_dang) VALUES
('Truyện A', 'Tác giả 1', 'Khoa học viễn tưởng', 'Truyện về hành trình khám phá vũ trụ', '2023-03-01 08:00:00', 1),
('Truyện B', 'Tác giả 2', 'Phiêu lưu', 'Câu chuyện về cuộc phiêu lưu của một anh hùng', '2023-03-02 09:00:00', 2),
('Truyện C', 'Tác giả 3', 'Kinh dị', 'Truyện về những sự kiện kỳ bí', '2023-03-03 10:00:00', 3),
('Truyện D', 'Tác giả 4', 'Lãng mạn', 'Một câu chuyện tình yêu', '2023-03-04 11:00:00', 4),
('Truyện E', 'Tác giả 5', 'Hài hước', 'Một câu chuyện vui nhộn', '2023-03-05 12:00:00', 5);

-- Thêm dữ liệu mẫu vào bảng CHAPTER
INSERT INTO CHAPTER (so_chuong, ten_chuong, noi_dung, ngay_dang, ma_truyen) VALUES
(1, 'Chương 1: Khởi đầu', 'Nội dung chương 1 của Truyện A', '2023-03-01 08:30:00', 1),
(2, 'Chương 2: Phát hiện', 'Nội dung chương 2 của Truyện A', '2023-03-02 08:30:00', 1),
(1, 'Chương 1: Cuộc phiêu lưu bắt đầu', 'Nội dung chương 1 của Truyện B', '2023-03-02 09:30:00', 2),
(1, 'Chương 1: Nỗi sợ hãi', 'Nội dung chương 1 của Truyện C', '2023-03-03 10:30:00', 3),
(1, 'Chương 1: Gặp gỡ định mệnh', 'Nội dung chương 1 của Truyện D', '2023-03-04 11:30:00', 4);

-- Thêm dữ liệu mẫu vào bảng COMMENT
INSERT INTO COMMENT (noi_dung, ngay_binh_luan, ma_nguoi_dung, ma_truyen) VALUES
('Truyện này rất hay!', '2023-03-01 09:00:00', 1, 1),
('Tôi thích nhân vật chính!', '2023-03-02 10:00:00', 2, 2),
('Câu chuyện gây cấn và hấp dẫn', '2023-03-03 11:00:00', 3, 3),
('Đoạn kết rất xúc động', '2023-03-04 12:00:00', 4, 4),
('Truyện này làm tôi cười rất nhiều', '2023-03-05 13:00:00', 5, 5);
