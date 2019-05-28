// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.onload = show_active_page();
function show_active_page() {
    //var x = document.getElementById("myDIV");
    //var y = document.querySelector("child");
    var y = document.querySelectorAll("a");
    //var x = document.querySelectorAll(".child");
    //x[0].style.backgroundColor = "red";
    //y = divers.getElementsByClassName("child");

    //y[0].className = y[0].className.replace("child", "red");
    //y[0].className = y[0].className.replace("child", "red");
    for (var i = 0; i < y.length; i++) {
        //y[i].className = 'red';
        if (document.links[i].href === document.URL) {
            y[i].className += ' my-active';
        }

        //y[i].className = y[i].className.replace("child", "red");
        //this[i].className = "red";
    }
}
