# TechChallenge.API

## Imagem do SQL Server usada para rodar o banco no Docker Desktop

mcr.microsoft.com/mssql/server:2022-latest

## Environment Variables do container do Docker
```bash
ACCEPT_EULA=Y
SA_PASSWORD=AquiVaiSuaSenhaForte
```

## Script para criar a tabela dbo.Contact

```sql
USE [TechChallenge]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[Region] [nvarchar](max) NOT NULL,
	[District] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```

## Inserts para popular o banco

```sql
INSERT INTO dbo.Contact(Id, Name, Email, PhoneNumber, Region, District)
VALUES
    (NEWID(), 'John Doe', 'john.doe@email.com', 47999999999, 'SC', '47'),
    (NEWID(), 'Jane Smith', 'jane.smith@email.com', 47988888888, 'SC', '47'),
    (NEWID(), 'Carlos Silva', 'carlos.silva@email.com', 47977777777, 'PR', '41'),
    (NEWID(), 'Maria Souza', 'maria.souza@email.com', 47966666666, 'PR', '41'),
    (NEWID(), 'Pedro Oliveira', 'pedro.oliveira@email.com', 47955555555, 'RS', '51'),
    (NEWID(), 'Lucas Pereira', 'lucas.pereira@email.com', 47944444444, 'RS', '51'),
    (NEWID(), 'Fernanda Costa', 'fernanda.costa@email.com', 47933333333, 'SP', '11'),
    (NEWID(), 'Roberto Lima', 'roberto.lima@email.com', 47922222222, 'SP', '11'),
    (NEWID(), 'Amanda Rocha', 'amanda.rocha@email.com', 47911111111, 'MG', '31'),
    (NEWID(), 'Ricardo Mendes', 'ricardo.mendes@email.com', 47900000000, 'MG', '31'),
    (NEWID(), 'Paula Oliveira', 'paula.oliveira@email.com', 47999999900, 'RJ', '21'),
    (NEWID(), 'Gabriel Costa', 'gabriel.costa@email.com', 47988888800, 'RJ', '21'),
    (NEWID(), 'Juliana Martins', 'juliana.martins@email.com', 47977777700, 'BA', '71'),
    (NEWID(), 'Felipe Lima', 'felipe.lima@email.com', 47966666600, 'BA', '71'),
    (NEWID(), 'Juliana Santos', 'juliana.santos@email.com', 47955555500, 'PE', '81'),
    (NEWID(), 'Victor Almeida', 'victor.almeida@email.com', 47944444400, 'PE', '81'),
    (NEWID(), 'Tatiane Ferreira', 'tatiane.ferreira@email.com', 47933333300, 'CE', '85'),
    (NEWID(), 'Matheus Almeida', 'matheus.almeida@email.com', 47922222200, 'CE', '85'),
    (NEWID(), 'Renata Costa', 'renata.costa@email.com', 47911111100, 'GO', '62'),
    (NEWID(), 'Marcos Rocha', 'marcos.rocha@email.com', 47900000000, 'GO', '62'),
    (NEWID(), 'Carla Souza', 'carla.souza@email.com', 47899999999, 'DF', '61'),
    (NEWID(), 'Bruno Silva', 'bruno.silva@email.com', 47888888888, 'DF', '61'),
    (NEWID(), 'Andreia Costa', 'andreia.costa@email.com', 47877777777, 'ES', '27'),
    (NEWID(), 'Douglas Pereira', 'douglas.pereira@email.com', 47866666666, 'ES', '27'),
    (NEWID(), 'Amanda Santos', 'amanda.santos@email.com', 47855555555, 'AL', '82'),
    (NEWID(), 'João Lima', 'joao.lima@email.com', 47844444444, 'AL', '82'),
    (NEWID(), 'Lúcia Mendes', 'lucia.mendes@email.com', 47833333333, 'SE', '79'),
    (NEWID(), 'José Costa', 'jose.costa@email.com', 47822222222, 'SE', '79'),
    (NEWID(), 'Daniela Silva', 'daniela.silva@email.com', 47811111111, 'RN', '84'),
    (NEWID(), 'Ricardo Martins', 'ricardo.martins@email.com', 47800000000, 'RN', '84'),
    (NEWID(), 'Amanda Almeida', 'amanda.almeida@email.com', 47799999999, 'PI', '86'),
    (NEWID(), 'Felipe Rocha', 'felipe.rocha@email.com', 47788888888, 'PI', '86'),
    (NEWID(), 'Cláudia Souza', 'claudia.souza@email.com', 47777777777, 'MA', '98'),
    (NEWID(), 'Sergio Costa', 'sergio.costa@email.com', 47766666666, 'MA', '98'),
    (NEWID(), 'Tatiane Silva', 'tatiane.silva@email.com', 47755555555, 'MT', '65'),
    (NEWID(), 'Gustavo Pereira', 'gustavo.pereira@email.com', 47744444444, 'MT', '65'),
    (NEWID(), 'Luana Rocha', 'luana.rocha@email.com', 47733333333, 'RO', '69'),
    (NEWID(), 'Júlia Almeida', 'julia.almeida@email.com', 47722222222, 'RO', '69'),
    (NEWID(), 'Marcelo Santos', 'marcelo.santos@email.com', 47711111111, 'AC', '68'),
    (NEWID(), 'Vanessa Lima', 'vanessa.lima@email.com', 47700000000, 'AC', '68'),
    (NEWID(), 'Sabrina Costa', 'sabrina.costa@email.com', 47699999999, 'AP', '96'),
    (NEWID(), 'Roberto Pereira', 'roberto.pereira@email.com', 47688888888, 'AP', '96'),
    (NEWID(), 'Eduardo Martins', 'eduardo.martins@email.com', 47677777777, 'TO', '63'),
    (NEWID(), 'Amanda Rocha', 'amanda.rocha@email.com', 47666666666, 'TO', '63'),
    (NEWID(), 'Gabriel Oliveira', 'gabriel.oliveira@email.com', 47655555555, 'PB', '83'),
    (NEWID(), 'Lucas Lima', 'lucas.lima@email.com', 47644444444, 'PB', '83'),
    (NEWID(), 'Julia Costa', 'julia.costa@email.com', 47633333333, 'BA', '73'),
    (NEWID(), 'Daniel Silva', 'daniel.silva@email.com', 47622222222, 'BA', '73'),
    (NEWID(), 'Thiago Ferreira', 'thiago.ferreira@email.com', 47611111111, 'PE', '85'),
    (NEWID(), 'Fernando Rocha', 'fernando.rocha@email.com', 47600000000, 'PE', '85'),
    (NEWID(), 'Priscila Lima', 'priscila.lima@email.com', 47599999999, 'SP', '19');
```
