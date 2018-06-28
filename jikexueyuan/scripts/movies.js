
$(function () {
    var ajaxform = function () {
        var aform = $(this);

        var option = {
            Url: aform.attr("action"),
            type: aform.attr("method"),
            data: aform.serialize()
        };
        //先执行请求获取了局部样式，将样式更换为获取的值
        $.ajax(option).done(function (d) {
            var targetId = $(aform.attr("data-movies-targetId"));
            targetId.replaceWith(d);
        });
        return false;
    };

    var submitAutoComp = function (event,ui) {
        var ipt = $(this);
        ipt.val(ui.item.label);
        var aform = ipt.parents("form:first");
        aform.submit();
    };
    var creatAutoComplete = function () {
        var ipt = $(this);
        var options = {
            select:submitAutoComp,
            source:ipt.attr("data-movies-autocomplete")
        };
        ipt.autocomplete(options);
    };

    $("form[data-movies-ajax='true']").submit(ajaxform);
    $("input[data-movies-autocomplete]").each(creatAutoComplete);

});