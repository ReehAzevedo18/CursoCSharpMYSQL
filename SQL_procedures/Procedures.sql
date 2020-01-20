--procedimento mostrar
create proc spmostrar_categoria
as
select top 200 * from categoria
order by idcategoria desc
go

--procedimento para buscar nome
create proc spbuscar_nome 
@textobuscar varchar(50)
as 
select * from categoria 
where nome like @textobuscar + '%' --Trazer todos os resultados apos a primeira letra
go

--procedimento para inserir categorias
create proc spinserir_categoria
@idcategoria int output, --output:
@nome varchar(50), @descricao varchar(256)
as 
insert into categoria (nome, descricao) 
values (@nome, @descricao)
go

--procedimento editar categoria
create proc speditar_categoria
@idcategoria int output, 
@nome varchar(50),
@descricao varchar(256)
as
update categoria 
set nome = @nome, 
	descricao = @descricao
where idcategoria = @idcategoria;
go

--procedimento excluir categoria
create proc spexcluir_categoria
@idcategoria int 
as 
delete from categoria
where idcategoria=@idcategoria
go
 


