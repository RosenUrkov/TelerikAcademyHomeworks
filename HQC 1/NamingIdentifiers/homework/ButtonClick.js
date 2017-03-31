function onButtonClick(event) {
    var currentBrowserWindow = window,
        browser = currentBrowserWindow.navigator.appCodeName,
        isMozila = browser === "Mozilla" ? true : false;

    if (isMozila) {
        alert("Yes");
    } else {
        alert("No");
    }
}