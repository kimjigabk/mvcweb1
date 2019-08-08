$(document).ready(function () {
    var table = $("#musics").DataTable({
        ajax: {
            url: "/api/musics",
            dataSrc: ""
        },
        columns: [
            {
                data: "title",
                render: function (data, type, music) {
                    return "<a href='/musics/detail/" + music.id + "'>" + music.title + "</a>";
                }
            },
            {
                data: "artist",
                render: function (data, type, music) {
                    return "<a href='/musics/detail/" + music.id + "'>" + music.artist + "</a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-music-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $("#musics").on("click", ".js-delete", function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this music?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/musics/" + button.attr("data-music-id"),
                    method: "DELETE",
                    success: function () {
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

});