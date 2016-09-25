function WarningMessage(msg) {
    bootbox.alert("<span style='color: red;'>" + msg + "</span>");
}
function ConfirmMessage(msg) {

    bootbox.confirm("<span style='color: red;'>" + msg + "</span>", function (result) {
        //Example.show("Confirm result: " + result);
        return result;
    });
    //return bootbox.confirm("<span style='color: red;'>" + msg + "</span>");
    //if (r == true) {
    //    return true;
    //} else {
    //    return false;
    //}
}