# DesafioMarlin
Cadastro de Turmas e alunos

Requisitos

Instalar entityframework.sqlserver

Instalar entityframework.tools

Instalar microsoft.aspnetcore.mvc.newtonsoftjson

Instalar automapper.extensions.microsoft.dependency

No código configure sua string de conexão no arquivo context

Para Gerar o banco rode os scripts abaixo

Add-Migration InitialCreate

Update-Database





Descrição do desafio abaixo

Criação da base de dados:
Criar uma base de dados utilizando o SQL Server Management Studio com no mínimo as seguintes tabelas:
Aluno - precisa ter pelo menos nome, cpf e e-mail
Turma - precisa ter pelo menos número, ano letivo

API em C#:
A API deve utilizar DDD com Code First ou Database first Mapping, o que preferir.
Os dados deverão ser manipulados utilizando o Entity Framework e a API deve possuir os seguintes métodos:
CRUD de Aluno 
cadastro 
alteração 
consulta - método que liste todos os alunos 
exclusão

CRUD de Turma
cadastro 
alteração 
consulta - método que liste todas as turmas
exclusão

CRUD de Matrícula 
cadastro
consulta - método que liste todas as matrículas
exclusão
Seguem algumas das regras de negócio do projeto que serão validadas:
Aluno não pode ser cadastrado repetido (validação pelo CPF)
No momento de cadastrar um aluno, deve-se informar pelo menos uma turma que ele irá cursar;
O mesmo aluno pode ser matriculado em várias turmas diferentes, porém a Matrícula não pode ser repetida na mesma turma;
Uma turma não pode ter mais de 5 alunos;
Turma não pode ser excluída se possuir alunos;
A API deve ser entregue com Swagger para visualização dos métodos criados.
