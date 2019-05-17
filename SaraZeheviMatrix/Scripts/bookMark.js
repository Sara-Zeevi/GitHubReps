(function () {
    var parsedBM = [];
    if (user.Bookmarks !== null)
        user.Bookmarks.forEach((bm) => {
            parsedBM.push(JSON.parse(bm));
        });
    for (var i = 0; i < parsedBM.length; i++) {
        $('#result').append(`<div class="project">
                                 <img class="avatar" src="${parsedBM[i].owner.avatar_url}" />
                                 <span class="repositoryName">${parsedBM[i].name}</span>
                                 </div>`);
    }
});