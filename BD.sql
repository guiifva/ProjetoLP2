CREATE TABLE [Usuarios](
[usuarioId] INT PRIMARY KEY IDENTITY,
[senha] VARCHAR(50),
[login] VARCHAR(20),
[nome] VARCHAR(30),
[permissao] VARCHAR(10)
);

CREATE TABLE Categorias (
categoriaId INT PRIMARY KEY IDENTITY,
nome VARCHAR(25),
ticketId INT
);

CREATE TABLE Ticket (
[data] DATETIME,
[descricao] VARCHAR(100),
[prioridade] VARCHAR(20),
[status] VARCHAR(20),
[printscreen] VARCHAR(255),
[ticketId] INT PRIMARY KEY IDENTITY
);

CREATE TABLE Testes (
[testeId] INT PRIMARY KEY IDENTITY,
[indiceDeSucesso] DECIMAL(10),
[tipoDeTeste] VARCHAR(25),
[data] DATETIME,
[descricao] VARCHAR(100)
);

CREATE TABLE Solicita (
user_id INT CONSTRAINT FK_user FOREIGN KEY REFERENCES Usuarios(usuarioId),
ticket_id INT CONSTRAINT FK_ticket FOREIGN KEY REFERENCES Ticket(ticketId)
);

CREATE TABLE Resolve (
funcionario_id INT CONSTRAINT FK_Funcionario FOREIGN KEY REFERENCES Usuarios(usuarioId),
ticket_id INT CONSTRAINT FK_TicketResolvido FOREIGN KEY REFERENCES Ticket(ticketId)
);

CREATE TABLE Relatam (
teste_id INT CONSTRAINT FK_TesteId FOREIGN KEY REFERENCES Testes(testeId),
funcionario_id INT CONSTRAINT FK_Usuario FOREIGN KEY REFERENCES Usuarios(usuarioId)
);

ALTER TABLE [dbo].[Categorias] WITH CHECK ADD CONSTRAINT [FK_TicketIdCategorias] FOREIGN KEY ([ticketId]) REFERENCES [dbo].[Ticket] ([ticketId]);
