﻿/*! smooth-scroll v16.1.3 | (c) 2020 Chris Ferdinandi | MIT License | http://github.com/cferdinandi/smooth-scroll */
window.Element && !Element.prototype.closest && (Element.prototype.closest = function (e) {
    var t, n = (this.document || this.ownerDocument).querySelectorAll(e),
        o = this;
    do {
        for (t = n.length; 0 <= --t && n.item(t) !== o;);
    } while (t < 0 && (o = o.parentElement));
    return o
}), (function () {
    if ("function" == typeof window.CustomEvent) return;

    function e(e, t) {
        t = t || {
            bubbles: !1,
            cancelable: !1,
            detail: void 0
        };
        var n = document.createEvent("CustomEvent");
        return n.initCustomEvent(e, t.bubbles, t.cancelable, t.detail), n
    }
    e.prototype = window.Event.prototype, window.CustomEvent = e
})(), (function () {
    for (var r = 0, e = ["ms", "moz", "webkit", "o"], t = 0; t < e.length && !window.requestAnimationFrame; ++t) window.requestAnimationFrame = window[e[t] + "RequestAnimationFrame"], window.cancelAnimationFrame = window[e[t] + "CancelAnimationFrame"] || window[e[t] + "CancelRequestAnimationFrame"];
    window.requestAnimationFrame || (window.requestAnimationFrame = function (e, t) {
        var n = (new Date).getTime(),
            o = Math.max(0, 16 - (n - r)),
            a = window.setTimeout((function () {
                e(n + o)
            }), o);
        return r = n + o, a
    }), window.cancelAnimationFrame || (window.cancelAnimationFrame = function (e) {
        clearTimeout(e)
    })
})(), (function (e, t) {
    "function" == typeof define && define.amd ? define([], (function () {
        return t(e)
    })) : "object" == typeof exports ? module.exports = t(e) : e.SmoothScroll = t(e)
})("undefined" != typeof global ? global : "undefined" != typeof window ? window : this, (function (M) {
    "use strict";
    var q = {
        ignore: "[data-scroll-ignore]",
        header: null,
        topOnEmptyHash: !0,
        speed: 500,
        speedAsDuration: !1,
        durationMax: null,
        durationMin: null,
        clip: !0,
        offset: 0,
        easing: "easeInOutCubic",
        customEasing: null,
        updateURL: !0,
        popstate: !0,
        emitEvents: !0
    },
        I = function () {
            var n = {};
            return Array.prototype.forEach.call(arguments, (function (e) {
                for (var t in e) {
                    if (!e.hasOwnProperty(t)) return;
                    n[t] = e[t]
                }
            })), n
        },
        r = function (e) {
            "#" === e.charAt(0) && (e = e.substr(1));
            for (var t, n = String(e), o = n.length, a = -1, r = "", i = n.charCodeAt(0); ++a < o;) {
                if (0 === (t = n.charCodeAt(a))) throw new InvalidCharacterError("Invalid character: the input contains U+0000.");
                1 <= t && t <= 31 || 127 == t || 0 === a && 48 <= t && t <= 57 || 1 === a && 48 <= t && t <= 57 && 45 === i ? r += "\\" + t.toString(16) + " " : r += 128 <= t || 45 === t || 95 === t || 48 <= t && t <= 57 || 65 <= t && t <= 90 || 97 <= t && t <= 122 ? n.charAt(a) : "\\" + n.charAt(a)
            }
            return "#" + r
        },
        F = function () {
            return Math.max(document.body.scrollHeight, document.documentElement.scrollHeight, document.body.offsetHeight, document.documentElement.offsetHeight, document.body.clientHeight, document.documentElement.clientHeight)
        },
        L = function (e) {
            return e ? (t = e, parseInt(M.getComputedStyle(t).height, 10) + e.offsetTop) : 0;
            var t
        },
        x = function (e, t, n) {
            0 === e && document.body.focus(), n || (e.focus(), document.activeElement !== e && (e.setAttribute("tabindex", "-1"), e.focus(), e.style.outline = "none"), M.scrollTo(0, t))
        },
        H = function (e, t, n, o) {
            if (t.emitEvents && "function" == typeof M.CustomEvent) {
                var a = new CustomEvent(e, {
                    bubbles: !0,
                    detail: {
                        anchor: n,
                        toggle: o
                    }
                });
                document.dispatchEvent(a)
            }
        };
    return function (o, e) {
        var b, a, A, O, C = {};
        C.cancelScroll = function (e) {
            cancelAnimationFrame(O), O = null, e || H("scrollCancel", b)
        }, C.animateScroll = function (a, r, e) {
            C.cancelScroll();
            var i = I(b || q, e || {}),
                c = "[object Number]" === Object.prototype.toString.call(a),
                t = c || !a.tagName ? null : a;
            if (c || t) {
                var s = M.pageYOffset;
                i.header && !A && (A = document.querySelector(i.header));
                var n, o, u, l, m, d, f, h, p = L(A),
                    g = c ? a : (function (e, t, n, o) {
                        var a = 0;
                        if (e.offsetParent)
                            for (; a += e.offsetTop, e = e.offsetParent;);
                        return a = Math.max(a - t - n, 0), o && (a = Math.min(a, F() - M.innerHeight)), a
                    })(t, p, parseInt("function" == typeof i.offset ? i.offset(a, r) : i.offset, 10), i.clip),
                    y = g - s,
                    v = F(),
                    w = 0,
                    S = (n = y, u = (o = i).speedAsDuration ? o.speed : Math.abs(n / 1e3 * o.speed), o.durationMax && u > o.durationMax ? o.durationMax : o.durationMin && u < o.durationMin ? o.durationMin : parseInt(u, 10)),
                    E = function (e) {
                        var t, n, o;
                        l || (l = e), w += e - l, d = s + y * (n = m = 1 < (m = 0 === S ? 0 : w / S) ? 1 : m, "easeInQuad" === (t = i).easing && (o = n * n), "easeOutQuad" === t.easing && (o = n * (2 - n)), "easeInOutQuad" === t.easing && (o = n < .5 ? 2 * n * n : (4 - 2 * n) * n - 1), "easeInCubic" === t.easing && (o = n * n * n), "easeOutCubic" === t.easing && (o = --n * n * n + 1), "easeInOutCubic" === t.easing && (o = n < .5 ? 4 * n * n * n : (n - 1) * (2 * n - 2) * (2 * n - 2) + 1), "easeInQuart" === t.easing && (o = n * n * n * n), "easeOutQuart" === t.easing && (o = 1 - --n * n * n * n), "easeInOutQuart" === t.easing && (o = n < .5 ? 8 * n * n * n * n : 1 - 8 * --n * n * n * n), "easeInQuint" === t.easing && (o = n * n * n * n * n), "easeOutQuint" === t.easing && (o = 1 + --n * n * n * n * n), "easeInOutQuint" === t.easing && (o = n < .5 ? 16 * n * n * n * n * n : 1 + 16 * --n * n * n * n * n), t.customEasing && (o = t.customEasing(n)), o || n), M.scrollTo(0, Math.floor(d)), (function (e, t) {
                            var n = M.pageYOffset;
                            if (e == t || n == t || (s < t && M.innerHeight + n) >= v) return C.cancelScroll(!0), x(a, t, c), H("scrollStop", i, a, r), !(O = l = null)
                        })(d, g) || (O = M.requestAnimationFrame(E), l = e)
                    };
                0 === M.pageYOffset && M.scrollTo(0, 0), f = a, h = i, c || history.pushState && h.updateURL && history.pushState({
                    smoothScroll: JSON.stringify(h),
                    anchor: f.id
                }, document.title, f === document.documentElement ? "#top" : "#" + f.id), "matchMedia" in M && M.matchMedia("(prefers-reduced-motion)").matches ? x(a, Math.floor(g), !1) : (H("scrollStart", i, a, r), C.cancelScroll(!0), M.requestAnimationFrame(E))
            }
        };
        var t = function (e) {
            if (!e.defaultPrevented && !(0 !== e.button || e.metaKey || e.ctrlKey || e.shiftKey) && "closest" in e.target && (a = e.target.closest(o)) && "a" === a.tagName.toLowerCase() && !e.target.closest(b.ignore) && a.hostname === M.location.hostname && a.pathname === M.location.pathname && /#/.test(a.href)) {
                var t, n;
                try {
                    t = r(decodeURIComponent(a.hash))
                } catch (e) {
                    t = r(a.hash)
                }
                if ("#" === t) {
                    if (!b.topOnEmptyHash) return;
                    n = document.documentElement
                } else n = document.querySelector(t);
                (n = n || "#top" !== t ? n : document.documentElement) && (e.preventDefault(), (function (e) {
                    if (history.replaceState && e.updateURL && !history.state) {
                        var t = M.location.hash;
                        t = t || "", history.replaceState({
                            smoothScroll: JSON.stringify(e),
                            anchor: t || M.pageYOffset
                        }, document.title, t || M.location.href)
                    }
                })(b), C.animateScroll(n, a))
            }
        },
            n = function (e) {
                if (null !== history.state && history.state.smoothScroll && history.state.smoothScroll === JSON.stringify(b)) {
                    var t = history.state.anchor;
                    "string" == typeof t && t && !(t = document.querySelector(r(history.state.anchor))) || C.animateScroll(t, null, {
                        updateURL: !1
                    })
                }
            };
        C.destroy = function () {
            b && (document.removeEventListener("click", t, !1), M.removeEventListener("popstate", n, !1), C.cancelScroll(), O = A = a = b = null)
        };
        return (function () {
            if (!("querySelector" in document && "addEventListener" in M && "requestAnimationFrame" in M && "closest" in M.Element.prototype)) throw "Smooth Scroll: This browser does not support the required JavaScript methods and browser APIs.";
            C.destroy(), b = I(q, e || {}), A = b.header ? document.querySelector(b.header) : null, document.addEventListener("click", t, !1), b.updateURL && b.popstate && M.addEventListener("popstate", n, !1)
        })(), C
    }
}));