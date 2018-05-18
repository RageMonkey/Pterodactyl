Imports PteroID.Models

Namespace ViewModels

    Public Class ComponentProcessUser
        Public Property Users As IEnumerable(Of Ptero_User)
        Public Property Processes As IEnumerable(Of Process)
        Public Property Components As IEnumerable(Of Component)
    End Class

End Namespace