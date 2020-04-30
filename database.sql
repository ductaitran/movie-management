CREATE Database MovieManagement;
Use MovieManagement;

CREATE TABLE Cinema_Box(
	cinemabox_id	int primary key,
	cinemabox_name nvarchar(20) NOT NULL,
	vacant			bit NOT NULL);

CREATE TABLE Movie(
	movie_id		int			  primary key,
	movie_name		nvarchar(100) NOT NULL,
	movie_cover		nvarchar(200) NOT NULL,
	movie_length	int			  NOT NULL,
	movie_desc		nvarchar(200) NOT NULL);
create table Box_Slot(
	boxslot_id int primary key,
	cinema_box_id int foreign key references Cinema_Box(cinemabox_id),
	boxslot_name nvarchar(5)
)

create table Schedule(
	schedule_id int primary key,
	cinema_box_id int foreign key references Cinema_Box(cinemabox_id),
	movie_id int foreign key references Movie(movie_id),
	date date,
	time time
)

create table Box_Status(
	boxstatus_id int IDENTITY(1,1) primary key,
	schedule_id int foreign key references Schedule(schedule_id),
	boxslot_id int foreign key references Box_Slot(boxslot_id),
	status bit
)
