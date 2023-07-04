USE master
GO

CREATE DATABASE TIF_PROG3
GO

USE TIF_PROG3
GO

-- Tabla SitacionLaboral
CREATE TABLE SituacionLaboral
(
CodSitLab_SL VARCHAR(8) NOT NULL,
Descripcion_SL VARCHAR(50) NOT NULL,
CONSTRAINT PK_SituacionLaboral PRIMARY KEY (CodSitLab_SL)
)
GO

-- Tabla Acercamiento
CREATE TABLE Acercamiento
(
CodAcerc_A VARCHAR(8) NOT NULL,
Descripcion_A VARCHAR(50),
CONSTRAINT PK_Acercamiento PRIMARY KEY (CodAcerc_A)
)
GO

-- Tabla Paciente
CREATE TABLE Paciente(
DNIPac_Pa VARCHAR(8) NOT NULL,
NombreApellido_PA VARCHAR(50) NOT NULL,
Edad_PA VARCHAR(3) NOT NULL,
NomAcompaniante_Pa VARCHAR(50) NULL,
Parentezco_Pa VARCHAR(50) NULL,
FechaEntrevista_Pa SMALLDATETIME NOT NULL DEFAULT GETDATE(),
CUD_Pa BIT DEFAULT 0 NOT NULL,
VencimientoCUD_Pa SMALLDATETIME NULL,
MotivoConsulta_Pa VARCHAR(50) NOT NULL,
Estado BIT NOT NULL DEFAULT 1,
CodSitLab_SL_Pa VARCHAR(8) NOT NULL,
CodAcerc_A_Pa VARCHAR(8) NOT NULL,
CONSTRAINT PK_Paciente PRIMARY KEY (DNIPac_Pa),
CONSTRAINT FK_Paciente_SituacionLaboral FOREIGN KEY (CodSitLab_SL_Pa) REFERENCES SituacionLaboral(CodSitLab_SL),
CONSTRAINT FK_Paciente_Acercamiento FOREIGN KEY (CodAcerc_A_Pa) REFERENCES Acercamiento (CodAcerc_A)
)
GO

-- Tabla Tratamiento
CREATE TABLE Tratamiento
(
NumTram_Tr INT IDENTITY(1,1) NOT NULL,
DNIPac_Tr VARCHAR(8) NOT NULL,
Droga_Tr VARCHAR(20) NULL,
Marca_Tr VARCHAR(20) NULL,
Psicoterapia_Tr BIT NULL DEFAULT 0,
Rehabilitacion_Tr BIT NULL DEFAULT 0,
TO_Tr BIT NULL DEFAULT 0,
Otras_Tr BIT NULL DEFAULT 0,
CONSTRAINT PK_Tratamiento PRIMARY KEY (NumTram_Tr,DNIPac_Tr),
CONSTRAINT FK_Tratamiento_Paciente FOREIGN KEY (DNIPac_Tr)REFERENCES Paciente(DNIPac_Pa)
)
GO

-- Tabla ComposicionFamiliar
CREATE TABLE ComposicionFamiliar
(
DNIFam_CF VARCHAR(8) NOT NULL,
DNIPac_CF VARCHAR(8) NOT NULL,
NombreFamiliar_CF VARCHAR(50) NOT NULL,
EdadFamiliar_CF VARCHAR(3) NOT NULL,
OcupacionFamiliar_CF VARCHAR(20) NOT NULL,
ConviveFamiliar_CF BIT NULL DEFAULT 0,
TelefonoFamiliar_CF VARCHAR(15) NOT NULL,
ParentescoFamiliar_CF VARCHAR(10) NOT NULL,
CONSTRAINT PK_ComposicionFamiliar PRIMARY KEY (DNIFam_CF,DNIPac_CF),
CONSTRAINT FK_ComposicionFamiliar_Paciente FOREIGN KEY(DNIPac_CF) REFERENCES Paciente(DNIPac_Pa) 
)
GO

-- Tabla Areas
CREATE TABLE Areas
(
CodArea_A VARCHAR(8) NOT NULL,
Descripcion_A VARCHAR(50) NOT NULL,
CONSTRAINT PK_Areas PRIMARY KEY (CodArea_A)
)
GO

