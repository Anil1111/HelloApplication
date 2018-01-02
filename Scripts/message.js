var message = (function () {
    return {
        deleteMessage: function (node, e) {
            var link = $(node).attr("href");
            $("#dialog-confirm").dialog("option",
                "buttons",
                {
                    "Да": function () {
                        location.href = link;
                    },
                    "Отмена": function () {
                        $("#dialog-confirm").dialog("close");
                    }
                }
            );
            $("#dialog-confirm").dialog("open");
            e.preventDefault();
        },
    }
})();

$(function () {
    $("#dialog-confirm").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        autoOpen: false
    });
});