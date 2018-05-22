@ModelType IEnumerable(Of PteroID.Models.Component)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.desc_short)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.desc_long)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.date_created)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.desc_short)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.desc_long)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.date_created)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
