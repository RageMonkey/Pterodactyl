Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PteroID
'Imports PteroID.Models
Imports PteroID.ViewModels

Namespace Controllers
    Public Class ComponentController
        Inherits System.Web.Mvc.Controller

        Private db As New Ptero2_dbEntities

        ' GET: ComponentPlus
        Function Index(ByVal sortOrder As String, ByVal id As Integer?, ByVal pteroUserId As Integer?) As ActionResult
            Dim viewModel = New ComponentProcessUser()
            ViewBag.NameSortParm = If(String.IsNullOrEmpty(sortOrder), "desc_short", String.Empty)
            ViewBag.DateSortParm = If(sortOrder = "Date", "date_created", "Date")
            'Process Descriptions

            Dim pd(db.Components.Count - 1) As String
            'Process Owners
            Dim po(db.Components.Count - 1) As String

            '   For Each c As Component In db.Components
            ' pd(c.Id - 1) = db.Processes.Where(Function(p) p.Id = (c.ComponentProcesses.Where(Function(cp) cp.ComponentId = c.Id).Single().ProcessId)).Single().Description
            ' po(c.Id - 1) = db.Processes.Where(Function(p) p.Id.Equals(c.ComponentProcesses.Where(Function(cp) cp.ComponentId = c.Id).Single.ProcessId)).Single.Description

            '   Next
            '  ViewData("ProcDesc") = pd


            viewModel.Components = db.Components.Include(Function(c) c.ComponentProcesses).Include(Function(c) c.ComponentUsers)

            For Each c As Component In viewModel.Components
                pd(c.Id - 1) = viewModel.Processes.Where(Function(p) p.Id =
                                                             (c.ComponentProcesses.Where(Function(cp) cp.ComponentId =
                                                             c.Id).SingleOrDefault().ProcessId)).SingleOrDefault().Description
            Next
            '  viewModel.Components = db.Components _
            '.Include(Function(i) i.ComponentProcesses.Select(Function(p) p.Process.Description)) _
            ' .Include(Function(i) i.ComponentUsers.Select(Function(u) u.Ptero_User.first_name))

            If id.HasValue Then
                ViewBag.ComponentID = id.Value
                viewModel.Processes = viewModel.Components.Where(Function(i) i.Id = id.Value)
                '    ViewBag.ProcessDescription = viewModel.Processes.Where(Function() )
            End If
            If pteroUserId.HasValue Then
                ViewBag.PteroUserID = pteroUserId.Value
                viewModel.Users = viewModel.Users.Where(Function(x) x.Id = pteroUserId).Single().ComponentUsers
            End If

            Select Case sortOrder
                Case "desc_short"
                    viewModel.Components = viewModel.Components.OrderByDescending(Function(s) s.desc_short)
                Case "desc_long"
                    viewModel.Components = viewModel.Components.OrderBy(Function(s) s.desc_long)
                Case "date_created"
                    viewModel.Components = viewModel.Components.OrderByDescending(Function(s) s.date_created)
                Case Else
                    viewModel.Components = viewModel.Components.OrderBy(Function(s) s.desc_short)
            End Select
            Return View(viewModel)
        End Function

        ' GET: ComponentPlus/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim component As Component = db.Components.Find(id)
            If IsNothing(component) Then
                Return HttpNotFound()
            End If
            Return View(component)
        End Function

        ' GET: ComponentPlus/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ComponentPlus/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,desc_short,desc_long,date_created")> ByVal component As Component) As ActionResult
            If ModelState.IsValid Then
                db.Components.Add(component)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(component)
        End Function

        ' GET: ComponentPlus/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim component As Component = db.Components.Find(id)
            If IsNothing(component) Then
                Return HttpNotFound()
            End If
            Return View(component)
        End Function

        ' POST: ComponentPlus/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,desc_short,desc_long,date_created")> ByVal component As Component) As ActionResult
            If ModelState.IsValid Then
                db.Entry(component).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(component)
        End Function

        ' GET: ComponentPlus/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim component As Component = db.Components.Find(id)
            If IsNothing(component) Then
                Return HttpNotFound()
            End If
            Return View(component)
        End Function

        ' POST: ComponentPlus/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim component As Component = db.Components.Find(id)
            db.Components.Remove(component)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
