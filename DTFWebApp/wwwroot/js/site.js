// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var url = window.location.href;
//console.log(url);

if (url == 'https://localhost:44341/') {
    $("#sidebar").hide();
    $("#navbar").hide();
} else {
    $("#sidebar").show();
    $("#navbar").show();
}