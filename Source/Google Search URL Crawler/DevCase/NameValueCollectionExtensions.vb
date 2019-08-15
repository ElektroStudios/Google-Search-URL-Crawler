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

Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Web

#End Region

#Region " NameValueCollection Extensions "

' ReSharper disable once CheckNamespace

Namespace DevCase.Core.Extensions.[NameValueCollection]

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains custom extension methods to use with an <see cref="Specialized.NameValueCollection"/>.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <HideModuleName>
    Public Module NameValueCollectionExtensions

#Region " Public Extension Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Converts the name and values of a <see cref="Specialized.NameValueCollection"/> 
        ''' to a formatted web-request query string.
        ''' <para></para>
        ''' Consider this method to be the opposite of <see cref="HttpUtility.ParseQueryString"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim baseAddress As String = "http://www.google.com/search"
        ''' Dim params As New NameValueCollection()
        ''' params.Add("q", "Hello World")
        ''' params.Add("lr", "lang_en")
        ''' params.Add("ie", "utf-8")
        ''' 
        ''' Console.WriteLine(String.Format("{0}?{1}", baseAddress, params.ToQueryString()))
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source <see cref="Specialized.NameValueCollection"/>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting web-request query string.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        <Extension>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ToQueryString(sender As Specialized.NameValueCollection) As String

            Return ToQueryString(sender, String.Empty)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Converts the name and values of a <see cref="Specialized.NameValueCollection"/> 
        ''' to a formatted web-request query string.
        ''' <para></para>
        ''' Consider this method to be the opposite of <see cref="HttpUtility.ParseQueryString"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim params As New NameValueCollection()
        ''' params.Add("q", "Hello World")
        ''' params.Add("lr", "lang_en")
        ''' params.Add("ie", "utf-8")
        ''' 
        ''' Console.WriteLine(params.ToQueryString(baseAddress:=New Uri("http://www.google.com/search")))
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source <see cref="Specialized.NameValueCollection"/>.
        ''' </param>
        ''' 
        ''' <param name="baseAddress">
        ''' The base url address.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting web-request query string.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        <Extension>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ToQueryString(sender As Specialized.NameValueCollection,
                                      baseAddress As System.Uri) As String

            Return ToQueryString(sender, baseAddress.AbsoluteUri)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Converts the name and values of a <see cref="Specialized.NameValueCollection"/> 
        ''' to a formatted web-request query string.
        ''' <para></para>
        ''' Consider this method to be the opposite of <see cref="HttpUtility.ParseQueryString"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim params As New NameValueCollection()
        ''' params.Add("q", "Hello World")
        ''' params.Add("lr", "lang_en")
        ''' params.Add("ie", "utf-8")
        ''' 
        ''' Console.WriteLine(params.ToQueryString(baseAddress:="http://www.google.com/search"))
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source <see cref="Specialized.NameValueCollection"/>.
        ''' </param>
        ''' 
        ''' <param name="baseAddress">
        ''' The base url address.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting web-request query string.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        <Extension>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ToQueryString(sender As Specialized.NameValueCollection,
                                      baseAddress As String) As String

            Dim sb As New System.Text.StringBuilder
            If Not String.IsNullOrWhiteSpace(baseAddress) Then
                sb.Append(baseAddress.TrimEnd("?"c))
                sb.Append("?")
            End If

            For Each key As String In sender.AllKeys
                sb.AppendFormat("{0}={1}&", key, HttpUtility.UrlEncode(sender(key)))
            Next

            Return sb.Remove((sb.Length - 1), 1).ToString() ' removes the last "&" char.

        End Function

#End Region

    End Module

End Namespace

#End Region