-- Tabla ObservacionesGenerales
CREATE TABLE ObservacionesGenerales
(
NumObser_OG INT IDENTITY (1,1) NOT NULL,
DNIPac_OG VARCHAR(8) NOT NULL,
Descripcion_OG VARCHAR(100) NOT NULL,
CodArea_OG VARCHAR(8) NOT NULL,
CONSTRAINT PK_ObservacionesGenerales PRIMARY KEY (NumObser_OG,DNIPac_OG),
CONSTRAINT FK_ObservacionesGenerales_Paciente FOREIGN KEY (DNIPac_OG) REFERENCES Paciente(DNIPac_Pa),
CONSTRAINT FK_ObservacionesGenerales_Areas FOREIGN KEY (CodArea_OG) REFERENCES Areas(CodArea_A)
)
GO

-- Tabla Usuario
CREATE TABLE Usuario
(
DNI_U VARCHAR(8) NOT NULL,
Rol_U BIT NOT NULL DEFAULT 0, /*0 es paciente 1 es admin*/
Contraseña_U VARCHAR(50) NOT NULL,
Estado BIT NOT NULL DEFAULT 1 /*1 es de alta 0 de baja*/
CONSTRAINT PK_Usuario PRIMARY KEY (DNI_U)
)
GO

-- CARGA DE DATOS
USE TIF_PROG3
GO

-- Tabla Areas INSERT
INSERT INTO Areas (CodArea_A,Descripcion_A)
SELECT 'CodArea1', 'Area Legal' UNION
SELECT 'CodArea2', 'Area Social' UNION
SELECT 'CodArea3', 'Area Salud Mental'
GO

-- Tabla SitacionLaboral INSERT
INSERT INTO SituacionLaboral(CodSitLab_SL,Descripcion_SL)
SELECT 'CodSL1','En relación de dependencia' UNION
SELECT 'CodSL2','Independiente / Autónomo ' UNION
SELECT 'CodSL3','Sin trabajo ' UNION
SELECT 'CodSL4','A cargo de Familiar' UNION
SELECT 'CodSL5','Pensionado' UNION
SELECT 'CodSL6','Iubilado' UNION
SELECT 'CodSL7','Monotributista' UNION
SELECT 'CodSL8','otro'
GO

-- Tabla Acercamiento INSERT
INSERT INTO Acercamiento(CodAcerc_A,Descripcion_A)
SELECT 'CodAcer1','Instagram/Facebook Página web' UNION
SELECT 'CodAcer2','Revista' UNION
SELECT 'CodAcer3','0tros' UNION
SELECT 'CodAcer4','Médico'
GO

-- Tabla Paciente INSERT
INSERT INTO Paciente(DNIPac_Pa,NombreApellido_PA,Edad_PA,NomAcompaniante_Pa,Parentezco_Pa,FechaEntrevista_Pa,CUD_Pa,VencimientoCUD_Pa,MotivoConsulta_Pa,CodSitLab_SL_Pa,CodAcerc_A_Pa)
SELECT '11111111','Nombre1Apellido1','10','NombreAcompañante1','Mama','01/01/2023',1,'01/01/2023','motivo consulta 1','CodSL1','CodAcer1' UNION
SELECT '22222222','Nombre1Apellido1','10','NombreAcompañante2','Mama','02/02/2023',1,'02/02/2023','motivo consulta 2','CodSL1','CodAcer2' UNION
SELECT '33333333','Nombre1Apellido1','10','NombreAcompañante3','Mama','03/03/2023',1,'03/03/2023','motivo consulta 3','CodSL1','CodAcer3' UNION
SELECT '44444444','Nombre1Apellido1','10','NombreAcompañante4','Mama','04/04/2023',1,'04/04/2023','motivo consulta 4','CodSL1','CodAcer4' UNION
SELECT '55555555','Nombre1Apellido1','10','NombreAcompañante5','Mama','05/05/2023',1,'05/05/2023','motivo consulta 5','CodSL1','CodAcer1' UNION
SELECT '66666666','Nombre1Apellido1','10','NombreAcompañante6','Mama','06/06/2023',1,'06/06/2023','motivo consulta 6','CodSL1','CodAcer2' UNION
SELECT '77777777','Nombre1Apellido1','10','NombreAcompañante7','Mama','07/07/2023',1,'07/07/2023','motivo consulta 7','CodSL1','CodAcer3' UNION
SELECT '88888888','Nombre1Apellido1','10','NombreAcompañante8','Mama','08/08/2023',1,'08/08/2023','motivo consulta 8','CodSL1','CodAcer4' UNION
SELECT '99999999','Nombre1Apellido1','10','NombreAcompañante9','Mama','09/09/2023',1,'09/09/2023','motivo consulta 9','CodSL1','CodAcer1'UNION
SELECT '10000010','Nombre1Apellido1','10','NombreAcompañante10','Mama','09/09/2023',1,'09/09/2023','motivo consulta 10','CodSL1','CodAcer1'UNION
SELECT '10000011','Nombre1Apellido1','10','NombreAcompañante11','Mama','09/09/2023',1,'09/09/2023','motivo consulta 11','CodSL1','CodAcer2'UNION
SELECT '10000012','Nombre1Apellido1','10','NombreAcompañante12','Mama','09/09/2023',1,'09/09/2023','motivo consulta 12','CodSL1','CodAcer3'UNION
SELECT '10000013','Nombre1Apellido1','10','NombreAcompañante13','Mama','09/09/2023',1,'09/09/2023','motivo consulta 13','CodSL1','CodAcer4'UNION
SELECT '10000014','Nombre1Apellido1','10','NombreAcompañante14','Mama','09/09/2023',1,'09/09/2023','motivo consulta 14','CodSL1','CodAcer1'UNION
SELECT '10000015','Nombre1Apellido1','10','NombreAcompañante15','Mama','09/09/2023',1,'09/09/2023','motivo consulta 15','CodSL1','CodAcer3'
GO

