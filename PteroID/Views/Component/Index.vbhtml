@ModelType IEnumerable(Of Models.Component)
@Code
    ViewData("Title") = "Components: Processes and Users"
End Code

<h2>Components</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
         
            @Html.ActionLink("Short Description", "Index", New With {.sortOrder = ViewBag.NameSortParm})
        </th>
        <th>
            @Html.ActionLink("Long Description", "Index", New With {.sortOrder = ViewBag.NameSortParm})
        </th>
        <th>
            @Html.ActionLink("Date Created", "Index", New With {.sortOrder = ViewBag.DateSortParm})
        </th>
        <th>
            Process
        </th>
        <th>
            Owner
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

        @Html.DisplayFor(Function(modelItem) item.ComponentProcesses.FirstOrDefault.ComponentId)

    </td>
    <td>

        @Html.DisplayFor(Function(modelItem) item.ComponentUsers.FirstOrDefault.Ptero_UserId)

    </td>
    <td>
        @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
        @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
        @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
    </td>
</tr>
Next

</table>
