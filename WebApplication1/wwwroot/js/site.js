// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ShowAndHideDiv() {
    if (document.getElementById('Stu_Yes').checked) {
        document.getElementById('StuWhenHide').style.visibility = 'visible';
    }

    if ((document.getElementById('Stu_No').checked || (document.getElementById('Stu_Unsure').checked))) {
        document.getElementById('StuWhenHide').style.visibility = 'hidden';
    }
}
 