USE DbMining;
DECLARE @message varchar(200); DECLARE @ret int; DECLARE @idVal int
EXECUTE @ret = dbo.sp_CategorieCreate 'Tool', 1, 1, @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_CategorieCreate 'Accessoire', 1, 1, @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_CategorieCreate 'Ressource', 1, 1, @idVal OUTPUT, @message OUTPUT
SELECT * FROM CategorieView

DECLARE @message varchar(200); DECLARE @ret int; DECLARE @idVal int;
EXECUTE @ret = dbo.sp_TypeCreate 'Finder', 1, 'Tool', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Excavator', 1, 'Tool', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Refiner', 1, 'Tool', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Finder Amplifier', 1, 'Accessoire', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Finder Depth Enhancer', 1, 'Accessoire', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Finder Range Enhancer', 1, 'Accessoire', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Finder Skill Enhancer', 1, 'Accessoire', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Excavator Speed Enhancer', 1, 'Accessoire', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Ore', 1, 'Ressource', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Enmatter', 1, 'Ressource', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Treasure', 1, 'Ressource', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Refined Ore', 1, 'Ressource', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Refined Enmatter', 1, 'Ressource', @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_TypeCreate 'Refined Treasure', 1, 'Ressource', @idVal OUTPUT, @message OUTPUT
SELECT * FROM TypeView

DECLARE @message varchar(200); DECLARE @ret int; DECLARE @idVal int;
EXECUTE @ret = dbo.sp_PlanetCreate 'Calypso', 1, @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_PlanetCreate 'Arkadia', 1, @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_PlanetCreate 'F.O.M.A.', 1, @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_PlanetCreate 'Toulan', 1, @idVal OUTPUT, @message OUTPUT
EXECUTE @ret = dbo.sp_PlanetCreate 'Rocktropia', 1, @idVal OUTPUT, @message OUTPUT
SELECT * FROM PlanetView

DECLARE @message varchar(200); DECLARE @ret int; DECLARE @idVal int;
EXECUTE sp_SearchModeCreate 'Mode Ore', 1, 'O', @idVal OUTPUT, @message OUTPUT
EXECUTE sp_SearchModeCreate 'Mode Enmatter', 1, 'E', @idVal OUTPUT, @message OUTPUT
EXECUTE sp_SearchModeCreate 'Mode Treasure', 1, 'T', @idVal OUTPUT, @message OUTPUT
EXECUTE sp_SearchModeCreate 'Mode Ore, Enmatter', 1, 'OE', @idVal OUTPUT, @message OUTPUT
EXECUTE sp_SearchModeCreate 'Mode Ore, Enmatter, Treasure', 1, 'OET', @idVal OUTPUT, @message OUTPUT
EXECUTE sp_SearchModeCreate 'Mode Enmatter, Treasure', 1, 'ET', @idVal OUTPUT, @message OUTPUT
SELECT * FROM SearchModeView

