<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" EnableCallbackMode="true" CallbackPageSize="10"
            IncrementalFilteringMode="Contains" ValueType="System.String" ValueField="OrderID"
            OnItemsRequestedByFilterCondition="ASPxComboBox_OnItemsRequestedByFilterCondition_SQL"
            OnItemRequestedByValue="ASPxComboBox_OnItemRequestedByValue_SQL" TextFormatString="{0} {1} {2}"
            Width="400px" DropDownStyle="DropDown">
            <Columns>
                <dx:ListBoxColumn FieldName="ShipName" />
                <dx:ListBoxColumn FieldName="ShipCity" />
                <dx:ListBoxColumn FieldName="ShipRegion" />
            </Columns>
        </dx:ASPxComboBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:NORTHWINDConnectionString %>" />
    </form>
</body>
</html>