/* SCRIPT INITIALE CIMA */
SET NOCOUNT ON
SELECT 'DELETE FROM USER;'
SELECT 'DELETE FROM Customer;'
SELECT 'DELETE FROM PRODUCT;'
SELECT 'DELETE FROM ProductFile;'
SELECT 'DELETE FROM ProductCategory;'
SELECT 'DELETE FROM Supplier;'
SELECT 'DELETE FROM City;'
SELECT 'DELETE FROM Address;'
SELECT 'DELETE FROM EnterpriseAddress;'
SELECT 'DELETE FROM Stock;'
SELECT 'update sqlite_sequence set seq = 0 where name = ''User'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''Customer'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''Product'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''ProductFile'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''ProductCategory'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''Supplier'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''City'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''Address'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''EnterpriseAddress'';'
SELECT 'update sqlite_sequence set seq = 0 where name = ''Stock'';'
SELECT 'SELECT * FROM sqlite_sequence'
SELECT 'INSERT INTO ProductCategory (IsActive,DateCreated,Language, Enterprise, Code, Description) VALUES (1,datetime(''now''),''' + langue + ''',2,' + CONVERT(varchar,no_categorie) + ',''' + replace(nom,'''','''''') + ''');' from CATEGORIE_PRODUIT where no_entreprise = 11
SELECT 'INSERT INTO Product (IsActive,DateCreated,Language,Enterprise,Ident,Name, UnitPrice, CostPrice, Description, Weight, search) VALUES (1,datetime(''now''),''' + langue + ''',2,''' + identifiant_produit + ''',''' + replace(nom_produit,'''','''''') +''',' + convert(varchar,prix_base) + ',' + convert(varchar,Isnull(Prix_coutant,0)) + ',''' + replace(IsNull(DESCRIPTION_PRODUIT,''),'''','''''') + ''',' + convert(varchar,IsNull(poids,1)) + ',''' + CONVERT(varchar,no_categorie) + ''');' FROM PRODUIT  where no_entreprise = 11 and identifiant_produit is not null
SELECT 'update Product set ProductCategory = (SELECT Id FROM ProductCategory WHERE Code = Product.Search);'
SELECT 'INSERT INTO Stock (IsActive,DateCreated,Product, InitialState, AdjustPrice, Feature, IsWarningOnLow, MinimumAccept, IsWithoutStock) SELECT 1,datetime(''now''),Id, 100, 0, '''',0,10,0 FROM PRODUCT;'
SELECT 'INSERT INTO User (IsActive,DateCreated,Login,Password, Email, FirstName, LastName, Search, IsAdministrator) VALUES (1,datetime(''now''),''riov01'',''test'',''admin@admin.com'',''Vincent'',''Rioux'',''001'',1);'
SELECT 'INSERT INTO User (IsActive,DateCreated,Login,Password, Email, FirstName, LastName, Search, IsAdministrator) VALUES (1,datetime(''now''),''' + replace(login_utilisateur,'''','''''') + ''',''' + mot_passe+ ''',''' + replace(ISnull(courriel_utilisateur,''),'''','''''') + ''',''' + replace(Isnull(nom_utilisateur,''),'''','''''') + ''',''' + replace(Isnull(prenom_utilisateur,''),'''','''''') + ''',''' + isnull(no_employe,'') + ''',0);' FROM TWEB_LOGIN where no_entreprise = 11 and statut = 'A'
SELECT 'INSERT INTO City (IsActive,DateCreated,Description,Code) VALUES (1,datetime(''now''),''Saint-Jérôme'',''STJER'');'
SELECT 'INSERT INTO Address (IsActive,DateCreated,WayType, Way, No,PostalCode, City,Country) VALUES (1,datetime(''now''),''Rue'',''Longpré #200'',''300'',''J7Y 3B9'', (SELECT Id FROM City WHERE Code = ''STJER''),38);'
SELECT 'INSERT INTO EnterpriseAddress (IsActive,DateCreated,Enterprise, Address, AddressType) VALUES (1,datetime(''now''),2,(select max(id) from Address),''Billing'');'
SELECT 'INSERT INTO EnterpriseAddress (IsActive,DateCreated,Enterprise, Address, AddressType) VALUES (1,datetime(''now''),2,(select max(id) from Address),''Shipping'');'
SELECT 'INSERT INTO Customer (IsActive,DateCreated,User, CustomerNumber, Enterprise, IsInvoicePossible, CustomerType) SELECT 1,datetime(''now''),Id, Search, 2, 1, 1 FROM User;'