-- Tabla Tratamiento INSERT
INSERT INTO Tratamiento (DNIPac_Tr,Droga_Tr,Marca_Tr,Psicoterapia_Tr,Rehabilitacion_Tr,TO_Tr,Otras_Tr)
SELECT '11111111','Droga1','Marca1',1,1,1,1 UNION
SELECT '22222222','Droga2','Marca2',1,1,1,1 UNION
SELECT '33333333','Droga3','Marca1',1,1,1,1 UNION
SELECT '44444444','Droga4','Marca1',1,1,1,1 UNION
SELECT '55555555','Droga5','Marca1',1,1,1,1 UNION
SELECT '66666666','Droga6','Marca1',1,1,1,1 UNION
SELECT '77777777','Droga7','Marca1',1,1,1,1 UNION
SELECT '88888888','Droga8','Marca1',1,1,1,1 UNION
SELECT '99999999','Droga9','Marca1',1,1,1,1 UNION
SELECT '10000010','Droga10','Marca1',1,1,1,1 UNION
SELECT '10000011','Droga11','Marca1',1,1,1,1 UNION
SELECT '10000012','Droga12','Marca1',1,1,1,1 UNION
SELECT '10000013','Droga13','Marca1',1,1,1,1 UNION
SELECT '10000014','Droga14','Marca1',1,1,1,1 UNION
SELECT '10000015','Droga15','Marca1',1,1,1,1 
GO

-- Tabla ComposicionFamiliar INSERT
INSERT INTO ComposicionFamiliar(DNIFam_CF,DNIPac_CF,NombreFamiliar_CF,EdadFamiliar_CF,OcupacionFamiliar_CF,ConviveFamiliar_CF,TelefonoFamiliar_CF,ParentescoFamiliar_CF)
SELECT '10000000','11111111','NombreFamiliar1',11,'ocupacion1',1,'telFamiliar1','Mama' UNION
SELECT '20000000','22222222','NombreFamiliar2',22,'ocupacion2',1,'telFamiliar2','Mama' UNION
SELECT '30000000','33333333','NombreFamiliar3',33,'ocupacion1',1,'telFamiliar3','Mama' UNION
SELECT '40000000','44444444','NombreFamiliar4',44,'ocupacion1',1,'telFamiliar4','Mama' UNION
SELECT '50000000','55555555','NombreFamiliar5',55,'ocupacion1',1,'telFamiliar5','Mama' UNION
SELECT '60000000','66666666','NombreFamiliar6',66,'ocupacion1',1,'telFamiliar6','Mama' UNION
SELECT '70000000','77777777','NombreFamiliar7',77,'ocupacion1',1,'telFamiliar7','Mama' UNION
SELECT '80000000','88888888','NombreFamiliar8',88,'ocupacion1',1,'telFamiliar8','Mama' UNION
SELECT '90000000','99999999','NombreFamiliar9',99,'ocupacion1',1,'telFamiliar9','Mama' union
SELECT '10000001','10000010','NombreFamiliar9',33,'ocupacion1',1 ,'telFamiliar10','Mama'UNION
SELECT '11000000','10000011','NombreFamiliar9',33,'ocupacion1',1,'telFamiliar11','Mama' UNION
SELECT '12000000','10000012','NombreFamiliar9',33,'ocupacion1',1,'telFamiliar12','Mama' UNION
SELECT '13000000','10000013','NombreFamiliar9',33,'ocupacion1',1,'telFamiliar13','Mama' UNION
SELECT '14000000','10000014','NombreFamiliar9',33,'ocupacion1',1,'telFamiliar14','Mama' UNION
SELECT '15000000','10000015','NombreFamiliar9',33,'ocupacion1',1,'telFamiliar15','Mama' 
GO



