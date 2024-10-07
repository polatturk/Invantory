document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchItem");
    const itemList = document.getElementById("itemList");
    const options = Array.from(itemList.querySelectorAll("option")).map(option => option.value);

    searchInput.addEventListener("input", function () {
        const searchValue = searchInput.value.toLowerCase();
        let matchFound = options.find(option => option.toLowerCase().startsWith(searchValue));

        if (matchFound && searchValue !== matchFound.toLowerCase()) {
            // Kullanıcının girdiği kısmı değişmeden bırak, geri kalan kısmı seçili göster
            searchInput.value = matchFound;
            searchInput.setSelectionRange(searchValue.length, matchFound.length);
        }
    });

    searchInput.addEventListener("keydown", function (e) {
        // Kullanıcı geri tuşuna basarsa veya yazmaya devam ederse seçili metni kaldır.
        if (e.key === "Backspace" || e.key === "ArrowLeft" || e.key === "ArrowRight") {
            searchInput.setSelectionRange(searchInput.value.length, searchInput.value.length);
        }
    });
});
