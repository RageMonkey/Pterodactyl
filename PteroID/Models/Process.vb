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

<System.ComponentModel.DataAnnotations.MetadataTypeAttribute(GetType(ProcessMetadata))>
Partial Public Class Process
    Public Property Id As Integer
    Public Property Description As String
    Public Property date_created As Date

    Public Overridable Property ComponentProcesses As ICollection(Of ComponentProcess) = New HashSet(Of ComponentProcess)
    Public Overridable Property PhaseProcesses As ICollection(Of PhaseProcess) = New HashSet(Of PhaseProcess)
    Public Overridable Property Processusers As ICollection(Of Processuser) = New HashSet(Of Processuser)

End Class
