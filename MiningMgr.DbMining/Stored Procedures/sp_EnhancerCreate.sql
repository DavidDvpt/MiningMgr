-- ***************************************************************
-- Procedure `sp_EnhancerCreate`
-- Créateur :		23/03/2019
-- Date Modif :		--/--/--
-- Paramétres :
-- 		p_Name (varchar(50))		:	Nom à ajouter
-- 		p_IsActive (bool)			:	Utilisable ou non dans l'application
-- 		p_Value (bool)				:	Valeur Max de l'objet
--		p_BonusValue1 (decimal(3,2)):	Bonus 1
--		p_BonusValue2 (int)			:	Bonus 2
-- Retour :
-- 		ret (tinyint) :
--			 0	:	Succès
--			-1	:	Erreur de paramètre
--			-2	:	Existe déjà
--			-3	:	Erreur Systême
--		idVal (int) :	Id de l'enregistrement créé
--		mes (varchar(50) : message de statut du retour
-- Description :  
-- 	Ajoute un enhancer.
-- ***************************************************************
CREATE PROCEDURE [dbo].[sp_EnhancerCreate]
	@p_Nom VARCHAR(50),
	@p_IsActive BIT,
	@p_Value BIT,
	@p_slot TINYINT,
	@p_BonusValue1 DECIMAL(3,2),
	@p_BonusValue2 INT,
	@idVal INT OUTPUT,
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @ret INT;
	DECLARE @iwRet INT;
	DECLARE @bidon CHAR;

	-- Validation des parametres
	IF(@p_Nom is null OR @p_Nom = '' OR @p_IsActive is null OR @p_Value is null OR @p_slot > 10 OR @p_slot < 1)
	BEGIN
		SET @ret = -1;
		SET @idVal = null;
		SET @mes = 'Un des paramètres est nul';
	END
	ELSE
	BEGIN
		-- Enregistrement des infos principales dans common
		EXECUTE @iwRet = dbo.sp_InWorldCreate @p_Nom, @p_IsActive, @p_Value, @idVal OUTPUT, @mes OUTPUT;

		--Si les infos sont enregistrées dans common, on continue
		IF(@iwRet = 0)
		BEGIN
			BEGIN TRY
				BEGIN TRANSACTION
				-- Lock de la table à modifier
				SELECT @bidon = '' FROM InWorld WITH (HOLDLOCK, TABLOCKX);

				-- Insertion de la ligne
				INSERT INTO Enhancer_Info(Id, Slot, BonusValue1, BonusValue2) VALUES(@idVal, @p_slot, @p_BonusValue1, @p_BonusValue2);
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
			SET @ret = @iwRet;
		END
	END
RETURN @ret
