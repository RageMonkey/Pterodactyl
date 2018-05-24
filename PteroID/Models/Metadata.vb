
Imports System.ComponentModel.DataAnnotations


Public Class ComponentMetadata
        '  <UIHint("Component_icon")>   120518   ditched using individual templates, too hard to access ViewData
        <Display(Name:="Short name")>
        <StringLength(8, ErrorMessage:="Short name cannot exceed 8 characters")>
        <Required>
        Public desc_short As Object

        <Display(Name:="Long name")>
        <StringLength(180, ErrorMessage:="Long name cannot exceed 180 characters")>
        Public desc_long As Object

    <DisplayFormat(DataFormatString:="{0:d}")>
    <DataType(DataType.Date)>
    <Display(Name:="Date Created")>
    Public date_created As Object
End Class

    Public Class ProcessMetadata
        <StringLength(20, ErrorMessage:="Description cannot exceed 20 characters")>
        <Required>
        Public Description As Object

    <DisplayFormat(DataFormatString:="{0:d}")>
    <DataType(DataType.Date)>
    <Display(Name:="Date Created")>
    Public date_created As Object
End Class

    Public Class PhaseMetadata
        <StringLength(20, ErrorMessage:="Description cannot exceed 20 characters")>
        <Required>
        Public Description As Object

    <DisplayFormat(DataFormatString:="{0:d}")>
    <DataType(DataType.Date)>
    <Display(Name:="Date Created")>
    Public date_created As Object
End Class
    Public Class Ptero_UserMetadata

        <StringLength(20, ErrorMessage:="First Name cannot exceed 20 characters")>
        <Display(Name:="First name")>
        <Required>
        Public first_name As Object

        <StringLength(20, ErrorMessage:="Last Name cannot exceed 20 characters")>
        <Display(Name:="Last name")>
        <Required>
        Public last_name As Object

        <StringLength(20, ErrorMessage:="Last Name cannot exceed 20 characters")>
        <Display(Name:="Email")>
        <DataType(DataType.EmailAddress)>
        <Required>
        Public user_email As Object

    <DisplayFormat(DataFormatString:="{0:d}")>
    <DataType(DataType.Date)>
    <Display(Name:="Date Created")>
    Public date_created As Object
End Class

    Public Class RoleMetadata
        <StringLength(20, ErrorMessage:="Description cannot exceed 20 characters")>
        <Required>
        Public Description As Object

    <DisplayFormat(DataFormatString:="{0:d}")>
    <DataType(DataType.Date)>
    <Display(Name:="Date Created")>
    Public date_created As Object
End Class

    Public Class UserRoleMetadata

    <DisplayFormat(DataFormatString:="{0:d}")>
    <DataType(DataType.Date)>
    <Display(Name:="Date Created")>
    Public date_created As Object
End Class
