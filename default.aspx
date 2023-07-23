<%@ Page Language="C#" Trace="false" Debug="true"
   CodeFile="~/default.aspx.cs"
   Inherits="Projet2"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
   <title>Bonhomme pendu</title>
   <style type="text/css">
      BODY, INPUT { font-family:Verdana; font-size:16px; }
      //TD { border:dotted 1px blue; }
      .sImage { width:25px; }
      .sPendu { width:180px; }
      .sPremiereCellule, .sTroisiemeCellule { width:720px; height:150px; }
      .sDeuxiemeCellule { height:300px; }
      .sReduit { font-size:10px; }
      .sTitreApplication { font-size:32px; }
      .sTitreSection { font-size:24px; }
      .sVisible { visibility:visible; }
      .sInvisible { visibility:hidden; }
   </style>
   <script type="text/javascript" src="librairie.js"></script>
   <script type="text/javascript" src="default.js"></script>
</head>

<body>
   <form id="frmSaisie" runat="server">
      <asp:PlaceHolder id="phDynamique" runat="server" />
   </form>
</body>
</html>
