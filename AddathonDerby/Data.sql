use addathon
go

if exists(select * from sys.tables where name = 'sturgeonscores')
begin
	drop table sturgeonscores
	print 'dropped table sturgeonscores'
end
go

if exists(select * from sys.tables where name = 'sturgeonteams')
begin
	drop table sturgeonteams
	print 'dropped table sturgeonteams'
end
go

if exists(select * from sys.tables where name = 'sturgeonderbies')
begin
	drop table sturgeonderbies
	print 'dropped table sturgeonderbies'
end
go

create table sturgeonderbies
(
	id int not null identity(1,1) primary key,
	name nvarchar(200) not null unique,
	event_date datetime not null,
	is_open bit not null default(0),
	short_name nvarchar(20) not null 
)
go

create table sturgeonteams
(
	id int not null identity(1,1) primary key,
	derby_id int not null foreign key references sturgeonderbies(id),
	name nvarchar(200) not null,
	secret_string nvarchar(200) not null
)
go

create unique index ux_sturgeonteams on sturgeonteams(derby_id, name);
go

create table sturgeonscores
(
	id int not null identity(1,1) primary key,
	team_id int not null foreign key references sturgeonteams(id),
	slot int not null,
	score int not null
)
go

create unique index ux_sturgeonscores on sturgeonscores(team_id, slot);
go

sp_help sturgeonteams
drop index sturgeonteams.UQ__sturgeon__72E12F1BD3DDE696
alter table sturgeonteams drop constraint UQ__sturgeon__72E12F1BD3DDE696

--insert sturgeonscores(team_id, slot, score) values(1, 1, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 2, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 3, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 4, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 5, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 6, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 7, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 8, 3);
--insert sturgeonscores(team_id, slot, score) values(1, 9, 3);
--insert sturgeonscores(team_id, slot, score) values(2, 1, 3);
--insert sturgeonscores(team_id, slot, score) values(2, 2, 5);
--insert sturgeonscores(team_id, slot, score) values(2, 3, 7);
--insert sturgeonscores(team_id, slot, score) values(2, 4, 5);
--insert sturgeonscores(team_id, slot, score) values(2, 5, 3);
--insert sturgeonscores(team_id, slot, score) values(2, 6, 7);
--insert sturgeonscores(team_id, slot, score) values(2, 7, 3);
--insert sturgeonscores(team_id, slot, score) values(2, 8, 7);
--insert sturgeonscores(team_id, slot, score) values(2, 9, 3);
--go

--update sturgeonteams set secret_string = 'andy' where name = N'crazy team 1'
--update sturgeonteams set secret_string = 'chip' where name = N'crazy team 2'
--update sturgeonteams set secret_string = 'dana' where name = N'crazy team 3'
--update sturgeonteams set secret_string = 'gage' where name = N'crazy team 4'
--update sturgeonteams set secret_string = 'jude' where name = N'crazy team 5'
--update sturgeonteams set secret_string = 'nick' where name = N'crazy team 6'
--update sturgeonteams set secret_string = 'rick' where name = N'crazy team 7'
--update sturgeonteams set secret_string = 'todd' where name = N'crazy team 8'
--update sturgeonteams set secret_string = 'zack' where name = N'crazy team 9'
--update sturgeonteams set secret_string = 'ivan' where name = N'crazy team 10'
--update sturgeonteams set secret_string = 'eddy' where name = N'crazy team 11'
--update sturgeonteams set secret_string = 'cody' where name = N'crazy team 12'
--update sturgeonteams set secret_string = 'aron' where name = N'crazy team 13'
--update sturgeonteams set secret_string = 'alba' where name = N'crazy team 14'
--update sturgeonteams set secret_string = 'finn' where name = N'crazy team 15'
--go

--insert sturgeonteams(name, secret_string) values (N'crazy team 8', N'alex');
--insert sturgeonteams(name, secret_string) values (N'crazy team 9', N'adda');
--insert sturgeonteams(name, secret_string) values (N'crazy team 10', N'baby');

--insert sturgeonteams(name, secret_string) values (N'crazy team 11', N'barb');
--insert sturgeonteams(name, secret_string) values (N'crazy team 12', N'caro');
--insert sturgeonteams(name, secret_string) values (N'crazy team 13', N'dema');
--insert sturgeonteams(name, secret_string) values (N'crazy team 14', N'dyan');
--insert sturgeonteams(name, secret_string) values (N'crazy team 15', N'emmy');
--insert sturgeonteams(name, secret_string) values (N'crazy team 16', N'esta');
--insert sturgeonteams(name, secret_string) values (N'crazy team 17', N'fran');
--insert sturgeonteams(name, secret_string) values (N'crazy team 18', N'gwyn');
--insert sturgeonteams(name, secret_string) values (N'crazy team 19', N'joni');
--insert sturgeonteams(name, secret_string) values (N'crazy team 20', N'kara');

--insert sturgeonteams(name, secret_string) values (N'crazy team 21', N'lana');
--insert sturgeonteams(name, secret_string) values (N'crazy team 22', N'lynn');
--insert sturgeonteams(name, secret_string) values (N'crazy team 23', N'neva');
--insert sturgeonteams(name, secret_string) values (N'crazy team 24', N'ozie');
--insert sturgeonteams(name, secret_string) values (N'crazy team 25', N'rose');
--insert sturgeonteams(name, secret_string) values (N'crazy team 26', N'tena');
--insert sturgeonteams(name, secret_string) values (N'crazy team 27', N'vicy');
--insert sturgeonteams(name, secret_string) values (N'crazy team 28', N'zola');
--insert sturgeonteams(name, secret_string) values (N'crazy team 29', N'wade');
--insert sturgeonteams(name, secret_string) values (N'crazy team 30', N'toma');
--go

--insert sturgeonteams(name, secret_string) values (N'crazy team 1', N'password');
--insert sturgeonteams(name, secret_string) values (N'crazy team 2', N'password');
--insert sturgeonteams(name, secret_string) values (N'crazy team 3', N'password');
--insert sturgeonteams(name, secret_string) values (N'crazy team 4', N'password');
--insert sturgeonteams(name, secret_string) values (N'crazy team 5', N'password');
--insert sturgeonteams(name, secret_string) values (N'crazy team 6', N'password');
--insert sturgeonteams(name, secret_string) values (N'crazy team 7', N'password');
--go

--if exists(select * from sys.tables where name = 'sturgeonscores')
--begin
--	drop table sturgeonscores
--	print 'dropped table sturgeonscores'
--end
--go