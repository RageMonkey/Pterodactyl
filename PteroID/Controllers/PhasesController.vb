Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PteroID
Imports PteroID.Models

Namespace Controllers
    Public Class PhasesController
        Inherits System.Web.Mvc.Controller

        Private db As New Ptero2_dbEntities

        ' GET: Phases
        Function Index() As ActionResult
            Return View(db.Phases.ToList())
        End Function

        ' GET: Phases/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim phase As Phase = db.Phases.Find(id)
            If IsNothing(phase) Then
                Return HttpNotFound()
            End If
            Return View(phase)
        End Function

        ' GET: Phases/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Phases/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Description,date_created")> ByVal phase As Phase) As ActionResult
            If ModelState.IsValid Then
                db.Phases.Add(phase)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(phase)
        End Function

        ' GET: Phases/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim phase As Phase = db.Phases.Find(id)
            If IsNothing(phase) Then
                Return HttpNotFound()
            End If
            Return View(phase)
        End Function

        ' POST: Phases/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Description,date_created")> ByVal phase As Phase) As ActionResult
            If ModelState.IsValid Then
                db.Entry(phase).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(phase)
        End Function

        ' GET: Phases/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim phase As Phase = db.Phases.Find(id)
            If IsNothing(phase) Then
                Return HttpNotFound()
            End If
            Return View(phase)
        End Function

        ' POST: Phases/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim phase As Phase = db.Phases.Find(id)
            db.Phases.Remove(phase)
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
