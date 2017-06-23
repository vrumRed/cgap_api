$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:59321/api/products",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var DIV = '';
            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td id='Description'>" + item.description + "</td>" +
                    "<td id='Brand'>" + item.brand + "</td>" +
                    "<td id='Tag'>" + item.tag + "</td>" +
                    "<td id='Price'>" + item.price + "</td>" +
                    "<td id='Room'>" + item.room + "</td>" +
                    "</tr>";
                $('#TableProducts').append(rows);
            }); //End of foreach Loop   
            console.log(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
});