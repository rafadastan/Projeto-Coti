create table Empresa(
	IdEmpresa		uniqueidentifier	not null,
	RazaoSocial		nvarchar(150)		not null,
	Cnpj			nvarchar(20)		not null,
	primary key(IdEmpresa))
go

create table Funcionario(
	IdFuncionario	uniqueidentifier	not null,
	Nome			nvarchar(150)		not null,
	Matricula		nvarchar(10)		not null,
	Cpf				nvarchar(11)		not null,
	DataAdmissao	date				not null,
	IdEmpresa		uniqueidentifier	not null,
	primary key(IdFuncionario),
	foreign key(IdEmpresa) references Empresa(IdEmpresa))
go

