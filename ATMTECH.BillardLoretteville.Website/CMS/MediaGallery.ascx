<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaGallery.ascx.cs"
    Inherits="ATMTECH.BillardLoretteville.Website.CMS.MediaGallery" %>
<link rel="stylesheet" type="text/css" href="CSS/jquery.ad-gallery.css">
<script type="text/javascript" src="../Javascript/jquery.min.js"></script>
<script type="text/javascript" src="../CMS/jquery.ad-gallery.js"></script>
<script type="text/javascript">
    $(function () {
        var galleries = $('.ad-gallery').adGallery();
        $('#switch-effect').change(
      function () {
          galleries[0].settings.effect = $(this).val();
          return false;
      }
    );
        $('#toggle-slideshow').click(
      function () {
          galleries[0].slideshow.toggle();
          return false;
      }
    );
        $('#toggle-description').click(
      function () {
          if (!galleries[0].settings.description_wrapper) {
              galleries[0].settings.description_wrapper = $('#descriptions');
          } else {
              galleries[0].settings.description_wrapper = false;
          }
          return false;
      }
    );
    });
</script>
<asp:PlaceHolder runat="server" ID="PlaceHolderMedia"></asp:PlaceHolder>
