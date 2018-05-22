@ModelType PteroID.Models.Component
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Component</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.desc_short)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.desc_short)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.desc_long)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.desc_long)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.date_created)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.date_created)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
