CREATE TABLE Contacts
(
	[id]		  [int]		IDENTITY primary key,
	[name]		  [varchar] (80)  NULL,
	[phone]		  [varchar] (15)  NULL,
	[address]	  [varchar] (200) NULL,
	[category]	  [varchar] (10)  NULL,
	[description] [varchar] (300) NULL,
	[photo]       [image]         NULL,
	[width]		  [int]			  NULL,
	[height]	  [int]			  NULL
)

select * from contacts

delete from contacts

insert into contacts(name,	phone, address, category, description)
values 
('Ivanov6', '071-307-30-52', 'good city', ' Business', 'good man')
