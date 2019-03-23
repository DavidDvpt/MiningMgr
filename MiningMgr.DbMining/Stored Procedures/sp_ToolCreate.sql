-- ***************************************************************
-- Procedure `sp_ToolCreate`
-- Créateur :		23/03/2019
-- Date Modif :		--/--/--
-- Paramétres :
-- 		p_Name (varchar(50)):	Nom à ajouter
-- 		p_IsActive (bool)	:	Utilisable ou non dans l'application
-- 		p_Value (bool):			Valeur Max de l'objet
--		@p_IsLimited (bit)
--		@p_Decay (decimal(7,3))
--		@p_UsePerMin (tinyint)
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
CREATE PROCEDURE [dbo].[sp_ToolCreate]
	@p_Nom VARCHAR(50),
	@p_IsActive BIT,
	@p_TypeNom VARCHAR(50),
	@p_Value DECIMAL(9,5),
	@p_IsLimited BIT,
	@p_Decay DECIMAL(7,3),
	@p_UsePerMin TINYINT,
	@idVal INT OUTPUT,
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @ret INT;
	DECLARE @usRet INT;
	DECLARE @typId INT;
	DECLARE @bidon CHAR;

	BEGIN
		-- Enregistrement des infos principales dans common
		EXECUTE @usRet = dbo.sp_UnstackableCreate @p_Nom, @p_IsActive, @p_TypeNom, @p_Value, @p_IsLimited, @p_Decay, @idVal OUTPUT, @mes OUTPUT;

		--Si les infos sont enregistrées dans common, on continue
		IF(@usRet = 0)
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
				-- Lock de la table à modifier
				SELECT @bidon = '' FROM InWorld WITH (HOLDLOCK, TABLOCKX);

				-- Insertion de la ligne
				INSERT INTO Tool(Id, UsePerMin) VALUES(@idVal, @p_UsePerMin);
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
			SET @ret = @usRet;
		END
	END
RETURN @ret
RETURN 0