select 'update product set ident = trim(ident);'
SELECT 'update product set name = trim(replace(name,ident,''''));'
SELECT 'update User set Search = FirstName || '' '' || LastName || '' '' || Email, ComboBoxDescription = FirstName || '' '' || LastName || '' '' || Email;'
SELECT 'update ProductCategory set Search = Description, ComboBoxDescription = Description;'
SELECT 'update Product set Search = ident || '' '' || description || '' '' || name, ComboBoxDescription = ident || ''-'' || name;'
SELECT 'update Stock set Search = (SELECT Search FROM Product WHERE Stock.Product = Product.Id), ComboBoxDescription = (SELECT ComboBoxDescription FROM Product WHERE Stock.Product = Product.Id);'
SELECT 'update Address set Search = WayType || '' '' || Way || '' '' || No || '' '' || PostalCode, ComboBoxDescription = WayType || '' '' || Way || '' '' || No || '' '' || PostalCode;'
SELECT 'update EnterpriseAddress set Search = (SELECT Search FROM Address WHERE EnterpriseAddress.Address = Address.Id), ComboBoxDescription = (SELECT Search FROM Address WHERE EnterpriseAddress.Address = Address.Id) || AddressType;'

select 'INSERT INTO convertir (ident, url) VALUES (''' + identifiant_produit + ''',''' + url_fichier + ''');', * from FICHIER_PRODUIT inner join produit on FICHIER_PRODUIT.no_produit = PRODUIT.no_produit and url_fichier is not null and PRODUIT.no_entreprise = 11






INSERT INTO convertir (ident, url) VALUES ('CIM-123W','Chemise femme de Ash City.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-101W','color_991_18.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-106W ','polotrimarkf.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-110W','Molleton.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-113W ','colV.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-114W ','CIM-114W.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-114W XX ','Chandail.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-120W','Manteau.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-121W','VESTEEE.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-125W ','Golf.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-101 ','CHAN.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-106','polotrimarkh.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-110 ','Molleton.jpg');
INSERT INTO convertir (ident, url) VALUES (' CIM-113 ','Colv2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-114 ','col mock.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-114XX','col mock.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-120 ','manteau2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-121 ','Veste2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-123','Chemise homme de Ash City.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-125  ','polo2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-104 ','coool.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-105 ','cim-105.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-115 ','cim-115.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-122','cim-122.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-124 ','cim-124.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-201','CIM-201.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-200','CIM-200.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-201','CIM-201.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-202','CIM-202.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-203','CIM-203.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-205','CIM-205.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-206','CIM-206.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-207','CIM-207.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-208','CIM-208.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-212','CIM-212.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-213','CIM-213.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-214','CIM-214.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-215','CIM-215.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-300','CIM-300.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-301','CIM-301.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-304','CIM-304.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-305','CIM-304.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-400','CIM-400.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-401','CIM-401.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-402','CIM-402.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-403','CIM-403.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-404','CIM-404.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-405','CIM-405.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-500','CIM-500.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-503','CIM-503.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-504','CIM-504.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-505','CIM-505.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-506','CIM-506.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-507','CIM-507.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-508','cim-508.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-600','CIM-600.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-204','CIM-204.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-406','CIM-406.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-216','CIM-216.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-407','saccima.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-125','cimcoupevent.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-126','cimT-SHIRT MANCHE LONGUE.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-127','manteaumarine.jpg');
INSERT INTO convertir (ident, url) VALUES (' CIM-113 ','Colv2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-101 ','CHAN.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-101W','color_991_18.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-104 ','coool.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-106','polotrimarkh.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-106W ','polotrimarkf.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-110 ','Molleton.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-110W','Molleton.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-114 ','col mock.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-114W ','Chandail.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-113W ','colV.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-120 ','manteau2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-115 ','cim-115.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-120W','Manteau.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-121 ','Veste2.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-121W','VESTEEE.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-123','Chemise homme de Ash City.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-123W','Chemise femme de Ash City.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-127','manteaumarine.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-122','cim-122.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-124 ','cim-124.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-125','cimcoupevent.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-126','cimT-SHIRT MANCHE LONGUE.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-201','CIM-201.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-203','CIM-203.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-204','CIM-204.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-205','CIM-205.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-206','CIM-206.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-207','CIM-207.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-212','CIM-212.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-213','CIM-213.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-214','CIM-214.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-215','CIM-215.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-216','CIM-216.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-300','CIM-300.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-301','CIM-301.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-304','CIM-304.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-305','CIM-304.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-400','CIM-400.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-401','CIM-401.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-402','CIM-402.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-403','CIM-403.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-404','CIM-404.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-405','CIM-405.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-407','saccima.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-500','CIM-500.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-503','CIM-503.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-504','CIM-504.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-505','CIM-505.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-506','CIM-506.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-507','CIM-507C.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-508','cim-508.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-600','CIM-600.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-306','cimCLE USB - 4 G.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-306','cimCLE USB - 4 G.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-408','CIM-408.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-408','CIM-408.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-409','saccima.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-409','saccima.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-123W','Chemise femme de Ash City.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-217','CIM-217.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-217','CIM-217.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-307','CIM-307.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-307','CIM-307.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-308','CIM-308.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-308','CIM-308.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-218','CIM-218.jpg');
INSERT INTO convertir (ident, url) VALUES ('CIM-218','CIM-218.jpg');