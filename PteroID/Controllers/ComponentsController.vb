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
    Public Class ComponentsController
        Inherits System.Web.Mvc.Controller

        Private db As New Ptero2_dbEntities

        ' GET: Components
        Function Index() As ActionResult
            ' Calculate the dimensions to be used for display characteristics 
            Dim dimensions(db.Components.Count - 1) As String
            For Each c As Component In db.Components
                Select Case DateDiff(DateInterval.Day, c.date_created, Now())
                    Case < 14
                        dimensions(c.Id - 1) = "comp_circle_100"
                    Case 15 To 30
                        dimensions(c.Id - 1) = "comp_circle_80"
                    Case 31 To 59
                        dimensions(c.Id - 1) = "comp_circle_60"
                    Case 60 To 179
                        dimensions(c.Id - 1) = "comp_circle_40"
                    Case > 180
                        dimensions(c.Id - 1) = "comp_circle_20"
                End Select

            Next
            ViewData("Age") = dimensions
            Return View(db.Components.ToList())
        End Function

        ' GET: Components/Details/5
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

        ' GET: Components/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Components/Create
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

        ' GET: Components/Edit/5
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

        ' POST: Components/Edit/5
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

        ' GET: Components/Delete/5
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

        ' POST: Components/Delete/5
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
