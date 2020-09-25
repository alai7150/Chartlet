<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FanG.aspx.cs" Inherits="FGS" %>

<%@ Register assembly="Chartlet" namespace="FanG" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>梵高 - Chartlet</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:chartlet id="Chartlet1" runat="server"></cc1:chartlet>
        <cc1:chartlet id="Chartlet2" runat="server"></cc1:chartlet>
        <cc1:chartlet id="Chartlet3" runat="server"></cc1:chartlet>
        <cc1:chartlet id="Chartlet4" runat="server"></cc1:chartlet>
    </div>
    </form>
</body>
</html>
