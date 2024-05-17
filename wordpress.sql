create database ~DB~;
create user '~USER~'@'localhost' identified by '~PASSWORD~';
grant all privileges on ~DB~.* to '~USER~'@'localhost';
flush privileges;
