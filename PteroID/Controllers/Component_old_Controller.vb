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

Namespace Controllers
    Public Class Component_old_Controller
        Inherits System.Web.Mvc.Controller

        Private db As New Ptero2_dbEntities

        ' GET: Component
        Function Index(ByVal sortOrder As String) As ActionResult
            ViewBag.NameSortParm = If(String.IsNullOrEmpty(sortOrder), "desc_short", String.Empty)
            ViewBag.DateSortParm = If(sortOrder = "Date", "date_created", "Date")
            '' Dim processes
            ' Generate a list of components and processes from ComponentProcess
            ''        processes = From m In db.ComponentProcesses
            ''       Select Case m
            ''      For Each c In db.Components
            ''     processes = processes.where(Function(s) s.ComponentId.Equals(c.Id))
            ''    Next



            ' Using Eager Loading
            Dim components = db.Components.Include(Function(c) c.ComponentProcesses.Select(Function(p) p.Process)).Include(Function(c) c.ComponentUsers.Select(Function(u) u.Ptero_User))
            ''  Dim components As Component = db.Components.Include(Function(i) i.ComponentProcesses).Where(Function(i) i.Id = id)

            ' Find Description of Process

            '   ViewBag.ProcessDescription = From p In db.Processes
            'Where p.Id.Equals(From c In components Select c.Id)
            'Select Case p.Description

            ''  If IsNothing(components) Then
            ''  Return HttpNotFound()
            ''  End If 
            Select Case sortOrder
                Case "desc_short"
                    components = components.OrderByDescending(Function(s) s.desc_short)
                Case "desc_long"
                    components = components.OrderBy(Function(s) s.desc_long)
                Case "date_created"
                    components = components.OrderByDescending(Function(s) s.date_created)
                Case Else
                    components = components.OrderBy(Function(s) s.desc_short)
            End Select

            Return View(components.ToList())
        End Function

        ' GET: Component/Details/5
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

        ' GET: Component/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Component/Create
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

        ' GET: Component/Edit/5
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

        ' POST: Component/Edit/5
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

        ' GET: Component/Delete/5
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

        ' POST: Component/Delete/5
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
