CREATE DATABASE QLTN;
go
USE QLTN
go
CREATE TABLE QuanLy (
  username VARCHAR(255),
  password VARCHAR(255)
);
INSERT INTO QuanLy (username, password) VALUES ('admin1', '1234');
INSERT INTO QuanLy (username, password) VALUES ('admin2', '1234');
CREATE TABLE NguoiDung (
  username VARCHAR(255),
  password VARCHAR(255),
  HoTen VARCHAR(255),
  Email VARCHAR(255),
);
INSERT INTO NguoiDung (username, password, HoTen, Email) VALUES ('thisinh1', '123', 'nguyen van A', 'thisinh1@gmail.com');
INSERT INTO NguoiDung (username, password, HoTen, Email) VALUES ('thisinh2', '123', 'nguyen van B', 'thisinh2@gmail.com');
INSERT INTO NguoiDung (username, password, HoTen, Email) VALUES ('thisinh3', '123', 'nguyen van C', 'thisinh3@gmail.com');

CREATE TABLE cauhoi (
  ID int,
  CauHoi VARCHAR(255),
  CauA VARCHAR(255),
  CauB VARCHAR(255),
  CauC VARCHAR(255),
  CauD VARCHAR(255),
  DA VARCHAR(255)
);



INSERT INTO cauhoi (ID, CauHoi, CauA, CauB, CauC, CauD, DA) VALUES (1, '@CauHoi', '@cauA', '@cauB', '@cauC', '@cauD', '@DapAn')
select * from NguoiDung
select * from cauhoi
select max(ID) from cauhoi
select * from QuanLy
create table CauTraLoi 
(
  
)