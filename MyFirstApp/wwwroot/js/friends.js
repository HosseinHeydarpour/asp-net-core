const loadFriendsButton = document.getElementById("load-friends-button");
loadFriendsButton.addEventListener("click", async (e) => {
    const response = await fetch("friends-list", { method: "GET" });
    const responseBody = await response.text();

    document.querySelector("#list").innerHTML = responseBody;
});