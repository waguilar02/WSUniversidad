select * from alumnos

insert into alumnos values (20122073008,'wilson y','aguilar u',GETDATE(),1,'ACTIVO')

insert into alumnos values (20122073002,'Diego A','Mendoza ',GETDATE(),1,'ACTIVO')

insert into materias values (743,'Ecuaciones Diferenciales',3)

insert into materias values (773,'métodos numéricos',2)

insert into materias values (999,'cálculo diferencial',4)



select * from materias

insert into rel_materia_alumno values (743,20122073002)


select * from rel_materia_alumno

delete from rel_materia_alumno where cod_alumno1 = 20122073008


select * from profesores

insert into profesores values (1025777977,'Maria ','Gonzales')


select * from notas

insert into notas values (743,20122073002,1025777977,3.5,1)

select nombres,apellidos, nombre_materia,nota from alumnos inner join notas on alumnos.codigo_alumno=notas.cod_alumno1 
inner join materias on notas.cod_materia1=materias.codigo_materia