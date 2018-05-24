@ModelType IEnumerable(Of AllAccountsViewModel)
    @Code
    ViewBag.Title = "List"
    End Code

    <h2>@ViewBag.Title.</h2>

    <p class="text-success">@ViewBag.StatusMessage</p>
 
        <h4>List users of Brainfarts</h4>
        <hr />
        <dl class="dl-horizontal">
            <table class="table">
                <tr>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.Email)
                    </th>
                    <th>
                        @Html.DisplayNameFor(Function(model) model.UserName)
                    </th>
                    <th></th>
                </tr>

                @For Each item In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.Email)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.UserName)
                    </td>
                  
                </tr>
Next

            </table>


        </dl>
   
