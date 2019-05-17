(function () {
    var results = [];
    var parsedBM = [];
    if (user.Bookmarks !== null)
        user.Bookmarks.forEach((bm) => {
            parsedBM.push(JSON.parse(bm));
        });

    var input = document.getElementById("searchProject");
    input.addEventListener("keyup", function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            document.getElementById("myBtn").click();
        }
    });
   
});

function GoToApiGitHub() {
    $("#result").empty();
    $.ajax({
        type: "GET",
        url: "https://api.github.com/search/repositories?q=" + $("#searchProject").val(),
        success: (response) => {
            console.log(response);
            results = response.items;
            showAllProjects(response.items);
        }
    });
}

function showAllProjects(response) {
    for (var i = 0; i < response.length; i++) {
        var exist = parsedBM.find(f => f.id === response[i].id) !== null;
        $("#result").append(`<div class="project">
                                 <img class="avatar" src="${response[i].owner.avatar_url}" />
                                 <span class="repositoryName">${response[i].name}</span>
                                 <div class="bookMark">
                                 <button onclick="setBookmark(${i},this)" data-exist="${exist}" class="bookmark-button ${exist ? 'chosen' : ''}"><i class="fa fa-star-o">bookMark</i></button>
                                 </div>
                                 </div>`);
    }
}

function setBookmark(index, elem) {
    var res = results[index];
    var exist = elem.getAttribute("data-exist") === 'true';
    if (!exist) {
        $.ajax({
            type: "POST",
            url: "/GitHub/AddBookmark",
            data: {
                bookmarkJson: JSON.stringify(res)
            },
            success: (res) => {
                if (res) {
                    elem.classList.add('chosen');
                    elem.setAttribute("data-exist", true);
                }
            }
        });
    }
    else {

        $.ajax({
            type: "POST",
            url: "/GitHub/RemoveBookmark",
            data: {
                bookmarkJson: JSON.stringify(res)
            },
            success: (res) => {
                if (res) {
                    elem.classList.remove('chosen');
                    elem.setAttribute("data-exist", false);
                }
            }
        });
    }
}