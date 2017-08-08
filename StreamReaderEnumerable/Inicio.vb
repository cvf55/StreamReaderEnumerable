''' <summary>
''' Proyecto que documenta la correcta implementacion de los interfaces IEnumerable y IEnumerator
''' Ver: https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/control-flow/walkthrough-implementing-ienumerable-of-t
''' 
''' En este ejemplo vamos a usar una instruccion LINQ, pero podiamos usar un for-each igual. Lee un fichero de texto y solo devuelve las lineas que cumplan una condicion dada.
''' </summary>
Module Inicio

    Public Sub Main()
        Dim results As List(Of String) = (From line In New StreamReaderEnumerable(CurDir() & "\Log\log.txt") Where line.Contains("image001.jpg")).ToList()

        For i As Integer = 0 To results.Count - 1
            Console.Write(results.Item(i))
        Next
    End Sub

End Module
