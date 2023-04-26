
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/07/2022 20:00:33
-- Generated from EDMX file: C:\Users\Elis Regina\Desktop\programs\SIGO\Projeto_SIGO_Web\Models\SIGO_BD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Projeto_SIGO];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__CarroAtua__IDCli__5D2BD0E6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarroAtual] DROP CONSTRAINT [FK__CarroAtua__IDCli__5D2BD0E6];
GO
IF OBJECT_ID(N'[dbo].[FK__Cliente__IDEnder__5772F790]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente] DROP CONSTRAINT [FK__Cliente__IDEnder__5772F790];
GO
IF OBJECT_ID(N'[dbo].[FK__Endereco__IDCida__336AA144]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Endereco] DROP CONSTRAINT [FK__Endereco__IDCida__336AA144];
GO
IF OBJECT_ID(N'[dbo].[FK__ItensOrde__IDOrd__6A85CC04]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensOrdem] DROP CONSTRAINT [FK__ItensOrde__IDOrd__6A85CC04];
GO
IF OBJECT_ID(N'[dbo].[FK__ItensOrde__IDPro__689D8392]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensOrdem] DROP CONSTRAINT [FK__ItensOrde__IDPro__689D8392];
GO
IF OBJECT_ID(N'[dbo].[FK__ItensOrde__IDSer__6991A7CB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItensOrdem] DROP CONSTRAINT [FK__ItensOrde__IDSer__6991A7CB];
GO
IF OBJECT_ID(N'[dbo].[FK__Login__IDCliente__5A4F643B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK__Login__IDCliente__5A4F643B];
GO
IF OBJECT_ID(N'[dbo].[FK__OrdemDeSe__IDCar__65C116E7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdemDeServico] DROP CONSTRAINT [FK__OrdemDeSe__IDCar__65C116E7];
GO
IF OBJECT_ID(N'[dbo].[FK__Produto__IDForne__4CF5691D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produto] DROP CONSTRAINT [FK__Produto__IDForne__4CF5691D];
GO
IF OBJECT_ID(N'[dbo].[FK__Produto__IDMarca__4C0144E4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Produto] DROP CONSTRAINT [FK__Produto__IDMarca__4C0144E4];
GO
IF OBJECT_ID(N'[dbo].[FK_Cidade_Estado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cidade] DROP CONSTRAINT [FK_Cidade_Estado];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CarroAtual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarroAtual];
GO
IF OBJECT_ID(N'[dbo].[Cidade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cidade];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Endereco]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Endereco];
GO
IF OBJECT_ID(N'[dbo].[Estado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estado];
GO
IF OBJECT_ID(N'[dbo].[Fornecedor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[ItensOrdem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItensOrdem];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[Marca]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marca];
GO
IF OBJECT_ID(N'[dbo].[mensagem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[mensagem];
GO
IF OBJECT_ID(N'[dbo].[OrdemDeServico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdemDeServico];
GO
IF OBJECT_ID(N'[dbo].[Produto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produto];
GO
IF OBJECT_ID(N'[dbo].[Servico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servico];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CarroAtual'
CREATE TABLE [dbo].[CarroAtual] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Marca] varchar(100)  NULL,
    [Modelo] varchar(100)  NULL,
    [Ano] varchar(4)  NULL,
    [Valvulas] varchar(10)  NULL,
    [Versao] varchar(10)  NULL,
    [Placa] varchar(10)  NULL,
    [IDCliente] int  NULL
);
GO

-- Creating table 'Cidade'
CREATE TABLE [dbo].[Cidade] (
    [CidadeId] int  NOT NULL,
    [Nome] varchar(38)  NOT NULL,
    [EstadoId] tinyint  NULL,
    [Capital] bit  NOT NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NULL,
    [Tipo] varchar(100)  NULL,
    [Celular] varchar(20)  NULL,
    [CPF_CNPJ] varchar(20)  NULL,
    [Email] varchar(60)  NULL,
    [IDEndereco] int  NULL
);
GO

-- Creating table 'Endereco'
CREATE TABLE [dbo].[Endereco] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Rua] varchar(120)  NULL,
    [Numero] varchar(6)  NULL,
    [Complemento] varchar(120)  NULL,
    [IDCidade] int  NULL
);
GO

-- Creating table 'Estado'
CREATE TABLE [dbo].[Estado] (
    [EstadoId] tinyint  NOT NULL,
    [Sigla] char(2)  NOT NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NULL,
    [Telefone] varchar(20)  NULL,
    [CNPJ] varchar(20)  NULL
);
GO

-- Creating table 'ItensOrdem'
CREATE TABLE [dbo].[ItensOrdem] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Tipo] varchar(10)  NULL,
    [Garantia] varchar(10)  NULL,
    [Quantidade] int  NULL,
    [Desconto] decimal(12,2)  NULL,
    [ValorTotal] decimal(12,2)  NULL,
    [Obs] varchar(max)  NULL,
    [Defeito] varchar(150)  NULL,
    [IDProduto] int  NULL,
    [IDServico] int  NULL,
    [IDOrdemDeServico] int  NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [dbo].[Login] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Usuario] varchar(100)  NULL,
    [Senha] varchar(150)  NULL,
    [Tipo] varchar(1)  NULL,
    [IDCliente] int  NULL
);
GO

-- Creating table 'Marca'
CREATE TABLE [dbo].[Marca] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NULL
);
GO

-- Creating table 'OrdemDeServico'
CREATE TABLE [dbo].[OrdemDeServico] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NULL,
    [TipoPagamento] varchar(50)  NULL,
    [IDCarroAtual] int  NULL
);
GO

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NULL,
    [Descricao] varchar(100)  NULL,
    [Valor] decimal(12,2)  NULL,
    [Estoque] int  NULL,
    [EstoqueMaximo] int  NULL,
    [EstoqueMinimo] int  NULL,
    [IDMarca] int  NULL,
    [IDFornecedor] int  NULL,
    [Foto] varbinary(max)  NULL
);
GO

-- Creating table 'Servico'
CREATE TABLE [dbo].[Servico] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(120)  NULL,
    [Valor] decimal(12,2)  NULL,
    [Vencimento] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'mensagem'
CREATE TABLE [dbo].[mensagem] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(255)  NULL,
    [Email] varchar(255)  NULL,
    [Numero] varchar(13)  NULL,
    [Mensagem1] varchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'CarroAtual'
ALTER TABLE [dbo].[CarroAtual]
ADD CONSTRAINT [PK_CarroAtual]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CidadeId] in table 'Cidade'
ALTER TABLE [dbo].[Cidade]
ADD CONSTRAINT [PK_Cidade]
    PRIMARY KEY CLUSTERED ([CidadeId] ASC);
GO

-- Creating primary key on [ID] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Endereco'
ALTER TABLE [dbo].[Endereco]
ADD CONSTRAINT [PK_Endereco]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [EstadoId] in table 'Estado'
ALTER TABLE [dbo].[Estado]
ADD CONSTRAINT [PK_Estado]
    PRIMARY KEY CLUSTERED ([EstadoId] ASC);
GO

-- Creating primary key on [ID] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ItensOrdem'
ALTER TABLE [dbo].[ItensOrdem]
ADD CONSTRAINT [PK_ItensOrdem]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Marca'
ALTER TABLE [dbo].[Marca]
ADD CONSTRAINT [PK_Marca]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrdemDeServico'
ALTER TABLE [dbo].[OrdemDeServico]
ADD CONSTRAINT [PK_OrdemDeServico]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [PK_Produto]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Servico'
ALTER TABLE [dbo].[Servico]
ADD CONSTRAINT [PK_Servico]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'mensagem'
ALTER TABLE [dbo].[mensagem]
ADD CONSTRAINT [PK_mensagem]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDCliente] in table 'CarroAtual'
ALTER TABLE [dbo].[CarroAtual]
ADD CONSTRAINT [FK__CarroAtua__IDCli__6ABAD62E]
    FOREIGN KEY ([IDCliente])
    REFERENCES [dbo].[Cliente]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CarroAtua__IDCli__6ABAD62E'
CREATE INDEX [IX_FK__CarroAtua__IDCli__6ABAD62E]
ON [dbo].[CarroAtual]
    ([IDCliente]);
GO

-- Creating foreign key on [IDCarroAtual] in table 'OrdemDeServico'
ALTER TABLE [dbo].[OrdemDeServico]
ADD CONSTRAINT [FK__OrdemDeSe__IDCar__02925FBF]
    FOREIGN KEY ([IDCarroAtual])
    REFERENCES [dbo].[CarroAtual]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__OrdemDeSe__IDCar__02925FBF'
CREATE INDEX [IX_FK__OrdemDeSe__IDCar__02925FBF]
ON [dbo].[OrdemDeServico]
    ([IDCarroAtual]);
GO

-- Creating foreign key on [IDCidade] in table 'Endereco'
ALTER TABLE [dbo].[Endereco]
ADD CONSTRAINT [FK__Endereco__IDCida__336AA144]
    FOREIGN KEY ([IDCidade])
    REFERENCES [dbo].[Cidade]
        ([CidadeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Endereco__IDCida__336AA144'
CREATE INDEX [IX_FK__Endereco__IDCida__336AA144]
ON [dbo].[Endereco]
    ([IDCidade]);
GO

-- Creating foreign key on [EstadoId] in table 'Cidade'
ALTER TABLE [dbo].[Cidade]
ADD CONSTRAINT [FK_Cidade_Estado]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[Estado]
        ([EstadoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cidade_Estado'
CREATE INDEX [IX_FK_Cidade_Estado]
ON [dbo].[Cidade]
    ([EstadoId]);
GO

-- Creating foreign key on [IDEndereco] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [FK__Cliente__IDEnder__67DE6983]
    FOREIGN KEY ([IDEndereco])
    REFERENCES [dbo].[Endereco]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Cliente__IDEnder__67DE6983'
CREATE INDEX [IX_FK__Cliente__IDEnder__67DE6983]
ON [dbo].[Cliente]
    ([IDEndereco]);
GO

-- Creating foreign key on [IDCliente] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [FK__Login__IDCliente__10E07F16]
    FOREIGN KEY ([IDCliente])
    REFERENCES [dbo].[Cliente]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Login__IDCliente__10E07F16'
CREATE INDEX [IX_FK__Login__IDCliente__10E07F16]
ON [dbo].[Login]
    ([IDCliente]);
GO

-- Creating foreign key on [IDFornecedor] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK__Produto__IDForne__6E8B6712]
    FOREIGN KEY ([IDFornecedor])
    REFERENCES [dbo].[Fornecedor]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Produto__IDForne__6E8B6712'
CREATE INDEX [IX_FK__Produto__IDForne__6E8B6712]
ON [dbo].[Produto]
    ([IDFornecedor]);
GO

-- Creating foreign key on [IDOrdemDeServico] in table 'ItensOrdem'
ALTER TABLE [dbo].[ItensOrdem]
ADD CONSTRAINT [FK__ItensOrde__IDOrd__075714DC]
    FOREIGN KEY ([IDOrdemDeServico])
    REFERENCES [dbo].[OrdemDeServico]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ItensOrde__IDOrd__075714DC'
CREATE INDEX [IX_FK__ItensOrde__IDOrd__075714DC]
ON [dbo].[ItensOrdem]
    ([IDOrdemDeServico]);
GO

-- Creating foreign key on [IDProduto] in table 'ItensOrdem'
ALTER TABLE [dbo].[ItensOrdem]
ADD CONSTRAINT [FK__ItensOrde__IDPro__056ECC6A]
    FOREIGN KEY ([IDProduto])
    REFERENCES [dbo].[Produto]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ItensOrde__IDPro__056ECC6A'
CREATE INDEX [IX_FK__ItensOrde__IDPro__056ECC6A]
ON [dbo].[ItensOrdem]
    ([IDProduto]);
GO

-- Creating foreign key on [IDServico] in table 'ItensOrdem'
ALTER TABLE [dbo].[ItensOrdem]
ADD CONSTRAINT [FK__ItensOrde__IDSer__0662F0A3]
    FOREIGN KEY ([IDServico])
    REFERENCES [dbo].[Servico]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ItensOrde__IDSer__0662F0A3'
CREATE INDEX [IX_FK__ItensOrde__IDSer__0662F0A3]
ON [dbo].[ItensOrdem]
    ([IDServico]);
GO

-- Creating foreign key on [IDMarca] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK__Produto__IDMarca__6D9742D9]
    FOREIGN KEY ([IDMarca])
    REFERENCES [dbo].[Marca]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Produto__IDMarca__6D9742D9'
CREATE INDEX [IX_FK__Produto__IDMarca__6D9742D9]
ON [dbo].[Produto]
    ([IDMarca]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------