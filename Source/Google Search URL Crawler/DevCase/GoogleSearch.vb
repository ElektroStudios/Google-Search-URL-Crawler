﻿' This source-code is freely distributed as part of "DevCase for .NET Framework".
' 
' Maybe you would like to consider to buy this powerful set of libraries to support me. 
' You can do loads of things with my apis for a big amount of diverse thematics.
' 
' Here is a link to the purchase page:
' https://codecanyon.net/item/elektrokit-class-library-for-net/19260282
' 
' Thank you.

#Region " Imports "

Imports System.Net
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web

Imports HtmlAgilityPack

#End Region

#Region " GoogleSearch "

' ReSharper disable once CheckNamespace

Namespace DevCase.ThirdParty.Google.Search

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Provides a way to use <c>Google Search</c> engine to crawl search results.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' Dim searchOptions As New GoogleSearchOptions With {
    '''     .SearchTerm = "Hello World",
    '''     .Language = GoogleLanguage.EN,
    '''     .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
    '''     .FilterResults = False,
    '''     .InputEncoding = Encoding.GetEncoding("ISO-8859-1"),
    '''     .OutputEncoding = Encoding.GetEncoding("ISO-8859-1")
    ''' }
    ''' 
    ''' Dim searchResults As List(Of GoogleSearchResult) = GoogleSearch.GetSearchResult(searchOptions)
    ''' Dim resultCount As Integer
    ''' 
    ''' For Each result As GoogleSearchResult In searchResults
    '''     Console.WriteLine("[{0:000}] Url: {1}; Title: {2}; Description: {3}", Interlocked.Increment(resultCount), result.Url, result.Title, result.Description)
    ''' Next result
    ''' 
    ''' Console.WriteLine("Finished.")
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class GoogleSearch

#Region " Private Fields "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A <see cref="Random"/> instance to generate random secuences of numbers.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private Shared ReadOnly RNG As New Random(Environment.TickCount)

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="GoogleSearch"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private Sub New()
        End Sub

#End Region

