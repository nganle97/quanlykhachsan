CREATE DATABASE QuanLyKhachSan
GO

 USE   QuanLyKhachSan
 GO

 CREATE TABLE NhanVienQL
(
	idNhanVien INT IDENTITY PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh DATE NOT NULL,
	QueQuan NVARCHAR(100) NOT NULL,
	email NCHAR(50) NOT NULL,
	sdt FLOAT NOT NULL,

    
)
GO
CREATE TABLE khachhang
(
	idNKhachHang INT IDENTITY PRIMARY KEY,
	HoTen NVARCHAR(100) NOT NULL ,
	NgaySinh DATE NOT NULL,
	
	Diachi NVARCHAR(100) NOT NULL,
	sdt FLOAT NOT NULL,
	So_CMT NVARCHAR(100) NOT NULL, --số chứng minh thư

	loaikhachhang NVARCHAR(100) NOT NULL
)
GO
CREATE TABLE Phong
(
	id INT IDENTITY PRIMARY KEY,
	tenphong NVARCHAR(100) NOT NULL,
	loaiphong NCHAR(50) NOT NULL,
	dongia FLOAT NOT NULL DEFAULT 0,--giá ban đầu bằng 0
	trangthai NVARCHAR(100) DEFAULT N'phòng Trống'

)
GO

CREATE TABLE phieuthuephong
(
	id INT IDENTITY PRIMARY KEY,
	idphong INT NOT NULL,
	
	ngay_bat_dau_thue DATETIME NOT NULL

	FOREIGN KEY (idphong) REFERENCES dbo.Phong(id),
	
)
GO

CREATE TABLE Chitietphong
(
	id INT IDENTITY PRIMARY KEY,
	idphieuthuephong INT NOT NULL,
	idkhachhnag INT NOT NULL

	FOREIGN KEY (idphieuthuephong) REFERENCES dbo.phieuthuephong(id),
	FOREIGN KEY (idkhachhnag) REFERENCES dbo.KhachHang(idNKhachHang)
	 
)
GO


CREATE TABLE thongtintaikhoan
(
	userName VARCHAR(100) PRIMARY KEY,
	pass VARCHAR(1000) NOT NULL,
	idNhanVien INT NOT NULL,
	loaiTK INT NOT NULL DEFAULT 1, -- 0: Admin || 1: Nhân Viên || 2: Quản Lý

	

	FOREIGN KEY (idNhanVien) REFERENCES dbo.NhanVienQL(idNhanVien)
)
GO
CREATE TABLE HoaDon
(
	id INT IDENTITY PRIMARY KEY,

	TG_NhanPhong DATETIME NOT NULL,--thời gian nhận phòng
	TG_TraPhong DATETIME NOT NULL,
	TongTien FLOAT NOT NULL,
	TrangThai NVARCHAR(100) NOT NULL DEFAULT N'chua thanh toan', 
	idphieuthuephong INT ,
	 idkhachhang INT NOT NULL,
	userName VARCHAR(100),
	
	 FOREIGN KEY (idkhachhang) REFERENCES dbo.KhachHang(idNKhachHang),
	FOREIGN KEY (userName) REFERENCES dbo.thongtintaikhoan(userName),
	FOREIGN KEY (idphieuthuephong) REFERENCES dbo.phieuthuephong(id)
)
GO

CREATE TABLE chitiethoadon
(
	id INT IDENTITY PRIMARY KEY,
	idhoadon INT NOT NULL,
	dongia FLOAT NOT NULL,
	thanhtien FLOAT NOT NULL,
	soluong INT NOT NULL,--so ngay thue phong
	
	FOREIGN KEY (idhoadon) REFERENCES dbo.HoaDon(id),
)	
GO


SELECT * FROM dbo.HoaDon



--kiem tra đăng nhập

CREATE PROC usp_kiemtradangnhap
@userName NVARCHAR(100),
@pass NVARCHAR(100),
@result INT OUT
AS
BEGIN
	IF(EXISTS(SELECT * FROM dbo.thongtintaikhoan WHERE @userName=userName AND @pass=pass))
	BEGIN
		SET @result=1
		RETURN
	END
		SET @result=0

