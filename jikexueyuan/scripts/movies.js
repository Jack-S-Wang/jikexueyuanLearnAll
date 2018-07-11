//$.noConflict();//使用该方法会放弃对$符号的控制使用

$.myjq = function () {
    alert("hello myjquery");
}

$.fn.myjq = function () {
    $(this).text("hello myJquery");
}


$(function () {

    //$.myjq();

    $(".reh").myjq();

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

    var submitAutoComp = function (event, ui) {
        var ipt = $(this);
        ipt.val(ui.item.label);
        var aform = ipt.parents("form:first");
        aform.submit();
    };
    var creatAutoComplete = function () {
        var ipt = $(this);
        //$(".ui-menu").css({
        //    "z-index": "1003",
        //    "border": "1px solid #808080 !important",
        //    "background-color": "white",
        //    "width": "145px"
        //});
        //$(".ui-helper-hidden-accessible").css("dispaly", "none");
        var options = {
            select: submitAutoComp,
            source: ipt.attr("data-movies-autocomplete")
        };
        ipt.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };
        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-movies-targetId");
            $(target).replaceWith(data);
        });

        return false;


        //$.ajaxSetup所传入的数使后续的ajax请求不进行明确指定将按这个参数的方式进行请求

    };

    //进行判断，如果成功则输出success失败则输出error
    //$.ajax('/test?err=n').then(function () {
    //    alert("success");
    //}, function () {
    //    alert("error");
    //});


    //使用deferred方法进行ajax请求
    //function tt() {
    //    var defer = $.Deferred();
    //    setTimeout(function () {
    //        var val = Math.random();
    //        val > 0.5 ? defer.resolve(val) : defer.reject(val);
    //    }, 100);
    //    return defer;
    //}

    //tt().done(function (data) {
    //    alert('done:' + data);
    //}).fail(function (data) {
    //    alert('fail:' + data);
    //});

    //异步多操作ui地址
    //function testWhen() {
    //    $.when($.ajax('/test?err=n&a=1'),
    //        $.ajax('/text?err=n&a=2'),
    //         $.ajax('/text?err=n&a=3')
    //        ).then(function () {
    //            alert('success');
    //            console.log(arguments);
    //        }, function (promise, statusText, errobj) {
    //            alert('error');
    //            console.log(arguments);
    //        });
    //};

    //function testChain() {
    //    $.ajax('/test?err=n').then(function () {
    //        alert("success 1");
    //        return $.ajax('/test?a=yes');
    //    }, function () {
    //        alert("error 1");
    //        return $.ajax('/test?a=no');
    //    }).then(function () {
    //        alert("success 2");
    //        return $.ajax();
    //    }).then();
    //};




    $("form[data-movies-ajax='true']").submit(ajaxform);
    $("input[data-movies-autocomplete]").each(creatAutoComplete);
    $(".body-content").on("click", ".pagedList a", getPage);
    $(document).ready(function () {
        //alert("加载完毕");
    });

    $(".h").click(function () {
        $(".pt").hide(1000);
    });
    $(".s").click(function () {
        $(".pt").show(1000);
    });
    $(".hs").click(function () {
        $(".pt").toggle(1000);
    });

    $(".fin").click(function () {
        $(".div1").fadeIn(1000);
        $(".div2").fadeIn(1000);
        $(".div3").fadeIn(1000);
    })
    $(".fout").click(function () {
        $(".div1").fadeOut(1000);
        $(".div2").fadeOut(1000);
        $(".div3").fadeOut(1000);
    })
    $(".ftoggle").click(function () {
        $(".div1").fadeToggle(1000);
        $(".div2").fadeToggle(1000);
        $(".div3").fadeToggle(1000);
    })
    $(".fto").click(function () {
        $(".div1").fadeTo(1000, 0.1);
        $(".div2").fadeTo(1000, 0.3);
        $(".div3").fadeTo(1000, 0.6);
    })

    $(".sdown").click(function () {
        $(".div1").slideDown(1000);
    })

    $(".sup").click(function () {
        $(".div1").slideUp(1000);
    })
    $(".stoggle").click(function () {
        $(".div1").slideToggle(1000);
    })
    $(".reh").click(function () {
        $(".div1").hide(1000).show(1000);
    })
    $(window).load(function () {
        imgLocation();
        //$(window).scroll(function () {
        //    var img = { "data": [{ "src": "/Resources/baby.jpg" }, { "src": "/Resources/baby2.jpg" }, { "src": "/Resources/bear.jpg" }, { "src": "/Resources/BEER.png" }, { "src": "/Resources/building.jpg" }] };
        //    if (scrollSide()) {
        //        $.each(img.data, function (index, value) {
        //            var box = $("<div>").addClass("box").appendTo("#cont");
        //            var content = $("<div>").addClass("content").appendTo(box);
        //            var imgb = $("<img>").attr("src", $(value).attr("src")).appendTo(content);
        //            console.log(imgb.attr("src"));
        //        });
        //    }
        //    imgLocation();
        //});
    });
    $(window).resize(function () {
        imgLocation();
    });


    $(".main>a").click(function () {
        var ulNode = $(this).next("ul");
        //if (ulNode.css("display") == "none") {
        //    ulNode.css("display", "block");
        //} else {
        //    ulNode.css("display", "none");
        //}
        //ulNode.toggle(1000);//数字，slow,normal,fast
        ulNode.slideToggle(1000);
    })

    //横向菜单鼠标停留在上面进行显示
    $(".hmain").hover(function () {
        var ulNode = $(this).children("ul");
        ulNode.slideDown(500);
    }, function () {
        $(this).children("ul").slideUp();
    });
    var timeoutid;
    $(".tabin-ul li").each(function (index) {
        var liNode = $(this);
        liNode.mouseover(function () {
            timeoutid = setTimeout(function () {
                $("div.tabin-div").removeClass("tabin-div");
                $(".tabin-ul li.tabin").removeClass("tabin");
                $(".contentfirst").eq(index).addClass("tabin-div");
                liNode.addClass("tabin");
            }, 300);
        }).mouseout(function () {
            clearTimeout(timeoutid);
        })
    });
    
    $("#realcontent").load("/Resources/hh.html");
    $("#tabsecond li").each(function (index) {
        $(this).click(function () {
            $("#tabsecond li.tabin").removeClass("tabin");
            $(this).addClass("tabin");
            if (index == 0) {
                $("#realcontent").load("/Resources/hh.html");
            } else if (index == 1) {
                $("#realcontent").load("/Resources/hh.html h3");
            } else if (index == 2) {
                $("#realcontent").load("/Resources/hh.html");
            }
        });
    });





})

