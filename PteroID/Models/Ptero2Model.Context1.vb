﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports PteroID.Models

Partial Public Class Ptero2_dbEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Ptero2_dbEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Components() As DbSet(Of Component)
    Public Overridable Property ComponentProcesses() As DbSet(Of ComponentProcess)
    Public Overridable Property ComponentUsers() As DbSet(Of ComponentUser)
    Public Overridable Property Phases() As DbSet(Of Phase)
    Public Overridable Property PhaseProcesses() As DbSet(Of PhaseProcess)
    Public Overridable Property Processes() As DbSet(Of Process)
    Public Overridable Property Processusers() As DbSet(Of Processuser)
    Public Overridable Property Ptero_User() As DbSet(Of Ptero_User)
    Public Overridable Property Roles() As DbSet(Of Role)
    Public Overridable Property UserRoles() As DbSet(Of UserRole)
    Public Overridable Property Component_log() As DbSet(Of Component_log)

End Class