END
GO
DECLARE @result INT;
EXECUTE dbo.usp_kiemtradangnhap @userName = N'', -- nvarchar(100)
    @pass = N'', -- nvarchar(100)
    @result = @result OUTPUT -- int



CREATE PROC usp_kiemtraUserName
@userName NVARCHAR(100),
@result INT
AS
BEGIN
	IF(EXISTS(SELECT * FROM dbo.thongtintaikhoan WHERE @userName=userName ))
	BEGIN
		SET @result=1
		RETURN
	END
		SET @result=0

END
GO

CREATE PROC usp_tracuudangnhap

AS
BEGIN
	SELECT userName AS [Tài khoản] ,pass AS [Mật khẩu] FROM dbo.thongtintaikhoan 
END
GO

CREATE PROC usp_InserDangnhap
@userName VARCHAR(100),
@pass VARCHAR(100),
@idnhanvien INT,
@loaitaikhoan INT
AS
BEGIN
	INSERT dbo.thongtintaikhoan VALUES(@userName,@pass,@idnhanvien,@loaitaikhoan)
END
GO

CREATE PROC usp_updateAccount
@userName VARCHAR(100),
@pass NVARCHAR(100),
@newpass NVARCHAR(100)
AS
BEGIN
	DECLARE @count INT =1
	SELECT @count=COUNT(*) FROM dbo.thongtintaikhoan WHERE userName=@userName AND pass=@pass
	IF(@count=1)
	UPDATE dbo.thongtintaikhoan SET pass=@newpass WHERE userName=@userName AND pass=@pass
    
END
GO
EXEC dbo.usp_updateAccount @userName, @pass , @newpass 

SELECT * FROM dbo.thongtintaikhoan

ALTER TABLE dbo.thongtintaikhoan DROP COLUMN displayName 


SELECT * FROM dbo.thongtintaikhoan
GO

CREATE PROC usp_DoiMatkhau
@userName NVARCHAR(100), 
@pass NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.thongtintaikhoan SET pass=@pass WHERE userName=@userName
END
GO

CREATE PROC usp_xoataikhoan
@userName NVARCHAR(100), 
@pass NVARCHAR(100)
AS
BEGIN
	DELETE dbo.thongtintaikhoan  WHERE userName=@userName AND pass=@pass
END
GO


--fix
ALTER PROC usp_themhoadon
@idhoadon INT 
AS
BEGIN
	INSERT dbo.HoaDon
	        ( TG_NhanPhong ,
	          TG_TraPhong ,
	          TongTien ,
	          TrangThai ,
	          idkhachhang ,
	          userName
	        )
	VALUES  ( GETDATE() , -- NgayNhanPhong - date
	          GETDATE() , -- NgayTraPhong - date
	          30000 , -- TongTien - float
	          N'đã thanh toán' , -- TrangThai - nvarchar(100)
	          1 , -- idkhachhang - int
	          'M10'  -- userName - varchar(100)
	        )
	         
END 
GO
EXEC dbo.usp_themhoadon @idhoadon
SELECT MAX(id) FROM dbo.HoaDon

CREATE PROC usp_themCTHD
@idhoahon INT ,
@soluong INT
AS
BEGIN
	DECLARE @kiemtra INT
	SELECT @kiemtra=COUNT(id) FROM dbo.chitiethoadon WHERE idhoadon=@idhoahon

	DECLARE @soluongmoi INT
	SELECT @soluongmoi=@soluong +soluong FROM dbo.chitiethoadon WHERE idhoadon=@idhoahon
	IF(@kiemtra > 0)
	BEGIN
		IF(@soluongmoi >0)
			UPDATE dbo.chitiethoadon SET soluong=@soluongmoi WHERE idhoadon=@idhoahon
		ELSE
		BEGIN
			DELETE dbo.chitiethoadon WHERE idhoadon=@idhoahon
		END        
    END
	ELSE 
		IF(@soluongmoi >0)
			INSERT dbo.chitiethoadon
			        ( idhoadon ,
			          dongia ,
			          thanhtien ,
			          soluong
			        )
			VALUES  ( @idhoahon , -- idhoadon - int
			          200 , -- dongia - float
			          250 , -- thanhtien - float
			          @soluong  -- soluong - int
			        )

