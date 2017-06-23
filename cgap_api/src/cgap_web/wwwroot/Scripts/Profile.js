$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:59321/api/profiles",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var DIV = '';
            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td id='Name'>" + item.name + "</td>" +
                    "<td id='Send'>" + item.send + "</td>" +
                    "<td id='Receive'>" + item.receive + "</td>" +
                    "<td id='Audit'>" + item.audit + "</td>" +
                    "</tr>";
                $('#TableProfiles').append(rows);
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