(function (window, document, $) {
    "use strict";
    function n(e, t) {
        return '<span class="ticket" data-row-id="' + e + '" data-column-id="' + t + '" data-index="' + e + "-" + t + '">' + e + "排" + t + "座</span>"
    }
    function s(e) {
        return e.hasClass("lover-left") || e.hasClass("lover-right")
    }
    function r(e) {
        return e.hasClass("lover-left") ? e.next(".lover-right") : e.prev(".lover-left")
    }
    function o(e) {
        var t = e.data()
            , a = t.rowId
            , s = t.columnId
            , r = t.no
            , o = t.st;
        B.push({
            rowId: a,
            columnId: s,
            seatNo: r,
            type: o
        }),
            k.append(n(a, s)),
            e.removeClass("selectable").addClass("selected")

        $('#selected-seat').val(JSON.stringify(B));
    }
    function c(e) {
        return /*B.length >= P ? d("一次最多购买" + P + "张票") :*/ (x.hide(),
            g.show(),
            o(e),
            s(e) && o(r(e)),
            q.removeClass("disable"))
        // void j.text(A[B.length].price.replace("元", "")))
    }
    function i(e) {
        var t = e.data()
            , a = t.rowId
            , n = t.columnId
            , s = a + "-" + n;
        B = B.filter(function (e) {
            return !(e.rowId === a && e.columnId === n)
        }),
            $('.ticket[data-index="' + s + '"]').remove(),
            //j.text(A[B.length].price.replace("元", "")),
            e.removeClass("selected").addClass("selectable")
        $('#selected-seat').val(JSON.stringify(B));
    }
    function l(e) {
        i(e), s(e) && i(r(e)), 0 === B.length && (x.show(), g.hide(), q.addClass("disable"))
    }
    function d(e, t) {
        //J.find(".icon").removeClass("ox xox"),
        //    t && J.find(".icon").addClass(t),
        //    J.find(".tip").text(e),
        //    J.show()
        alert(e);
    }
    function u(e) {
        return e.hasClass("selectable")
    }
    function h(e) {
        return e.hasClass("selected")
    }
    function f(e, t) {
        function a(t) {
            var a = e ? t.prev() : t.next();
            return 0 === a.length || a.hasClass("empty") ? $() : a
        }
        return t ? a(t) : a
    }
    function p(e, t, a) {
        var n = t(e);
        if (u(n)) {
            if (n = t(n),
                u(n))
                return !1;
            if (h(n))
                return d("座位中间不要留空", "xox"),
                    !0;
            if (!u(n)) {
                var s = P;
                for (n = e; s--;)
                    if (n = a(n),
                        !h(n)) {
                        var r = u(n);
                        return r && d("座位旁边不要留空", "ox"),
                            r
                    }
            }
        }
    }
    function m() {
        for (var e = $(".seats-wrapper").find(".selected"), t = e.length, a = f(!0), n = f(!1), s = 0; s < t; ++s) {
            var r = e.eq(s);
            if (p(r, a, n) || p(r, n, a))
                return !1
        }
        return !0
    }
    function v() {
        var e = N.data()
            , t = e.sectionId
            , a = e.sectionName
            , n = e.seqNo
            , s = {
                count: B.length,
                list: B
            }
            , r = {
                sectionId: t,
                sectionName: a,
                seqNo: n,
                seats: JSON.stringify(s)
            };
        console.log(r);
    }

    function getUrlVars() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            if (vars[hash[0]]) {
                if (typeof vars[hash[0]] === 'string') {
                    var origin = vars[hash[0]];
                    vars[hash[0]] = [];
                    vars[hash[0]].push(origin);
                }
                vars[hash[0]].push(hash[1]);
            } else {
                vars[hash[0]] = hash[1];
            }
        }
        return vars;
    }

    var x = $(".no-ticket")
        , g = $(".has-ticket")
        , k = $(".ticket-container")
        , N = $(".seats-block")
        , _ = $(".screen")
        , j = $(".total-price .price")
        , q = $(".confirm-btn")
        , J = $(".modal-container")
        , L = $(".input-phone")
        , O = $(".input-code")
        , D = $(".send-code")
        , H = $(".captcha")
        , P = +k.data("limit")
        , S = _.width()
        , z = $(".seats-wrapper").width()
        , A = { "0": { "price": "0元" }, "1": { "expression": "38X1", "price": "38" }, "2": { "expression": "38X2", "price": "76" }, "3": { "expression": "38X3", "price": "114" }, "4": { "expression": "38X4", "price": "152" }, "5": { "expression": "38X5", "price": "190" }, "6": { "expression": "38X6", "price": "228" } }
        , B = []
        , E = void 0
        , F = void 0;

    A && (A[0] = {
        price: "0元"
    }),

        $(".ticket-container").on("click", ".ticket", function () {
            var e = $(this).data()
                , t = e.rowId
                , a = e.columnId;
            $(".seat").each(function () {
                var e = $(this);
                if (e.data("columnId") === a && e.data("rowId") === t)
                    return l(e),
                        !1
            })
        }),
        function () {
            var e = z / 2;
            $(".screen-container").css("left", e - S / 2)
        }(),

        $(".seats-block").on("click", ".seat", function () {
            var e = $(this);
            if (!e.hasClass("empty") && !e.hasClass("sold"))
                return u(e) ? c(e) : h(e) ? l(e) : void 0
        }),

        $('#select-all').on('click', function () {
        $('.seats-block .selectable').trigger('click');
        }),

        $('#select-none').on('click', function () {
        $('.seats-block .selected').trigger('click');
        })

    //恢复已选座位
    var seatNos = getUrlVars()['seatNos'];
    if (seatNos && seatNos.length > 0)
        seatNos.forEach(item => {
            $('.seats-block .seat[data-no="' + item + '"]').trigger('click');
        })
})(window, document, jQuery);