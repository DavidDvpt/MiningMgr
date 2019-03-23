-- ***************************************************************
-- Procedure `sp_TypeCreate`
-- Créateur :		23/03/2019
-- Date Modif :		--/--/--
-- Paramétres :
-- 		p_Name (varchar(50)):	Nom du type à ajouter
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
CREATE PROCEDURE [dbo].[sp_TypeCreate]
	@p_Nom VARCHAR(50),
	@p_IsActive BIT,
	@p_CategorieNom VARCHAR(50),
	@idVal INT OUTPUT,
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @ret INT;
	DECLARE @comRet INT;
	DECLARE @catId INT;
	DECLARE @bidon CHAR;
	IF(@p_Nom is null OR @p_Nom = '' OR @p_IsActive is null OR @p_CategorieNom is null OR @p_CategorieNom = '' OR NOT EXISTS (SELECT Id FROM Common WHERE Nom = @p_CategorieNom))
	BEGIN
		SET @ret = -1;
		SET @idVal = null;
		SET @mes = 'Un des paramètres est nul';
	END
	ELSE
	BEGIN
		EXECUTE @comRet = dbo.sp_CommonCreate @p_Nom, @p_IsActive, @idVal OUTPUT, @mes OUTPUT;

		IF(@comRet = 0)
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
				SELECT @bidon = '' FROM Categorie WITH (HOLDLOCK, TABLOCKX);

				SELECT @catId = Id FROM Common WHERE Nom = @p_CategorieNom;

				INSERT INTO Type(Id, CategorieId) VALUES(@idVal, @catId);
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
