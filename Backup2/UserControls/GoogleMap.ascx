<%@ Register TagPrefix="artem" Namespace="Artem.Google.UI" Assembly="Artem.Google, Version=6.0.0.0, Culture=neutral, PublicKeyToken=fc8d6190a3aeb01c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMap.ascx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.UserControls.GoogleMap" %>
<style>
    .coordinate
    {
        border: none;
        color: white;
        height: 1px;
        font-size: 1px;
        display: none;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $("#div1").dblclick(function (e) {
            
            $("[id$='txtCoordinateMouseX']").val(e.pageX);
            $("[id$='txtCoordinateMouseY']").val(e.pageY);
            $("form:first").submit();
        });
    });

    function handleClick(sender, e) {
        if (e) {
            if (e.latLng) {
                $("[id$='txtLatitudeClicked']").val(e.latLng.lat());
                $("[id$='txtLongitudeClicked']").val(e.latLng.lng());
            }
        }
    }

//    function test() {
//        var overlay = 
//        var coordinates = overlay.getProjection().fromContainerPixelToLatLng(new google.maps.Point(92, 61));
//    }
</script>
<div id="div1">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <artem:GoogleMap ID="GoogleMapFishingAtWork" runat="server" Draggable="False" DisableDefaultUI="true"
                Width="800" Height="600" EnableZoomControl="false" EnableStreetViewControl="false"
                EnableScaleControl="False" EnableScrollWheelZoom="false" OnClientClick="handleClick" EnableMapTypeControl="False">
            </artem:GoogleMap>
            <artem:GoogleMarkers ID="GoogleMarkerFishingAtWork" TargetControlID="GoogleMapFishingAtWork"
                runat="server">
                <MarkerOptions>
                </MarkerOptions>
                <Markers>
                </Markers>
            </artem:GoogleMarkers>
            <artem:GoogleRectangle runat="server" TargetControlID="GoogleMapFishingAtWork">
                
            </artem:GoogleRectangle>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:TextBox runat="server" ID="txtCoordinateMouseX" Text="0" Visible="true" CssClass="coordinate" />
    <asp:TextBox runat="server" ID="txtCoordinateMouseY" Text="0" Visible="true" CssClass="coordinate" />
    <asp:TextBox runat="server" ID="txtLatitudeClicked" Text="0" Visible="true" CssClass="coordinate" />
    <asp:TextBox runat="server" ID="txtLongitudeClicked" Text="0" Visible="true" CssClass="coordinate" />
</div>
