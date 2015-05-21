create proc MyTab as 
select * from INFORMATION_SCHEMA.TABLES


create proc L_Insert
(@Lang_Name nvarchar(max))
as begin
insert into language(Lang_Name) values(@Lang_Name)
declare @Lang_ID int set @Lang_ID=IDENT_CURRENT('language')
return @Lang_ID
end


create proc L_Select
as
select * from language



create proc L_UserIns
(@Lang_Name nvarchar(max))
as begin
insert into userSelectedLang(lang) values(@Lang)
declare @idl int set @idl=IDENT_CURRENT('userSelectedLang')
return @idl
end
