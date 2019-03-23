-- ***************************************************************
-- Procedure `sp_CommonCreate`
-- Créateur :		23/03/2019
-- Date Modif :		--/--/--
-- Paramétres :
-- 		p_Name (varchar(50)):	Nom à ajouter
-- 		p_IsActive (bool)	:	Utilisable ou non dans l'application
-- Retour :
-- 		ret (tinyint) :
--			 0	:	Succès
--			-1	:	Erreur de paramètre
--			-2	:	Existe déjà
--			-3	:	Erreur Systême
--		idVal (int) :	Id de l'enregistrement créé
--		mes (varchar(50) : message de statut du retour
-- Description :  
-- 	Ajoute un nom dans la table principale common.
-- ***************************************************************
CREATE PROCEDURE [dbo].[sp_CommonCreate]
	@p_Nom VARCHAR(50),
	@p_IsActive BIT,
	@idVal INT OUTPUT,
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @bidon CHAR;
	DECLARE @ret INT;
	-- Validation des parametres
	IF(@p_Nom is null OR @p_Nom = '' OR @p_IsActive is null)
	BEGIN
		SET @ret = -1;
		SET @idVal = null;
		SET @mes = 'Un des paramètres est nul';
	END
	ELSE
	BEGIN
		BEGIN TRY
		BEGIN TRANSACTION
			-- Lock de la table à modifier
			SELECT @bidon = '' FROM Common WITH (HOLDLOCK, TABLOCKX);

			-- Test de de doublon
			IF EXISTS(SELECT * FROM Common WHERE Nom = @p_Nom)
			BEGIN
				SET @ret = -2;
				SET @idVal = null;
				SET @mes = 'Ce nom existe déjà dans la table Common';
				ROLLBACK TRANSACTION;
			END
			-- Insertion de la ligne
			ELSE
			BEGIN
				INSERT INTO Common(Nom, Is_Active) VALUES(@p_Nom, @p_IsActive);
				SET @ret = 0;
				SELECT @idVal = IDENT_CURRENT ('Common');
				SET @mes = 'L''enregistrement a éta ajouté avec succès';
				COMMIT TRANSACTION;
			END
		END TRY
		BEGIN CATCH
			SET @ret = -3;
			SET @idVal = null;
			SET @mes = 'Erreur SQL : ' + ERROR_MESSAGE();
			ROLLBACK TRANSACTION;
		END CATCH
	END	
RETURN @ret;
