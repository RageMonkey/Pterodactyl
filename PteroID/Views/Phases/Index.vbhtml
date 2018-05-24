@ModelType IEnumerable(Of Phase)
@Code
    ViewData("Title") = "Phases"
End Code

<h2>Phases</h2>
<div class="container">
    <p class="col-md-6">These are the minor stages each Process goes through.  We show the default three steps as set out in the PMI's official paper</p>
</div>
<div class="container">
    <p class="col-md-6">
        @Html.ActionLink("Create New", "Create")
    </p>
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.date_created)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.date_created)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </td>
        </tr>
    Next

</table>
