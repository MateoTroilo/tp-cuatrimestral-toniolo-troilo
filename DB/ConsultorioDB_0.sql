create database ConsultorioDB

use ConsultorioDB

create table ObrasSociales(
	IDObraSocial bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
)

create table Planes(
	IDPlan bigint not null primary key identity (1, 1),
	IDObraSocial bigint not null foreign key references ObrasSociales(IDObraSocial),
	Nombre varchar(100) not null,
	PorcentajeCobertura int not null check(PorcentajeCobertura between 0 and 100)
)

create table Pacientes(
	IDPaciente bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	DNI varchar(8) not null unique,
	FechaNacimiento datetime not null,
	Sexo char null,
	Email varchar(50) not null unique,
	IDPlan bigint null foreign key references Planes(IDPlan),
)

create table Especialidades(
	IDEspecialidad bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null
)

create table Medicos(
	IDMedico bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	DNI varchar(8) not null unique,
	FechaNacimiento datetime not null,
	Sexo char null,
	Email varchar(50) not null unique,
	IDEspecialidad bigint not null foreign key references Especialidades(IDEspecialidad)
)

create table Turnos(
	IDTurno bigint not null primary key identity (1, 1),
	Fecha datetime not null,
	Estado varchar(50) null,
	IDPaciente bigint not null foreign key references Pacientes(IDPaciente),
	IDMedico bigint not null foreign key references Medicos(IDMedico),
	Observaciones text null,
)

create table Permisos(
	IDPermiso bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
)

create table Usuarios(
	IDUsuario bigint not null primary key identity (1, 1),
	Nombre varchar(100) not null,
	Apellido varchar(100) not null,
	DNI varchar(8) not null unique,
	FechaNacimiento datetime not null,
	Sexo char null,
	Email varchar(50) not null unique,
	IDPermiso bigint not null foreign key references Permisos(IDPermiso)
)

----------------------


insert into ObrasSociales (Nombre) values ('Pharmaceutical Associates, Inc.');
insert into ObrasSociales (Nombre) values ('Allure Labs, Inc.');
insert into ObrasSociales (Nombre) values ('Aidarex Pharmaceuticals LLC');
insert into ObrasSociales (Nombre) values ('UDL Laboratories, Inc.');
insert into ObrasSociales (Nombre) values ('ALK-Abello, Inc.');
insert into ObrasSociales (Nombre) values ('McKesson Packaging Services a business unit of McKesson Corporation');
insert into ObrasSociales (Nombre) values ('Imagenetix');
insert into ObrasSociales (Nombre) values ('BluePoint Laboratories');
insert into ObrasSociales (Nombre) values ('Ballay Pharmaceuticals, Inc');
insert into ObrasSociales (Nombre) values ('Carilion Materials Management');

-----------------

insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (9, 'Pain Reliever', 92);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (5, 'ESIKA', 88);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (4, 'Librium', 31);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (4, 'Ranitidine', 69);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (8, 'BC Arthritis', 87);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (1, 'Quik Wipes', 67);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (3, 'LIFT LUMIERE', 57);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (8, 'Red Kidney Beans', 42);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (3, 'METHYLERGONOVINE MALEATE', 58);
insert into Planes (IDObraSocial, Nombre, PorcentajeCobertura) values (4, 'SYNTHROID', 54);

--------------------

insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Sherri', 'Bater', 12501924, '2022-02-15', 'F', 'sbater0@slashdot.org', 6);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Violante', 'Renforth', 81043574, '2022-02-04', 'F', 'vrenforth1@4shared.com', 7);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Judah', 'Astley', 23818034, '2021-09-22', 'M', 'jastley2@people.com.cn', 7);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Hugh', 'Drescher', 69454463, '2021-06-21', 'M', 'hdrescher3@springer.com', 2);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Cindelyn', 'Snar', 89200396, '2021-07-21', 'F', 'csnar4@jimdo.com', 7);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Siana', 'Shivell', 44039695, '2022-03-11', 'F', 'sshivell5@amazonaws.com', 10);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Anjanette', 'Adame', 36375239, '2021-06-22', 'F', 'aadame6@slideshare.net', 1);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Karena', 'Marien', 54329488, '2022-03-17', 'F', 'kmarien7@mtv.com', 9);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Dewie', 'Martignoni', 46470238, '2022-03-01', 'M', 'dmartignoni8@newyorker.com', 9);
insert into Pacientes (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPlan) values ('Karim', 'MacGarrity', 31857910, '2022-05-25', 'M', 'kmacgarrity9@wordpress.org', 10);

