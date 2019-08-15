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
Imports System.Globalization
Imports System.Text

#End Region

#Region " EncodingTypeConverter "

' ReSharper disable once CheckNamespace

Namespace DevCase.Core.Design

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Provides a unified way of converting types of values to a <see cref="System.Text.Encoding"/> object.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code>
    ''' &lt;TypeConverter(GetType(EncodingTypeConverter))&gt;
    ''' &lt;DefaultValue(GetType(String), "UTF-8")&gt;
    ''' &lt;Browsable(True)&gt;
    ''' Public Property TextEncoding As Encoding = Encoding.UTF8
    ''' 
    ''' &lt;TypeConverter(GetType(EncodingTypeConverter))&gt;
    ''' &lt;DefaultValue(GetType(String), "UTF-8")&gt;
    ''' &lt;Browsable(True)&gt;
    ''' Public Property TextEncodingName As String = "UTF-8"
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <seealso cref="TypeConverter"/>
    ''' ----------------------------------------------------------------------------------------------------
    Public Class EncodingTypeConverter : Inherits TypeConverter

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="EncodingTypeConverter"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

#End Region

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns whether this converter can convert an object of the given type to the type of this converter, 
        ''' using the specified context.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="context">
        ''' An <see cref="ITypeDescriptorContext"/> that provides a format context.
        ''' </param>
        ''' 
        ''' <param name="sourceType">
        ''' A <see cref="Type"/> that represents the type you want to convert from.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if this converter can perform the conversion; otherwise, <see langword="False"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overloads Overrides Function CanConvertFrom(context As ITypeDescriptorContext, sourceType As Type) As Boolean

            If sourceType = GetType(Integer) Then
                Return True
            End If

            If sourceType = GetType(String) Then
                Return True
            End If

            Return MyBase.CanConvertFrom(context, sourceType)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns whether this converter can convert the object to the specified type, using the specified context.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="context">
        ''' An <see cref="ITypeDescriptorContext"/> that provides a format context.
        ''' </param>
        ''' 
        ''' <param name="destinationType">
        ''' A <see cref="Type"/> that represents the type you want to convert to.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if this converter can perform the conversion; otherwise, <see langword="False"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overloads Overrides Function CanConvertTo(context As ITypeDescriptorContext, destinationType As Type) As Boolean

            If destinationType = GetType(Integer) Then
                Return True
            End If

            If destinationType = GetType(String) Then
                Return True
            End If

            Return MyBase.CanConvertTo(context, destinationType)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Converts the given object to the type of this converter, using the specified context and culture information.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="context">
        ''' An <see cref="ITypeDescriptorContext"/> that provides a format context.
        ''' </param>
        ''' 
        ''' <param name="culture">
        ''' The <see cref="CultureInfo"/> to use as the current culture.
        ''' </param>
        ''' 
        ''' <param name="value">
        ''' The <see cref="Object"/> to convert.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' An <see cref="Object"/> that represents the converted value.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="FormatException">
        ''' Valid Range is between 0% and 100%.
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overloads Overrides Function ConvertFrom(context As ITypeDescriptorContext, culture As CultureInfo,
                                                        value As Object) As Object

            If TypeOf value Is String Then
                Dim intValue As Integer
                If Integer.TryParse(value.ToString(), intValue) Then
                    Return Encoding.GetEncoding(intValue)
                End If

                Return Encoding.GetEncoding(value.ToString())
            End If

            Return MyBase.ConvertFrom(context, culture, value)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Converts the given value object to the specified type, using the specified context and culture information.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="context">
        ''' An <see cref="ITypeDescriptorContext"/> that provides a format context.
        ''' </param>
        ''' 
        ''' <param name="culture">
        ''' A <see cref="CultureInfo"/>. If null is passed, the current culture is assumed.
        ''' </param>
        ''' 
        ''' <param name="value">
        ''' The <see cref="Object"/> to convert.
        ''' </param>
        ''' 
        ''' <param name="destinationType">
        ''' The <see cref="Type"/> to convert the <paramref name="value"/> parameter to.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' An <see cref="Object" /> that represents the converted value.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentNullException">
        ''' destinationType
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        Public Overloads Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo,
                                                      value As Object, destinationType As Type) As Object

            If (destinationType Is Nothing) Then
                Throw New ArgumentNullException(NameOf(destinationType))
            End If

            If TypeOf value Is Encoding Then
                Return DirectCast(value, Encoding).WebName.ToUpper()
            End If

            If TypeOf value Is Integer Then
                Return Encoding.GetEncoding(CInt(value)).WebName.ToUpper()
            End If

            If TypeOf value Is String Then
                Return Encoding.GetEncoding(value.ToString()).WebName.ToUpper()
            End If

            Return MyBase.ConvertTo(context, culture, value, destinationType)

        End Function

#End Region

    End Class

End Namespace

#End Region
