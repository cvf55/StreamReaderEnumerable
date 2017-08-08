Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class StreamReaderEnumerator
    Implements IEnumerator(Of String)

    Private _sr As IO.StreamReader
    Private disposedValue As Boolean ' Para detectar llamadas redundantes
    Private _current As String

    Public Sub New(ByVal filePath As String)
        _sr = New IO.StreamReader(filePath)
    End Sub

    Public ReadOnly Property Current() As String Implements IEnumerator(Of String).Current

        Get
            If _sr Is Nothing OrElse _current Is Nothing Then
                Throw New InvalidOperationException()
            End If

            Return _current
        End Get
    End Property

    Private ReadOnly Property Current1() As Object Implements IEnumerator.Current

        Get
            Return Me.Current
        End Get
    End Property

    Public Sub Reset() _
    Implements System.Collections.IEnumerator.Reset

        _sr.DiscardBufferedData()
        _sr.BaseStream.Seek(0, IO.SeekOrigin.Begin)
        _current = Nothing
    End Sub

    Public Function MoveNext() As Boolean _
    Implements System.Collections.IEnumerator.MoveNext

        _current = _sr.ReadLine()
        If _current Is Nothing Then Return False
        Return True
    End Function

#Region "IDisposable Support"
    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' Dispose of managed resources.
            End If
            _current = Nothing
            _sr.Close()
            _sr.Dispose()
        End If

        Me.disposedValue = True
    End Sub

    ' TODO: reemplace Finalize() solo si el anterior Dispose(disposing As Boolean) tiene código para liberar recursos no administrados.
    Protected Overrides Sub Finalize()
        ' No cambie este código. Coloque el código de limpieza en el anterior Dispose(disposing As Boolean).
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' Visual Basic agrega este código para implementar correctamente el patrón descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
