Imports System.Data.Sql
Imports System.Data.SqlClient
Module ConexionLogin
    Public conexion As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader

    'CAROLINA10\CAROLINA
    'AMAYA
    'DANIELRUEDA\LOCALHOST
    'localhost
    'DORIS\SQLEXPRESS
    'DESKTOP-DE4EAJJ
    Sub abrir()

        Try
            conexion = New SqlConnection("Data Source=DESKTOP-DE4EAJJ;Initial Catalog=BazarRoxana;Integrated Security=True")
            conexion.Open()
            ' MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("No se pudo conectar" + ex.ToString)
        End Try
    End Sub

    Function usuarioRegistrado(ByVal nombreUsuario As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("Select * from Empleados where UsuarioEmple='" & nombreUsuario & "' and EstadoEmple=1 ", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    Public Function mostrarProveedor() As DataTable
        Try
            conexion.Open()
            enunciado = New SqlCommand("mostrar_proveedor", conexion)
            enunciado.CommandType = CommandType.StoredProcedure

            enunciado.Connection = conexion

            If enunciado.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(enunciado)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function mostrarCategoria() As DataTable
        Try
            conexion.Open()
            enunciado = New SqlCommand("mostrar_categoría", conexion)
            enunciado.CommandType = CommandType.StoredProcedure

            enunciado.Connection = conexion

            If enunciado.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(enunciado)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function insertarCategoria(nombre As String, estado As Integer, descripcion As String)
        Try
            conexion.Open()
            enunciado = New SqlCommand("insertar_categoria", conexion)
            enunciado.CommandType = CommandType.StoredProcedure
            enunciado.Parameters.AddWithValue("@nombre", nombre)
            enunciado.Parameters.AddWithValue("@Estado", estado)
            enunciado.Parameters.AddWithValue("@Descrip", descripcion)

            If enunciado.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try

    End Function

    Public Function buscarProduct(Nombre As String) As DataTable
        Try
            conexion.Open()
            Dim cmb As New SqlCommand("buscarProduct", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@nombre", Nombre)
            If cmb.ExecuteNonQuery <> 0 Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmb)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function buscarCategoria(Nombre As String) As DataTable
        Try
            conexion.Open()
            Dim cmb As New SqlCommand("buscarCategoria", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@nombre", Nombre)
            If cmb.ExecuteNonQuery <> 0 Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmb)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function buscarCategoriaI(Nombre As String) As DataTable
        Try
            conexion.Open()
            Dim cmb As New SqlCommand("buscarCategoriaI", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@nombre", Nombre)
            If cmb.ExecuteNonQuery <> 0 Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmb)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function buscarCategoriaH(Nombre As String) As DataTable
        Try
            conexion.Open()
            Dim cmb As New SqlCommand("buscarCategoriaH", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@nombre", Nombre)
            If cmb.ExecuteNonQuery <> 0 Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmb)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function buscarProveedor(Nombre As String) As DataTable
        Try
            conexion.Open()
            Dim cmb As New SqlCommand("buscarProveedor", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@nombre", Nombre)
            If cmb.ExecuteNonQuery <> 0 Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmb)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function


    Function contrasena(ByVal nombreUsuario As String) As String
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select Contraseña from Empleados where UsuarioEmple='" & nombreUsuario & "' and EstadoEmple=1 ", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("Contraseña")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    Function ConsultarTipoUsuario(ByVal nombreUsuario As String) As Integer
        Dim resultado As Integer
        Try
            enunciado = New SqlCommand("Select NivelEmple from Empleados where UsuarioEmple='" & nombreUsuario & "' and EstadoEmple=1 ", conexion)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = CInt(respuesta.Item("NivelEmple"))
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resultado
    End Function

    Function PersonaRegistradaClientes(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Clientes where CodCli='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function

    Function PersonaRegistradaCategoria(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Categoria where NombCateg='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function

    Function RegistradoCompras(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Compras where NumCompra='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function

    Function RegistradoVentas(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Ventas where NumVent='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function

    Function RegistradoEmpleados(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Empleados where CodEmple='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function

    Function RegistradoProducto(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Producto where CodProduc='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function

    Function RegistradoProveedores(ByVal id As String) As Boolean
        Dim resultado As Boolean = False
        Try
            enunciado = New SqlCommand("select*from Proveedores where CodProv='" & id & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento: " + ex.ToString)
        End Try
        Return resultado
    End Function
End Module
