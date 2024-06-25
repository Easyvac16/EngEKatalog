// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('search-btn').addEventListener('click', function () {
    var searchValue = document.getElementById('search').value;
    if (searchValue) {
        window.location.href = `/ApiResponse/List?q=${encodeURIComponent(searchValue)}`;
    }
});

let search = document.getElementById('search')

function searchItem() {
    let assignStr = `?q=${search.value}`;

    if (searchValue) {
        window.location.href = `/ApiResponse/List?q=${encodeURIComponent(searchValue)}`;
    }
    
    window.location.assign(assignStr);
}