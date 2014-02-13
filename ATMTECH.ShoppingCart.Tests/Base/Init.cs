using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Constant;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Tests.Builder;
using ErrorCode = ATMTECH.Common.ErrorCode;

namespace ATMTECH.ShoppingCart.Tests.Base
{
    public class Init
    {
        private void CreateDatabase()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.ShoppingCart.Tests\Database\ShoppingCart.db3";
            string sqlDropTable = string.Empty;
            string sql = string.Empty;
            ManageClass manageClass = new ManageClass();

            const string nameSpaceAtmtech = "ATMTECH.Entities";
            IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            foreach (string s in listAtmtech.Where(s => s != "EntityInformation" && s != "EntityProperty" && s != "Localization"))
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s);
            }
            
            const string nameSpace = "ATMTECH.ShoppingCart.Entities";
            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpace, s);
            }

            BaseDao<Product, int> dao = new BaseDao<Product, int>();

            dao.ExecuteSql(sqlDropTable);
            dao.ExecuteSql(sql);
        }
        private static void CreateErrorMessage()
        {
            BaseDao<Message, int> dao = new BaseDao<Message, int>();
            Message message1 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_BILLING_ADDRESS_NULL, Language = "fr", Description = "L'adresse de facturation ne peut pas être vide." };
            Message message2 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ENTERPRISE_CANT_ORDER, Language = "fr", Description = "Cette entreprise ne peut pas passer de commande." };
            Message message3 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ENTERPRISE_NULL_ORDER, Language = "fr", Description = "Aucune entreprise associé à la commande." };
            Message message4 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ORDERLINE_COUNT_ZERO, Language = "fr", Description = "Aucune ligne de commande." };
            Message message5 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ORDERLINE_NULL, Language = "fr", Description = "Aucune ligne de commande." };
            Message message6 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ORDERLINE_PRODUCT_ID_ZERO, Language = "fr", Description = "Le produit dans une des lignes de commandes est inconnu." };
            Message message7 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ORDERSTATUS_UNKNOWN, Language = "fr", Description = "Statut de la commande inconnu." };
            Message message8 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ORDER_CREATE_NOT_ZERO, Language = "fr", Description = "On ne peut pas créer une commande en affectant un ID." };
            Message message9 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_SHIPPING_ADDRESS_NULL, Language = "fr", Description = "L'adresse de'envoi ne peut pas être vide." };
            Message message10 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_ORDER_NULL, Language = "fr", Description = "La commande ne peut pas être vide" };
            Message message11 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_NO_USER_AUTHENTICATED, Language = "fr", Description = "Vous ne pouvez pas exécuter cette action si vous n'êtes pas préalablement authentifié par le système." };
            Message message12 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_NO_TAXE_TYPE, Language = "fr", Description = "Aucun type de taxe fourni" };
            Message message13 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_NO_CUSTOMER_LINKED_TO_ORDER, Language = "fr", Description = "Il n'y pas de client lié à la commande." };
            Message message14 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_THIS_PRODUCT_NUMBER_DONT_EXIST, Language = "fr", Description = "Ce produit n'existe pas dans le système" };
            Message message15 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_PUROLATOR_ERROR, Language = "fr", Description = "Erreur avec le service de purolator." };
            Message message16 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_SEND_MAIL_FAILED, Language = "fr", Description = "L'envoi de courriel n'a pas fonctionné." };
            Message message17 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM, Language = "fr", Description = "Le mot de passe saisi ne correspond pas à la confirmation." };
            Message message18 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_INVALID_EMAIL, Language = "fr", Description = "Le courriel que vous avez saisie est invalide." };
            Message message19 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_THIS_USER_ALREADY_EXIST, Language = "fr", Description = "Cet utilisateur existe déjà." };
            Message message20 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_CUSTOMER_IS_NULL, Language = "fr", Description = "Erreur technique customer est null." };
            Message message21 = new Message { InnerId = ErrorCode.ADM_BAD_LOGIN, Language = "fr", Description = "Vos informations d'identification ne sont pas valide." };
            Message message22 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_SHIPPING_PARAMETER_CANNOT_BE_NULL, Language = "fr", Description = "Le parametre de shipping ne peut être null, message destiné aux développeurs" };
            Message message23 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM, Language = "fr", Description = "Vous ne pouvez pas confirmer cet utilisateur" };
            Message message24 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_CAPTCHA_INVALID, Language = "fr", Description = "Veuillez saisir les chiffres dans l'image." };
            Message message25 = new Message { InnerId = ErrorCode.ADM_UPS_EMPTY_ERROR, Language = "fr", Description = "Aucune donnée envoyé de UPS" };
            Message message26 = new Message { InnerId = ErrorCode.ADM_UPS_ERROR, Language = "fr", Description = "Erreur avec UPS" };
            Message message27 = new Message { InnerId = ErrorCode.ADM_UPS_TIMEOUT_ERROR, Language = "fr", Description = "Erreur de connection avec UPS" };
            Message message28 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_SHIPPING_CODE_DONT_EXIST, Language = "fr", Description = "Le code d'envoi n'existe pas" };
            Message message29 = new Message { InnerId = ShoppingCart.Services.ErrorCode.ErrorCode.SC_STOCK_INSUFICIENT, Language = "fr", Description = "L'inventaire pour le produit: {0} étant la quantité maximale en inventaire ce qui est insufisant pour compléter votre commande. Veuillez inscrire une quantité inférieur au maximum." };

            dao.Save(message1);
            dao.Save(message2);
            dao.Save(message3);
            dao.Save(message4);
            dao.Save(message5);
            dao.Save(message6);
            dao.Save(message7);
            dao.Save(message8);
            dao.Save(message9);
            dao.Save(message10);
            dao.Save(message11);
            dao.Save(message12);
            dao.Save(message13);
            dao.Save(message14);
            dao.Save(message15);
            dao.Save(message16);
            dao.Save(message17);
            dao.Save(message18);
            dao.Save(message19);
            dao.Save(message20);
            dao.Save(message21);
            dao.Save(message22);
            dao.Save(message23);
            dao.Save(message24);
            dao.Save(message25);
            dao.Save(message26);
            dao.Save(message27);
            dao.Save(message28);
            dao.Save(message29);
        }

        private static void FillData()
        {

            BaseDao<FileType, int> daoFileType = new BaseDao<FileType, int>();
            FileType fileType1 = new FileType { Code = "jpg", Type = "jpg" };
            FileType fileType2 = new FileType { Code = "png", Type = "png" };
            FileType fileType3 = new FileType { Code = "pdf", Type = "pdf" };
            FileType fileType4 = new FileType { Code = "unk", Type = "unk" };
            fileType1.Id = daoFileType.Save(fileType1);
            fileType2.Id = daoFileType.Save(fileType2);
            fileType3.Id = daoFileType.Save(fileType3);
            fileType4.Id = daoFileType.Save(fileType4);



            BaseDao<Product, int> dao = new BaseDao<Product, int>();
            dao.ExecuteSql("INSERT INTO Country (Description, Code, IsActive) SELECT Name, Iso3, 1 FROM CountryIso");

            BaseDao<Parameter, int> daoParameter = new BaseDao<Parameter, int>();
            Parameter parameter1 = new Parameter { Code = Constant.ADMIN_MAIL, Description = "sagacemarketing@gmail.com" };
            daoParameter.Save(parameter1);
            Parameter parameter2 = new Parameter { Code = Constant.MAIL_BODY_CONFIRM_CREATE, Description = @"Cliquer ici pour confirmer la création de votre compte:<br><br><a href='http:\\dev.sagacemarketing.com\ConfirmCreate.aspx?ConfirmCreate={0}'>Confirmer la création de mon compte</a>" };
            daoParameter.Save(parameter2);
            Parameter parameter3 = new Parameter { Code = Constant.MAIL_SUBJECT_CONFIRM_CREATE, Description = "Nouvelle demande de création de compte" };
            daoParameter.Save(parameter3);
            Parameter parameter4 = new Parameter { Code = Constant.MAIL_SUBJECT_FORGET_PASSWORD, Description = "Une demande d'oubli de mot de passe a été demandé." };
            daoParameter.Save(parameter4);
            Parameter parameter5 = new Parameter { Code = Constant.MAIL_BODY_FORGET_PASSWORD, Description = "Voici votre mot de passe: {0}" };
            daoParameter.Save(parameter5);
            Parameter parameter6 = new Parameter { Code = Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED, Description = "1" };
            daoParameter.Save(parameter6);
            Parameter parameter7 = new Parameter { Code = Constant.MAIL_SUBJECT_ORDER_FINALIZED, Description = "Entete du message quand on finalise la commande" };
            daoParameter.Save(parameter7);
            Parameter parameter8 = new Parameter { Code = Constant.MAIL_BODY_ORDER_FINALIZED, Description = "Corps du message quand on finalise la commande" };
            daoParameter.Save(parameter8);
            Parameter parameter10 = new Parameter { Code = "Environment", Description = "PROD" };
            daoParameter.Save(parameter10);
            Parameter parameter11 = new Parameter { Code = "SmtpServer", Description = "smtp.gmail.com" };
            daoParameter.Save(parameter11);
            Parameter parameter12 = new Parameter { Code = "SmtpServerLogin", Description = "sagacemarketing@gmail.com" };
            daoParameter.Save(parameter12);
            Parameter parameter13 = new Parameter { Code = "SmtpServerPassword", Description = "10sagace01" };
            daoParameter.Save(parameter13);
            Parameter parameter14 = new Parameter { Code = "SmtpServerPort", Description = "587" };
            daoParameter.Save(parameter14);
            Parameter parameter17 = new Parameter { Code = "CountryReceiverCode", Description = "CA" };
            daoParameter.Save(parameter17);
            Parameter parameter18 = new Parameter { Code = "PurolatorBillingAccount", Description = "1539293" };
            daoParameter.Save(parameter18);
            Parameter parameter19 = new Parameter { Code = "PurolatorPassword", Description = "}2Jk-aJ|" };
            daoParameter.Save(parameter19);
            Parameter parameter20 = new Parameter { Code = "PurolatorUserName", Description = "f5effc1701f841d69d8a4a20ffd41ced" };
            daoParameter.Save(parameter20);
            Parameter parameter21 = new Parameter { Code = "PurolatorWebServiceUrl", Description = "https://webservices.purolator.com/EWS/V1/Estimating/EstimatingService.asmx" };
            daoParameter.Save(parameter21);
            Parameter parameter22 = new Parameter { Code = "SenderPostalCode", Description = "G1M3R8" };
            daoParameter.Save(parameter22);
            Parameter parameter23 = new Parameter { Code = "UpsAccessLicenceNumber", Description = "4C351CEF022AC42C" };
            daoParameter.Save(parameter23);
            Parameter parameter24 = new Parameter { Code = "UpsUserId", Description = "upssagace" };
            daoParameter.Save(parameter24);
            Parameter parameter25 = new Parameter { Code = "UpsPassword", Description = "fra321" };
            daoParameter.Save(parameter25);
            Parameter parameter26 = new Parameter { Code = "OrderMessagePaypal", Description = "Commande passé le : {0} pour {1}", Language = "fr" };
            daoParameter.Save(parameter26);
            Parameter parameter27 = new Parameter { Code = "OrderMessagePaypal", Description = "Order on : {0} for {1}", Language = "en" };
            daoParameter.Save(parameter27);
            Parameter parameter28 = new Parameter { Code = "SendMail", Description = "1", Language = "en" };
            daoParameter.Save(parameter28);
            Parameter parameter29 = new Parameter { Code = "TrackingPurolator", Description = "https://eshiponline.purolator.com/ShipOnline/Public/Track/TrackingDetails.aspx?pin={0}", Language = "en" };
            daoParameter.Save(parameter29);
            Parameter parameter30 = new Parameter { Code = "TrackingUps", Description = "http://wwwapps.ups.com/WebTracking/track?HTMLVersion=5.0&Requester=UPSHome&WBPM_lid=homepage%2Fct1.html_pnl_trk&trackNums={0}", Language = "en" };
            daoParameter.Save(parameter30);

            Parameter parameter31 = new Parameter { Code = "MailSubjectOrderConfirmed", Description = "Nous avons confirmé la commande numéro {0}", Language = "fr" };
            daoParameter.Save(parameter31);
            Parameter parameter32 = new Parameter { Code = "MailBodyOrderConfirmed", Description = "Nous avons confirmé la commande numéro {0}, vous pouvez suivre l'envoi du colis par ce lien {1}", Language = "fr" };
            daoParameter.Save(parameter32);

            Parameter parameter33 = new Parameter { Code = Constant.NO_STOCK_AVAILABLE, Description = "Un produit n'a pas d'inventaire, chaque produit créer doit avoir obligatoirement un inventaire. <br> Le produit est: {0}-{1} Entreprise: {2}", Language = "fr" };
            daoParameter.Save(parameter33);


            BaseDao<Taxes, int> daoTaxes = new BaseDao<Taxes, int>();
            Taxes taxes = TaxesBuilder.Create().WithCountry(10).WithRegional(10).WithType("QBC");
            daoTaxes.Save(taxes);

            BaseDao<City, int> daoCity = new BaseDao<City, int>();
            City city1 = CityBuilder.Create().WithCode("QBC").WithDescription("Québec");
            City city2 = CityBuilder.Create().WithCode("MTL").WithDescription("Montréal");
            daoCity.Save(city1);
            daoCity.Save(city2);
            city1.WithId(1);
            city2.WithId(2);

            BaseDao<Country, int> daoCountry = new BaseDao<Country, int>();
            Country country1 = daoCountry.GetAllOneCriteria(BaseEnumeration.CODE, "CAN")[0];
            Country country2 = daoCountry.GetAllOneCriteria(BaseEnumeration.CODE, "AUS")[0];

            BaseDao<Address, int> daoAddress = new BaseDao<Address, int>();
            Address address1 = AddressBuilder.Create().WithWayType("Rue").WithWay("W").WithPostalCode("G1R5P8").WithCity(city1).WithCountry(country1);
            Address address2 = AddressBuilder.Create().WithWayType("Rue").WithWay("X").WithPostalCode("G1R5P8").WithCity(city1).WithCountry(country2);
            Address address3 = AddressBuilder.Create().WithWayType("Rue").WithWay("Y").WithPostalCode("G1R5P8").WithCity(city2).WithCountry(country1);
            Address address4 = AddressBuilder.Create().WithWayType("Rue").WithWay("Z").WithPostalCode("G1R5P8").WithCity(city2).WithCountry(country1);
            daoAddress.Save(address1);
            daoAddress.Save(address2);
            daoAddress.Save(address3);
            daoAddress.Save(address4);
            address1.WithId(1);
            address2.WithId(2);
            address3.WithId(3);
            address4.WithId(4);


            BaseDao<User, int> daoUser = new BaseDao<User, int>();
            User user1 = UserBuilder.Create().WithFirstName("Vincent").WithLastName("Rioux").WithLogin("riov01").WithPassword("test").WithIsAdministrator(true).WithEmail("test@test.com");
            User user2 = UserBuilder.Create().WithFirstName("Vicky").WithLastName("Pommerleau").WithLogin("pomv01").WithPassword("test").WithEmail("test@test.com");
            User user3 = UserBuilder.Create().WithFirstName("Frank").WithLastName("Cotroni").WithLogin("cotf01").WithPassword("test").WithEmail("test@test.com");
            User user4 = UserBuilder.Create().WithFirstName("Nikita").WithLastName("Kroutchev").WithLogin("kron01").WithPassword("test").WithEmail("test@test.com");
            User user5 = UserBuilder.Create().WithFirstName("Administrateur").WithLastName("Administrateur").WithLogin("admin").WithPassword("test").WithIsAdministrator(true).WithEmail("test@test.com");
            daoUser.Save(user1);
            daoUser.Save(user2);
            daoUser.Save(user3);
            daoUser.Save(user4);
            daoUser.Save(user5);
            user1.WithId(1);
            user2.WithId(2);
            user3.WithId(3);
            user4.WithId(4);
            user5.WithId(5);

            BaseDao<CustomerType, int> daoCustomerType = new BaseDao<CustomerType, int>();
            CustomerType customerType1 = CustomerTypeBuilder.Create().WithCode("EMP").WithDescription("Employe");
            CustomerType customerType2 = CustomerTypeBuilder.Create().WithCode("DIR").WithDescription("Directeur");
            CustomerType customerType3 = CustomerTypeBuilder.Create().WithCode("VP").WithDescription("Vice président");
            daoCustomerType.Save(customerType1);
            daoCustomerType.Save(customerType2);
            daoCustomerType.Save(customerType3);
            customerType1.WithId(1);
            customerType2.WithId(2);
            customerType3.WithId(3);

            BaseDao<File, int> daoFile = new BaseDao<File, int>();
            File file1 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\Jacket1.jpg",
                FileName = "Jacket1.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file1.Id = daoFile.Save(file1);


            File file2 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\Jacket2.jpg",
                FileName = "Jacket2.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file2.Id = daoFile.Save(file2);


            File file3 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\Jacket3.jpg",
                FileName = "Jacket3.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file3.Id = daoFile.Save(file3);

            File file4 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\Tuque.jpg",
                FileName = "tuque.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file4.Id = daoFile.Save(file4);

            File file6 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\Stylo.jpg",
                FileName = "Stylo.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file6.Id = daoFile.Save(file6);

            File file5 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\trotinette.jpg",
                FileName = "trotinette.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file5.Id = daoFile.Save(file5);

            File file7 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Product\Jacket1_2.jpg",
                FileName = "Jacket1_2.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Product"
            };
            file7.Id = daoFile.Save(file7);

            File file8 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Enterprise\BoutiqueCorporative.jpg",
                FileName = "BoutiqueCorporative.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Enterprise"
            };
            file8.Id = daoFile.Save(file8);

            File file9 = new File
            {
                ServerPath = @"C:\dev\Atmtech\ATMTECH.ShoppingCart.WebSite\Images\Enterprise\Cima.jpg",
                FileName = "Cima.jpg",
                FileType = fileType1,
                Size = 20100,
                Category = "Enterprise"
            };
            file9.Id = daoFile.Save(file9);


            BaseDao<Enterprise, int> daoEnterprise = new BaseDao<Enterprise, int>();
            Enterprise enterprise1 = EnterpriseBuilder.Create().WithName("Boutique Corporative").WithIsOrderPossible(false).WithImageUrl(file8).WithFrenchWelCome("Bienvenue sur notre espace corporatif, vous devez vous authentifiez par le bouton Ouvrir une session").WithEnglishWelcome("Welcome open session");
            Enterprise enterprise2 = EnterpriseBuilder.Create().WithName("Cima").WithIsOrderPossible(true).WithFrenchInformations("informations en francais CIMA").WithEnglishInformations("Informations english CIMA").WithFrenchContact("Contact en francais CIMA").WithEnglishContact("Contact English CIMA").WithImageUrl(file9).WithFrenchWelCome("Bienvenue ! Nous sommes fiers de vous présenter la nouvelle gamme de produit produits promotionnels").WithEnglishWelcome("Welcome ! We are proud");
            daoEnterprise.Save(enterprise1);
            daoEnterprise.Save(enterprise2);
            enterprise1.WithId(1);
            enterprise2.WithId(2);

            BaseDao<EnterpriseAddress, int> daoEnterpriseAddress = new BaseDao<EnterpriseAddress, int>();
            EnterpriseAddress enterpriseAddress1 = EnterpriseAddressBuilder.Create().WithAddress(address1).WithEnterprise(enterprise2).WithAddressType(EnterpriseAddress.CODE_ADRESS_TYPE_BILLING);
            EnterpriseAddress enterpriseAddress2 = EnterpriseAddressBuilder.Create().WithAddress(address2).WithEnterprise(enterprise2).WithAddressType(EnterpriseAddress.CODE_ADRESS_TYPE_SHIPPING);
            EnterpriseAddress enterpriseAddress3 = EnterpriseAddressBuilder.Create().WithAddress(address3).WithEnterprise(enterprise2).WithAddressType(EnterpriseAddress.CODE_ADRESS_TYPE_BILLING);
            EnterpriseAddress enterpriseAddress4 = EnterpriseAddressBuilder.Create().WithAddress(address4).WithEnterprise(enterprise2).WithAddressType(EnterpriseAddress.CODE_ADRESS_TYPE_SHIPPING);
            daoEnterpriseAddress.Save(enterpriseAddress1);
            daoEnterpriseAddress.Save(enterpriseAddress2);
            daoEnterpriseAddress.Save(enterpriseAddress3);
            daoEnterpriseAddress.Save(enterpriseAddress4);

            BaseDao<Customer, int> daoCustomer = new BaseDao<Customer, int>();

            Customer customer1 = CustomerBuilder.Create().WithUser(user1).WithCustomerNumber("1").WithCustomerType(customerType1).WithIsPaypalRequired(true).WithTaxes(taxes).WithIsPaypalAuthorized(true).WithEnterprise(enterprise2);
            Customer customer2 = CustomerBuilder.Create().WithUser(user2).WithCustomerNumber("2").WithCustomerType(customerType2).WithIsPaypalRequired(false).WithTaxes(taxes).WithIsPaypalAuthorized(false).WithEnterprise(enterprise2);
            Customer customer3 = CustomerBuilder.Create().WithUser(user3).WithCustomerNumber("3").WithCustomerType(customerType2).WithIsPaypalRequired(false).WithTaxes(taxes).WithIsPaypalAuthorized(false).WithEnterprise(enterprise2);
            Customer customer4 = CustomerBuilder.Create().WithUser(user5).WithCustomerNumber("5").WithCustomerType(customerType1).WithIsPaypalRequired(true).WithTaxes(taxes).WithIsPaypalAuthorized(true).WithEnterprise(enterprise2);
            daoCustomer.Save(customer1);
            daoCustomer.Save(customer2);
            daoCustomer.Save(customer3);
            daoCustomer.Save(customer4);
            customer1.WithId(1);
            customer2.WithId(2);
            customer3.WithId(3);
            customer4.WithId(4);


            BaseDao<Supplier, int> daoSupplier = new BaseDao<Supplier, int>();
            Supplier supplier1 = SupplierBuilder.Create().WithName("Adidas");
            Supplier supplier2 = SupplierBuilder.Create().WithName("Lois");
            Supplier supplier3 = SupplierBuilder.Create().WithName("Peugeot");
            Supplier supplier4 = SupplierBuilder.Create().WithName("Voyage sol");
            daoSupplier.Save(supplier1);
            daoSupplier.Save(supplier2);
            daoSupplier.Save(supplier3);
            daoSupplier.Save(supplier4);
            supplier1.WithId(1);
            supplier2.WithId(2);
            supplier3.WithId(3);
            supplier4.WithId(4);


            BaseDao<ProductCategory, int> daoProductCategory = new BaseDao<ProductCategory, int>();
            ProductCategory productCategory1 = ProductCategoryBuilder.Create().WithCode("VET").WithDescription("Vêtement").WithEnterprise(enterprise2).WithLanguage(LocalizationLanguage.FRENCH);
            ProductCategory productCategory2 = ProductCategoryBuilder.Create().WithCode("BUR").WithDescription("Article de bureau").WithEnterprise(enterprise2).WithLanguage(LocalizationLanguage.FRENCH);
            ProductCategory productCategory3 = ProductCategoryBuilder.Create().WithCode("SPORT").WithDescription("Article de sport").WithEnterprise(enterprise2).WithLanguage(LocalizationLanguage.FRENCH);
            daoProductCategory.Save(productCategory1);
            daoProductCategory.Save(productCategory2);
            daoProductCategory.Save(productCategory3);
            productCategory1.WithId(1);
            productCategory2.WithId(2);
            productCategory3.WithId(3);

        

            BaseDao<Product, int> daoProduct = new BaseDao<Product, int>();
            Product product1 = ProductBuilder.Create().WithCostPrice(110).WithUnitPrice(Convert.ToDecimal(124.99)).WithName("Veston de jeans").WithIdent("CIM-01").WithEnterprise(enterprise2).WithSupplier(supplier1).WithWeight(5).WithProductCategory(productCategory1).WithLanguage(LocalizationLanguage.FRENCH).WithDescription("Veston de jeans de qualité supérieur");
            Product product2 = ProductBuilder.Create().WithCostPrice(150).WithUnitPrice(Convert.ToDecimal(299.99)).WithName("Manteau d'hiver").WithIdent("CIM-02").WithEnterprise(enterprise2).WithSupplier(supplier2).WithWeight(5).WithProductCategory(productCategory1).WithLanguage(LocalizationLanguage.FRENCH).WithDescription("Manteau d'hiver de qualité supérieur");
            Product product3 = ProductBuilder.Create().WithCostPrice(50).WithUnitPrice(Convert.ToDecimal(79.95)).WithName("Manteau coquille verte").WithIdent("CIM-03").WithEnterprise(enterprise2).WithSupplier(supplier3).WithWeight(5).WithProductCategory(productCategory1).WithLanguage(LocalizationLanguage.FRENCH).WithDescription("Manteau vert de qualité supérieur");
            Product product4 = ProductBuilder.Create().WithCostPrice(3).WithUnitPrice(12).WithName("Tuque").WithIdent("CIM-04").WithEnterprise(enterprise2).WithSupplier(supplier3).WithWeight(5).WithProductCategory(productCategory1).WithLanguage(LocalizationLanguage.FRENCH).WithDescription("Tuque de qualité supérieur");
            Product product5 = ProductBuilder.Create().WithCostPrice(75).WithUnitPrice(100).WithName("Trotinette").WithIdent("CIM-05").WithEnterprise(enterprise2).WithSupplier(supplier3).WithWeight(5).WithProductCategory(productCategory3).WithLanguage(LocalizationLanguage.FRENCH).WithDescription("Trotinette de qualité supérieur");
            Product product6 = ProductBuilder.Create().WithCostPrice(4).WithUnitPrice(100).WithName("Stylo").WithIdent("CIM-06").WithEnterprise(enterprise2).WithSupplier(supplier3).WithWeight(5).WithProductCategory(productCategory2).WithLanguage(LocalizationLanguage.FRENCH).WithDescription("Stylo de qualité supérieur"); ;
            daoProduct.Save(product1);
            daoProduct.Save(product2);
            daoProduct.Save(product3);
            daoProduct.Save(product4);
            daoProduct.Save(product5);
            daoProduct.Save(product6);
            product1.WithId(1);
            product2.WithId(2);
            product3.WithId(3);
            product4.WithId(4);
            product5.WithId(5);
            product6.WithId(6);

            BaseDao<ProductFile, int> daoProductFile = new BaseDao<ProductFile, int>();
            ProductFile productFile1_1 = ProductFileBuilder.Create().WithProduct(product1).WithFile(file1).IsPrincipal(true);
            ProductFile productFile1_2 = ProductFileBuilder.Create().WithProduct(product1).WithFile(file7).IsPrincipal(false);
            ProductFile productFile1_3 = ProductFileBuilder.Create().WithProduct(product1).WithFile(file2).IsPrincipal(false).WithProductLinked(product2);
            ProductFile productFile2 = ProductFileBuilder.Create().WithProduct(product2).WithFile(file2).IsPrincipal(true);
            ProductFile productFile3 = ProductFileBuilder.Create().WithProduct(product3).WithFile(file3).IsPrincipal(true);
            ProductFile productFile4 = ProductFileBuilder.Create().WithProduct(product4).WithFile(file4).IsPrincipal(true);
            ProductFile productFile5 = ProductFileBuilder.Create().WithProduct(product5).WithFile(file5).IsPrincipal(true);
            ProductFile productFile6 = ProductFileBuilder.Create().WithProduct(product6).WithFile(file6).IsPrincipal(true);

            daoProductFile.Save(productFile1_1);
            daoProductFile.Save(productFile1_2);
            daoProductFile.Save(productFile1_3);
            daoProductFile.Save(productFile2);
            daoProductFile.Save(productFile3);
            daoProductFile.Save(productFile4);
            daoProductFile.Save(productFile5);
            daoProductFile.Save(productFile6);



            // Sécurité
            //Group group1 = new Group { Name = "IsRead: false, IsOrderable: false sur produit 1" };
            //Group group2 = new Group { Name = "IsRead: true, IsOrderable: false sur produit 2" };
            //Group group3 = new Group { Name = "IsRead: true, IsOrderable: true sur produit 3" };
            //BaseDao<Group, int> daoGroup = new BaseDao<Group, int>();
            //daoGroup.Save(group1);
            //daoGroup.Save(group2);
            //daoGroup.Save(group3);
            //group1.Id = 1;
            //group2.Id = 2;
            //group3.Id = 3;

            //BaseDao<GroupUser, int> daoGroupUser = new BaseDao<GroupUser, int>();
            //GroupUser groupUser1 = new GroupUser { Group = group1, User = user1 };
            //GroupUser groupUser2 = new GroupUser { Group = group2, User = user2 };
            //GroupUser groupUser3 = new GroupUser { Group = group3, User = user3 };
            //daoGroupUser.Save(groupUser1);
            //daoGroupUser.Save(groupUser2);
            //daoGroupUser.Save(groupUser3);

            //BaseDao<GroupProduct, int> daoGroupProduct = new BaseDao<GroupProduct, int>();
            //GroupProduct groupProduct1 = new GroupProduct { Group = group1, IsRead = false, IsOrderable = false, Product = product1 };
            //GroupProduct groupProduct2 = new GroupProduct { Group = group2, IsRead = true, IsOrderable = false, Product = product2 };
            //GroupProduct groupProduct3 = new GroupProduct { Group = group2, IsRead = true, IsOrderable = true, Product = product3 };
            //daoGroupProduct.Save(groupProduct1);
            //daoGroupProduct.Save(groupProduct2);
            //daoGroupProduct.Save(groupProduct3);


            BaseDao<Stock, int> daoStock = new BaseDao<Stock, int>();
            Stock stock1_1 = StockBuilder.Create().WithProduct(product1).WithInitialState(100).WithFeature("Petit");
            Stock stock1_2 = StockBuilder.Create().WithProduct(product1).WithInitialState(100).WithFeature("Large");
            Stock stock1_3 = StockBuilder.Create().WithProduct(product1).WithInitialState(100).WithFeature("XLarge");

            Stock stock3 = StockBuilder.Create().WithProduct(product2).WithInitialState(200).WithFeature("Bleu");
            Stock stock4 = StockBuilder.Create().WithProduct(product3).WithInitialState(10).WithFeature("Vert");
            Stock stock5 = StockBuilder.Create().WithProduct(product4).WithInitialState(10).WithFeature("Avec écriture brodé");
            Stock stock6 = StockBuilder.Create().WithProduct(product5).WithInitialState(10).WithFeature("Avec décalque de la compagnie");
            daoStock.Save(stock1_1);
            daoStock.Save(stock1_2);
            daoStock.Save(stock1_3);
            daoStock.Save(stock3);
            daoStock.Save(stock4);
            daoStock.Save(stock5);
            daoStock.Save(stock6);
            stock1_1.WithId(1);
            stock1_2.WithId(2);
            stock1_3.WithId(3);
            stock3.WithId(4);
            stock4.WithId(5);
            stock5.WithId(6);
            stock6.WithId(7);

        }

        public void InitDatabaseForTest()
        {
            CreateDatabase();
            CreateErrorMessage();
            FillData();
        }

    }
}
