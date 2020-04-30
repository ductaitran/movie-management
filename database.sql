CREATE Database MovieManagement;
Use MovieManagement;

CREATE TABLE Cinema_Box(
	cinemabox_id	nvarchar(5) primary key,
	cinemabox_name nvarchar(20) NOT NULL,
	vacant			bit NOT NULL);

CREATE TABLE Movie(
	movie_id		nvarchar(5)			  primary key,
	movie_name		nvarchar(100) NOT NULL,
	movie_cover		nvarchar(200) NOT NULL,
	movie_length	int			  NOT NULL,
	movie_desc		nvarchar(200) NOT NULL);
create table Box_Slot(
	boxslot_id nvarchar(5) primary key,
	cinema_box_id nvarchar(5) foreign key references Cinema_Box(cinemabox_id),
	boxslot_name nvarchar(5)
)

create table Schedule(
	schedule_id nvarchar(5) primary key,
	cinema_box_id nvarchar(5) foreign key references Cinema_Box(cinemabox_id),
	movie_id nvarchar(5) foreign key references Movie(movie_id),
	date date,
	time nvarchar(100)
)

create table Box_Status(
	boxstatus_id nvarchar(5) primary key,
	schedule_id nvarchar(5) foreign key references Schedule(schedule_id),
	boxslot_id nvarchar(5) foreign key references Box_Slot(boxslot_id),
	status bit
)

create table Users(
	users_id nvarchar(5) primary key,
	users_name nvarchar(100),
	users_type nvarchar(5) foreign key references Users_Type(userstype_id),
)

create table Users_Type(
	userstype_id nvarchar(5) primary key,
	userstype_name nvarchar(100)
)

insert into dbo.Cinema_Box values 
('CB1', '1st Box', 1),
('CB2', '2nd Box', 1),
('CB3', '3rd Box', 1)

insert into dbo.Box_Slot values
('BS1', 'CB1', 'A1'),
('BS2', 'CB1', 'A2'),
('BS3', 'CB1', 'A3'),
('BS4', 'CB1', 'A4'),
('BS5', 'CB1', 'A5'),
('BS6', 'CB1', 'B1'),
('BS7', 'CB1', 'B2'),
('BS8', 'CB1', 'B3'),
('BS9', 'CB1', 'B4'),
('BS10', 'CB1', 'B5'),
('BS11', 'CB1', 'C1'),
('BS12', 'CB1', 'C2'),
('BS13', 'CB1', 'C3'),
('BS14', 'CB1', 'C4'),
('BS15', 'CB1', 'C5'),
('BS16', 'CB1', 'D1'),
('BS17', 'CB1', 'D2'),
('BS18', 'CB1', 'D3'),
('BS19', 'CB1', 'D4'),
('BS20', 'CB1', 'D5'),
('BS21', 'CB2', 'A1'),
('BS22', 'CB2', 'A2'),
('BS23', 'CB2', 'A3'),
('BS24', 'CB2', 'A4'),
('BS25', 'CB2', 'A5'),
('BS26', 'CB2', 'B1'),
('BS27', 'CB2', 'B2'),
('BS28', 'CB2', 'B3'),
('BS29', 'CB2', 'B4'),
('BS30', 'CB2', 'B5'),
('BS31', 'CB2', 'C1'),
('BS32', 'CB2', 'C2'),
('BS33', 'CB2', 'C3'),
('BS34', 'CB2', 'C4'),
('BS35', 'CB2', 'C5'),
('BS36', 'CB2', 'D1'),
('BS37', 'CB2', 'D2'),
('BS38', 'CB2', 'D3'),
('BS39', 'CB2', 'D4'),
('BS40', 'CB2', 'D5'),
('BS41', 'CB3', 'A1'),
('BS42', 'CB3', 'A2'),
('BS43', 'CB3', 'A3'),
('BS44', 'CB3', 'A4'),
('BS45', 'CB3', 'A5'),
('BS46', 'CB3', 'B1'),
('BS47', 'CB3', 'B2'),
('BS48', 'CB3', 'B3'),
('BS49', 'CB3', 'B4'),
('BS50', 'CB3', 'B5'),
('BS51', 'CB3', 'C1'),
('BS52', 'CB3', 'C2'),
('BS53', 'CB3', 'C3'),
('BS54', 'CB3', 'C4'),
('BS55', 'CB3', 'C5'),
('BS56', 'CB3', 'D1'),
('BS57', 'CB3', 'D2'),
('BS58', 'CB3', 'D3'),
('BS59', 'CB3', 'D4'),
('BS60', 'CB3', 'D5')


delete from Box_Slot
delete from Cinema_Box
select * from Box_Slot