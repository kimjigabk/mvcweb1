$(document).ready(function () {
    var table = $("#musics").DataTable({
        ajax: {
            url: "/api/musics",
            dataSrc: ""
        },
        columns: [
            {
                data: "title",
                render: function (data,type,music) {
                    return "<a href='/musics/" + music.id + "'>" + music.title + "</a>";
                }
            },
            {
                data: "artist",
                render: function (data, type, music) {
                    return "<a href='/musics/" + music.id + "'>" + music.artist + "</a>";
                }

            },
        ]
    });
});