'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

<System.ComponentModel.DataAnnotations.MetadataTypeAttribute(GetType(ComponentMetadata))>
Partial Public Class Component
    Public Property Id As Integer
    Public Property desc_short As String
    Public Property desc_long As String
    Public Property date_created As Date

    Public Overridable Property ComponentProcesses As ICollection(Of ComponentProcess) = New HashSet(Of ComponentProcess)
    Public Overridable Property ComponentUsers As ICollection(Of ComponentUser) = New HashSet(Of ComponentUser)
    Public Overridable Property Component_log As ICollection(Of Component_log) = New HashSet(Of Component_log)

End Class
