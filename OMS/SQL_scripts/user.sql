alter session set "_ORACLE_SCRIPT"=true; 
create user oms_projekat identified by ftn
	default tablespace USERS temporary tablespace TEMP;


	grant connect, resource to oms_projekat;

	grant create table to oms_projekat;

	grant create view to oms_projekat;

	grant create procedure to oms_projekat;

	grant create synonym to oms_projekat;

	grant create sequence to oms_projekat;

	grant select on dba_rollback_segs to oms_projekat;

	grant select on dba_segments to oms_projekat;

	grant unlimited tablespace to oms_projekat;