' This source-code is freely distributed as part of "DevCase for .NET Framework".
' 
' Maybe you would like to consider to buy this powerful set of libraries to support me. 
' You can do loads of things with my apis for a big amount of diverse thematics.
' 
' Here is a link to the purchase page:
' https://codecanyon.net/item/elektrokit-class-library-for-net/19260282
' 
' Thank you.

#Region " Imports "

Imports System

#End Region

#Region " FileSystem Util "

' ReSharper disable once CheckNamespace

Namespace DevCase.Core.Shell.Tools

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains related FileSystem utilities.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class FileSystemUtil

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="FileSystemUtil"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Invokes an item verb on the specified file or directory.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="filename">
        ''' The item path.
        ''' </param>
        ''' 
        ''' <param name="replacementChar">
        ''' The verb.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Shared Function MakeValidWin32Filename(filename As String, Optional ByVal replacementChar As Char = "_"c) As String

            If String.IsNullOrWhiteSpace(filename) Then
                Throw New ArgumentNullException(NameOf(filename))
            End If

            If String.IsNullOrWhiteSpace(replacementChar) Then
                Throw New ArgumentNullException(NameOf(replacementChar))
            End If

            Dim invalidChars As Char() = ":/\|=*<>?""".ToCharArray()
            If invalidChars.Contains(replacementChar) Then
                Throw New ArgumentException("The replacement character is invalid.", paramName:=NameOf(replacementChar))
            End If

            Return New String(filename.Select(Function(c As Char) If(invalidChars.Contains(c), replacementChar, c)).ToArray())

            ' DEPRECATED:
            ' ----------------------------------------------------------------------------------
            ' https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getinvalidfilenamechars
            '
            ' The array returned from this method is not guaranteed to contain 
            ' the complete set of characters that are invalid in file and directory names. 
            ' The full set of invalid characters can vary by file system. 
            '
            ' For example, on Windows-based desktop platforms, invalid path characters might include 
            ' ASCII/Unicode characters 1 through 31, as well as quote ("), less than (<), 
            ' greater than(>), pipe (|), backspace (\b), null (\0) and tab (\t).
            ' -----------------------------------------------------------------------------------
            ' Dim invalidChars As New HashSet(Of Char)(Path.GetInvalidFileNameChars())
            ' Return New String(filename.Select(Function(c As Char) If(invalidChars.Contains(c), replacementChar, c)).ToArray())

        End Function

#End Region

    End Class

End Namespace

#End Region
