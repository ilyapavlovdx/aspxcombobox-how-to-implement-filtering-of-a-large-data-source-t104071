Imports DevExpress.Web.ASPxEditors
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ASPxComboBox_OnItemsRequestedByFilterCondition_SQL(ByVal source As Object, ByVal e As ListEditItemsRequestedByFilterConditionEventArgs)
        Dim comboBox As ASPxComboBox = DirectCast(source, ASPxComboBox)
        SqlDataSource1.SelectCommand = "SELECT [ShipName], [ShipCity], [ShipRegion], [OrderID] FROM (select [ShipName], [ShipCity], [ShipRegion], [OrderID], row_number()over(order by t.[ShipName]) as [rn] from [Orders] as t where (([ShipName] + ' ' + [ShipCity] + ' ' + [ShipRegion]) LIKE @filter)) as st where st.[rn] between @startIndex and @endIndex"
        SqlDataSource1.SelectParameters.Clear()
        SqlDataSource1.SelectParameters.Add("filter", TypeCode.String, String.Format("%{0}%", e.Filter))
        SqlDataSource1.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString())
        SqlDataSource1.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString())
        comboBox.DataSource = SqlDataSource1
        comboBox.DataBind()
    End Sub

    Protected Sub ASPxComboBox_OnItemRequestedByValue_SQL(ByVal source As Object, ByVal e As ListEditItemRequestedByValueEventArgs)
        Dim value As Long = 0
        If e.Value Is Nothing OrElse Not Int64.TryParse(e.Value.ToString(), value) Then
            Return
        End If
        Dim comboBox As ASPxComboBox = DirectCast(source, ASPxComboBox)
        SqlDataSource1.SelectCommand = "SELECT [ShipName], [ShipCity], [ShipRegion], [OrderID] FROM Orders WHERE ([OrderID] = @OrderID) ORDER BY ShipRegion"

        SqlDataSource1.SelectParameters.Clear()
        SqlDataSource1.SelectParameters.Add("OrderID", TypeCode.Int64, e.Value.ToString())
        comboBox.DataSource = SqlDataSource1
        comboBox.DataBind()
    End Sub

End Class