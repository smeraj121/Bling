var menuOpen = false;
function openNav() {
    if (menuOpen) { closeNav(); return; }
    document.getElementById("mySidenav").style.width = "250px";
    document.getElementById("mySidenav").style.padding = "60px 0 0 0";
    menuOpen = true;
}
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("mySidenav").style.padding = "0 0 0 0";
    menuOpen = false;
}