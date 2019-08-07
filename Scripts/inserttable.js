$(document).ready(function () {
    var table = $("#musics").DataTable({
        ajax: {
            url: "/api/musics",
            dataSrc: ""
        },
        columns: [
            {
                data: "title",
            },
            {
                data: "artist"
            },
            {
                data: "id",
                render: function (data) {
                    return "<a href='/musics/" + data + "'>" + "View" + "</a>";
                }
            }
        ]
    });
});