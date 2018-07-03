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
        debugger;
        ipt.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type:"get"
        };
        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-movies-targetId");
            $(target).replaceWith(data);
        });
        return false;
    };

    $("form[data-movies-ajax='true']").submit(ajaxform);
    $("input[data-movies-autocomplete]").each(creatAutoComplete);
    $(".body-content").on("click", ".pagedList a", getPage);
});