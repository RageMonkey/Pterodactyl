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
    <Authorize>
    Public Class ProcessesController
        Inherits System.Web.Mvc.Controller

        Private db As New Ptero2_dbEntities

        ' GET: Processes
        Function Index() As ActionResult
            Return View(db.Processes.ToList())
        End Function

        ' GET: Processes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim process As Process = db.Processes.Find(id)
            If IsNothing(process) Then
                Return HttpNotFound()
            End If
            Return View(process)
        End Function

        ' GET: Processes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Processes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,date_created")> ByVal process As Process) As ActionResult
            If ModelState.IsValid Then
                db.Processes.Add(process)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(process)
        End Function

        ' GET: Processes/Edit/5 
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim process As Process = db.Processes.Find(id)
            If IsNothing(process) Then
                Return HttpNotFound()
            End If
            Return View(process)
        End Function

        ' POST: Processes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,date_created")> ByVal process As Process) As ActionResult
            If ModelState.IsValid Then
                db.Entry(process).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(process)
        End Function

        ' GET: Processes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim process As Process = db.Processes.Find(id)
            If IsNothing(process) Then
                Return HttpNotFound()
            End If
            Return View(process)
        End Function

        ' POST: Processes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim process As Process = db.Processes.Find(id)
            db.Processes.Remove(process)
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
