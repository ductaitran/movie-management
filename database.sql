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

