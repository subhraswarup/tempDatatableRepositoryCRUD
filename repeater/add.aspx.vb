Public Class add
    Inherits System.Web.UI.Page
    Dim gObjDtReport As New DataTable
    Dim rand As New Random
    Private Sub BindRepeater()
        Repeater1.DataSource = gObjDtReport
        Repeater1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CreateDatatable()
            BindRepeater()
        Else
            gObjDtReport = CType(ViewState("DataTable"), DataTable)
        End If
        ViewState("DataTable") = gObjDtReport
    End Sub
    Private Sub CreateDatatable()
        Try
            gObjDtReport.Columns.Add("Id")
            gObjDtReport.Columns.Add("PostId")
            gObjDtReport.Columns.Add("brokerId")
            gObjDtReport.Columns.Add("email")
            gObjDtReport.Columns.Add("createdon")
            gObjDtReport.Columns.Add("createdby")
        Catch ex As Exception
            Response.Write("<script>alert('" & ex.Message & "')</script>")
        End Try
    End Sub
    Private Sub AddToDataTable()
        Try
            Dim strSts As String = 0
            Dim dr As DataRow = gObjDtReport.NewRow()
            dr("Id") = rand.Next(0, 1000)
            dr("PostId") = "0"
            dr("brokerId") = 35
            dr("email") = txtEmail.Text
            dr("createdon") = DateTime.Now.Date
            dr("createdby") = 1
            gObjDtReport.Rows.Add(dr)
        Catch ex As Exception
            Response.Write("<script>alert('" & ex.Message & "')</script>")
        End Try
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddToDataTable()
        BindRepeater()
    End Sub

    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Dim lblName As Label = e.Item.FindControl("lblPostEmail")
        Dim lblrptID As Label = e.Item.FindControl("PostId")
        Dim txtName As TextBox = e.Item.FindControl("txtPostEmail")
        Dim btnEdit As Button = e.Item.FindControl("btnEdit")
        Dim btnUpdate As Button = e.Item.FindControl("btnUpdate")
        Dim btnDelete As Button = e.Item.FindControl("btnDelete")
        Dim hdnId As HiddenField = e.Item.FindControl("hdnId")
        If e.CommandName = "edit" Then
            txtName.Visible = True
            lblName.Visible = False
            btnEdit.Visible = False
            btnUpdate.Visible = True
        End If
        If e.CommandName = "update" Then
            If lblrptID.Text = "0" Then
                For Each row As DataRow In gObjDtReport.Rows
                    Dim currnetId As Int32 = Convert.ToInt32(row("Id"))
                    If Convert.ToInt32(hdnId.Value) = currnetId Then
                        row("email") = txtName.Text
                        lblName.Text = txtName.Text
                    End If
                Next
            Else

            End If
            lblName.Visible = True
                txtName.Visible = False
                btnEdit.Visible = True
                btnUpdate.Visible = False
            End If
        If e.CommandName = "delete" Then
            gObjDtReport.Rows(e.Item.ItemIndex).Delete()
        End If
        'BindRepeater()
    End Sub
End Class