$(document).ready(function () {
   
    $("#details-btn").click(function () {
        var inputid = document.getElementById('person-id').value;
        if (inputid != null && inputid > 0
            && inputid < 1000 && Number.isInteger(parseFloat(inputid))) {
            $.ajax({
                type: "POST",
                url: "/Person/PersonDetails",
                data: { id: inputid },
                dataType: "HTML",
                success: function (data) {
                    $("#message").empty();
                    $("#People").empty();
                    document.getElementById('People').innerHTML = data;
                },
                error: function () {
                    alert("Error occured!!")
                }
            })
        }
        else {
            $("#People").empty();
            $("#message").empty();
            document.getElementById('message').innerHTML = "Invalid ID";
        }
    })
    
})
