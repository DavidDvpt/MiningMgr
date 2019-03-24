-- ***************************************************************
-- Procedure `sp_FinderCreate`
-- Créateur :		23/03/2019
-- Date Modif :		--/--/--
-- Paramétres :
-- 		p_Name (varchar(50)):	Nom à ajouter
-- 		p_IsActive (bool)	:	Utilisable ou non dans l'application
-- 		p_Value (bool):			Valeur Max de l'objet
--		@p_IsLimited (bit)
--		@p_Decay (decimal(7,3))
--		@p_Depth (decimal(5,1))
--		@p_Range (decimal(3,1))
-- Retour :
-- 		ret (tinyint) :
--			 0	:	Succès
--			-1	:	Erreur de paramètre
--			-2	:	Existe déjà
--			-3	:	Erreur Systême
--		idVal (int) :	Id de l'enregistrement créé
--		mes (varchar(50) : message de statut du retour
-- Description :  
-- 	Ajoute un finder faisant parti du monde entropia.
-- ***************************************************************
CREATE PROCEDURE [dbo].[sp_FinderCreate]
	@p_Nom VARCHAR(50),
	@p_IsActive BIT,
	@p_IsLimited BIT,
	@p_TypeNom VARCHAR(50),
	@p_Value DECIMAL(9,5),
	@p_Decay DECIMAL(7,3),
	@p_Range DECIMAL(3,1),
	@p_Depth DECIMAL(5,1),
	@p_UsePerMin TINYINT,
	@p_BasePecSearch int,
	@idVal INT OUTPUT,
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @ret INT;
	DECLARE @toolRet INT;
	DECLARE @typId INT;
	DECLARE @bidon CHAR;

	BEGIN
		-- Enregistrement des infos principales dans common
		EXECUTE @toolRet = dbo.sp_ToolCreate @p_Nom, @p_IsActive, @p_TypeNom, @p_Value, @p_IsLimited, @p_Decay, @p_UsePerMin, @idVal OUTPUT, @mes OUTPUT;

		--Si les infos sont enregistrées dans common, on continue
		IF(@toolRet = 0)
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
				-- Lock de la table à modifier
				SELECT @bidon = '' FROM InWorld WITH (HOLDLOCK, TABLOCKX);

				-- Insertion de la ligne
				INSERT INTO Finder_Info(Id, Depth, FinderRange, BasePecSearch) VALUES(@idVal, @p_Depth, @p_Range, @p_BasePecSearch);
				SET @ret = 0;
				SET @mes = 'L''enregistrement a éta ajouté avec succès';
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				SET @ret = -3;
				SET @idVal = null;
				SET @mes = 'Erreur SQL : ' + ERROR_MESSAGE();
				ROLLBACK TRANSACTION;
			END CATCH
		END
		ELSE
		BEGIN
			SET @ret = @toolRet;
		END
	END
RETURN @ret
RETURN 0