------------------

insert into Especialidades (Nombre) values ('Operator');
insert into Especialidades (Nombre) values ('Financial Analyst');
insert into Especialidades (Nombre) values ('Marketing Assistant');
insert into Especialidades (Nombre) values ('Statistician IV');
insert into Especialidades (Nombre) values ('Environmental Tech');
insert into Especialidades (Nombre) values ('Help Desk Technician');
insert into Especialidades (Nombre) values ('Web Designer II');
insert into Especialidades (Nombre) values ('Systems Administrator IV');
insert into Especialidades (Nombre) values ('Nurse');
insert into Especialidades (Nombre) values ('Research Nurse');

-------------------

insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Irita', 'Blow', 52316241, '2021-06-16', 'F', 'iblow0@printfriendly.com', 4);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Starr', 'Collyns', 82547589, '2022-03-16', 'F', 'scollyns1@weather.com', 4);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Clement', 'Taplin', 98297625, '2022-04-19', 'M', 'ctaplin2@yellowbook.com', 8);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Anastasie', 'Wafer', 48461783, '2021-08-08', 'F', 'awafer3@dailymail.co.uk', 6);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Culley', 'Toseland', 46392827, '2021-07-19', 'M', 'ctoseland4@soup.io', 2);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Margie', 'Putnam', 71449527, '2021-06-26', 'F', 'mputnam5@ft.com', 8);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Alie', 'Canario', 46268655, '2021-11-18', 'F', 'acanario6@foxnews.com', 6);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Lelia', 'Cool', 22726676, '2021-10-16', 'F', 'lcool7@narod.ru', 7);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Dame', 'Pallister', 77485418, '2021-11-01', 'M', 'dpallister8@usnews.com', 9);
insert into Medicos (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDEspecialidad) values ('Adolphus', 'Hare', 40772861, '2022-03-28', 'M', 'ahare9@plala.or.jp', 9);

------------------

insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('9/29/2021', 'false', 7, 3, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis. Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('10/10/2021', 'false', 4, 2, 'Etiam pretium iaculis justo. In hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('3/18/2022', 'false', 10, 2, 'Duis mattis egestas metus. Aenean fermentum. Donec ut mauris eget massa tempor convallis. Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh. Quisque id justo sit amet sapien dignissim vestibulum.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('9/18/2021', 'true', 9, 9, 'Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat. Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede. Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus. In est risus, auctor sed, tristique in, tempus sit amet, sem.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('6/10/2022', 'true', 9, 7, 'Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo. Maecenas pulvinar lobortis est. Phasellus sit amet erat.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('9/4/2021', 'true', 2, 8, 'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('8/31/2021', 'false', 4, 4, 'Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('7/16/2021', 'true', 3, 3, 'Curabitur in libero ut massa volutpat convallis. Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('1/22/2022', 'true', 1, 2, 'Vestibulum rutrum rutrum neque. Aenean auctor gravida sem. Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo.');
insert into Turnos (Fecha, Estado, IDPaciente, IDMedico, Observaciones) values ('12/13/2021', 'true', 5, 5, 'Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque. Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla.');

-------------------

insert into Permisos (Nombre) values ('Administrador');
insert into Permisos (Nombre) values ('Recepcionista');
insert into Permisos (Nombre) values ('Medico');

------------------

insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Madge', 'Spracklin', 53464188, '2021-09-28', 'F', 'mspracklin0@example.com', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Wolfy', 'Medlicott', 82828974, '2021-10-19', 'M', 'wmedlicott1@archive.org', 1);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Issie', 'Adamolli', 16739761, '2021-12-04', 'F', 'iadamolli2@utexas.edu', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Wells', 'Callway', 35927076, '2022-01-15', 'M', 'wcallway3@exblog.jp', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Webster', 'Bentham', 29921377, '2021-11-19', 'M', 'wbentham4@columbia.edu', 3);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Evy', 'D''Oyley', 26810057, '2021-10-17', 'F', 'edoyley5@army.mil', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Hieronymus', 'Gaskamp', 79260581, '2021-10-23', 'M', 'hgaskamp6@yale.edu', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Benedicto', 'Trundler', 57542613, '2022-02-14', 'M', 'btrundler7@forbes.com', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Madlen', 'Matuszyk', 63225913, '2022-01-22', 'F', 'mmatuszyk8@dell.com', 2);
insert into Usuarios (Nombre, Apellido, DNI, FechaNacimiento, Sexo, Email, IDPermiso) values ('Shina', 'Clineck', 35247751, '2021-12-18', 'F', 'sclineck9@oakley.com', 3);

