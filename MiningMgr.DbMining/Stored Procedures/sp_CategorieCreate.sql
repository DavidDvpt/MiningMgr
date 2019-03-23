-- ***************************************************************
-- Procedure `sp_CategorieCreate`
-- Créateur :		23/03/2019
-- Date Modif :		--/--/--
-- Paramétres :
-- 		p_Name (varchar(50)):	Nom à ajouter
-- 		p_IsActive (bool)	:	Utilisable ou non dans l'application
-- 		p_IsStackable (bool):	Objet empilable ou non
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
CREATE PROCEDURE [dbo].[sp_CategorieCreate]
	@p_Nom VARCHAR(50),
	@p_IsActive BIT,
	@p_IsStackable BIT,
	@idVal INT OUTPUT,
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @ret INT;
	DECLARE @comRet INT;
	DECLARE @bidon CHAR;

	-- Validation des parametres
	IF(@p_Nom is null OR @p_Nom = '' OR @p_IsActive is null OR @p_IsStackable is null)
	BEGIN
		SET @ret = -1;
		SET @idVal = null;
		SET @mes = 'Un des paramètres est nul';
	END
	ELSE
	BEGIN
		-- Enregistrement des infos principales dans common
		EXECUTE @comRet = dbo.sp_CommonCreate @p_Nom, @p_IsActive, @idVal OUTPUT, @mes OUTPUT;

		--Si les infos sont enregistrées dans common, on continue
		IF(@comRet = 0)
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
				-- Lock de la table à modifier
				SELECT @bidon = '' FROM Categorie WITH (HOLDLOCK, TABLOCKX);

				-- Insertion de la ligne
				INSERT INTO Categorie(Id, Is_Stackable) VALUES(@idVal, @p_IsStackable);
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
			SET @ret = @comRet;
		END
	END
RETURN @ret
