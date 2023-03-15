USE master
GO

CREATE DATABASE HospitalManagementDB
GO

USE HospitalManagementDB
GO

CREATE TABLE StaffAccount 
(
 HRAccountId nvarchar(50) PRIMARY KEY,
 HRFullname nvarchar(50) NOT NULL,
 HREmail nvarchar(50) NOT NULL, 
 HRPassword nvarchar(50), 
 StaffRole int
);
GO

INSERT INTO StaffAccount VALUES ('SA0001', 'Hospital Admin', 'HospitalAdmin@AbcHospital.gov','abc',0);
INSERT INTO StaffAccount VALUES ('SA0002', 'Ralph Chen', 'RalphChen@AbcHospital.gov','123',1);
INSERT INTO StaffAccount VALUES ('SA0003', 'Dominic Magnus', 'DominicMagnus@AbcHospital.gov','123@abc',2);
GO

CREATE TABLE Department(
  DepartmentId int PRIMARY KEY,
  DepartmentName nvarchar(120) NOT NULL,
  DepartmentLocation nvarchar(250), 
  TelephoneNumber nvarchar(20), 
  ShortDescription nvarchar(250)
)
GO

INSERT INTO Department VALUES (9610, 'Emergency Department', 'Block H, Building A, Room 122, Floor 2','880903914555','Emergency Department');
INSERT INTO Department VALUES (9611, 'Otorhinolaryngology', 'Block H, Building A, Room 455 Floor 4','880903914666','Otorhinolaryngology');
INSERT INTO Department VALUES (9612, 'Department of Gastroenterology', 'Tower K, Building M, Room 2342 Floor 23','880903914777','Department of Gastroenterology');
INSERT INTO Department VALUES (9613, 'Cardiology Department', 'Tower J, Building M, Room 459 Floor 4','880903914444','Cardiology Department');
INSERT INTO Department VALUES (9614, 'Department of Gastroenterology', 'Room 1233 Floor 12, Building M','880903914888','Department of Gastroenterology');
INSERT INTO Department VALUES (9615, 'Ophthalmology', 'Room 123 Floor 12, Building M, Block A','880903919999','Ophthalmology Department');
GO

CREATE TABLE DoctorInformation(
 DoctorID nvarchar(20) PRIMARY KEY,
 DoctorName nvarchar(100) NOT NULL,
 Birthday Datetime NOT NULL,
 Email nvarchar(250) NOT NULL,
 DoctorAddress nvarchar(200),
 GraduationYear int, 
 DoctorLicenseNumber nvarchar(25), 
 DepartmentID int REFERENCES Department(DepartmentID ) ON DELETE CASCADE ON UPDATE CASCADE)
GO

INSERT INTO DoctorInformation VALUES (N'DOC0001',N'Corbin Beckham',CAST(N'1990-09-01' AS DateTime), N'CorbinBeckham@AbcHospital.gov',N'Paris, France', 2015, N'VNBS011022033', 9615);
INSERT INTO DoctorInformation VALUES (N'DOC0002',N'Otis Saint',CAST(N'1988-05-01' AS DateTime), N'OtisSaint@AbcHospital.gov',N'Paris, France', 2010, N'VNBS011022997', 9615);
INSERT INTO DoctorInformation VALUES (N'DOC0004',N'Amory Patrick',CAST(N'1986-08-01' AS DateTime), N'AmoryPatrick@AbcHospital.gov',N'Vienna, Austria', 2008, N'VNBS011021228', 9615);
INSERT INTO DoctorInformation VALUES (N'DOC0007',N'Dalziel Leighton',CAST(N'1991-10-01' AS DateTime), N'DalzielLeighton@AbcHospital.gov',N'Vienna, Austria', 2016, N'VNBS011029877', 9615);
INSERT INTO DoctorInformation VALUES (N'DOC0009',N'Michael John',CAST(N'1992-07-01' AS DateTime), N'MichaelJohn@AbcHospital.gov',N'Berlin, Germany', 2013, N'VNBS011026223', 9615);
INSERT INTO DoctorInformation VALUES (N'DOC0229',N'Engelbert Orson',CAST(N'1992-08-01' AS DateTime), N'EngelbertOrson@AbcHospital.gov',N'Oslo, Norway', 2013, N'VNBS011026223', 9615);
INSERT INTO DoctorInformation VALUES (N'DOC0449',N'Stephan Halk',CAST(N'1992-09-01' AS DateTime), N'StephanHalk@AbcHospital.gov',N'Moskow, Russia', 2013, N'VNBS011026223', 9615);
GO

INSERT INTO DoctorInformation VALUES (N'DOC0010',N'Alexander Leo',CAST(N'1992-07-01' AS DateTime), N'AlexanderLeo@AbcHospital.gov',N'Berlin, Germany', 2013, N'VNBS011026223', 9614);
INSERT INTO DoctorInformation VALUES (N'DOC0012',N'Athelstan Leo',CAST(N'1988-05-01' AS DateTime), N'AthelstanDelvin@AbcHospital.gov',N'Paris, France', 2010, N'VNBS011022997', 9613);
INSERT INTO DoctorInformation VALUES (N'DOC0014',N'Joyce Randolph',CAST(N'1986-08-01' AS DateTime), N'JoyceRandolph@AbcHospital.gov',N'Vienna, Austria', 2008, N'VNBS011021228', 9612);
INSERT INTO DoctorInformation VALUES (N'DOC0017',N'Kenelm Maynard',CAST(N'1991-10-01' AS DateTime), N'KenelmMaynard@AbcHospital.gov',N'Vienna, Austria', 2016, N'VNBS011029877', 9612);
GO