let flyToggleButton = document.getElementById(".burger");
let flyMenu = document.getElementById(".menu-tools");

flyToggleButton.addEventListener("click", (e) => {
    e.preventDefault();
    flyMenu.classList.toggle("open");
});