-- Tabla ObservacionesGenerales INSERT
INSERT INTO ObservacionesGenerales(DNIPac_OG,Descripcion_OG,CodArea_OG)
SELECT '11111111','Descripcion ObservacionesGenerales 1', 'codArea1' UNION
SELECT '22222222','Descripcion ObservacionesGenerales 2', 'codArea2' UNION
SELECT '33333333','Descripcion ObservacionesGenerales 3', 'codArea3' UNION
SELECT '44444444','Descripcion ObservacionesGenerales 4', 'codArea1' UNION
SELECT '55555555','Descripcion ObservacionesGenerales 5', 'codArea2' UNION
SELECT '66666666','Descripcion ObservacionesGenerales 6', 'codArea3' UNION
SELECT '77777777','Descripcion ObservacionesGenerales 7', 'codArea1' UNION
SELECT '88888888','Descripcion ObservacionesGenerales 8', 'codArea2' UNION
SELECT '99999999','Descripcion ObservacionesGenerales 9', 'codArea3' UNION
SELECT '10000010','Descripcion ObservacionesGenerales 10', 'codArea3' UNION
SELECT '10000011','Descripcion ObservacionesGenerales 11', 'codArea3' UNION
SELECT '10000012','Descripcion ObservacionesGenerales 12', 'codArea3' UNION
SELECT '10000013','Descripcion ObservacionesGenerales 13', 'codArea3' UNION
SELECT '10000014','Descripcion ObservacionesGenerales 14', 'codArea3' UNION
SELECT '10000015','Descripcion ObservacionesGenerales 15', 'codArea3'
GO

-- Tabla Usuario INSERT
INSERT INTO usuario (DNI_U,Rol_U,Contraseña_U)
SELECT '00000000',1,'00000000' UNION
SELECT '11111111',0,'11111111' UNION
SELECT '22222222',0,'22222222' UNION
SELECT '33333333',0,'33333333' UNION
SELECT '44444444',0,'44444444' UNION
SELECT '55555555',0,'55555555' UNION
SELECT '66666666',0,'66666666' UNION
SELECT '77777777',0,'77777777' UNION
SELECT '88888888',0,'88888888' UNION
SELECT '99999999',0,'99999999' UNION
SELECT '10000010',0,'10000010'UNION
SELECT '10000011',0,'10000011'UNION
SELECT '10000012',0,'10000012'UNION
SELECT '10000013',0,'10000013'UNION
SELECT '10000014',0,'10000014'UNION
SELECT '10000015',0,'10000015'
GO


-- PROCEDIMIENTO ALMACENADOS
-- ## Usuario ##
-- SP_AgregarUsuario
CREATE PROCEDURE SP_AgregarUsuario
(
@DNI_U VARCHAR(8),
@Contraseña_U VARCHAR(50)
)
AS
INSERT INTO Usuario(DNI_U,Contraseña_U)
SELECT @DNI_U,@Contraseña_U
GO

