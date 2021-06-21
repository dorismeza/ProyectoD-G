Public Class FrmBusquedaCategoria
    Dim dt As New DataTable()
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtBuscarCateg_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarCateg.TextChanged
        buscar()
    End Sub

    Private Sub dgvcategoria_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvcategoria.CellContentClick

    End Sub

    Private Sub FrmBusquedaCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub

    Public Sub mostrar()
        Try
            dt = ConexionLogin.mostrarCategoria

            If dt.Rows.Count <> 0 Then
                dgvcategoria.DataSource = dt

                dgvcategoria.ColumnHeadersVisible = True


            Else
                dgvcategoria.DataSource = Nothing

                dgvcategoria.ColumnHeadersVisible = False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub buscar()
        Dim dt As New DataTable()
        Dim Proveedores As String

        Try
            Proveedores = txtBuscarCateg.Text
            dt = ConexionLogin.buscarProveedor(Proveedores)

            If dt.Rows.Count <> 0 Then
                dgvcategoria.DataSource = dt
                ConexionLogin.conexion.Close()

            Else
                dgvcategoria.DataSource = Nothing
                ConexionLogin.conexion.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class