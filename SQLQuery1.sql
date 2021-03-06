create Table CadastroUsuario(
Id Uniqueidentifier not null,
Nome Nvarchar (150)not null,
Email Nvarchar(150) unique not null,
Senhar Nvarchar not null, 
DataCadastro Date not null,
DataAlteração Date not null,
primary key(Id))
GO