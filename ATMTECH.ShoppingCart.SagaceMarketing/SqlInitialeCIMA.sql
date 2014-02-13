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


