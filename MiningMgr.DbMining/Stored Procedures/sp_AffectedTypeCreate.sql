CREATE PROCEDURE [dbo].[sp_AffectedTypeCreate]
	@p_ToolTypeNom VARCHAR(50),
	@p_AccessoireTypeNom VARCHAR(50),
	@mes VARCHAR(200) OUTPUT
AS
	DECLARE @idTool int;
	DECLARE @idAccessoire int;
	DECLARE @ret int;
	DECLARE @bidon CHAR;

	-- Validation des parametres
	IF(	NOT EXISTS(SELECT * FROM Type INNER JOIN Common ON Type.Id = Common.Id WHERE Common.Nom = @p_ToolTypeNom) OR
		NOT EXISTS(SELECT * FROM Type INNER JOIN Common ON Type.Id = Common.Id WHERE Common.Nom = @p_AccessoireTypeNom))
	BEGIN
		SET @ret = -1;
		SET @mes = 'Un des paramètres est nul';
	END
	ELSE
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				SELECT @bidon = '' FROM AffectedType WITH (HOLDLOCK, TABLOCKX);

				SELECT @idTool = Id FROM Common WHERE Nom = @p_ToolTypeNom;
				SELECT @idAccessoire = Id FROM Common WHERE Nom = @p_AccessoireTypeNom;

				INSERT INTO AffectedType(ToolTypeId, AccessoireTypeId) VALUES(@idTool, @idAccessoire)
				SET @ret = 0;
				SET @mes = 'L''enregistrement a éta ajouté avec succès';
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			SET @ret = -3;
			SET @mes = 'Erreur SQL : ' + ERROR_MESSAGE();
			ROLLBACK TRANSACTION;
		END CATCH
	END
RETURN @ret
