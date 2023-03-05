$(document).ready(function () {
   

});

var BaseApi = "https://localhost:7183/help-desk-api/";

function getCountries() {
   $.ajax({
      url: BaseApi + "countries",
      type: "GET",
      dataType: "json",
      contentType: "application/json",
      success: function (res) {
         console.log(res);
      },
      error: function (err) {
         console.log(err);
      }
   });
}