END
GO
SELECT * FROM dbo.HoaDon
--xóa hóa đơn
CREATE PROC usp_xoahoadon
AS
BEGIN
	DROP TABLE dbo.HoaDon
END
GO
--tính số hóa đơn by ngày
CREATE PROC StoredProcedure_laySoHoaDonDTT
@dateIn DATE, @dateOut DATE
AS
BEGIN
	SELECT COUNT(*)
	FROM dbo.HoaDon AS b, dbo.BanAn AS t
	WHERE b.ngayDen >= @dateIn AND b.ngayDen <= @dateOut AND b.trangThai = N'Đã thanh toán'
	AND t.idBanAn = b.idBanAn 
END
GO
--
CREATE PROC usp_tinhsohoadon
@DateIn DATETIME,
@DateOut DATETIME
AS
BEGIN
	SELECT COUNT(*) FROM dbo.HoaDon AS h, dbo.phieuthuephong AS p WHERE h.TG_nhanphong>=@DateIn AND h.TG_traphong<=@DateOut AND h.TrangThai='đã thanh toán'
	AND h.idphieuthuephong=p.id
END
GO
EXEC dbo.usp_tinhsohoadon @DateIn, @DateOut 

--sửa hóa đơn
--tìm hóa đơn chưa song 
CREATE PROC usp_timhoadon
@idhoadon INT OUT,
@idkhachhang INT ,
@username NVARCHAR(100)

AS
BEGIN
	SELECT @idhoadon=id FROM dbo.HoaDon WHERE userName=@username AND idkhachhang=@idkhachhang
	IF(@idhoadon>0)
		RETURN
	SET @idhoadon=0
END
GO
SELECT * FROM dbo.HoaDon
--tìm khách hàng
CREATE PROC usp_timkhachhang
@idKhachhang INT =0 OUTPUT,
@SoCMT INT ,
@hoten NVARCHAR(100)

AS
BEGIN
		
		SELECT @idKhachhang=idNKhachHang 
		 FROM dbo.khachhang
		 WHERE So_CMT=@SoCMT AND HoTen=@hoten 
		 IF(@idKhachhang>0)
		 RETURN
		 SET @idKhachhang=0
END
GO
--tính số nhân viên
CREATE PROC usp_tinhsonhanvien
AS
BEGIN 
	SELECT COUNT(*) FROM dbo.NhanVienQL
END
GO

--tính tổng doanh thu
CREATE PROC usp_tinhtongdoanhthu
AS
BEGIN	
		SELECT SUM(TongTien) FROM dbo.HoaDon WHERE TrangThai='đã thanh toán'
END
GO

CREATE PROC usp_updatehoadon
@idhoadon INT ,
@tongtien FLOAT, 
@trangthai NVARCHAR(100)
AS
BEGIN
	DECLARE @count INT =0
	SELECT @count=COUNT(*) FROM dbo.HoaDon WHERE id=@idhoadon  
	IF(@count>0)
	UPDATE dbo.HoaDon SET TG_TraPhong=GETDATE(), TongTien=@tongtien, TrangThai='chua thanh toan' WHERE id=@idhoadon
END
GO
EXEC dbo.usp_updatehoadon @idhoadon = 0,@tongtien = 0.0, @trangthai = N'' 




CREATE TRIGGER tg_update_hoadon
ON dbo.HoaDon
FOR UPDATE
AS
BEGIN
	DECLARE @idbill INT
	SELECT @idbill=Inserted.id FROM Inserted
	DECLARE @idphieuthuephong INT
	SELECT @idphieuthuephong=idphieuthuephong FROM dbo.HoaDon WHERE id=@idbill
	DECLARE @count INT =0 
	SELECT @count=COUNT(*) FROM dbo.HoaDon WHERE idphieuthuephong=@idphieuthuephong AND TrangThai='chưa thanh toán'
	IF(@count>0)
		UPDATE dbo.HoaDon SET TrangThai='trống'  WHERE idphieuthuephong=@idphieuthuephong 
