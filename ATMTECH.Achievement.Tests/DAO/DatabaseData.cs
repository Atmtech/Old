using System;
using System.IO;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.ErrorCode;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Test.Builder;
using ATMTECH.Web.Services.Base;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Achievement.Tests.DAO
{
    public class DatabaseData
    {
        public string ConnectionString { get; set; }

        public void FillData()
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



            BaseDao<Parameter, int> daoParameter = new BaseDao<Parameter, int>();
            Parameter parameter1 = new Parameter { Code = ParameterConstant.ADMIN_MAIL, Description = "test@test.com" };
            daoParameter.Save(parameter1);
            Parameter parameter2 = new Parameter { Code = ParameterConstant.MAIL_BODY_CONFIRM_CREATE, Description = @"Cliquer ici pour confirmer la création de votre compte:<br><br><a href='http:\\dev.sagacemarketing.com\ConfirmCreate.aspx?ConfirmCreate={0}'>Confirmer la création de mon compte</a>" };
            daoParameter.Save(parameter2);
            Parameter parameter3 = new Parameter { Code = ParameterConstant.MAIL_SUBJECT_CONFIRM_CREATE, Description = "Nouvelle demande de création de compte" };
            daoParameter.Save(parameter3);
            Parameter parameter4 = new Parameter { Code = ParameterConstant.MAIL_SUBJECT_FORGET_PASSWORD, Description = "Une demande d'oubli de mot de passe a été demandé." };
            daoParameter.Save(parameter4);
            Parameter parameter5 = new Parameter { Code = ParameterConstant.MAIL_BODY_FORGET_PASSWORD, Description = "Voici votre mot de passe: {0}" };
            daoParameter.Save(parameter5);

            BaseDao<Message, int> dao = new BaseDao<Message, int>();
            Message message1 = new Message { InnerId = ErrorCode.ACH_AUCUNE_QUALITE_ASSOCIE_ACCOMPLISSEMENT, Language = "fr", Description = "Aucune qualité associé" };
            dao.Save(message1);

            BaseDao<User, int> daoUser = new BaseDao<User, int>();
            User user1 = UserBuilder.Create().WithId(0).WithFirstName("Vincent").WithLastName("Rioux").WithLogin("sagaan@hotmail.com").WithPassword("test").WithIsAdministrator(true).WithEmail("sagaan@hotmail.com");
            int idUser1 = daoUser.Save(user1);
            user1.Id = idUser1;
            User user2 = UserBuilder.Create().WithId(0).WithFirstName("Jan").WithLastName("23").WithLogin("test@hotmail.com").WithPassword("test").WithIsAdministrator(true).WithEmail("test@hotmail.com");
            int idUser2 = daoUser.Save(user2);
            user2.Id = idUser2;

            CreerDiscussion(user1, user2);

            BaseDao<Categorie, int> daoCategorie = new BaseDao<Categorie, int>();
            Categorie categorie1 = new Categorie { Code = "SEX", Description = "Sexualité" };
            Categorie categorie2 = new Categorie { Code = "SOC", Description = "Sociales" };
            Categorie categorie3 = new Categorie { Code = "CON", Description = "Consommation" };
            Categorie categorie4 = new Categorie { Code = "SPORT", Description = "Sports" };
            Categorie categorie5 = new Categorie { Code = "TRAV", Description = "Travail" };
            Categorie categorie6 = new Categorie { Code = "PASS", Description = "Passe-temps" };
            Categorie categorie7 = new Categorie { Code = "INS", Description = "Insolite" };
            Categorie categorie8 = new Categorie { Code = "EDUC", Description = "Éducation" };
            Categorie categorie9 = new Categorie { Code = "LANG", Description = "Langage" };
            Categorie categorie10 = new Categorie { Code = "TAL", Description = "Talent" };

            daoCategorie.Save(categorie1);
            daoCategorie.Save(categorie2);
            daoCategorie.Save(categorie3);
            daoCategorie.Save(categorie4);
            daoCategorie.Save(categorie5);
            daoCategorie.Save(categorie6);
            daoCategorie.Save(categorie7);
            daoCategorie.Save(categorie8);
            daoCategorie.Save(categorie9);
            daoCategorie.Save(categorie10);


            BaseDao<File, int> daoFile = new BaseDao<File, int>();
            string[] array1 = Directory.GetFiles(@"C:\dev\atmtech\ATMTECH.Achievement.WebSite\images\Badge");

            foreach (string s in array1)
            {
                FileInfo fileInfo = new FileInfo(s);

                File file = new File
                {
                    Category = "badge",
                    FileType = fileType1,
                    FileName = Path.GetFileName(s),
                    Size = (int)fileInfo.Length
                };

                daoFile.Save(file);
            }

            CreerToutTrait();

            CreerAccomplissement("SEX", "Hit n run", "Avoir embrassé un étranger dans un endroit public", "#FF99CC", "kiss-48.png", "442", "350", "37");
            CreerAccomplissement("TAL", "Un bâtisseur", "Avoir construit une maison complête sans l'aide de personne", "#CCCCFF", "home-48.png", "255", "123", "136");

            CreerAccomplissementUtilisateur("Hit n run");
            CreerAccomplissementUtilisateur("Un bâtisseur");

        }
        private void CreerDiscussion(User user, User repondant)
        {
            BaseDao<Discussion, int> daoDiscussion = new BaseDao<Discussion, int>();
            Discussion discussion = new Discussion
            {
                Utilisateur = user,
                Description =
                    "Je viens de me rendre compte que les gens sont des gens de partout",
                DateCreated = DateTime.Now
            };
            int idDiscussion = daoDiscussion.Save(discussion);
            discussion.Id = idDiscussion;

            BaseDao<DiscussionReponse, int> daoDiscussionReponse = new BaseDao<DiscussionReponse, int>();
            DiscussionReponse discussionReponse1 = new DiscussionReponse
            {
                Discussion = discussion,
                Utilisateur = repondant,
                Description =
                    "tu dis vraiment ça pour me faire fâcher tu sais",
                DateCreated = DateTime.Now
            };

            daoDiscussionReponse.Save(discussionReponse1);


            DiscussionReponse discussionReponse2 = new DiscussionReponse
            {
                Discussion = discussion,
                Utilisateur = user,
                Description =
                    "Mais non pas du tout ! ",
                DateCreated = DateTime.Now.AddMinutes(10)
            };

            daoDiscussionReponse.Save(discussionReponse2);

        }

        private void CreerToutTrait()
        {
            CreerTrait("1", "A l'écoute");
            CreerTrait("2", "Abordable");
            CreerTrait("3", "Accessible");
            CreerTrait("4", "Accompli");
            CreerTrait("5", "Accueillant");
            CreerTrait("6", "Actif");
            CreerTrait("7", "Admirable");
            CreerTrait("8", "Adorable");
            CreerTrait("9", "Adroit");
            CreerTrait("10", "Affable");
            CreerTrait("11", "Affectueux");
            CreerTrait("12", "Affirmatif");
            CreerTrait("13", "Agréable");
            CreerTrait("14", "Aidant");
            CreerTrait("15", "Aimable");
            CreerTrait("16", "Aimant");
            CreerTrait("17", "Ambitieux");
            CreerTrait("18", "Amical");
            CreerTrait("19", "Amusant");
            CreerTrait("20", "Animé");
            CreerTrait("21", "Apaisant");
            CreerTrait("22", "Appliqué");
            CreerTrait("23", "Ardent");
            CreerTrait("24", "Artistique");
            CreerTrait("25", "Assertif");
            CreerTrait("26", "Assidu");
            CreerTrait("27", "Astucieux");
            CreerTrait("28", "Attachant");
            CreerTrait("29", "Attentif");
            CreerTrait("30", "Attentionné");
            CreerTrait("31", "Attractif");
            CreerTrait("32", "Audacieux");
            CreerTrait("33", "Authentique");
            CreerTrait("34", "Autonome");
            CreerTrait("35", "Autoritaire");
            CreerTrait("36", "Avenant");
            CreerTrait("37", "Aventureux");
            CreerTrait("38", "Bavard");
            CreerTrait("39", "Beau");
            CreerTrait("40", "Bienfaisant");
            CreerTrait("41", "Bienséant");
            CreerTrait("42", "Bienveillant");
            CreerTrait("43", "Bon");
            CreerTrait("44", "Brave");
            CreerTrait("45", "Brillant");
            CreerTrait("46", "Bûcheur");
            CreerTrait("47", "Câlin");
            CreerTrait("48", "Calme");
            CreerTrait("49", "Capable");
            CreerTrait("50", "Captivant");
            CreerTrait("51", "Chaleureux");
            CreerTrait("52", "Chanceux");
            CreerTrait("53", "Charismatique");
            CreerTrait("54", "Charitable");
            CreerTrait("55", "Charmant");
            CreerTrait("56", "Charmeur");
            CreerTrait("57", "Chouette");
            CreerTrait("58", "Civil");
            CreerTrait("59", "Clément");
            CreerTrait("60", "Cohérent");
            CreerTrait("61", "Collaborateur");
            CreerTrait("62", "Combatif");
            CreerTrait("63", "Comique");
            CreerTrait("64", "Communicatif");
            CreerTrait("65", "Compatissant");
            CreerTrait("66", "Compétent");
            CreerTrait("67", "Compétitif");
            CreerTrait("68", "Complaisant");
            CreerTrait("69", "Complice");
            CreerTrait("70", "Compréhensif");
            CreerTrait("71", "Concentré");
            CreerTrait("72", "Concerné");
            CreerTrait("73", "Conciliant");
            CreerTrait("74", "Confiant");
            CreerTrait("75", "Consciencieux");
            CreerTrait("76", "Conséquent");
            CreerTrait("77", "Constant");
            CreerTrait("78", "Content");
            CreerTrait("79", "Convaincant");
            CreerTrait("80", "Convenable");
            CreerTrait("81", "Coopératif");
            CreerTrait("82", "Courageux");
            CreerTrait("83", "Courtois");
            CreerTrait("84", "Créatif");
            CreerTrait("85", "Critique");
            CreerTrait("86", "Cultivé");
            CreerTrait("87", "Curieux");
            CreerTrait("88", "Débonnaire");
            CreerTrait("89", "Débrouillard");
            CreerTrait("90", "Décidé");
            CreerTrait("91", "Décontracté");
            CreerTrait("92", "Délicat");
            CreerTrait("93", "Détendu");
            CreerTrait("94", "Déterminé");
            CreerTrait("95", "Dévoué");
            CreerTrait("96", "Digne");
            CreerTrait("97", "Digne de confiance");
            CreerTrait("98", "Diligent");
            CreerTrait("99", "Diplomate");
            CreerTrait("100", "Direct");
            CreerTrait("101", "Discipliné");
            CreerTrait("102", "Discret");
            CreerTrait("103", "Disponible");
            CreerTrait("104", "Distingué");
            CreerTrait("105", "Distrayant");
            CreerTrait("106", "Divertissant");
            CreerTrait("107", "Doué");
            CreerTrait("108", "Doux");
            CreerTrait("109", "Droit");
            CreerTrait("110", "Drôle");
            CreerTrait("111", "Dynamique");
            CreerTrait("112", "Éblouissant");
            CreerTrait("113", "Éclatant");
            CreerTrait("114", "Économe");
            CreerTrait("115", "Efficace");
            CreerTrait("116", "Égayant");
            CreerTrait("117", "Éloquent");
            CreerTrait("118", "Émouvant");
            CreerTrait("119", "Empathique");
            CreerTrait("120", "Encourageant");
            CreerTrait("121", "Endurant");
            CreerTrait("122", "Energique");
            CreerTrait("123", "Engagé");
            CreerTrait("124", "Enjoué");
            CreerTrait("125", "Enthousiaste");
            CreerTrait("126", "Entreprenant");
            CreerTrait("127", "Épanoui");
            CreerTrait("128", "Galant");
            CreerTrait("129", "Humble");
            CreerTrait("130", "Humoristique");
            CreerTrait("131", "Imaginatif");
            CreerTrait("132", "impliqué");
            CreerTrait("133", "Indulgent");
            CreerTrait("134", "Infatigable");
            CreerTrait("135", "influent");
            CreerTrait("136", "Ingénieux");
            CreerTrait("137", "Inoubliable");
            CreerTrait("138", "Inspiré");
            CreerTrait("139", "Intègre");
            CreerTrait("140", "Intelligent");
            CreerTrait("141", "Intéressé");
            CreerTrait("142", "Intrépide");
            CreerTrait("143", "Intuitif");
            CreerTrait("144", "Inventif 2");
            CreerTrait("145", "Jovial");
            CreerTrait("146", "Joyeux");
            CreerTrait("147", "Judicieux");
            CreerTrait("148", "Juste");
            CreerTrait("149", "Leader");
            CreerTrait("150", "Libéré");
            CreerTrait("151", "Libre");
            CreerTrait("152", "Logique");
            CreerTrait("153", "Loyal");
            CreerTrait("154", "Lucide");
            CreerTrait("155", "Magistral");
            CreerTrait("156", "Maître de soi");
            CreerTrait("157", "Malin");
            CreerTrait("158", "Mature");
            CreerTrait("159", "Méritant");
            CreerTrait("160", "Méthodique");
            CreerTrait("161", "Mignon");
            CreerTrait("162", "Minutieux");
            CreerTrait("163", "Modèle");
            CreerTrait("164", "Modeste");
            CreerTrait("165", "Moral");
            CreerTrait("166", "Motivé");
            CreerTrait("167", "Naturel");
            CreerTrait("168", "Noble");
            CreerTrait("169", "Novateur");
            CreerTrait("170", "Nuancé");
            CreerTrait("171", "Objectif");
            CreerTrait("172", "Obligeant");
            CreerTrait("173", "Observateur");
            CreerTrait("174", "Opiniâtre");
            CreerTrait("175", "Optimiste");
            CreerTrait("176", "Ordonné");
            CreerTrait("177", "Organisé");
            CreerTrait("178", "Original");
            CreerTrait("179", "Ouvert");
            CreerTrait("180", "Ouvert d’esprit");
            CreerTrait("181", "Pacificateur");
            CreerTrait("182", "Pacifique");
            CreerTrait("183", "Paisible");
            CreerTrait("184", "Passionnant");
            CreerTrait("185", "Passionné");
            CreerTrait("186", "Patient");
            CreerTrait("187", "Persévérant");
            CreerTrait("188", "Perspicace");
            CreerTrait("189", "Persuasif");
            CreerTrait("190", "Pétillant");
            CreerTrait("191", "Philosophe");
            CreerTrait("192", "Plaisant");
            CreerTrait("193", "Poli");
            CreerTrait("194", "Polyvalent");
            CreerTrait("195", "Ponctuel");
            CreerTrait("196", "Pondéré");
            CreerTrait("197", "Posé");
            CreerTrait("198", "Positif");
            CreerTrait("199", "Pragmatique");
            CreerTrait("200", "Pratique");
            CreerTrait("201", "Précis");
            CreerTrait("202", "Présent");
            CreerTrait("203", "Prévenant");
            CreerTrait("204", "Prévoyant");
            CreerTrait("205", "Productif");
            CreerTrait("206", "Propre");
            CreerTrait("207", "Protecteur");
            CreerTrait("208", "Prudent");
            CreerTrait("209", "Pugnace");
            CreerTrait("210", "Pur");
            CreerTrait("211", "Raffiné");
            CreerTrait("212", "Raisonnable");
            CreerTrait("213", "Rassurant");
            CreerTrait("214", "Rationnel");
            CreerTrait("215", "Réaliste");
            CreerTrait("216", "Réceptif");
            CreerTrait("217", "Réconfortant");
            CreerTrait("218", "Reconnaissant");
            CreerTrait("219", "Réfléchi");
            CreerTrait("220", "Résistant");
            CreerTrait("221", "Résolu");
            CreerTrait("222", "Respectueux");
            CreerTrait("223", "Responsable");
            CreerTrait("224", "Rigoureux");
            CreerTrait("225", "Romantique");
            CreerTrait("226", "Rusé");
            CreerTrait("227", "Sage");
            CreerTrait("228", "Savant");
            CreerTrait("229", "Séduisant");
            CreerTrait("230", "Sensible");
            CreerTrait("231", "Serein");
            CreerTrait("232", "Sérieux");
            CreerTrait("233", "Serviable");
            CreerTrait("234", "Sincère");
            CreerTrait("235", "Sociable");
            CreerTrait("236", "Social");
            CreerTrait("237", "Soigneux");
            CreerTrait("238", "Solide");
            CreerTrait("239", "Souriant");
            CreerTrait("240", "Sportif");
            CreerTrait("241", "Stable");
            CreerTrait("242", "Stimulant");
            CreerTrait("243", "Stratège");
            CreerTrait("244", "Structuré");
            CreerTrait("245", "Studieux");
            CreerTrait("246", "Sûr de soi");
            CreerTrait("247", "Sympathique");
            CreerTrait("248", "Talentueux");
            CreerTrait("249", "Tempéré");
            CreerTrait("250", "Tenace");
            CreerTrait("251", "Tendre");
            CreerTrait("252", "Timide");
            CreerTrait("253", "Tolérant");
            CreerTrait("254", "Tranquille");
            CreerTrait("255", "Travaillant");
            CreerTrait("256", "Unique");
            CreerTrait("257", "Vaillant");
            CreerTrait("258", "Valeureux");
            CreerTrait("259", "Vif");
            CreerTrait("260", "Vigilant");
            CreerTrait("261", "Vigoureux");
            CreerTrait("262", "Vivace");
            CreerTrait("263", "Volontai");
            CreerTrait("264", "Volubile");
            CreerTrait("265", "Vrai");
            CreerTrait("266", "Zen");
            CreerTrait("267", "Abrupt");
            CreerTrait("268", "Accro");
            CreerTrait("269", "Accusateur");
            CreerTrait("270", "Acerbe");
            CreerTrait("271", "Agressif");
            CreerTrait("272", "Aigri");
            CreerTrait("273", "Amateur");
            CreerTrait("274", "Amorphe");
            CreerTrait("275", "Angoissé");
            CreerTrait("276", "Anxieux");
            CreerTrait("277", "Arbitraire");
            CreerTrait("278", "Arriviste");
            CreerTrait("279", "Arrogant");
            CreerTrait("280", "Associable");
            CreerTrait("281", "Asocial");
            CreerTrait("282", "Assisté");
            CreerTrait("283", "Autoritaire");
            CreerTrait("284", "Avare");
            CreerTrait("285", "Bagarreur");
            CreerTrait("286", "Baratineur");
            CreerTrait("287", "Bavard");
            CreerTrait("288", "Blasé");
            CreerTrait("289", "Blessant");
            CreerTrait("290", "Borné");
            CreerTrait("291", "Boudeur");
            CreerTrait("292", "Brouillon");
            CreerTrait("293", "Brute");
            CreerTrait("294", "Bruyant");
            CreerTrait("295", "Cachottier");
            CreerTrait("296", "Calculateur");
            CreerTrait("297", "Capricieux");
            CreerTrait("298", "Caractériel");
            CreerTrait("299", "Caricatural");
            CreerTrait("300", "Carriériste");
            CreerTrait("301", "Cassant");
            CreerTrait("302", "Casse-cou");
            CreerTrait("303", "Catastrophiste");
            CreerTrait("304", "Caustique");
            CreerTrait("305", "Censeur");
            CreerTrait("306", "Coléreux");
            CreerTrait("307", "Colérique");
            CreerTrait("308", "Complexé");
            CreerTrait("309", "Compliqué");
            CreerTrait("310", "Confus");
            CreerTrait("311", "Crédule");
            CreerTrait("312", "Cruel");
            CreerTrait("313", "Cynique");
            CreerTrait("314", "Débordé");
            CreerTrait("315", "Défaitiste");
            CreerTrait("316", "Dépensier");
            CreerTrait("317", "Désinvolte");
            CreerTrait("318", "Désobéissant");
            CreerTrait("319", "Désordonné");
            CreerTrait("320", "Désorganisé");
            CreerTrait("321", "Diabolique");
            CreerTrait("322", "Distrait");
            CreerTrait("323", "Docile");
            CreerTrait("324", "Dominateur");
            CreerTrait("325", "Dragueur");
            CreerTrait("326", "Égocentrique");
            CreerTrait("327", "Égoïste");
            CreerTrait("328", "Emotif");
            CreerTrait("329", "Enigmatique");
            CreerTrait("330", "Entêté");
            CreerTrait("331", "Envahissant");
            CreerTrait("332", "Envieux");
            CreerTrait("333", "Étourdi");
            CreerTrait("334", "Excentrique");
            CreerTrait("335", "Excessif");
            CreerTrait("336", "Fainéant");
            CreerTrait("337", "Familier");
            CreerTrait("338", "Fantasque");
            CreerTrait("339", "Fataliste");
            CreerTrait("340", "Froid");
            CreerTrait("341", "Grossier");
            CreerTrait("342", "Hautain");
            CreerTrait("343", "Hésitant");
            CreerTrait("344", "Humiliant");
            CreerTrait("345", "Hypocrite");
            CreerTrait("346", "Imbu de lui-même");
            CreerTrait("347", "Immature");
            CreerTrait("348", "Impatient");
            CreerTrait("349", "Imprudent");
            CreerTrait("350", "Impulsif");
            CreerTrait("351", "Inaccessible");
            CreerTrait("352", "Inattentif");
            CreerTrait("353", "Incompétent");
            CreerTrait("354", "Inconstant");
            CreerTrait("355", "Inculte");
            CreerTrait("356", "Indécis");
            CreerTrait("357", "Indiscret");
            CreerTrait("358", "Indomptable");
            CreerTrait("359", "Influençable");
            CreerTrait("360", "Insatisfait");
            CreerTrait("361", "Insignifiant");
            CreerTrait("362", "Insouciant");
            CreerTrait("363", "Instable");
            CreerTrait("364", "Intéressé");
            CreerTrait("365", "Intolérant");
            CreerTrait("366", "Intransigeant");
            CreerTrait("367", "Introverti");
            CreerTrait("368", "Ironique");
            CreerTrait("369", "Irréaliste");
            CreerTrait("370", "Irrespectueux");
            CreerTrait("371", "Irresponsable");
            CreerTrait("372", "Jaloux");
            CreerTrait("373", "Joueur");
            CreerTrait("374", "Laxiste");
            CreerTrait("375", "Lent");
            CreerTrait("376", "Lunatique");
            CreerTrait("377", "Macho");
            CreerTrait("378", "Magnanime");
            CreerTrait("379", "Mal à l’aise");
            CreerTrait("380", "Mal élevé");
            CreerTrait("381", "Maladroit");
            CreerTrait("382", "Malhonnête");
            CreerTrait("383", "Maniaque");
            CreerTrait("384", "Maniéré");
            CreerTrait("385", "Manipulateur");
            CreerTrait("386", "Méchant");
            CreerTrait("387", "Médiocre");
            CreerTrait("388", "Médisant");
            CreerTrait("389", "Méfiant");
            CreerTrait("390", "Mégalomane");
            CreerTrait("391", "Menteur");
            CreerTrait("392", "Méprisant");
            CreerTrait("393", "Mesquin");
            CreerTrait("394", "Misogyne");
            CreerTrait("395", "Moqueur");
            CreerTrait("396", "Mou");
            CreerTrait("397", "Muet");
            CreerTrait("398", "Mystérieux");
            CreerTrait("399", "Mythomane");
            CreerTrait("400", "Naïf");
            CreerTrait("401", "Narcissique");
            CreerTrait("402", "Négatif");
            CreerTrait("403", "Négligeant");
            CreerTrait("404", "Nerveux");
            CreerTrait("405", "Nonchalant");
            CreerTrait("406", "Obstiné");
            CreerTrait("407", "Obtus");
            CreerTrait("408", "Odieux");
            CreerTrait("409", "Opiniâtre");
            CreerTrait("410", "Orgueilleux");
            CreerTrait("411", "Paresseux");
            CreerTrait("412", "Passif");
            CreerTrait("413", "Pédant");
            CreerTrait("414", "Persécuteur");
            CreerTrait("415", "Pervers");
            CreerTrait("416", "Pessimiste");
            CreerTrait("417", "Peureux");
            CreerTrait("418", "Plaintif");
            CreerTrait("419", "Possessif");
            CreerTrait("420", "Présomptueux");
            CreerTrait("421", "Prétentieux");
            CreerTrait("422", "Procrastinateur");
            CreerTrait("423", "Profiteur");
            CreerTrait("424", "Provocateur");
            CreerTrait("425", "Puéril");
            CreerTrait("426", "Raciste 4");
            CreerTrait("427", "Radin");
            CreerTrait("428", "Râleur");
            CreerTrait("429", "Rancunier");
            CreerTrait("430", "Rebelle");
            CreerTrait("431", "Renfermé");
            CreerTrait("432", "Réservé");
            CreerTrait("433", "Résigné");
            CreerTrait("434", "Rétrograde");
            CreerTrait("435", "Revanchard");
            CreerTrait("436", "Revêche");
            CreerTrait("437", "Révolté");
            CreerTrait("438", "Rigide");
            CreerTrait("439", "Rigide");
            CreerTrait("440", "Ringard");
            CreerTrait("441", "Routinier");
            CreerTrait("442", "Sans gêne");
            CreerTrait("443", "Sarcastique");
            CreerTrait("444", "Secret");
            CreerTrait("445", "Sensible");
            CreerTrait("446", "Solitaire");
            CreerTrait("447", "Sombre");
            CreerTrait("448", "Soupçonneux");
            CreerTrait("449", "Sournois");
            CreerTrait("450", "Stressé");
            CreerTrait("451", "Strict");
            CreerTrait("452", "Stupide");
            CreerTrait("453", "Suffisant");
            CreerTrait("454", "Superficiel");
            CreerTrait("455", "Susceptible");
            CreerTrait("456", "Tatillon");
            CreerTrait("457", "Tempétueux");
            CreerTrait("458", "Têtu");
            CreerTrait("459", "Timide");
            CreerTrait("460", "Triste");
            CreerTrait("461", "Vaniteux");
            CreerTrait("462", "Versatile");
            CreerTrait("463", "Vulgaire");
        }

        private void CreerTrait(string code, string description)
        {
            BaseDao<Trait, int> daoTrait = new BaseDao<Trait, int>();
            Trait trait = new Trait { Code = code, Description = description };
            daoTrait.Save(trait);
        }
        private void CreerAccomplissementUtilisateur(string titre)
        {
            BaseDao<AccomplissementUtilisateur, int> daoAAccomplissementUtilisateur = new BaseDao<AccomplissementUtilisateur, int>();
            BaseDao<Accomplissement, int> daoAccomplissement = new BaseDao<Accomplissement, int>();
            BaseDao<User, int> daoUser = new BaseDao<User, int>();

            AccomplissementUtilisateur accomplissementUtilisateur = new AccomplissementUtilisateur
            {
                Accomplissement = daoAccomplissement.GetAllOneCriteria("titre", titre)[0],
                Utilisateur = daoUser.GetAllOneCriteria(User.LOGIN, "sagaan@hotmail.com")[0],
                EstPublic = true
            };

            daoAAccomplissementUtilisateur.Save(accomplissementUtilisateur);

        }
        private void CreerAccomplissement(string codeCategorie, string titre, string description, string couleur,
                                          string image, string codeTrait1, string codeTrait2, string codeTrait3)
        {
            BaseDao<Accomplissement, int> daoAccomplissement = new BaseDao<Accomplissement, int>();
            BaseDao<Categorie, int> daoCategorie = new BaseDao<Categorie, int>();
            BaseDao<File, int> daoFile = new BaseDao<File, int>();
            BaseDao<User, int> daoUser = new BaseDao<User, int>();
            BaseDao<AccomplissementTrait, int> daoAccomplissementTrait = new BaseDao<AccomplissementTrait, int>();
            BaseDao<Trait, int> daoTrait = new BaseDao<Trait, int>();

            Accomplissement accomplissement = new Accomplissement
            {
                Categorie = daoCategorie.GetAllOneCriteria("CODE", codeCategorie)[0],
                Titre = titre,
                Description = description,
                Couleur = couleur,
                Image = daoFile.GetAllOneCriteria(File.FILE_NAME, image)[0],
                ProposePar = daoUser.GetAllOneCriteria(User.LOGIN, "sagaan@hotmail.com")[0],
                Language = "FR"
            };
            daoAccomplissement.Save(accomplissement);
            Accomplissement accomplissementsave = daoAccomplissement.GetAllOneCriteria("TITRE", titre)[0];

            Trait trait1 = daoTrait.GetAllOneCriteria("CODE", codeTrait1)[0];
            Trait trait2 = daoTrait.GetAllOneCriteria("CODE", codeTrait2)[0];
            Trait trait3 = daoTrait.GetAllOneCriteria("CODE", codeTrait3)[0];

            AccomplissementTrait accomplissementTrait1 = new AccomplissementTrait { Accomplissement = accomplissementsave, Trait = trait1, ValeurMultiplicative = 1 };
            AccomplissementTrait accomplissementTrait2 = new AccomplissementTrait { Accomplissement = accomplissementsave, Trait = trait2, ValeurMultiplicative = 2 };
            AccomplissementTrait accomplissementTrait3 = new AccomplissementTrait { Accomplissement = accomplissementsave, Trait = trait3, ValeurMultiplicative = 1 };
            daoAccomplissementTrait.Save(accomplissementTrait1);
            daoAccomplissementTrait.Save(accomplissementTrait2);
            daoAccomplissementTrait.Save(accomplissementTrait3);


        }


    }
}
