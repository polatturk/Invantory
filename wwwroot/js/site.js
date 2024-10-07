document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchItem");
    const itemList = document.getElementById("itemList");
    const options = Array.from(itemList.querySelectorAll("option")).map(option => option.value);

    //tamamlama islemi
    searchInput.addEventListener("input", function () {
        const searchValue = searchInput.value.toLowerCase();
        let matchFound = options.find(option => option.toLowerCase().startsWith(searchValue));

        if (matchFound && searchValue !== matchFound.toLowerCase()) {
            searchInput.value = matchFound;
            searchInput.setSelectionRange(searchValue.length, matchFound.length);
        }
    });

    //silme islemi
    searchInput.addEventListener("keydown", function (e) {
        if (e.key === "Backspace" || e.key === "Delete") {
            e.preventDefault();

            let start = searchInput.selectionStart;
            let end = searchInput.selectionEnd;

            if (start === end) {
                if (e.key === "Backspace" && start > 0) {
                    searchInput.value = searchInput.value.slice(0, start - 1) + searchInput.value.slice(start);
                    searchInput.setSelectionRange(start - 1, start - 1);
                }
                else if (e.key === "Delete" && start < searchInput.value.length) {
                    searchInput.value = searchInput.value.slice(0, start) + searchInput.value.slice(start + 1);
                    searchInput.setSelectionRange(start, start);
                }
            } else {
                searchInput.value = searchInput.value.slice(0, start) + searchInput.value.slice(end);
                searchInput.setSelectionRange(start, start);
            }
        }
    });
});
