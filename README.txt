TRABALHO PRÁTICO 1º BIMESTRE - TLP II
Agenda de Eventos e Palestras (ASP.NET MVC 5 + Entity Framework Database First + SQL Server)

Aluno: Guilherme Autulo Santana
RA: 103844

Versão do Visual Studio: Visual Studio Community 2026 (18.9.3)
.NET Framework: 4.8.1
Servidor SQL usado na connection string: BAC002\SQLEXPRESS
Nome da connection string: AgendaEventosEntities (arquivo AgendaEventos\AgendaEventos\Web.config)


CONTEÚDO DO ZIP
- AgendaEventos\      pasta da solução (AgendaEventos.slnx + projeto AgendaEventos)
- script.sql          criação do banco AgendaEventos + inserts
- README.txt          este arquivo
- Telas.docx          prints das telas


PASSO A PASSO PARA RODAR

1. Executar o script do banco
   - Abrir o SQL Server Management Studio e conectar no servidor.
   - Abrir o arquivo script.sql e executar inteiro (F5).
   - O script cria o banco AgendaEventos, as tabelas Categorias, Palestrantes
     e Eventos e insere 3 categorias, 4 palestrantes e 8 eventos.

2. Ajustar a connection string
   - Abrir o arquivo AgendaEventos\AgendaEventos\Web.config.
   - Na connection string "AgendaEventosEntities", trocar o trecho
         data source=BAC002\SQLEXPRESS
     pelo nome do servidor SQL da máquina (o mesmo usado para conectar no
     Management Studio). Não alterar o restante da linha.

3. Abrir a solução
   - Abrir o arquivo AgendaEventos\AgendaEventos.slnx no Visual Studio.

4. Restaurar os pacotes NuGet
   - As pastas packages, bin, obj e .vs foram removidas do zip.
   - Clicar com o botão direito na solução > "Restaurar Pacotes do NuGet"
     (ou apenas compilar com Ctrl+Shift+B, que o Visual Studio restaura sozinho).

5. Executar
   - Compilar (Ctrl+Shift+B) e executar com F5.
   - O site abre na Vitrine (página inicial).


ENDEREÇOS
Vitrine (pública):
- /Vitrine                          cartões dos eventos
- /Vitrine?categoria=1&destaque=1&titulo=texto   filtros combináveis
- /Vitrine/Detalhes/5               detalhes do evento

Admin:
- /Eventos, /Eventos/Create, /Eventos/Edit/5, /Eventos/Details/5, /Eventos/Delete/5
- /Categorias e /Categorias/Create
- /Palestrantes e /Palestrantes/Create


OBSERVAÇÕES
- O template MVC 5 desta versão do Visual Studio usa Bootstrap 5 (e não
  Bootstrap 3). Por isso os cartões da Vitrine usam a classe "card" no lugar
  de "panel panel-default".
- As validações de campo obrigatório (Título, Data/Hora e Local) e os textos
  das telas ficam em Models\EventoMetaData.cs (classe parcial com
  [MetadataType]), para não serem perdidos se o .edmx for atualizado.
- A regra "não cadastrar evento com data no passado" está nas actions POST de
  Create e Edit do EventosController, usando ModelState.AddModelError.
- Se aparecer erro de certificado ao conectar no SQL Server, a connection
  string já possui "trustservercertificate=True".
