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

Namespace Models
    Partial Public Class Component_log
        Public Property Id As Integer
        Public Property KeyFieldID As Integer
        Public Property AuditActionTypeENUM As Integer
        Public Property DateTimeStamp As Date
        Public Property DataModel As String
        Public Property Changes As String
        Public Property ValueBefore As String
        Public Property ValueAfter As String

        Public Overridable Property Component As Component

    End Class
End Namespace