-- ## Paciente ##
-- SP_AgregarPaciente
CREATE PROCEDURE SP_AgregarPaciente
(
@DNIPac_Pa VARCHAR(8), 
@NombreApellido_PA VARCHAR(50),
@Edad_PA VARCHAR(3),
@NomAcompaniante_Pa VARCHAR(50),
@Parentezco_Pa VARCHAR(50),
@FechaEntrevista_Pa SMALLDATETIME,
@CUD_Pa BIT,
@VencimientoCUD_Pa SMALLDATETIME ,
@MotivoConsulta_Pa VARCHAR(50) ,
@CodSitLab_SL_Pa VARCHAR(8) ,
@CodAcerc_A_Pa VARCHAR(8)
)
AS
INSERT INTO Paciente(DNIPac_Pa, NombreApellido_PA, Edad_PA, NomAcompaniante_Pa, Parentezco_Pa, FechaEntrevista_Pa, CUD_Pa, VencimientoCUD_Pa, MotivoConsulta_Pa, ESTADO, CodSitLab_SL_Pa, CodAcerc_A_Pa) 
SELECT @DNIPac_Pa, @NombreApellido_PA, @Edad_PA, @NomAcompaniante_Pa, @Parentezco_Pa, @FechaEntrevista_Pa, @CUD_Pa, @VencimientoCUD_Pa, @MotivoConsulta_Pa, 'TRUE', @CodSitLab_SL_Pa, @CodAcerc_A_Pa 
GO
-- SP_BajaLogicaUsuario
CREATE PROCEDURE SP_BajaLogicaUsuario
(
@DNIPac VARCHAR(8)
)
AS
BEGIN
	UPDATE Usuario SET ESTADO = 0 WHERE DNI_U = @DNIPac
END
GO

-- SP_BajaLogicaPaciente
CREATE PROCEDURE SP_BajaLogicaPaciente
(
@DNIPac_Pa VARCHAR(8)
)
AS
BEGIN
	UPDATE Paciente SET ESTADO = 0 WHERE DNIPac_Pa = @DNIPac_Pa
END
BEGIN 
	EXEC SP_BajaLogicaUsuario @DNIPac_Pa
END
GO

-- SP_ModificarPaciente
CREATE PROCEDURE SP_ModificarPaciente
( 
@DNIPac_Pa VARCHAR(8),
@NombreApellido_PA VARCHAR(50),
@Edad_PA VARCHAR(3),
@NomAcompaniante_Pa VARCHAR(50),
@Parentezco_Pa VARCHAR(50),
@FechaEntrevista_Pa SMALLDATETIME,
@CUD_Pa BIT,
@VencimientoCUD_Pa SMALLDATETIME ,
@MotivoConsulta_Pa VARCHAR(50) ,
@CodSitLab_SL_Pa VARCHAR(8) ,
@CodAcerc_A_Pa VARCHAR(8)
)
AS 

BEGIN 
	UPDATE Paciente
	SET NombreApellido_PA = @NombreApellido_PA,
	Edad_PA = @Edad_PA,
	NomAcompaniante_Pa = @NomAcompaniante_Pa, 
	Parentezco_Pa = @Parentezco_Pa,
	FechaEntrevista_Pa = @FechaEntrevista_Pa,
	CUD_Pa = @CUD_Pa,
	VencimientoCUD_Pa = @VencimientoCUD_Pa,
	MotivoConsulta_Pa = @MotivoConsulta_Pa, 
	CodSitLab_SL_Pa = @CodSitLab_SL_Pa,
	CodAcerc_A_Pa = @CodAcerc_A_Pa
	WHERE DNIPac_PA = @DNIPac_Pa 
END
GO

-- ## ObservacionGeneral ##
-- SP_AgregarObservacionGeneral
CREATE PROCEDURE SP_AgregarObservacionGeneral
(
@DNIPac_OG VARCHAR(8), 
@Descripcion_OG VARCHAR(100),
@CodArea_OG varchar(8)
)
AS
INSERT INTO ObservacionesGenerales(DNIPac_OG,Descripcion_OG,CodArea_OG)
SELECT @DNIPac_OG,@Descripcion_OG,@CodArea_OG
GO

-- ## Tratamiento ##
-- SP_AgregarTratamiento
CREATE PROCEDURE SP_AgregarTratamiento
(
@DNIPac_Tr VARCHAR(8), 
@Droga_Tr VARCHAR(20),
@Marca_Tr VARCHAR(20),
@Psicoterapia_Tr BIT,
@Rehabilitacion_Tr BIT,
@TO_Tr BIT,
@Otras_Tr BIT
)
AS
INSERT INTO Tratamiento(DNIPac_Tr,Droga_Tr,Marca_Tr,Psicoterapia_Tr,Rehabilitacion_Tr,TO_Tr,Otras_Tr)
SELECT @DNIPac_Tr, @Droga_Tr, @Marca_Tr, @Psicoterapia_Tr, @Rehabilitacion_Tr, @TO_Tr, @Otras_Tr
GO