END
GO
SELECT * FROM dbo.HoaDon
GO

CREATE TRIGGER tg_update_chitiethoadon
ON dbo.chitiethoadon
FOR UPDATE
AS
BEGIN
	DECLARE @idchitiethoadon INT 
	SELECT @idchitiethoadon=Inserted.id FROM Inserted
	DECLARE @idhoadon INT 
	SELECT @idhoadon=idhoadon FROM dbo.chitiethoadon WHERE id=@idchitiethoadon
	DECLARE @count INT =0 
	SELECT @count=COUNT(*) FROM dbo.chitiethoadon WHERE idhoadon=@idhoadon 
	IF(@count>0)
	
	DECLARE @idbill INT
	SELECT @idbill=MAX(id) FROM dbo.HoaDon
	INSERT dbo.chitiethoadon
	        ( idhoadon ,
	          dongia ,
	          thanhtien ,
	          soluong
	        )
	VALUES  (@idbill, -- idhoadon - int
	          0.0 , -- dongia - float
	          0.0 , -- thanhtien - float
	          0  -- soluong - int
	        )
END 
GO
SELECT * FROM dbo.chitiethoadon
  
GO

CREATE TRIGGER tg_deletehoadon 
	ON dbo.HoaDon 
	FOR DELETE
AS
BEGIN
	DECLARE @idphieuthuephong INT 
	SELECT @idphieuthuephong=Deleted.idphieuthuephong FROM Deleted
	UPDATE dbo.HoaDon SET TrangThai='chua thanh toán' WHERE idphieuthuephong=@idphieuthuephong

	IF (@idphieuthuephong IS NOT NULL)
	BEGIN 
		DECLARE @count INT 
		SELECT @count=COUNT(idphieuthuephong) FROM dbo.HoaDon WHERE idphieuthuephong=@idphieuthuephong
		IF(@count=0) 
		 INSERT dbo.HoaDon
		         ( NgayNhanPhong ,
		           NgayTraPhong ,
		           TongTien ,
		           TrangThai ,
		           idphieuthuephong ,
		           idkhachhang ,
		           userName
		         )
		 VALUES  ( GETDATE() , -- NgayNhanPhong - date
		           GETDATE() , -- NgayTraPhong - date
		           0.0 , -- TongTien - float
		           N'' , -- TrangThai - nvarchar(100)
		           @idphieuthuephong , -- idphieuthuephong - int
		           0 , -- idkhachhang - int
		           ''  -- userName - varchar(100)
		         )
			END
END 
GO
CREATE TRIGGER tg_insert_hoadon
ON dbo.HoaDon
FOR INSERT
AS
BEGIN
	DECLARE @idphieuthuephong INT
	SELECT @idphieuthuephong=Inserted.id FROM Inserted
	UPDATE dbo.HoaDon SET TrangThai='chưa thanh toán 'WHERE idphieuthuephong=@idphieuthuephong
	IF(@idphieuthuephong IS NOT NULL)
	BEGIN 
		DECLARE @count INT
		SELECT @count=COUNT(*) FROM dbo.HoaDon WHERE idphieuthuephong=@idphieuthuephong
		IF(@count=0)
			INSERT dbo.HoaDon
			        ( NgayNhanPhong ,
			          NgayTraPhong ,
			          TongTien ,
			          TrangThai ,
			          idphieuthuephong ,
			          idkhachhang ,
			          userName
			        )
			VALUES  ( GETDATE() , -- NgayNhanPhong - date
			          GETDATE() , -- NgayTraPhong - date
			          0.0 , -- TongTien - float
			          N'' , -- TrangThai - nvarchar(100)
			          @idphieuthuephong, -- idphieuthuephong - int
			          0 , -- idkhachhang - int
			          ''  -- userName - varchar(100)
			        )

END
GO


INSERT dbo.HoaDon
        (TG_NhanPhong ,
          TG_TraPhong ,
          TongTien ,
          TrangThai ,
          idphieuthuephong ,
          idkhachhang ,
          userName
        )
