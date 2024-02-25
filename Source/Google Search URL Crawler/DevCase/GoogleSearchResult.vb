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

Imports System.Text

#End Region

#Region " GoogleSearch Result "

' ReSharper disable once CheckNamespace

Namespace DevCase.ThirdParty.Google.Search

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Represents a <c>Google Search</c> result.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Class GoogleSearchResult

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the search result title.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The search result title.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overridable ReadOnly Property Title As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the search result title in the specified text encoding.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="inEnc">
        ''' The source text encoding.
        ''' </param>
        ''' 
        ''' <param name="outEnc">
        ''' The target text encoding.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The search result title in the specified text encoding.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overridable ReadOnly Property Title(inEnc As Encoding, outEnc As Encoding) As String
            Get
                Dim data As Byte() = inEnc.GetBytes(Me.Title)
                Return outEnc.GetString(data)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the search result description.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The search result description.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overridable ReadOnly Property Description As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the search result description in the specified text encoding.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="inEnc">
        ''' The source text encoding.
        ''' </param>
        ''' 
        ''' <param name="outEnc">
        ''' The target text encoding.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The search result description in the specified text encoding.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overridable ReadOnly Property Description(inEnc As Encoding, outEnc As Encoding) As String
            Get
                Dim data As Byte() = inEnc.GetBytes(Me.Description)
                Return outEnc.GetString(data)
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the search result <see cref="Uri"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The search result <see cref="Uri"/>.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overridable ReadOnly Property Url As Uri

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="GoogleSearchResult"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="GoogleSearchResult"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="title">
        ''' The search result title.
        ''' </param>
        ''' 
        ''' <param name="url">
        ''' The search result url.
        ''' </param>
        ''' 
        ''' <param name="description">
        ''' The search result description.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Sub New(title As String, url As String, description As String)
            Me.New(title, New Uri(url), description)
        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="GoogleSearchResult"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="title">
        ''' The search result title.
        ''' </param>
        ''' 
        ''' <param name="url">
        ''' The search result url.
        ''' </param>
        ''' 
        ''' <param name="description">
        ''' The search result description.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Sub New(title As String, url As Uri, description As String)
            Me.Title = title
            Me.Url = url
            Me.Description = description
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a <see cref="String"/> that represents this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="String"/> that represents this instance.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overrides Function ToString() As String
            Return $"{NameOf(GoogleSearchResult.Title)}: {Me.Title}; {NameOf(GoogleSearchResult.Url)}: {Me.Url}; {NameOf(GoogleSearchResult.Description)}: {Me.Description}"
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a <see cref="String"/> of comma-separated values (CSV) that represents this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="String"/> of comma-separated values (CSV) that represents this instance.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Public Function ToStringCsv() As String
            Return $"{Me.Title.Replace(";"c, ",")}; {Me.Url.ToString().Replace(";"c, "%3B")}; {Me.Description.Replace(";"c, ",")}"
        End Function

#End Region

    End Class

End Namespace

#End Region
