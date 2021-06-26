// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// function ShowAndHideDiv() applied to StudentRequest.cshtml
function ShowAndHideDiv() {
    if (document.getElementById('Stu_Yes').checked) {
        document.getElementById('StuWhenHide').style.visibility = "visible";
    }

    if ((document.getElementById('Stu_No').checked || (document.getElementById('Stu_Unsure').checked))) {
        document.getElementById('StuWhenHide').style.visibility = "hidden";
    }
}


//function getSelectedLeaderID() is used in LeaderList.cshtml to get selected option value

function getSelectedLeaderID() {

    document.getElementById("label").innerHTML = document.getElementById("leadersOption").value;

}

