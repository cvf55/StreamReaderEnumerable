Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class StreamReaderEnumerable
    Implements IEnumerable(Of String)

    Private _filePath As String

    Public Sub New(ByVal filePath As String)
        _filePath = filePath
    End Sub

    ''' <summary>
    ''' Inicializar el enumerador. Simplemente devuelve una nueva instancia de una clase que haya implementado IEnumerator
    ''' </summary>
    ''' <returns></returns>
    Public Function GetEnumerator() As IEnumerator(Of String) Implements IEnumerable(Of String).GetEnumerator

        Return New StreamReaderEnumerator(_filePath)
    End Function

    Private Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator

        Return Me.GetEnumerator()
    End Function

End Class
