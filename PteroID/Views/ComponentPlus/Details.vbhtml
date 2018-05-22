@ModelType PteroID.Models.Component
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
