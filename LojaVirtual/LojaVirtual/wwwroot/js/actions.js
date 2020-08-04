$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var confirm = confirm("Tem certeza que deseja excluir este registro?");
        e.preventDefault();

        if (confirm == false) {
            e.preventDefault();
        }
    });
})