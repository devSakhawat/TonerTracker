// JavaScript source code

$(function () {
   getCustomers();
});

var baseApi = "https://localhost:7252/toner-tracker/";
// Get Customers list
function getCompanies() {
$.ajax({
   url: baseApi + 'companies',
   type: 'GET',
   dataType: 'json',
   contextType: 'application/json',
   success: function (res) {
      $.each(res, function (i, item) {
         var companiesNbranch = '<div class="nav-item dropdown">'
            + '<a onclick="getBranch()" class="dropdown - item">'
            + item.companyName
            + '</a>'
            + 
               <div class="dropdown-menu bg-transparent border-0">
                  @foreach (var branch in Model.Branches.ToList())
                  {
                     <a asp-controller="Machine" asp-action="Index" asp-route-branchId="@branch.ID" class="dropdown-item">
                        @branch.BranchName
                     </a>
                  }
                  <a asp-area="" asp-controller="Company" asp-action="Index" class="dropdown-item">Companies</a>
                  <a asp-controller="Company" asp-action="Create" class="dropdown-item">New Company</a>
               </div>
            + '</div>';
         var rows = "<tr>"
            + "<td class='prtoducttd'>" + item.studentID + "</td>"
            + "<td class='prtoducttd'>" + item.studentName + "</td>"
            + "<td class='prtoducttd'>" + item.studentAddress + "</td>"
            + "</tr>";
         $('#tblStudent tbody').append(rows);
      });
               },
   error: function (err) {
      console.log(err);
      }
   });
};

