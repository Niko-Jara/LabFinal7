Create database Fondos2;
use Fondos2;

create table Pais
(
idPais int identity(1,1) primary key,
DescPais varchar(45) not null
);
Create table Idiomas
(
idIdioma int  identity(1,1) primary key,
DescIdioma varchar(45) not null
);
Create table GestionPrestamos
(
idprestamo int identity (1,1) primary key,
Habitantes int not null,
PIB decimal(10,5) not null,
Superficie int not null,
Riesgo varchar(10) not null,
Prestamo bit not null,
idPais int not null,
idIdioma int not null,

Constraint Fk_GestionPrestamos_Pais Foreign key (idPais) References Pais(idPais),
Constraint Fk_GestionPrestamos_Idiomas Foreign key (idIdioma) References Idiomas(idIdioma),
);

USE [Fondos]
GO

SELECT [idprestamo]
      ,[Habitantes]
      ,[PIB]
      ,[Superficie]
      ,[Riesgo]
      ,[Prestamo]
      ,[DescPais]
      ,[DescIdioma]
  FROM [dbo].[GestionPrestamos] gt
  JOIN Pais ON  Pais.idPais = gt.idPais
  JOIN Idiomas On Idiomas.idIdioma = gt.idIdioma
GO

INSERT INTO [dbo].[Idiomas]
           ([DescIdioma])
     VALUES
           ('Español');
GO

INSERT INTO [dbo].[Idiomas]
           ([DescIdioma])
     VALUES
           ('Ingles');
GO

INSERT INTO [dbo].[Idiomas]
           ([DescIdioma])
     VALUES
           ('Aleman');


INSERT INTO [dbo].[Pais]
           ([DescPais])
     VALUES
           ('Costa Rica');
GO

INSERT INTO [dbo].[Pais]
           ([DescPais])
     VALUES
           ('Korea');
GO

INSERT INTO [dbo].[Pais]
           ([DescPais])
     VALUES
           ('USA');
GO















