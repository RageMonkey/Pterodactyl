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
    Partial Public Class PhaseProcess
        Public Property Id As Integer
        Public Property PhaseId As Integer
        Public Property ProcessId As Integer
        Public Property date_created As Date

        Public Overridable Property Phase As Phase
        Public Overridable Property Process As Process

    End Class
End Namespace