IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCalculPeche_CreerExpedition]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[spCalculPeche_CreerExpedition]
	GO
CREATE PROCEDURE [dbo].[spCalculPeche_CreerExpedition] (@nom varchar(1000), @dateDebut DateTime, @dateFin DateTime)
as
BEGIN
	INSERT INTO Expedition (IsActive, Nom, DateDebut, DateFin, Search) VALUES (1, @nom, @dateDebut, @dateFin)
	DECLARE @idExpedition int = (SELECT max(id) FROM Expedition)
	
	INSERT INTO ParticipantExpedition (IsActive, Participant,Expedition, MontantAutomobile, MontantBateau, MontantPropane,MontantNourriture)
	SELECT 1, Id, @idExpedition, 0, 0, 0, 0
	FROM Participant

	DECLARE @dateEnCours DateTime = @DateDebut
	
	-- Automobile
	while @dateEnCours <> @dateFin
	BEGIN
		INSERT INTO ParticipantAutomobileExpedition (IsActive,Participant, Expedition, Date, EstAutomobile)
		SELECT 1, Id,@idExpedition, @dateEnCours,0
		FROM Participant
		SET @dateEnCours = dateadd(day,1,@dateEnCours)
	END
	INSERT INTO ParticipantAutomobileExpedition (IsActive,Participant, Expedition, Date, EstAutomobile)
	SELECT 1, Id,@idExpedition, @dateEnCours,0
	FROM Participant

	-- Bateau
	SET @dateEnCours = @dateDebut
	while @dateEnCours <> @dateFin
	BEGIN
		INSERT INTO ParticipantBateauExpedition (IsActive,Participant, Expedition, Date, EstBateau)
		SELECT 1, Id,@idExpedition, @dateEnCours,0
		FROM Participant
		SET @dateEnCours = dateadd(day,1,@dateEnCours)
	END
	INSERT INTO ParticipantBateauExpedition (IsActive,Participant, Expedition, Date, EstBateau)
	SELECT 1, Id,@idExpedition, @dateEnCours,0
	FROM Participant
	
	-- Presence
	SET @dateEnCours = @dateDebut
	while @dateEnCours <> @dateFin
	BEGIN
		INSERT INTO ParticipantPresenceExpedition(IsActive,Participant, Expedition, Date, EstPresence)
		SELECT 1, Id,@idExpedition, @dateEnCours,0
		FROM Participant
		SET @dateEnCours = dateadd(day,1,@dateEnCours)
	END
	INSERT INTO ParticipantPresenceExpedition (IsActive,Participant, Expedition, Date, EstPresence)
	SELECT 1, Id,@idExpedition, @dateEnCours,0
	FROM Participant
	
	-- Repas
	SET @dateEnCours = @dateDebut
	while @dateEnCours <> @dateFin
	BEGIN
		INSERT INTO ParticipantRepasExpedition(IsActive,Participant, Expedition, Date, NombreRepas)
		SELECT 1, Id,@idExpedition, @dateEnCours,0
		FROM Participant
		SET @dateEnCours = dateadd(day,1,@dateEnCours)
	END
	INSERT INTO ParticipantRepasExpedition(IsActive,Participant, Expedition, Date, NombreRepas)
	SELECT 1, Id,@idExpedition, @dateEnCours,0
	FROM Participant

END
go
exec [dbo].[spCalculPeche_CreerExpedition] @nom = 'TEst', @dateDebut = '2016-08-18', @dateFin ='2016-08-25'
go
select * from Expedition
select * from ParticipantExpedition
select * from ParticipantAutomobileExpedition
select * from ParticipantBateauExpedition
select * from ParticipantPresenceExpedition
select * from ParticipantRepasExpedition
--EXEC sp_msforeachtable @command1 ='DELETE FROM ?'

delete from Expedition
DBCC CHECKIDENT ( 'Expedition', RESEED, 0)
delete from ParticipantExpedition
DBCC CHECKIDENT ( 'ParticipantExpedition', RESEED, 0)
delete from ParticipantAutomobileExpedition
DBCC CHECKIDENT ( 'ParticipantAutomobileExpedition', RESEED, 0)
delete from ParticipantBateauExpedition
DBCC CHECKIDENT ( 'ParticipantBateauExpedition', RESEED, 0)
delete from ParticipantPresenceExpedition
DBCC CHECKIDENT ( 'ParticipantPresenceExpedition', RESEED, 0)
delete from ParticipantRepasExpedition
DBCC CHECKIDENT ( 'ParticipantRepasExpedition', RESEED, 0)