function scrollSide() {
    var box = $(".box");
    if (box != undefined) {
        var imglastHeight = box.last().get(0).offsetTop + Math.floor(box.last().height() / 2);
        var documentHeight = $(window).height();
        var scrollHeight = $(window).scrollTop();
        return (documentHeight + scrollHeight > imglastHeight) ? true : false;
    }
    return false;
};


function imgLocation() {
    var box = $(".box");
    var boxWidth = box.eq(0).width();
    var allWidth = $(window).width();
    var num = Math.floor(allWidth / boxWidth);
    //console.log(num);
    var boxArr = [];
    box.each(function (index, value) {
        // console.log(index + "---" + value);
        var boxHeight = box.eq(index).height();
        if (index < num) {
            boxArr[index] = boxHeight;
            var left = 0;
            if (index > 0) {
                left = box.eq(index - 1).position().left + boxWidth;
            }
            $(value).css({
                "position": "absolute",
                "top": 0,
                "left": left
            });
            //console.log(boxHeight);
        } else {
            var minboxHeight = Math.min.apply(null, boxArr);
            //console.log(minboxHeight);
            var minboxIndex = $.inArray(minboxHeight, boxArr);
            //console.log(minboxIndex);
            //console.log(value);
            $(value).css({
                "position": "absolute",
                "top": minboxHeight,
                "left": box.eq(minboxIndex).position().left
            });
            boxArr[minboxIndex] += box.eq(index).height();

        }
    });
}