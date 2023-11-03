// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#example').DataTable({
        "aLengthMenu": [[5, 50, 15, -1], [5, 10, 15, "All"]],
            "pageLength": 5
    });
});