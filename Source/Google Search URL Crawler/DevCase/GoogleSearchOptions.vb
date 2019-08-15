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

Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Text
Imports System.Web

Imports DevCase.Core.Design
Imports DevCase.Core.Extensions.NameValueCollection
Imports DevCase.Core.NET

#End Region

#Region " GoogleSearch Options "

' ReSharper disable once CheckNamespace

Namespace DevCase.ThirdParty.Google.Search

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Represents the query parameters to use with <c>Google Search</c> engine.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim searchOptions As New GoogleSearchOptions With {
    '''     .SearchTerm = "Hello World",
    '''     .Language = GoogleLanguage.EN,
    '''     .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
    '''     .ExcludeSimilarResults = False,
    '''     .StartPage = 0,
    '''     .InputEncoding = Encoding.UTF8,
    '''     .OutputEncoding = Encoding.GetEncoding("Windows-1252")
    ''' }
    ''' 
    ''' Dim searchResults As List(Of GoogleSearchResult) = GoogleSearch.GetSearchResult(searchOptions)
    ''' Dim resultCount As Integer
    ''' 
    ''' For Each result As GoogleSearchResult In searchResults
    '''     Console.WriteLine("[{0:000}] Url: {1}; Title: {2}; Description: {3}", Interlocked.Increment(resultCount), result.Url, result.Title, result.Description)
    ''' Next result
    ''' 
    ''' Console.WriteLine("Done.")
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' <see href="http://www.google.com/support/enterprise/static/gsa/docs/admin/72/gsa_doc_set/xml_reference/request_format.html"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    Public Class GoogleSearchOptions : Implements ICloneable

#Region " Constant Values "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The maximum number of search results to return.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Shared ReadOnly MaxNumberOfResults As Integer = 1000

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The maximum number of search results that can be included in one page.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Shared ReadOnly MaxNumberOfResultsPerPage As Integer = 100

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The maximum search results that can be included to documents in the specified domain, host or web directory.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Shared ReadOnly MaxWebsiteLength As Integer = 125

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' The <c>Google Search</c> base address for a GET request.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Protected ReadOnly googleSearchBaseAddress As String = "http://www.google.com/search?"

#End Region

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the search query. Note that whitespaces are automatically separated by a plus (+) sign
        ''' <para></para>
        ''' Default value: {null}
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#qsp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("The search query. Note that whitespaces are automatically separated by a plus (+) sign.")>
        <DefaultValue("")>
        Public Property SearchTerm As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value to restrict search results to pages in the specified language. 
        ''' If there are no results In the specified language, the search appliance displays results In all languages.
        ''' <para></para>
        ''' Default value: <see cref="GoogleLanguage.Auto"/>
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#lrsp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("A value to restrict searches to pages in the specified language.")>
        <DefaultValue(GetType(GoogleLanguage), NameOf(GoogleLanguage.Auto))>
        Public Overridable Property Language As GoogleLanguage

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that allows you to restrict search results to documents with a particular file extension.
        ''' <para></para>
        ''' Default value: {null}
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#as_filetypesp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("A value that allows you to restrict search results to documents with a particular file extension.")>
        <DefaultValue("")>
        Public Property Filetype As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value indicating whether to exclude similar website results from the search pages.
        ''' <para></para>
        ''' Default value: <see langword="False"/>
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#filtersp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("A value indicating whether to exclude similar website results from the search pages.")>
        <DefaultValue(False)>
        Public Property FilterResults As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the number of search results to return.
        ''' <para></para>
        ''' The maximum allowed value is <see cref="GoogleSearchOptions.MaxNumberOfResults"/>.
        ''' <para></para>
        ''' Default value: <c>100</c>
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#numsp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("The number of search results to return.")>
        <DefaultValue(100)>
        Public Property NumberOfResults As Integer
            <DebuggerNonUserCode>
            Get
                Return Me.numberOfResults_
            End Get
            <DebuggerStepperBoundary>
            Set(value As Integer)
                If (value < 1) Then
                    value = 1
                ElseIf (value > GoogleSearchOptions.MaxNumberOfResults) Then
                    value = GoogleSearchOptions.MaxNumberOfResults
                End If
                Me.numberOfResults_ = value
            End Set
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing field )
        ''' The number of search results to return.
        ''' <para></para>
        ''' The maximum allowed value is <see cref="GoogleSearchOptions.MaxNumberOfResults"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private numberOfResults_ As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that indicates the first matching result that should be included in the search results.
        ''' <para></para>
        ''' Default value: <c>0</c> 
        ''' <para></para>
        ''' The <c>start</c> parameter uses a zero-based index, 
        ''' meaning the first result is 0, the second result is 1 and so forth.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#startsp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("A value that indicates the first matching result that should be included in the search results.")>
        <DefaultValue(0)>
        <Browsable(False)>
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Property Start As Integer
            <DebuggerNonUserCode>
            Get
                Return Me.start_
            End Get
            <DebuggerStepperBoundary>
            Set(value As Integer)
                If (value < 0) Then
                    value = 0
                End If
                Me.start_ = value
            End Set
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing field )
        ''' The first matching result that should be included in the search results.
        ''' <para></para>
        ''' The <c>start</c> parameter uses a zero-based index, 
        ''' meaning the first result is 0, the second result is 1 and so forth.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private start_ As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that allows you to restrict all search results should to a given site.
        ''' <para></para>
        ''' The specified value must contain less than <see cref="GoogleSearchOptions.MaxWebsiteLength"/> characters.
        ''' <para></para>
        ''' Default value: {null}
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#as_sitesearchsp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Search")>
        <Description("A value that allows you to restrict all search results should to a given site.")>
        <DefaultValue("")>
        Public Property Website As String
            <DebuggerNonUserCode>
            Get
                Return Me.website_
            End Get
            <DebuggerStepperBoundary>
            Set(value As String)
                If (value.Length > GoogleSearchOptions.MaxWebsiteLength) Then
                    value = value.Substring(0, GoogleSearchOptions.MaxWebsiteLength)
                End If
                Me.website_ = value
            End Set
        End Property
        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' ( Backing field )
        ''' A value that allows you to restrict all search results should to a given site.
        ''' <para></para>
        ''' The specified value must contain less than <see cref="GoogleSearchOptions.MaxWebsiteLength"/> characters.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private website_ As String

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the input character encoding.
        ''' <para></para>
        ''' Default value: ISO-8859-1 (latin1)
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#iesp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Text Encoding")>
        <Description("The input character encoding.")>
        <DefaultValue(GetType(String), "ISO-8859-1")>
        <TypeConverter(GetType(EncodingTypeConverter))>
        Public Property InputEncoding As Encoding

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the output character encoding.
        ''' <para></para>
        ''' Default value: ISO-8859-1 (latin1)
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <remarks>
        ''' <see href="https://developers.google.com/custom-search/docs/xml_results#oesp"/>
        ''' </remarks>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Text Encoding")>
        <Description("The output character encoding.")>
        <DefaultValue(GetType(String), "ISO-8859-1")>
        <TypeConverter(GetType(EncodingTypeConverter))>
        Public Property OutputEncoding As Encoding

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="GoogleSearchOptions"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Sub New()
            Me.SearchTerm = ""
            Me.Language = GoogleLanguage.Auto
            Me.NumberOfResults = 20
            Me.Start = 0
            Me.FilterResults = False
            Me.Filetype = ""
            Me.Website = ""
            Me.InputEncoding = Encoding.GetEncoding("ISO-8859-1")  ' Latin1
            Me.OutputEncoding = Encoding.GetEncoding("ISO-8859-1") ' Latin1
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a <see cref="NameValueCollection"/> that represents the <c>Google</c> query for this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="NameValueCollection"/> that represents the <c>Google</c> query for this instance.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Overridable Function ToNameValueCollection() As NameValueCollection
            Dim params As New NameValueCollection From {
                {"q", HttpUtility.UrlEncode(Me.SearchTerm)}
            }

            If Not String.IsNullOrEmpty(Me.Filetype) Then
                params.Add("as_filetype", Me.Filetype.ToLower())
            End If

            If Not String.IsNullOrEmpty(Me.Website) Then
                params.Add("as_sitesearch", HttpUtility.UrlEncode(Me.Website.ToLower()))
            End If

            If (Me.InputEncoding IsNot Nothing) Then
                params.Add("ie", Me.InputEncoding.WebName.ToLower())
            End If

            If (Me.OutputEncoding IsNot Nothing) Then
                params.Add("oe", Me.OutputEncoding.WebName.ToLower())
            End If

            If (Me.Language <> GoogleLanguage.Auto) Then
                params.Add("lr", $"lang_{Me.Language.ToString().Replace("_"c, "-"c).ToLower()}")
            End If

            If (Me.NumberOfResults > 0) Then
                params.Add("num", Me.NumberOfResults.ToString())
            End If

            params.Add("filter", CStr(CInt(Me.FilterResults)))
            params.Add("start", CStr(Me.Start))

            Return params

        End Function

#End Region

#Region " Operator Overrides "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a <see cref="String"/> that represents the <c>Google Search</c> GET request string for this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="String"/> that represents the <c>Google Search</c> GET request string for this instance.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Overrides Function ToString() As String

            ' Firstly I decode the encoded params, otherwise they will be reencoded by the 
            ' DevCase.Core.Generics.Extensions.NameValueCollection.ToQueryString() Function.
            Dim params As NameValueCollection = Me.ToNameValueCollection()

            params("q") = HttpUtility.UrlDecode(params("q"))

            If Not String.IsNullOrEmpty(params.Get("as_sitesearch")) Then
                params("as_sitesearch") = HttpUtility.UrlDecode(params("as_sitesearch"))
            End If

            Return params.ToQueryString(baseAddress:=Me.googleSearchBaseAddress)

        End Function

#End Region

#Region " ICloneable Implementation "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Creates a new object that is a copy of the current instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A new object that is a copy of this instance.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Public Function Clone() As Object Implements ICloneable.Clone
            Return New GoogleSearchOptions With {
                .SearchTerm = Me.SearchTerm,
                .Language = Me.Language,
                .NumberOfResults = Me.NumberOfResults,
                .Start = Me.Start,
                .FilterResults = Me.FilterResults,
                .Filetype = Me.Filetype,
                .Website = Me.Website,
                .InputEncoding = Me.InputEncoding,
                .OutputEncoding = Me.OutputEncoding
            }

        End Function

#End Region

    End Class

End Namespace

#End Region
