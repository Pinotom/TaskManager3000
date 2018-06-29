$(document).ready(function () {
    $("body").on("click", ".close", function () {
        var taskId = this.id;
        $(this).parent().parent().load('DeleteTask/' + taskId);
    });
    $("#User_Id").change(function () {
        if ($(this).val() === "") {
            $("#newUserForm").show();
            $("#btnConfirm").hide();
        }
        else {
            $("#newUserForm").hide();
            $("#btnConfirm").show();
        }
    });
});