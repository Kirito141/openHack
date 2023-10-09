<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImage.aspx.cs" Inherits="Hackathon2.AddImage" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="AddImage.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 475px;
        }
        .auto-style3 {
            width: 605px;
        }
        .auto-style4 {
            width: 475px;
            height: 26px;
        }
        .auto-style5 {
            width: 605px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</head>
  <body>
    <form id="form2" runat="server">
      <asp:FileUpload ID="FileUpload2" runat="server" />
      <asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" />
      <hr />
      <asp:Image ID="Image1" Visible = "false" runat="server" Height = "100" Width = "100" />
    </form>
  </body>
</html>
