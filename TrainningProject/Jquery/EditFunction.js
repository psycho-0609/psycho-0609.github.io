$(document).ready(function () {
    $("#btnEdit").click(function () {
        ShowForm();
    })
    $("#btnCancel").click(function () {
        HideForm();
    })
})
function ShowForm() {
    $("#sectionEdit").slideDown("slow");
    $("#btnEdit").css("visibility", "hidden");

}
function HideForm() {
    $("#sectionEdit").slideUp("slow");
    $("#btnEdit").css("visibility", "visible");
}