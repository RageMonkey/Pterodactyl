<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - INFS3202</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Ideas", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                <img src="~/Content/Images/lb.png" class="img-center" height="50" width="50" />
                <img src="~/Content/Images/spc.png" class="img-center" height="50" width="50" />
               
                    <a class="panel-title" href="@Url.Action("Index", "Components")">
                        All together
                    </a>

               
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li role="separator" class="divider"></li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="modal-body row admin">
        <div class="col-md-4">
            <h2 class="col-md-4">Setup</h2>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Components", "Index", "Component", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block btn-toggle", .onClick = "onTog(this);"})</div>
            </div>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Processes", "Index", "Processes", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block btn-toggle", .onClick = "onTog(this);"})</div>
            </div>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Phases", "Index", "Phases", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block", .onClick = "onTog(this);"})</div>
            </div>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Users", "List", "Manage", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block"})</div>
            </div>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Roles", "Index", "AspNetRoles", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block"})</div>
            </div>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Claims", "Index", "AspNetUserClaims", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block"})</div>
            </div>
            <div class="row">
                <div class="col-md-9 margin-top-20">@Html.ActionLink("Strategies", "Index", "Strategies", New With {.area = ""}, New With {.class = "btn btn-primary btn-lg btn-block disabled"})</div>
            </div>
        </div>
        <div class="col-md-8">
            @RenderBody()
        </div>
    </div>
            <hr />
            <footer>
                <p>&copy; @DateTime.Now.Year - Brainfartz</p>
            </footer>
      

        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/bootstrap")
        @RenderSection("scripts", required:=False)
</body>
</html>