#Region " Constant Values "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' A fake agent to get the expected data to parse in the resulting html string response of <c>Google Search</c> requests.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ' Private Const FakeAgent As String = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2"
        Private Shared ReadOnly UserAgent As String =
            $"{My.Application.Info.AssemblyName}/1.1 (Windows; .NET Framework 4.8; non-harmful scraper; bot; scraper; en-US)"

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Searches the World Wide Web using <c>Google Search</c> service with the specified search options.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim searchOptions As New GoogleSearchOptions With {
        '''     .SearchTerm = "Hello World",
        '''     .Language = GoogleLanguage.EN,
        '''     .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
        '''     .FilterResults = False,
        '''     .InputEncoding = Encoding.GetEncoding("ISO-8859-1"),
        '''     .OutputEncoding = Encoding.GetEncoding("ISO-8859-1")
        ''' }
        ''' 
        ''' Dim html As String = GetSearchResultString(searchOptions)
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="searchOptions">
        ''' The search options to use with the <c>Google Search</c> service.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting response as a <c>Html</c> string.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetSearchResultString(searchOptions As GoogleSearchOptions) As String

            If (searchOptions.Start >= searchOptions.NumberOfResults) Then
                Return String.Empty
            End If

            Dim uri As New Uri(searchOptions.ToString())
            Using wc As New WebClient
                wc.Headers.Add("user-agent", GoogleSearch.UserAgent)
                Return wc.DownloadString(uri)
            End Using

        End Function

#If Not NET40 Then

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Asynchronously searches the World Wide Web using <c>Google Search</c> service with the specified search options.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim searchOptions As New GoogleSearchOptions With {
        '''     .SearchTerm = "Hello World",
        '''     .Language = GoogleLanguage.EN,
        '''     .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
        '''     .FilterResults = False,
        '''     .InputEncoding = Encoding.GetEncoding("ISO-8859-1"),
        '''     .OutputEncoding = Encoding.GetEncoding("ISO-8859-1")
        ''' }
        ''' 
        ''' Dim html As String = Await GetSearchResultStringAsync(searchOptions, page:=0)
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="searchOptions">
        ''' The search options to use with the <c>Google Search</c> service.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting response as a <c>Html</c> string.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Async Function GetSearchResultStringAsync(searchOptions As GoogleSearchOptions) As Task(Of String)

            If (searchOptions.Start >= searchOptions.NumberOfResults) Then
                Return String.Empty
            End If

            Dim uri As New Uri(searchOptions.ToString())
            Using wc As New WebClient
                wc.Headers.Add("user-agent", GoogleSearch.UserAgent)
                Return Await wc.DownloadStringTaskAsync(uri)
            End Using

        End Function

#End If

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Searches the World Wide Web using <c>Google Search</c> service with the specified search options.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim searchOptions As New GoogleSearchOptions With {
        '''     .SearchTerm = "Hello World",
        '''     .Language = GoogleLanguage.EN,
        '''     .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
        '''     .FilterResults = False,
        '''     .InputEncoding = Encoding.GetEncoding("ISO-8859-1"),
        '''     .OutputEncoding = Encoding.GetEncoding("ISO-8859-1")
        ''' }
        ''' 
        ''' Dim searchResults As List(Of GoogleSearchResult) = GetSearchResult(searchOptions)
        ''' Dim resultCount As Integer
        ''' 
        ''' For Each result As GoogleSearchResult In searchResults
        '''     Console.WriteLine("[{0:000}] Url: {1}; Title: {2}; Description: {3}", Interlocked.Increment(resultCount), result.Url, result.Title, result.Description)
        ''' Next result
        ''' 
        ''' Console.WriteLine("Finished.")
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="searchOptions">
        ''' The search options to use with the <c>Google Search</c> service.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="List(Of GoogleSearchResult)"/> that represents the search results.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetSearchResult(searchOptions As GoogleSearchOptions) As List(Of GoogleSearchResult)

            Dim tmpOptions As GoogleSearchOptions = DirectCast(searchOptions.Clone(), GoogleSearchOptions)

            Dim html As String = GoogleSearch.GetSearchResultString(tmpOptions)
            Dim results As New List(Of GoogleSearchResult)

            Do While True

                If String.IsNullOrEmpty(html) Then ' No search-page to parse.
                    Return results
                End If

                ' Load the html document.
                Dim doc As New HtmlDocument
                doc.LoadHtml(html)

                ' Select the result nodes.
                Dim nodes As HtmlNodeCollection
                nodes = doc.DocumentNode.SelectNodes("//div[@class='g']")

                If (nodes Is Nothing) Then ' No search results in this page.
                    Return results
                End If

                ' Loop trough the nodes.
                For Each node As HtmlNode In nodes

                    Dim title As String = "Title unavailable."
                    Dim description As String = "Description unavailable."
                    Dim url As String = ""

                    Try
                        title = HttpUtility.HtmlDecode(node.SelectSingleNode(".//div[@class='r']/a[@href]/h3").InnerText)
                    Catch ex As NullReferenceException
                    End Try

                    Try
                        description = HttpUtility.HtmlDecode(node.SelectSingleNode(".//div[@class='s']/div[1]/span[@class='st']").InnerText)
                    Catch ex As NullReferenceException
                    End Try

                    Try
                        url = HttpUtility.UrlDecode(node.SelectSingleNode(".//div[@class='r']/a[@href]").GetAttributeValue("href", "Unknown URL"))
                    Catch ex As NullReferenceException
                        Continue For
                    End Try

                    results.Add(New GoogleSearchResult(title, url, description))
                    If (results.Count = tmpOptions.NumberOfResults) Then
                        Exit Do
                    End If
                Next node

                If (tmpOptions.NumberOfResults >= GoogleSearchOptions.MaxNumberOfResultsPerPage) Then
                    tmpOptions.Start += GoogleSearchOptions.MaxNumberOfResultsPerPage
                    html = GoogleSearch.GetSearchResultString(tmpOptions)
                End If

            Loop

            Return results

        End Function

#If Not NET40 Then

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Asynchronously searches the World Wide Web using <c>Google Search</c> service with the specified search options.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim searchOptions As New GoogleSearchOptions With {
        '''     .SearchTerm = "Hello World",
        '''     .Language = GoogleLanguage.EN,
        '''     .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
        '''     .FilterResults = False,
        '''     .InputEncoding = Encoding.GetEncoding("ISO-8859-1"),
        '''     .OutputEncoding = Encoding.GetEncoding("ISO-8859-1")
        ''' }
        ''' 
        ''' Dim searchResults As List(Of GoogleSearchResult) = Await GetSearchResultAsync(searchOptions)
        ''' Dim resultCount As Integer
        ''' 
        ''' For Each result As GoogleSearchResult In searchResults
        '''     Console.WriteLine("[{0:000}] Url: {1}; Title: {2}; Description: {3}", Interlocked.Increment(resultCount), result.Url, result.Title, result.Description)
        ''' Next result
        ''' 
        ''' Console.WriteLine("Finished.")
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="searchOptions">
        ''' The search options to use with the <c>Google Search</c> service.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A <see cref="List(Of GoogleSearchResult)"/> that represents the search results.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepperBoundary>
        Public Shared Async Function GetSearchResultAsync(searchOptions As GoogleSearchOptions, statuslabel As ToolStripStatusLabel) As Task(Of List(Of GoogleSearchResult))

            Dim tmpOptions As GoogleSearchOptions = DirectCast(searchOptions.Clone(), GoogleSearchOptions)

            statuslabel.Text = $"Sending request..."
            Application.DoEvents()
            Dim html As String = Await GoogleSearch.GetSearchResultStringAsync(tmpOptions)
            Dim results As New List(Of GoogleSearchResult)

            Do While True

                If String.IsNullOrEmpty(html) Then ' No search-page to parse.
                    Return results
                End If

                ' Load the html document.
                Dim doc As New HtmlDocument
                doc.LoadHtml(html)

#If DEBUG Then
                ' Console.WriteLine(html)
#End If

                ' Select the result nodes.
                ' Dim nodes As HtmlNode()
                ' nodes = doc.DocumentNode.SelectNodes("//div[@class='g']")
                statuslabel.Text = $"Fetching search result nodes..."
                Application.DoEvents()
                Dim urlNodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//a[contains(@href, '&amp;sa=U&amp;') and not(contains(@href, 'q=/search'))]")

                If (urlNodes Is Nothing) Then ' No search results in this page.
                    MessageBox.Show(Nothing, "No results found.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return results
                End If

                ' Loop trough the nodes.
                For Each node As HtmlNode In urlNodes

#If DEBUG Then
                    Console.WriteLine(node?.OuterHtml)
#End If

                    Dim title As String = "Title unavailable."
                    Dim description As String = "Description unavailable."
                    Dim url As String = ""

                    Try
                        ' title = HttpUtility.HtmlDecode(node.SelectSingleNode(".//div[@class='r']/a[@href]/h3").InnerText)
                        Dim lastDivText As String = node.Descendants("div").LastOrDefault(Function(d As HtmlNode) Not String.IsNullOrWhiteSpace(d.InnerText))?.InnerText
                        title = HttpUtility.HtmlDecode(lastDivText)
                    Catch ex As NullReferenceException
                    End Try

                    Try
                        ' description = HttpUtility.HtmlDecode(node.SelectSingleNode(".//div[@class='s']/div[1]/span[@class='st']").InnerText)
                        description = HttpUtility.HtmlDecode(node.InnerText)
                    Catch ex As NullReferenceException
                    End Try

                    Try
                        ' url = HttpUtility.UrlDecode(node.SelectSingleNode(".//div[@class='r']/a[@href]").GetAttributeValue("href", "Unknown URL"))
                        url = node.GetAttributeValue("href", "Unknown URL")
                        url = If(url.IndexOf("&amp;") <> -1,
                                 HttpUtility.UrlDecode(url.Substring(0, url.IndexOf("&amp;")).Replace("/url?q=", "")),
                                 HttpUtility.UrlDecode(url.Replace("/url?q=", "")))

                    Catch ex As NullReferenceException
                        Continue For
                    End Try

                    If Not results.Any(Function(item As GoogleSearchResult) item.Url.ToString().Equals(url, StringComparison.OrdinalIgnoreCase)) Then
                        statuslabel.Text = $"Adding result to collection..."
                        Application.DoEvents()
                        results.Add(New GoogleSearchResult(title, url, description))
                        If (results.Count = tmpOptions.NumberOfResults) Then
                            Exit Do
                        End If
                    End If

                Next node

                If (tmpOptions.NumberOfResults >= GoogleSearchOptions.MaxNumberOfResultsPerPage) Then
                    tmpOptions.Start += GoogleSearchOptions.MaxNumberOfResultsPerPage
                    Dim ms As Integer = GoogleSearch.RNG.Next(3000, 10000)
                    statuslabel.Text = $"Current results: {results.Count} | Waiting {ms \ 1000} seconds before continuing fetching results..."
                    Application.DoEvents()
                    Thread.Sleep(ms)
                    html = Await GoogleSearch.GetSearchResultStringAsync(tmpOptions)
                End If

            Loop

            Return results

        End Function

#End If

#End Region

    End Class

End Namespace

#End Region
