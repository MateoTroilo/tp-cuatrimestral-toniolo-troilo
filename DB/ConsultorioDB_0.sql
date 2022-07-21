create database ConsultorioDB

use ConsultorioDB

create table ObrasSociales(
	IDObraSocial int not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Cobertura int null
)

create table Pacientes(
	IDPaciente int not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	DNI varchar(8) not null unique,
	FechaNacimiento datetime not null,
	Sexo varchar(20) null,
	Email varchar(50) not null unique,
	IDObraSocial int null foreign key references ObrasSociales(IDObraSocial),
)

create table Especialidades(
	IDEspecialidad int not null primary key identity (1, 1),
	Nombre varchar(120) not null
)

create table Medicos(
	IDMedico int not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	DNI varchar(8) not null unique,
	FechaNacimiento datetime not null,
	Sexo varchar(20) null,
	Email varchar(50) not null unique,
	HorarioInicio int not null,
	HorarioFin int not null
)

Create Table Especialidades_x_Medico(
    IDEspecialidad int not null foreign key references Especialidades(IDEspecialidad),
    IDMedico int not null foreign key references Medicos(IDMedico),
    primary key (IDEspecialidad, IDMedico)
)

create table Turnos(
	IDTurno int not null primary key identity (1, 1),
	Fecha datetime not null,
	Estado varchar(50) null,
	IDPaciente int not null foreign key references Pacientes(IDPaciente),
	IDMedico int not null foreign key references Medicos(IDMedico),
    IDEspecialidad int not null foreign key references Especialidades(IDEspecialidad),
	Observaciones text null,
)

create table Permisos(
	IDPermiso int not null primary key identity (1, 1),
	Nombre varchar(100) not null
)

create table Dias(
	IDDia int not null primary key identity (1, 1),
	Nombre varchar(100) not null
)

Create Table Dias_x_Medico(
    IDDia int not null foreign key references Dias(IDDia),
    IDMedico int not null foreign key references Medicos(IDMedico),
    primary key (IDDia, IDMedico)
)

create table Usuarios(
	IDUsuario int not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	DNI varchar(8) not null unique,
	FechaNacimiento datetime not null,
	Sexo varchar(20) null,
	Email varchar(50) not null unique,
	IDPermiso int not null foreign key references Permisos(IDPermiso)
)

----------------------

insert into Dias (Nombre) values ('Lunes');
insert into Dias (Nombre) values ('Martes');
insert into Dias (Nombre) values ('Miercoles');
insert into Dias (Nombre) values ('Jueves');
insert into Dias (Nombre) values ('Viernes');
insert into Dias (Nombre) values ('Sabado');

--------------------

insert into Permisos (Nombre) values ('Usuario');
insert into Permisos (Nombre) values ('Admin');
insert into Permisos (Nombre) values ('Medico');

--------------------

insert into ObrasSociales (Nombre, Cobertura) values ('Sub-Ex', 86);
insert into ObrasSociales (Nombre, Cobertura) values ('Subin', 37);
insert into ObrasSociales (Nombre, Cobertura) values ('Sonsing', 95);
insert into ObrasSociales (Nombre, Cobertura) values ('Cardguard', 86);
insert into ObrasSociales (Nombre, Cobertura) values ('Treeflex', 46);
insert into ObrasSociales (Nombre, Cobertura) values ('Bamity', 40);
insert into ObrasSociales (Nombre, Cobertura) values ('Alpha', 80);
insert into ObrasSociales (Nombre, Cobertura) values ('Veribet', 47);
insert into ObrasSociales (Nombre, Cobertura) values ('Sonair', 32);
insert into ObrasSociales (Nombre, Cobertura) values ('Opela', 70);

----------------------

insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Lotstring', 'Normant', 46194267, '01/07/2021', 'Female', 'gnormant0@1688.com', 3);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Cardguard', 'Boyack', 60872002, '01/06/2022', 'Male', 'cboyack1@sohu.com', 1);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Fintone', 'Bottomley', 42083187, '06/01/2022', 'Female', 'mbottomley2@dailymail.co.uk', 9);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Otcom', 'Loreit', 52071613, '01/05/2022', 'Female', 'dloreit3@discuz.net', 1);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Latlux', 'Bogart', 63198898, '05/01/2022', 'Female', 'pbogart4@instagram.com', 7);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Daltfresh', 'O'' Mahony', 97273986, '01/08/2021', 'Genderqueer', 'komahony5@yahoo.co.jp', 2);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Home Ing', 'Woodcroft', 57535582, '04/09/2021', 'Female', 'fwoodcroft6@epa.gov', 4);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Flowdesk', 'Frostdicke', 57345441, '01/06/2022', 'Male', 'efrostdicke7@a8.net', 7);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Konklab', 'Drohun', 11536964, '01/07/2021', 'Female', 'cdrohun8@vkontakte.ru', 2);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDObraSocial) values ('Duobam', 'Mulvey', 54034432, '01/10/2021', 'Female', 'wmulvey9@yolasite.com', 8);

----------------------

insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Bigtax', 'Cradick', 47297626, '07/12/2021', 'Female', 'scradick0@tmall.com', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Voltsillam', 'Abbey', 50397139, '01/08/2021', 'Male', 'jabbey1@xrea.com', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Stronghold', 'Jakobssen', 44027814, '01/10/2021', 'Bigender', 'tjakobssen2@pcworld.com', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Alpha', 'MacConnel', 11512795, '01/01/2022', 'Female', 'mmacconnel3@harvard.edu', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Tresom', 'McGragh', 91569473, '01/10/2021', 'Male', 'cmcgragh4@wikia.com', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Toughjoyfax', 'Svanetti', 61151141, '01/10/2021', 'Male', 'csvanetti5@google.fr', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Bitchip', 'Baines', 15625737, '02/09/2021', 'Male', 'jbaines6@myspace.com', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Span', 'Valerius', 94035024, '01/11/2021', 'Female', 'zvalerius7@lycos.com', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Sub-Ex', 'Bayne', 42601729, '01/11/2021', 'Male', 'fbayne8@vinaora.com', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Latlux', 'Sandercock', 11731579, '01/08/2021', 'Agender', 'asandercock9@pbs.org', 2);

----------------------

insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Vagram', 'Nardi', 71416958, '03/04/2022', 'Male', 'fnardi0@yahoo.com', '7', '19');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Regrant', 'Lints', 15433965, '08/03/2022', 'Female', 'clints1@goodreads.com', '10', '18');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('It', 'Gudyer', 73490711, '01/12/2021', 'Female', 'wgudyer2@t-online.de', '7', '12');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Asoka', 'Ruben', 60009209, '01/11/2021', 'Male', 'aruben3@so-net.ne.jp', '16', '17');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Fixflex', 'Clampin', 70161783, '12/08/2021', 'Male', 'fclampin4@multiply.com', '14', '20');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Asoka', 'Askham', 73330243, '01/10/2021', 'Male', 'daskham5@ucoz.ru', '12', '15');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Veribet', 'Kittel', 17604322, '01/08/2021', 'Female', 'bkittel6@columbia.edu', '11', '15');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Zathin', 'Snepp', 82201194, '01/09/2021', 'Genderqueer', 'lsnepp7@mysql.com', '10', '14');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Y-Solowarm', 'Macias', 86370664, '01/06/2022', 'Male', 'dmacias8@51.la', '8', '20');
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, HorarioInicio, HorarioFin) values ('Keylex', 'Boolsen', 14719697, '01/11/2021', 'Male', 'mboolsen9@mapy.cz', '16', '20');

----------------------

insert into Especialidades (Nombre) values ('Alergista');
insert into Especialidades (Nombre) values ('Cardiólogo');
insert into Especialidades (Nombre) values ('Dermatólogo');
insert into Especialidades (Nombre) values ('Cirujano');
insert into Especialidades (Nombre) values ('Infectólogo');
insert into Especialidades (Nombre) values ('Endocrinólogo');
insert into Especialidades (Nombre) values ('Pediatra');
insert into Especialidades (Nombre) values ('Traumatólogo');
insert into Especialidades (Nombre) values ('Urólogo');
insert into Especialidades (Nombre) values ('Oftalmólogo');

----------------------

insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (1, 1);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (5, 1);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (3, 1);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (7, 3);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (7, 4);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (9, 3);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (4, 8);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (5, 2);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (3, 7);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (5, 7);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (7, 7);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 1);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 2);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 3);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 4);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 5);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 6);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 7);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 8);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 9);
insert into Especialidades_x_Medico (IDEspecialidad, IDMedico) values (10, 10);

----------------------

insert into Dias_x_Medico (IDDia, IDMedico) values (4, 2);
insert into Dias_x_Medico (IDDia, IDMedico) values (5, 2);
insert into Dias_x_Medico (IDDia, IDMedico) values (2, 1);
insert into Dias_x_Medico (IDDia, IDMedico) values (3, 7);
insert into Dias_x_Medico (IDDia, IDMedico) values (5, 3);
insert into Dias_x_Medico (IDDia, IDMedico) values (1, 4);
insert into Dias_x_Medico (IDDia, IDMedico) values (2, 8);
insert into Dias_x_Medico (IDDia, IDMedico) values (4, 9);
insert into Dias_x_Medico (IDDia, IDMedico) values (5, 6);
insert into Dias_x_Medico (IDDia, IDMedico) values (3, 8);
insert into Dias_x_Medico (IDDia, IDMedico) values (3, 5);
insert into Dias_x_Medico (IDDia, IDMedico) values (5, 7);
insert into Dias_x_Medico (IDDia, IDMedico) values (1, 10);

----------------------

insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('10/30/2022 10:00.000', 0, 8, 3, 10, 'Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus. Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('11/25/2022 11:00.000', 1, 9, 7, 10, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('5/11/2022', 2, 5, 7, 10, 'Morbi vestibulum, velit id pretium iaculis, diam erat fermentum justo, nec condimentum neque sapien placerat ante. Nulla justo.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('7/9/2022', 3, 5, 7, 10, 'Nunc rhoncus dui vel sem. Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('6/27/2022', 0, 9, 3, 10, 'Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('7/28/2022  12:00.000', 1, 5, 7, 10, 'Aliquam non mauris. Morbi non lectus. Aliquam sit amet diam in magna bibendum imperdiet. Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('4/20/2022', 2, 9, 3, 10, 'In quis justo. Maecenas rhoncus aliquam lacus. Morbi quis tortor id nulla ultrices aliquet. Maecenas leo odio, condimentum id, luctus nec, molestie sed, justo.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('7/7/2022', 3, 9, 4, 10, 'Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('10/1/2022  14:00.000', 0, 6, 7, 10, 'Nunc purus. Phasellus in felis. Donec semper sapien a libero. Nam dui. Proin leo odio, porttitor id, consequat in, consequat ut, nulla.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, IDEspecialidad, Observaciones) values ('3/15/2022', 1, 1, 3, 10, 'Nulla tempus. Vivamus in felis eu sapien cursus vestibulum. Proin eu mi. Nulla ac enim.');

---------------------


