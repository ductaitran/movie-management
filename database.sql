CREATE Database MovieManagement;
Use MovieManagement;

CREATE TABLE Cinema_Box(
	cinemabox_id	nvarchar(5) primary key,
	cinemabox_name nvarchar(20) NOT NULL,
	cinemabox_vacant			bit NOT NULL);

CREATE TABLE Movie(
	movie_id		nvarchar(5)			  primary key,
	movie_name		nvarchar(100) NOT NULL,
	movie_cover		nvarchar(200) NOT NULL,
	movie_length	int			  NOT NULL,
	movie_desc		nvarchar(200) NOT NULL);
create table Box_Slot(
	boxslot_id nvarchar(5) primary key,
	cinemabox_id nvarchar(5) foreign key references Cinema_Box(cinemabox_id) ON UPDATE CASCADE ON DELETE CASCADE,
	boxslot_name nvarchar(5)
)

create table Schedule(
	schedule_id nvarchar(5) primary key,
	cinemabox_id nvarchar(5) foreign key references Cinema_Box(cinemabox_id) ON UPDATE CASCADE ON DELETE CASCADE,
	movie_id nvarchar(5) foreign key references Movie(movie_id) ON UPDATE CASCADE ON DELETE CASCADE,
	schedule_date date,
	schedule_time nvarchar(100)
)

create table Box_Status(
	boxstatus_id int identity(1, 1) primary key,
	schedule_id nvarchar(5) foreign key references Schedule(schedule_id),
	boxslot_id nvarchar(5) foreign key references Box_Slot(boxslot_id),
	boxstatus_status bit default 0
/*	CONSTRAINT FK_BoxStatus_Schedule FOREIGN KEY (schedule_id)
    REFERENCES Schedule(schedule_id) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_BoxStatus_BoxSlot FOREIGN KEY (boxslot_id)
    REFERENCES Box_Slot(boxslot_id) ON UPDATE CASCADE ON DELETE CASCADE */
)

create table Users_Type(
	userstype_id nvarchar(5) primary key,
	userstype_name nvarchar(100)
)

create table Users(
	users_id nvarchar(5) primary key,
	users_password nvarchar(200),
	users_name nvarchar(100),
	users_type nvarchar(5) foreign key references Users_Type(userstype_id) ON UPDATE CASCADE ON DELETE CASCADE,
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

insert into dbo.Users_Type values 
('US1', 'Admin'),
('US2', 'Staff'),
('US3', 'Manager')

insert into dbo.Users values 
('USS1', 'admin', 'Admin1', 'US1'),
('USS2', 'staff', 'Staff1', 'US2'),
('USS3', 'manager', 'Manager1', 'US3'),
('USS4', 'admin', 'Admin2', 'US1');

insert into dbo.Movie values 
('mv1', 'Kiem than ti hon', '../../../source/img/Kiem_than_ti_hon.JPG', 90, 'Tiled say decay spoil now walls meant house. My mr interest thoughts screened of outweigh removing. Evening society musical besides inhabit ye my. Lose hill well up will he over on' ),
('mv2', 'Meo may Kuro', '../../../source/img/kuro.JPG', 100, 'Tiled say decay spoil now walls meant house. My mr interest thoughts screened of outweigh removing. Evening society musical besides inhabit ye my. Lose hill well up will he over on' ),
('mv3', 'Natra', '../../../source/img/natra.JPG', 180, 'Tiled say decay spoil now walls meant house. My mr interest thoughts screened of outweigh removing. Evening society musical besides inhabit ye my. Lose hill well up will he over on' ),
('mv4', 'My neighbor Totoro', '../../../source/img/totoro.JPG', 80, 'Tiled say decay spoil now walls meant house. My mr interest thoughts screened of outweigh removing. Evening society musical besides inhabit ye my. Lose hill well up will he over on' ),
('mv5', '1917', '../../../source/img/1917.JPG', 130, 'Tiled say decay spoil now walls meant house. My mr interest thoughts screened of outweigh removing. Evening society musical besides inhabit ye my. Lose hill well up will he over on' );

insert into dbo.Schedule values 
('SC1', 'CB1', 'mv1', '2020/04/30', '5:00 pm'),
('SC2', 'CB1', 'mv2', '2020/04/30', '8:00 pm'),
('SC3', 'CB1', 'mv3', '2020/04/30', '11:00 pm'),
('SC4', 'CB2', 'mv3', '2020/04/30', '3:00 pm'),
('SC5', 'CB2', 'mv4', '2020/04/30', '7:00 pm'),
('SC6', 'CB3', 'mv1', '2020/04/30', '5:00 pm'),
('SC7', 'CB3', 'mv5', '2020/04/30', '10:00 pm')

-- init data for box_status
insert into dbo.Box_Status 
select schedule_id, boxslot_id, 0
from Schedule join Box_Slot on Schedule.cinemabox_id = Box_Slot.cinemabox_id

update Box_Status
set boxstatus_status = 1
where schedule_id = 'SC1' and boxslot_id in ('BS1', 'BS10', 'BS11', 'BS12', 'BS13')


delete from Box_Slot
delete from Cinema_Box
select * from Box_Status
select * from Schedule


-- load movie on schedule
select distinct movie_name
from Schedule join Movie on Schedule.movie_id = Movie.movie_id

-- load time on schedule
select distinct schedule_time
from Schedule
where movie_id = 'mv1'

-- load cinema on schedule with movie and time
select cinemabox_name
from Schedule join Cinema_Box on Schedule.cinemabox_id = Cinema_Box.cinemabox_id
where schedule_time = '5:00 pm' and movie_id = 'mv1'


select Box_Status.boxslot_id as Slot_id, Box_Slot.boxslot_name as Slot_name, Box_Status.boxstatus_status as status
                                 from Box_Status 
                                 join Schedule on Box_Status.schedule_id = Schedule.schedule_id
                                 join Box_Slot on Box_Status.boxslot_id = Box_Slot.boxslot_id
                                 join Movie on Schedule.movie_id = Movie.movie_id
                                 join Cinema_Box on Schedule.cinemabox_id = Cinema_box.cinemabox_id
                                 where movie_name = 'Kiem than ti hon' and schedule_time = '5:00 pm' and cinemabox_name = '1st Box'