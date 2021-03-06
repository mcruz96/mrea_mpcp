USE [master]
GO
/****** Object:  Table [dbo].[altas_mejoras]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[altas_mejoras](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[num_empleado] [varchar](30) NOT NULL,
	[tipo_mejora] [varchar](30) NULL,
	[tipo_propuesta] [varchar](150) NULL,
	[propuesta] [varchar](max) NULL,
	[fecha_propuesta] [date] NULL,
	[aprobado] [varchar](10) NULL,
	[razon] [varchar](200) NULL,
	[puntos] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[altas_revisiones]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[altas_revisiones](
	[id_revision] [bigint] IDENTITY(1,1) NOT NULL,
	[num_empleado] [varchar](30) NULL,
	[tipo_propuesta] [varchar](150) NULL,
	[propuesta] [varchar](max) NULL,
	[fecha_revision] [date] NULL,
	[aprobacion] [varchar](20) NULL,
	[razon] [varchar](max) NULL,
	[puntos] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RS_LPA_ADD]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RS_LPA_ADD](
	[emp_user] [varchar](30) NULL,
	[departament] [varchar](50) NULL,
	[desc_report] [varchar](max) NULL,
	[points] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RS_LPA_REMOVE]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RS_LPA_REMOVE](
	[emp_user] [varchar](30) NULL,
	[departament] [varchar](50) NULL,
	[desc_report] [varchar](max) NULL,
	[points] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RS_POINTS]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RS_POINTS](
	[emp_user] [varchar](30) NULL,
	[points] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RS_REPORT]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RS_REPORT](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[emp_user] [varchar](50) NULL,
	[departament] [varchar](50) NULL,
	[type_report] [varchar](50) NULL,
	[description] [varchar](max) NULL,
	[date] [date] NULL,
	[aproved] [varchar](10) NULL,
	[reason] [varchar](250) NULL,
	[points] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RS_USERS]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RS_USERS](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[admin_user] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[name_user] [varchar](50) NULL,
	[role] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sr_LPA]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sr_LPA](
	[num_empleado] [varchar](50) NULL,
	[departamento] [varchar](50) NOT NULL,
	[reporte] [varchar](150) NULL,
	[puntos] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xls_bulk]    Script Date: 28/08/2020 01:10:49 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xls_bulk](
	[A] [varchar](50) NULL,
	[B] [varchar](50) NULL,
	[C] [varchar](50) NULL,
	[D] [varchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[altas_mejoras] ON 

INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (182, N'1234', N'Seguridad', N'LPA', N'Seguridad 1', NULL, NULL, NULL, 800)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (183, N'24688', N'Calidad', N'LPA', N'Calidad 1', NULL, NULL, NULL, 24)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (184, N'22468', N'Seguridad', N'LPA', N'Seguridad 2', NULL, NULL, NULL, 3)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (185, N'1234', N'Seguridad', N'LPA', N'Seguridad 1', NULL, NULL, NULL, 8000)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (186, N'24688', N'Calidad', N'LPA', N'Calidad 1', NULL, NULL, NULL, 24)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (187, N'22468', N'Seguridad', N'LPA', N'Seguridad 2', NULL, NULL, NULL, 3)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (179, N'1234', N'Seguridad', N'LPA', N'Seguridad 1', NULL, NULL, NULL, 800)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (180, N'24688', N'Calidad', N'LPA', N'Calidad 1', NULL, NULL, NULL, 24)
INSERT [dbo].[altas_mejoras] ([id], [num_empleado], [tipo_mejora], [tipo_propuesta], [propuesta], [fecha_propuesta], [aprobado], [razon], [puntos]) VALUES (181, N'22468', N'Seguridad', N'LPA', N'Seguridad 2', NULL, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[altas_mejoras] OFF
INSERT [dbo].[RS_LPA_ADD] ([emp_user], [departament], [desc_report], [points]) VALUES (N'2468', N'Seguridad', N'REPORTE1', 50)
INSERT [dbo].[RS_LPA_ADD] ([emp_user], [departament], [desc_report], [points]) VALUES (N'298', N'Seguridad', N'REPORTE2', 50)
INSERT [dbo].[RS_LPA_ADD] ([emp_user], [departament], [desc_report], [points]) VALUES (N'1234', N'Seguridad', N'REPORTE3', 20)
INSERT [dbo].[RS_LPA_REMOVE] ([emp_user], [departament], [desc_report], [points]) VALUES (N'123', N'Seguridad', N'No uso de EPP', 50)
INSERT [dbo].[RS_LPA_REMOVE] ([emp_user], [departament], [desc_report], [points]) VALUES (N'1234', N'Seguridad', N'Mal manejo de montacargas', 50)
INSERT [dbo].[RS_LPA_REMOVE] ([emp_user], [departament], [desc_report], [points]) VALUES (N'12345', N'Calidad', N'Hallazgos en plan de reacci&#243;n', 20)
INSERT [dbo].[RS_POINTS] ([emp_user], [points]) VALUES (N'1234', 170)
INSERT [dbo].[RS_POINTS] ([emp_user], [points]) VALUES (N'2468', 50)
INSERT [dbo].[RS_POINTS] ([emp_user], [points]) VALUES (N'298', 50)
INSERT [dbo].[RS_POINTS] ([emp_user], [points]) VALUES (N'123', 0)
INSERT [dbo].[RS_POINTS] ([emp_user], [points]) VALUES (N'12345', 80)
SET IDENTITY_INSERT [dbo].[RS_REPORT] ON 

INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (62, N'1234', N'Seguridad', N'Casi accidente', N'descripción', CAST(N'2020-07-14' AS Date), N'SI', N'', 100)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (66, N'123', N'Seguridad', N'LPA', N'No uso de EPP', CAST(N'2020-07-14' AS Date), NULL, NULL, -50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (67, N'1234', N'Seguridad', N'LPA', N'Mal manejo de montacargas', CAST(N'2020-07-14' AS Date), NULL, NULL, -50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (68, N'12345', N'Calidad', N'LPA', N'Hallazgos en plan de reacci&#243;n', CAST(N'2020-07-14' AS Date), NULL, NULL, -20)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (69, N'123', N'Seguridad', N'LPA', N'No uso de EPP', CAST(N'2020-08-03' AS Date), NULL, NULL, 50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (70, N'1234', N'Seguridad', N'LPA', N'Mal manejo de montacargas', CAST(N'2020-08-03' AS Date), NULL, NULL, 50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (71, N'12345', N'Calidad', N'LPA', N'Hallazgos en plan de reacci&#243;n', CAST(N'2020-08-03' AS Date), NULL, NULL, 20)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (72, N'2468', N'Seguridad', N'LPA', N'REPORTE1', CAST(N'2020-08-03' AS Date), NULL, NULL, 50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (73, N'298', N'Seguridad', N'LPA', N'REPORTE2', CAST(N'2020-08-03' AS Date), NULL, NULL, 50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (74, N'1234', N'Seguridad', N'LPA', N'REPORTE3', CAST(N'2020-08-03' AS Date), NULL, NULL, 20)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (75, N'123', N'Seguridad', N'LPA', N'No uso de EPP', CAST(N'2020-08-03' AS Date), NULL, NULL, -50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (76, N'1234', N'Seguridad', N'LPA', N'Mal manejo de montacargas', CAST(N'2020-08-03' AS Date), NULL, NULL, -50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (77, N'12345', N'Calidad', N'LPA', N'Hallazgos en plan de reacci&#243;n', CAST(N'2020-08-03' AS Date), NULL, NULL, -20)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (63, N'123', N'Seguridad', N'LPA', N'Accion insegura', CAST(N'2020-07-14' AS Date), NULL, NULL, 50)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (64, N'1234', N'Calidad', N'LPA', N'Casi accidente', CAST(N'2020-07-14' AS Date), NULL, NULL, 100)
INSERT [dbo].[RS_REPORT] ([id], [emp_user], [departament], [type_report], [description], [date], [aproved], [reason], [points]) VALUES (65, N'12345', N'Mejoras', N'LPA', N'Evitar costos', CAST(N'2020-07-14' AS Date), NULL, NULL, 100)
SET IDENTITY_INSERT [dbo].[RS_REPORT] OFF
SET IDENTITY_INSERT [dbo].[RS_USERS] ON 

INSERT [dbo].[RS_USERS] ([id], [admin_user], [password], [name_user], [role]) VALUES (1, N'admin', N'admin', N'admin', N'ADMIN')
INSERT [dbo].[RS_USERS] ([id], [admin_user], [password], [name_user], [role]) VALUES (3, N'seg', N'seg', N'seg', N'Seguridad')
INSERT [dbo].[RS_USERS] ([id], [admin_user], [password], [name_user], [role]) VALUES (4, N'cal', N'cal', N'cal', N'Calidad')
INSERT [dbo].[RS_USERS] ([id], [admin_user], [password], [name_user], [role]) VALUES (5, N'mej', N'mej', N'mej', N'Mejoras')
INSERT [dbo].[RS_USERS] ([id], [admin_user], [password], [name_user], [role]) VALUES (6, N'lpa', N'lpa', N'lpa', N'LPA')
SET IDENTITY_INSERT [dbo].[RS_USERS] OFF
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'No uso de EPP', 50)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Hallazgos en plan de reaccion', 20)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Mal manejo de montacargas', 50)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 8000)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'1234', N'Seguridad', N'Seguridad 1', 800)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'24688', N'Calidad', N'Calidad 1', 24)
INSERT [dbo].[sr_LPA] ([num_empleado], [departamento], [reporte], [puntos]) VALUES (N'22468', N'Seguridad', N'Seguridad 2', 3)
INSERT [dbo].[xls_bulk] ([A], [B], [C], [D]) VALUES (N'123', N'Seguridad', N'No uso de EPP', N'50')
INSERT [dbo].[xls_bulk] ([A], [B], [C], [D]) VALUES (N'1234', N'Seguridad', N'Mal manejo de montacargas', N'50')
INSERT [dbo].[xls_bulk] ([A], [B], [C], [D]) VALUES (N'12345', N'Calidad', N'Hallazgos en plan de reacción', N'20')