-- SP_ModificarTratamiento
CREATE PROCEDURE SP_ModificarTratamiento
( 
@NumTram_Tr int, 
@DNIPac_Tr VARCHAR(8), 
@Droga_Tr VARCHAR(20),
@Marca_Tr VARCHAR(20),
@Psicoterapia_Tr BIT,
@Rehabilitacion_Tr BIT,
@TO_Tr BIT,
@Otras_Tr BIT
)
AS 
BEGIN 
	UPDATE Tratamiento	 
	SET Droga_Tr = @Droga_Tr,
	Marca_Tr = @Marca_Tr,
	Psicoterapia_Tr = @Psicoterapia_Tr,
	Rehabilitacion_Tr = @Rehabilitacion_Tr,
	TO_Tr = @TO_Tr,
	Otras_Tr = @Otras_Tr
	WHERE NumTram_Tr = @NumTram_Tr AND DNIPac_Tr = @DNIPac_Tr
END
GO

-- ## ComposicionFamilair ##
-- SP_AgregarFamiliar
CREATE PROCEDURE SP_AgregarFamiliar
( 
@DNIFAM_CF VARCHAR(8),
@DNIPAC_CF VARCHAR(8),
@NombreFamiliar_CF VARCHAR(50),
@EdadFamiliar_CF VARCHAR(3),
@OcupacionFaimiliar_CF VARCHAR(20) ,
@ConviveFamiliar_CF BIT,
@TelefonoFamiliar_CF VARCHAR(15),
@ParentescoFamiliar_CF VARCHAR(10)		
)
AS
INSERT INTO ComposicionFamiliar(DNIFam_CF,DNIPac_CF,NombreFamiliar_CF,EdadFamiliar_CF,OcupacionFamiliar_CF,ConviveFamiliar_CF,TelefonoFamiliar_CF,ParentescoFamiliar_CF)
SELECT @DNIFAM_CF, @DNIPAC_CF, @NombreFamiliar_CF, @EdadFamiliar_CF, @OcupacionFaimiliar_CF, @ConviveFamiliar_CF, @TelefonoFamiliar_CF, @ParentescoFamiliar_CF
GO

-- ## ObservacionesGenerales ##
-- SP_ModificarObservacionesGenerales
CREATE PROCEDURE SP_ModificarObservacionesGenerales
( 
@NumObser_OG INT,
@DNIPac_OG VARCHAR(8), 
@Descripcion_OG VARCHAR(100),
@CodArea_OG varchar(8)
)
AS 
BEGIN 
	UPDATE ObservacionesGenerales
	SET Descripcion_OG = @Descripcion_OG,
	CodArea_OG = @CodArea_OG
	WHERE DNIPac_OG = @DNIPac_OG AND NumObser_OG = @NumObser_OG
END
GO

CREATE PROCEDURE SP_ModificarComposicionFamiliar  
(  
@DNIFam_CF varchar(8),  
@DNIPac_CF varchar(8),  
@NombreFamiliar_CF varchar(50),  
@EdadFamiliar_CF varchar(3),  
@OcupacionFamiliar_CF varchar(20),  
@ConviveFamiliar_CF BIT,  
@TelefonoFamiliar_CF varchar(15),  
@ParentescoFamiliar_CF varchar(10)  
)  
AS  
BEGIN  
 Update ComposicionFamiliar  
 SET NombreFamiliar_CF = @NombreFamiliar_CF,  
 EdadFamiliar_CF = @EdadFamiliar_CF,  
 OcupacionFamiliar_CF = @OcupacionFamiliar_CF,  
 ConviveFamiliar_CF = @ConviveFamiliar_CF,  
 TelefonoFamiliar_CF = @TelefonoFamiliar_CF,  
 ParentescoFamiliar_CF = @ParentescoFamiliar_CF  
  
 WHERE DNIFam_CF = @DNIFam_CF AND DNIPac_CF = @DNIPac_CF  
END  


