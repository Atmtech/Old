<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.GestionMultimedia.Twiggy.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        @import url(http://fonts.googleapis.com/css?family=Pacifico);
        @import url(http://fonts.googleapis.com/css?family=Montserrat);

        body {
            margin: 0 0 0 0;
            font-family: Montserrat;
        }

        html {
            background: url(images/photomain.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .textBox {
            background-color: gray;
            color: white;
            padding: 4px 4px 4px 4px;
            border: solid 1px rgb(53, 53, 53);
            width: 100%;
        }
        textarea 
        {
            background-color: gray;
            color: white;
            padding: 4px 4px 4px 4px;
            border: solid 1px rgb(53, 53, 53);
            width: 100%;
        }

        .centerPanel {
            margin-top: 100px;
            width: 500px;
            margin: 0 auto;
            -webkit-border-radius: 15;
            -moz-border-radius: 15;
            border-radius: 15px;
            border: solid #426d87 4px;
            background-color: rgb(43, 43, 43);
            color: white;
            padding: 5px 25px 15px 15px;
        }

        .bouton {
            background: #3498db;
            background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
            background-image: -moz-linear-gradient(top, #3498db, #2980b9);
            background-image: -ms-linear-gradient(top, #3498db, #2980b9);
            background-image: -o-linear-gradient(top, #3498db, #2980b9);
            background-image: linear-gradient(to bottom, #3498db, #2980b9);
            -webkit-border-radius: 15;
            -moz-border-radius: 15;
            border-radius: 15px;
            font-family: Arial;
            color: #ffffff;
            font-size: 14px;
            padding: 5px 20px 5px 20px;
            border: solid #426d87 4px;
            text-decoration: none;
            cursor: pointer;
        }

            .bouton:hover {
                background: #3cb0fd;
                background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
                background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
                background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
                background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
                background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
                text-decoration: none;
            }

        .header {
            font-family: Montserrat;
            font-size: 30px;
            background-color: black;
            width: 97%;
            height: 100px;
            color: white;
            padding-top: 15px;
            padding-left: 40px;
            text-align: center;
        }

        .label {
            padding-top: 10px;
            padding-bottom: 10px;
            color: aliceblue;
            font-size: 15px;
        }

        ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
            color: lightblue;
            opacity: 1; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: lightblue;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: lightblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2 class="header">ENGLISH CLASS</h2>
        <asp:panel runat="server" id="pnlInformation" class="centerPanel">
            <h2> WRITE THE REQUIRED INFORMATIONS</h2>
            <div class="label">What is your group number ? <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="red" ErrorMessage="Required, can't be empty !" ControlToValidate="txtNoGroupe" ValidationGroup="Enregistrer"></asp:RequiredFieldValidator></div>
            <asp:TextBox runat="server" ID="txtNoGroupe" class="textBox" PlaceHolder="Group number"></asp:TextBox>
            <div class="label">What is your movie style ? (Documentary, horror, scifi, etc)</div>
            <asp:TextBox runat="server" ID="txtVideoStyle" class="textBox" PlaceHolder="Video style"></asp:TextBox>

            <div class="label">List all the student name <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="red" ErrorMessage="Required, can't be empty !" ControlToValidate="txtStudents" ValidationGroup="Enregistrer"></asp:RequiredFieldValidator></div>
            <asp:TextBox runat="server" ID="txtStudents" class="textBox" TextMode="MultiLine" PlaceHolder="Students list" Rows="10"></asp:TextBox>
            <div class="label">Write the url address of your movie <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="red" ErrorMessage="Required, can't be empty !" ControlToValidate="txtUrl" ValidationGroup="Enregistrer"></asp:RequiredFieldValidator></div>
            <asp:TextBox runat="server" ID="txtUrl" class="textBox" PlaceHolder="URL"></asp:TextBox>
            <asp:Label runat="server" ID="lblInvalideUrl" Visible="False" Text="URL invalid, please retry" ForeColor="red"></asp:Label>
            <div class="label">If you don't know howto upload your movie follow the link below</div>
            <a href="https://support.google.com/youtube/answer/57407?co=GENIE.Platform%3DDesktop&hl=en" target="_blank"><img src="Images/YouTube.png" style="width: 125px" /></a>
            <a href="https://vimeo.com/fr/upload" target="_blank"><img src="Images/vimeo.png" style="width: 125px"/></a>
            <a href="https://faq.dailymotion.com/hc/en-us/articles/115009030368-Upload-videos-to-dailymotion" target="_blank"><img src="Images/dailymotion.png" style="width: 125px"/></a>
            <div style="padding-top: 20px;">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:Button runat="server" ID="btnSave" Text="SAVE YOUR INFORMATION" CssClass="bouton" OnClick="btnSaveClick" ValidationGroup="Enregistrer"/>
                
            </div>
        </asp:panel>
        <asp:Panel runat="server" runat="server" id="pnlThankYou" Visible="False"  class="centerPanel"><div style="text-align: center;"><br/><br/>THANK YOU ! <br/><br/></div></asp:Panel>
    </form>
</body>
</html>
