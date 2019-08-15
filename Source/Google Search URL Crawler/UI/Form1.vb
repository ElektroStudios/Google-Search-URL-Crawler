
#Region " Imports "

Imports System.IO
Imports System.Text

Imports DevCase.Core.NET
Imports DevCase.Core.Shell.Tools
Imports DevCase.ThirdParty.Google.Search

#End Region

#Region " Form1 "

Friend NotInheritable Class Form1

#Region " Private Fields "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' The Google search options.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private ReadOnly searchOptions As GoogleSearchOptions

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' The Google search results.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private searchResults As List(Of GoogleSearchResult)

#End Region

#Region " Constructors "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Initializes a new instance of the <see cref="Form1"/> class.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public Sub New()
        MyClass.InitializeComponent()
        Me.CircularProgressBar1.Hide()

        Me.searchOptions = New GoogleSearchOptions With {
            .SearchTerm = "",
            .Language = GoogleLanguage.Auto,
            .NumberOfResults = GoogleSearchOptions.MaxNumberOfResults,
            .FilterResults = False,
            .Start = 0,
            .InputEncoding = Encoding.GetEncoding("ISO-8859-1"),
            .OutputEncoding = Encoding.GetEncoding("ISO-8859-1")
        }

        Me.searchResults = New List(Of GoogleSearchResult)
    End Sub

#End Region

#Region " Event Handlers "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Form.Load"/> event of the <see cref="Form1"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size
        Me.PropertyGridSearchOptions.SelectedObject = Me.searchOptions
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="PropertyGrid.PropertyValueChanged"/> event of the <see cref="Form1.PropertyGridSearchOptions"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="PropertyValueChangedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub PropertyGridSearchOptions_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGridSearchOptions.PropertyValueChanged
        Me.TextBoxQuery.Text = Me.searchOptions.ToString()
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="PropertyGrid.SelectedObjectsChanged"/> event of the <see cref="Form1.PropertyGridSearchOptions"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub PropertyGridSearchOptions_SelectedObjectsChanged(sender As Object, e As EventArgs) Handles PropertyGridSearchOptions.SelectedObjectsChanged
        Me.TextBoxQuery.Text = Me.searchOptions.ToString()
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="TextBox.MouseUp"/> event of the <see cref="Form1.TextBoxQuery"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="MouseEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub TextBoxQuery_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBoxQuery.MouseUp
        DirectCast(sender, TextBox).SelectAll()
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Form.Load"/> event of the <see cref="Form1"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Async Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click

        If String.IsNullOrWhiteSpace(Me.searchOptions.SearchTerm) Then
            MessageBox.Show(Me, "Search Term can't be empty.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Disable Controls.
        Me.ButtonSearch.Enabled = False
        Me.PropertyGridSearchOptions.Enabled = False

        Me.DataGridViewSearchResults.DataSource = Nothing
        Me.CircularProgressBar1.Show()

        Try
            Me.searchResults = Await GoogleSearch.GetSearchResultAsync(Me.searchOptions)

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Me.DataGridViewSearchResults.DataSource = Me.searchResults
        Me.CircularProgressBar1.Hide()
        Me.LabelResults.Text = $"Displaying {Me.searchResults.Count} results."

        ' Re-enable controls.
        Me.ButtonSearch.Enabled = True
        Me.PropertyGridSearchOptions.Enabled = True

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="DataGridView.RowsAdded"/> event of the <see cref="Form1.DataGridViewSearchResults"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="DataGridViewRowsAddedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub DataGridViewSearchResults_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewSearchResults.RowsAdded
        Me.ClearResultsToolStripMenuItem.Enabled = True
        Me.ExportResultsToolStripMenuItem.Enabled = True
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="DataGridView.RowsRemoved"/> event of the <see cref="Form1.DataGridViewSearchResults"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="DataGridViewRowsRemovedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub DataGridViewSearchResults_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridViewSearchResults.RowsRemoved
        Dim rowsCount As Integer = DirectCast(sender, DataGridView).Rows.Count
        Me.ClearResultsToolStripMenuItem.Enabled = (rowsCount <> 0)
        Me.ExportResultsToolStripMenuItem.Enabled = (rowsCount <> 0)
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="Form1.ClearResultsToolStripMenuItem"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ClearResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearResultsToolStripMenuItem.Click
        Me.DataGridViewSearchResults.DataSource = Nothing
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="Form1.PlainTextToolStripMenuItem"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub PlainTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlainTextToolStripMenuItem.Click

        Using dlg As New SaveFileDialog()
            With dlg
                .AddExtension = True
                .AutoUpgradeEnabled = True
                .CheckFileExists = False
                .CheckPathExists = True
                .DefaultExt = ".txt"
                .FileName = $"GoogleSearchResults_{FileSystemUtil.MakeValidWin32Filename(Me.searchOptions.SearchTerm)}.txt"
                .Filter = "Text files (*.txt)|*.txt"
                .FilterIndex = 1
                .OverwritePrompt = True
                .RestoreDirectory = True
                .ShowHelp = False
                .SupportMultiDottedExtensions = True
                .Title = "Select a text file to save the current Google results..."
                .ValidateNames = True
            End With

            If dlg.ShowDialog() = DialogResult.OK Then
                Try
                    File.WriteAllLines(dlg.FileName, From result As GoogleSearchResult In Me.searchResults Select (result.ToString()))
                    MessageBox.Show(Me, "File successfully saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            End If
        End Using

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="Form1.CSVToolStripMenuItem"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click

        Using dlg As New SaveFileDialog()
            With dlg
                .AddExtension = True
                .AutoUpgradeEnabled = True
                .CheckFileExists = False
                .CheckPathExists = True
                .DefaultExt = ".csv"
                .FileName = $"GoogleSearchResults_{FileSystemUtil.MakeValidWin32Filename(Me.searchOptions.SearchTerm)}.csv"
                .Filter = "CSV files (*.csv)|*.csv"
                .FilterIndex = 1
                .OverwritePrompt = True
                .RestoreDirectory = True
                .ShowHelp = False
                .SupportMultiDottedExtensions = True
                .Title = "Select a CSV file to save the current Google results..."
                .ValidateNames = True
            End With

            If dlg.ShowDialog() = DialogResult.OK Then
                Try
                    File.WriteAllLines(dlg.FileName, From result As GoogleSearchResult In Me.searchResults Select (result.ToStringCsv()))
                    MessageBox.Show(Me, "File successfully saved.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    MessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            End If
        End Using

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="Form1.ExitToolStripMenuItem"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="Form1.AboutToolStripMenuItem"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        My.Forms.AboutBox1.ShowDialog()
    End Sub

#End Region

End Class

#End Region
