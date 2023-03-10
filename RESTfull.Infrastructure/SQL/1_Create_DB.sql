-- *** CREATE new migration ***
-- Add-Migration InitialCreate
-- Update-Database

DROP DATABASE [RESTFull]
GO

CREATE DATABASE [RESTFull]
 CONTAINMENT = NONE
 ON PRIMARY 
( NAME = N'RESTFull', FILENAME = N'C:\Labs\OOP\Lab-2\DB\RESTFull.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RESTFull_log', FILENAME = N'C:\Labs\OOP\Lab-2\DB\RESTFull_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