VALUES  ( GETDATE() , -- NgayNhanPhong - datetime
          GETDATE() , -- NgayTraPhong - datetime
          400000 , -- TongTien - float
          N'chua thanh toan' , -- TrangThai - nvarchar(100)
          2, -- idphieuthuephong - int
          1 , -- idkhachhang - int
          'admin'  -- userName - varchar(100)
        )

INSERT dbo.HoaDon
        (TG_NhanPhong ,
          TG_TraPhong ,
          TongTien ,
          TrangThai ,
          idphieuthuephong ,
          idkhachhang ,
          userName
        )
VALUES  ( GETDATE() , -- NgayNhanPhong - datetime
          GETDATE() , -- NgayTraPhong - datetime
          300000 , -- TongTien - float
          N'chua thanh toan' , -- TrangThai - nvarchar(100)
          2, -- idphieuthuephong - int
          2 , -- idkhachhang - int
          'M10'  -- userName - varchar(100)
        )

SELECT * FROM dbo.HoaDon
INSERT dbo.phieuthuephong
        ( idphong, ngay_bat_dau_thue )
VALUES  ( 2, -- idphong - int
          GETDATE()  -- ngay_bat_dau_thue - datetime
          )

INSERT dbo.phieuthuephong
        ( idphong, ngay_bat_dau_thue )
VALUES  ( 3, -- idphong - int
          GETDATE()  -- ngay_bat_dau_thue - datetime
          )

INSERT dbo.phieuthuephong
        ( idphong, ngay_bat_dau_thue )
VALUES  ( 4, -- idphong - int
          GETDATE()  -- ngay_bat_dau_thue - datetime
          )

SELECT * FROM dbo.phieuthuephong
GO

INSERT dbo.Phong
        (tenphong, loaiphong, dongia, trangthai )
VALUES  ( '101',
			N'Loại A', -- loaiphong - nchar(50)
          200000, -- dongia - float
          N'trống'  -- trangthai - nvarchar(100)
          )

INSERT dbo.Phong
        (tenphong, loaiphong, dongia, trangthai )
VALUES  ( '102',
			N'Loại A', -- loaiphong - nchar(50)
          200000, -- dongia - float
          N'trống'  -- trangthai - nvarchar(100)
          )
INSERT dbo.Phong
        (tenphong, loaiphong, dongia, trangthai )
VALUES  ( '103',
			N'Loại A', -- loaiphong - nchar(50)
          200000, -- dongia - float
          N'trống'  -- trangthai - nvarchar(100)
          )

INSERT dbo.Phong
        (tenphong, loaiphong, dongia, trangthai )
VALUES  ( '201',
			N'Loại B', -- loaiphong - nchar(50)
          300000, -- dongia - float
          N'trống'  -- trangthai - nvarchar(100)
          )
INSERT dbo.Phong
        (tenphong, loaiphong, dongia, trangthai )
VALUES  ( '202',
			N'Loại B', -- loaiphong - nchar(50)
          300000, -- dongia - float
          N'trống'  -- trangthai - nvarchar(100)
          )

SELECT * FROM dbo.Phong
GO

INSERT dbo.khachhang
        ( HoTen , NgaySinh , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'lê phú trọng ngân' , '08/08/1997'  , N'ktx khu b' , 016352486591 , 102356201 , N'Nội Địa')


INSERT dbo.khachhang
        ( HoTen , NgaySinh  , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'nguyễn văn trạng' , '05/01/1999' , N'dĩ an' , 0968579428 , 10234561 , N'Nội Địa')
INSERT dbo.khachhang
        ( HoTen , NgaySinh  , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'võ quốc vương' , CONVERT(DATETIME,23/08/1997) , N'ktx khu b' , 01679112233 , 11236201 , N'Nội Địa')
--chưa insert 
INSERT dbo.khachhang
        ( HoTen , NgaySinh ,QueQuan , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'nguyễn ngọc tường' , CONVERT(DATETIME,16/05/1996) ,  N'bến tre' , N'thủ đức' , 0907679678 , 102188201 , N'sinh viên')

INSERT dbo.khachhang
        ( HoTen , NgaySinh ,QueQuan , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'trần đức long' ,CONVERT(DATETIME, 30/06/1993 ),  N'vũng tàu' , N'quận 9' , 0971485216 , 102164798 , N'thường ')
