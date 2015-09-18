<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.XWingCampaign.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 10px 10px 10px 10px">
        <div style="display: table; color: wheat; width: 365px; font-weight: bold; margin-bottom: 10px;">XWing Campaign aide</div>

        <div style="Color: white; margin-bottom: 10px;">
           
        </div>

        <asp:ImageMap runat="server" ID="imgVaisseau" ImageUrl="Images/Website/TieFighter.png" OnClick="imgVaisseauClick">

            <asp:PolygonHotSpot AlternateText="test" Coordinates="156,-20,365,-20,327,80,196,80" PostBackValue="N;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="202,90,319,90, 280, 197,238,197" PostBackValue="N;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="373,0,500,120,413,160,334,80" PostBackValue="NE;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="326,110,400,180,316,220,300,180" PostBackValue="NE;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="505,155,500,340,419,300,419,180" PostBackValue="E;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="400,190,400,300,300,260,300,225" PostBackValue="E;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="500,355,360,460,335,400,400,320" PostBackValue="SE;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="330,390,296,315,320,280,400,315" PostBackValue="SE;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="162,495,198,400,326,400,358,500" PostBackValue="S;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="200,400,315,380,278,300,239,300" PostBackValue="S;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="161,460,55,430,20,365,107,320,190,400" PostBackValue="SW;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="193,380,119,316,200,280,226,300" PostBackValue="SW;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="20,346,20,150,100,190,115,300" PostBackValue="W;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="126,300,126,195,200,230,200,260" PostBackValue="W;R1;R2C" HotSpotMode="PostBack" />

            <asp:PolygonHotSpot AlternateText="test" Coordinates="16,125,148,0,185,100,110,180" PostBackValue="NW;R3;R2F" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="test" Coordinates="120,180,200,110,228,180,205,215" PostBackValue="NW;R1;R2C" HotSpotMode="PostBack" />

        </asp:ImageMap>


        <div style="margin-top: 5px; text-align: center; background-color: white; border: solid 2px gray; border-radius: 10px; padding: 20px 10px 10px 10px; width: 515px;">
            <asp:Label runat="server" ID="lblRetour"><br/><br/></asp:Label>
        </div>
    </div>

</asp:Content>
