show databases; 

drop database scsm;

create database if not exists scsm;

use scsm;

show tables;

create table userInfo(
	name varchar(20) primary key,
	password varchar(20) not null,
	role int default 2 not null
) default charset=utf8;

insert into userInfo (name,password) values (uuid(),'bb');

insert into userInfo (name,password,role) values ('admin','1111',1);
insert into userInfo (name,password,role) values ('aaaa','1111',2);
insert into userInfo (name,password,role) values ('bbbb','1111',3);

create table alarm(
	id bigint(20) primary key auto_increment ,
	aType int(11),
	address varchar(30),
	createTime timestamp not null default current_timestamp ,
	description varchar(100)
) default charset=utf8;

insert into alarm (aType,address,description) values(2,'aa',3);

create table analogSensor(
	name varchar(30) primary key,
	address varchar(30) not null,
	description varchar(100),
	aInterval  int(11) default 60,
	aFormat varchar(20) default '0.00',

	aMd double(8,3),
	aMu double(8,3),

	ut varchar(10),

        h4l double(8,3),
        h3l double(8,3),
        h2l double(8,3),
        h1l double(8,3),

        l1l double(8,3),
        l2l double(8,3),
        l3l double(8,3),
        l4l double(8,3)
) default charset=utf8;

insert into analogSensor (name,address,description,aInterval,aFormat,aMd,aMu,ut,h4l,h3l,h2l,h1l,l1l,l2l,l3l,l4l) 
values ('U2CSP001AM','admin.stationA.moduleA.2','模拟量1',60,'0.00',0,100,'MPa',95,90,85,80,20,15,10,5);

insert into analogSensor (name,address,description,aInterval,aFormat,aMd,aMu,ut,h4l,h3l,h2l,h1l,l1l,l2l,l3l,l4l) 
values ('U2CSP002AM','admin.stationA.moduleA.3','模拟量1',60,'0.00',0,100,'MPa',95,90,85,80,20,15,10,5);

create table anaSensorData(
	id bigint(20) primary key auto_increment, 
	name varchar(30),
	createTime timestamp not null default current_timestamp ,
	q bool,
	av double(8,3)
) default charset=utf8;

insert into anaSensorData(name,q,av) values ('U2CSP001AM',0,1.1);
insert into anaSensorData(name,q,av) values ('U2CSP001AM',0,2.2);


create table digitalSensor(	
	name varchar(30) primary key,
	address varchar(30) not null,
	description varchar(100),
	aInterval  int(11)
) default charset=utf8;

insert into digitalSensor (name,address,description,aInterval) values ('U2CSP001DM','admin.stationA.moduleA.0','中文会乱码',60);
insert into digitalSensor (name,address,description,aInterval) values ('U2CSP002DM','admin.stationA.moduleA.1','中文会乱码',60);

create table digSensorData(
	id bigint(20) primary key auto_increment, 
	name varchar(30),
	createTime timestamp not null default current_timestamp ,
	q bool,
	dv bool
) default charset=utf8;

insert into digSensorData(name,q,dv) values ('U2CSP001DM',0,1);
insert into digSensorData(name,q,dv) values ('U2CSP001DM',0,0);

create table logInfo(
	id bigint(20) primary key auto_increment,
	aType int(11),
	address varchar(100),
	createTime timestamp not null default current_timestamp,
	description varchar(50)
) default charset=utf8;

insert into logInfo(aType,address,createTime,description) values (1,'U2CSP001DM',Now(),'abc');
insert into logInfo(aType,address,createTime,description) values (2,'U2CSP001DM',Now(),'abcd');

create table module(
	name varchar(20) ,
	address varchar(100) primary key,
	description varchar(50),
	anaSensorCount int(11) default 0,
	digSensorCount int(11) default 0
) default charset=utf8;

insert into module (name,address,description,anaSensorCount,digSensorCount) values ('moduleA','admin.stationA.moduleA','description',1,7);
insert into module (name,address,description,anaSensorCount,digSensorCount) values ('moduleB','admin.stationB.moduleB','description',2,3);

create table station(
	name varchar(20),
	address varchar(100) primary key,
	description varchar(50),
	moduleCount int(11)
) default charset=utf8;

insert into station (name,address,description,moduleCount) values ('stationA','admin.stationA','d1',1);
insert into station (name,address,description,moduleCount) values ('stationB','admin.stationB','d2',2);

create table UIInfomation(
	id int(11) primary key auto_increment, 
	userName varchar(20),
	caption varchar(100),
	title varchar(100)
) default charset=utf8;

insert into UIInfomation (userName,caption,title) values ('aa','cc','dd');
insert into UIInfomation (userName,caption,title) values ('ad','csddc','dtitled');

select * from userInfo;