INSERT dbo.khachhang
        ( HoTen , NgaySinh ,QueQuan , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'Nguyễn hữu cảnh' ,CONVERT(DATETIME, 02/06/1995 ),  N'Đồng Nai' , N'Biên Hòa' ,01635207592, 103412128 , N'Đại Gia ')
INSERT dbo.khachhang
        ( HoTen , NgaySinh ,QueQuan , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'Trần Thị Trang' ,CONVERT(DATETIME, 16/10/1990 ),  N'Long An' , N'Dĩ An-Bình Dương' , 0169784514 , 1029871457 , N'thường ')
INSERT dbo.khachhang
        ( HoTen , NgaySinh ,QueQuan , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'Doãn Chí Bình' ,CONVERT(DATETIME, 1/01/1991 ),  N'Sóc Trăng' , N'Quận 1' , 0123486579 , 104797218 , N'Đại Gia ')
INSERT dbo.khachhang
        ( HoTen , NgaySinh ,QueQuan , Diachi ,sdt , So_CMT , loaikhachhang )
VALUES  ( N'Ngô Thị Hải Yến' ,CONVERT(DATETIME, 23/08/1999 ),  N'vũng tàu' , N'quận 9' , 0971523156 , 102179842 , N'thường ')

SELECT * FROM dbo.khachhang
SELECT * FROM dbo.thongtintaikhoan
GO

SELECT DISTINCT *  FROM dbo.khachhang 
DELETE FROM dbo.khachhang WHERE idNKhachHang='2'

GO

INSERT dbo.NhanVienQL
        ( HoTen, NgaySinh, QueQuan, email, sdt )
VALUES  ( N'trần văn nhật', -- HoTen - nvarchar(100)
          CONVERT(DATETIME, 30/06/1989), -- NgaySinh - date
          N'gia lai', -- QueQuan - nvarchar(100)
          N'nhat12@gmail.com', -- email - nchar(50)
          0163524897 -- sdt - float
          )
SELECT * FROM dbo.NhanVienQL

GO


INSERT dbo.thongtintaikhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( 'admin', -- userName - varchar(100)
          'admin', -- pass - varchar(1000)
          1, -- idNhanVien - int
          0  
		  )
GO
SELECT * FROM dbo.chitiethoadon
INSERT dbo.thongtintaikhoan
        ( userName, pass, idNhanVien, loaiTK )
VALUES  ( 'M10', -- userName - varchar(100)
          '123', -- pass - varchar(1000)
          1, -- idNhanVien - int
          0  -- loaiTK - int
          )
 SELECT * FROM dbo.NhanVienQL         
SELECT * FROM dbo.thongtintaikhoan WHERE userName='admin' AND pass='admin'
 DECLARE @result INT;
 EXECUTE dbo.usp_kiemtradangnhap @userName = N'admin', -- nvarchar(100)
     @pass = N'admin', -- nvarchar(100)
     @result = @result OUTPUT -- int
go

SELECT * FROM dbo.Phong
SELECT * FROM dbo.thongtintaikhoan 
SELECT * FROM dbo.NhanVienQL
 SELECT * FROM dbo.HoaDon
  SELECT * FROM dbo.khachhang
  SELECT * FROM dbo.phieuthuephong
 
 
GO
Alter TABLE dbo.khachhang

alter COLUMN sdt NVARCHAR(100)
CREATE PROC usp_getuncheckbillidbyifRom
@id INT,
@trangthai NVARCHAR(100)
BEGIN
	SELECT * FROM dbo.HoaDon WHERE id=@id AND TrangThai='chưa thanh toán'
END
GO

SELECT * FROM dbo.HoaDon WHERE id=idphieuthuephong AND TrangThai='chua thanh toan'
--ALTER TABLE dbo.Phong ADD Tên Phòng NVARCHAR(100)
ALTER TABLE dbo.Phong DROP COLUMN[Tên Phòng]
SELECT idkhachhang FROM dbo.HoaDon

DELETE dbo.Phong 