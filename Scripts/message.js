var message = (function () {
    return {
        submit: function (id, e) {
            $(id).submit();
            e.preventDefault();
        },
        error: function () {
            $("#dialog-error").dialog("open");
        },
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
    $("#dialog-confirm, #dialog-error").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        autoOpen: false
    });
});