DECLARE @message varchar(200); DECLARE @ret int; DECLARE @idVal int;
EXECUTE sp_FinderCreate 'A.R.C. Finder 0001 (L)',					1, 1, 'Finder', 0.1,	0.25,	54,		204,	9,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'CDF Finder z10 (L)',						1, 1, 'Finder', 100,	null,	54,		223.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'CDF Finder z25 (L)',						1, 1, 'Finder', 200,	0.56,	54.2,	422.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'CDF Finder z40 (L)',						1, 1, 'Finder', 400,	null,	54.6,	741.3,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Demonic Detector MK-I (L)',				1, 1, 'Finder', 475,	0.5,	54,		204,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'DSEC Seeker L2 (L)',						1, 1, 'Finder', 1860,	null,	55,		213.9,	null,	50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'DSEC Seeker L12 (L)',						1, 1, 'Finder', 4900,	2.29,	55,		462.7,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'DSEC Seeker L30 (L)',						1, 1, 'Finder', 13600,	3.96,	55,		820.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'eMINE FS (L)',								1, 1, 'Finder', 12200,	1.743,	54,		676.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-101',								1, 0, 'Finder', 550,	1,		54,		263.7,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-102',								1, 0, 'Finder', 3000,	1.15,	54,		323.4,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-103',								1, 0, 'Finder', 5500,	1.45,	54.5,	363.2,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-104',								1, 0, 'Finder', 6660,	1.63,	54.5,	432.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-105',								1, 0, 'Finder', 8200,	2.05,	55,		522.4,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-105 TEN Edition',					1, 0, 'Finder', 8200,	2,		55,		552.3,	9,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-106',								1, 0, 'Finder', 7995,	1.799,	55,		582.1,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-210 (L)',							1, 1, 'Finder', 10500,	1.25,	54,		383.1,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-211 (L)',							1, 1, 'Finder', 12120,	1.306,	55,		472.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-212 (L)',							1, 1, 'Finder', 15520,	1.343,	55,		592,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-212, SGA Edition (L)',			1, 1, 'Finder', 15520,	null,	55,		612,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-213 (L)',							1, 1, 'Finder', 20120,	1.66,	54.5,	631.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-213 (L) Adapted',					1, 1, 'Finder', 67800,	2.33,	54,		811,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-213 (L) Customized',				1, 1, 'Finder', 267800, 2.68,	55,		850.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Finder F-214 (L)',							1, 1, 'Finder', 23120,	null,	54,		651.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Genesis Rookie Finder (L)',				1, 1, 'Finder', 6,		0.239,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Genesis Star Rookie Finder (L)',			1, 1, 'Finder', 10,		null,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Imperium Detectonator X2 (L)',				1, 1, 'Finder', 17000,	7,		54,		626.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Imperium Trainee Finder (L)',				1, 1, 'Finder', 10,		0.52,	54,		204,	9,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Island Ziplex Z1 Seeker',					1, 0, 'Finder', 240,	0.751,	55,		204,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Lost Soul Seeker (L)',						1, 1, 'Finder', 4800,	3.7,	54.8,	721,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'NI Finder New Settler Issue (L)',			1, 1, 'Finder', 100,	null,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Omegaton Detectonator MD-1 (L)',			1, 1, 'Finder', 10,		0.239,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Omegaton Detectonator MD-10',				1, 0, 'Finder', 240,	1,		53,		204,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Omegaton Detectonator MD-20',				1, 0, 'Finder', 2600,	2,		53,		223.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Omegaton Detectonator MD-30',				1, 0, 'Finder', 4000,	1,		53.5,	333.4,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Omegaton Detectonator MD-40',				1, 0, 'Finder', 5600,	0.83,	53.5,	373.1,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Omegaton Detectonator MD-50',				1, 0, 'Finder', 6400,	0.8,	54,		492.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'PaySafe Finder (L)',						1, 1, 'Finder', 620,	1.215,	55,		303.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Punk Metal Detector (L)',					1, 1, 'Finder', 10,		0.239,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'ROCTEC C0UGR Finder (L)',					1, 1, 'Finder', 5000,	3.3,	55.2,	562.2,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'ROCTEC M1-LF Finder  (L)',					1, 1, 'Finder', 4500,	2.4,	55.2,	900.5,	8,		75,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'ROCTEC S16 Finder (L)',					1, 1, 'Finder', 3500,	4,		54,		253.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Rookie TerraMaster',						1, 0, 'Finder', 100,	0.239,	54,		109.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Sabad Finder Beginner (L)',				1, 1, 'Finder', 8,		null,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Sabad Finder M1 (L)',						1, 1, 'Finder', 200,	0.751,	54,		204,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Sabad Finder M2 (L)',						1, 1, 'Finder', 2600,	null,	55,		303.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Sabad Finder M3 (L)',						1, 1, 'Finder', null,	null,	0,		0,		null,	50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Sabad Finder M4 (L)',						1, 1, 'Finder', 7800,	null,	55,		477.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Sabad Finder M5 (L)',						1, 1, 'Finder', null,	null,	0,		0,		null,	50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 1 (L)',						1, 1, 'Finder', 250,	1.5,	55,		206,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 2 (L)',						1, 1, 'Finder', 5500,	2.2,	55,		408,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 3 (L)',						1, 1, 'Finder', 9500,	3.225,	55,		631.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 3 Gold Rush',					1, 0, 'Finder', 9500,	3.225,	55,		631.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 4 (L)',						1, 1, 'Finder', 15000,	3.72,	55,		741.3,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 5 (L)',						1, 1, 'Finder', 20500,	4.125,	55,		830.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 6 (L)',						1, 1, 'Finder', 26000,	4.372,	55,		885.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 7 (L)',						1, 1, 'Finder', 32000,	4.552,	55,		925.4,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 8 (L)',						1, 1, 'Finder', 39000,	4.89,	55,		1000,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster 8 Gold Rush',					1, 0, 'Finder', 39000,	null,	55,		1000,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster Trainer (L)',					1, 1, 'Finder', 40,		0.75,	55,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'TerraMaster TT (L)',						1, 1, 'Finder', 10,		0.239,	54,		104.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A10 (L)',							1, 1, 'Finder', 5000,	1.5,	54,		204,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A13 (L)',							1, 1, 'Finder', 5100,	null,	54,		223.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A16 (L)',							1, 1, 'Finder', 5200,	null,	54,		253.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A19 (L)',							1, 1, 'Finder', 5300,	1.8,	55,		303.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A22 (L)',							1, 1, 'Finder', 5400,	1.9,	55,		403,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A25 (L)',							1, 1, 'Finder', 5500,	2,		55.1,	502.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A28 (L)',							1, 1, 'Finder', 5600,	null,	55.2,	602,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A31 (L)',							1, 1, 'Finder', 5700,	null,	55.2,	701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A33 (L)',							1, 1, 'Finder', 5800,	null,	55.2,	801,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex A35 (L)',							1, 1, 'Finder', 5900,	null,	55.2,	900.5,	null,	50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex B35 (L)',							1, 1, 'Finder', 5000,	3,		55,		502.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex B40 (L)',							1, 1, 'Finder', 5100,	null,	55.1,	522.4,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex B50 (L)',							1, 1, 'Finder', 5200,	3.2,	55.2,	542.3,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex B60 (L)',							1, 1, 'Finder', 5300,	null,	55.2,	562.2,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex B70 (L)',							1, 1, 'Finder', 5400,	3,		55.2,	582.1,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex C50 (L)',							1, 1, 'Finder', 4000,	null,	55.2,	283.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex C65 (L)',							1, 1, 'Finder', 4400,	1.2,	55.2,	313.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex C70 (L)',							1, 1, 'Finder', 4600,	1.2,	55.2,	363.2,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex D33 (L)',							1, 1, 'Finder', 4400,	3.6,	54,		801,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex D44 (L)',							1, 1, 'Finder', 4600,	3.2,	54,		900.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex D52 (L)',							1, 1, 'Finder', 5500,	3,		54.5,	990,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex P20 (L)',							1, 1, 'Finder', 1000,	null,	55.2,	701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex P30 (L)',							1, 1, 'Finder', 1000,	0.16,	55.2,	701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex P50 (L)',							1, 1, 'Finder', 1000,	null,	55.2,	701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex P85 (L)',							1, 1, 'Finder', 1000,	null,	55.2,	701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex P160 (L)',							1, 1, 'Finder', 1000,	0.7,	55.2,	701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex TK120 Seeker (L)',					1, 1, 'Finder', 21860,	1.803,	55,		701.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex TK220 Seeker (L)',					1, 1, 'Finder', 26480,	3.96,	55,		776.1,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex TK320 Seeker (L)',					1, 1, 'Finder', 31100,	4.303,	55,		850.8,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex TK320 Seeker, SGA Edition (L)',		1, 1, 'Finder', 23325,	null,	55,		870.7,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex VRX2000 Seeker (L)',				1, 1, 'Finder', 33900,	4.651,	55,		925.4,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex VRX3000 Seeker (L)',				1, 1, 'Finder', 38700,	5.01,	55,		1000,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z1 Seeker',							1, 0, 'Finder', 240,	1.501,	55,		204,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z5 Seeker (L)',						1, 1, 'Finder', 2980,	1.855,	55,		303.5,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z10 Seeker (L)',					1, 1, 'Finder', 5500,	2.209,	55,		403,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z10 Seeker, SGA Edition (L)',		1, 1, 'Finder', 5500,	null,	null,	0,		null,	50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z15 Seeker (L)',					1, 1, 'Finder', 8000,	2.557,	55,		477.6,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z20 Seeker (L)',					1, 1, 'Finder', 12620,	1.452,	55,		552.3,	8,		50,		@idVal OUTPUT, @message OUTPUT
EXECUTE sp_FinderCreate 'Ziplex Z25 Seeker (L)',					1, 1, 'Finder', 17240,	3.251,	55,		626.9,	8,		50,		@idVal OUTPUT, @message OUTPUT
SELECT @ret, @idVal, @message