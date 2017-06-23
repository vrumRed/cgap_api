$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:59321/api/users",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(JSON.stringify(data));                  
            $("#DIV").html('');
            var DIV = '';
            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td id='Name'>" + item.name + "</td>" +
                    "<td id='Birthdate'>" + item.birthdate + "</td>" +
                    "<td id='RG'>" + item.rg + "</td>" +
                    "<td id='CPF'>" + item.cpf + "</td>" +
                    "<td id='E-mail'>" + item.email + "</td>" +
                    "<td id='Department'>" + item.department + "</td>" +
                    "<td id='Profile'>" + item.profile + "</td>" +
                    "</tr>";
                $('#TableUsers').append(rows);
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