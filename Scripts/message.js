var message = (function () {
    return {
        submit: function (id, e) {
            $(id).submit();
            e.preventDefault();
        },
        error: function () {
            $("#dialog-error").dialog("open");
        },
        delete: function (node, e) {
            $("#dialog-confirm").dialog("option",
                "buttons",
                {
                    "Да": function () {
                        if (node.tagName === 'A') {
                            var link = $(node).attr("href");
                            location.href = link;
                        }
                        else if (node.tagName === 'FORM') {
                            node.submit();
                        }
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