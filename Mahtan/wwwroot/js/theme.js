﻿function ownKeys(t, e) {
    var r, n = Object.keys(t);
    return Object.getOwnPropertySymbols && (r = Object.getOwnPropertySymbols(t), e && (r = r.filter(function (e) {
        return Object.getOwnPropertyDescriptor(t, e).enumerable
    })), n.push.apply(n, r)), n
}

function _objectSpread(t) {
    for (var e = 1; e < arguments.length; e++) {
        var r = null != arguments[e] ? arguments[e] : {};
        e % 2 ? ownKeys(Object(r), !0).forEach(function (e) {
            _defineProperty(t, e, r[e])
        }) : Object.getOwnPropertyDescriptors ? Object.defineProperties(t, Object.getOwnPropertyDescriptors(r)) : ownKeys(Object(r)).forEach(function (e) {
            Object.defineProperty(t, e, Object.getOwnPropertyDescriptor(r, e))
        })
    }
    return t
}

function _defineProperty(e, t, r) {
    return t in e ? Object.defineProperty(e, t, {
        value: r,
        enumerable: !0,
        configurable: !0,
        writable: !0
    }) : e[t] = r, e
}

function _typeof(e) {
    return (_typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (e) {
        return typeof e
    } : function (e) {
        return e && "function" == typeof Symbol && e.constructor === Symbol && e !== Symbol.prototype ? "symbol" : typeof e
    })(e)
}
/**
 * Cartzilla | Bootstrap E-Commerce Template
 * Copyright 2022 Createx Studio
 * Theme core scripts
 * 
 * @author Createx Studio
 * @version 2.5.0
 */
! function () {
    "use strict";
    var t, r, n, a, o, l, e;
    null != (r = document.querySelector(".navbar-sticky")) && (r.classList, t = r.offsetHeight, window.addEventListener("scroll", function (e) {
        r.classList.contains("position-absolute") ? 500 < e.currentTarget.pageYOffset ? r.classList.add("navbar-stuck") : r.classList.remove("navbar-stuck") : 500 < e.currentTarget.pageYOffset ? (document.body.style.paddingTop = t + "px", r.classList.add("navbar-stuck")) : (document.body.style.paddingTop = "", r.classList.remove("navbar-stuck"))
    })), e = document.querySelector(".navbar-stuck-toggler"), n = document.querySelector(".navbar-stuck-menu"), null != e && e.addEventListener("click", function (e) {
        n.classList.toggle("show"), e.preventDefault()
    }),
        function () {
            var e, t = document.querySelectorAll(".masonry-grid");
            if (null !== t)
                for (var r = 0; r < t.length; r++) e = new Shuffle(t[r], {
                    itemSelector: ".masonry-grid-item",
                    sizer: ".masonry-grid-item"
                }), imagesLoaded(t[r]).on("progress", function () {
                    e.layout()
                })
        }(),
        function () {
            for (var r = document.querySelectorAll(".password-toggle"), e = 0; e < r.length; e++) ! function (e) {
                var t = r[e].querySelector(".form-control");
                r[e].querySelector(".password-toggle-btn").addEventListener("click", function (e) {
                    "checkbox" === e.target.type && (e.target.checked ? t.type = "text" : t.type = "password")
                }, !1)
            }(e)
        }(),
        function () {
            for (var t = document.querySelectorAll(".file-drop-area"), e = 0; e < t.length; e++) ! function (e) {
                var n = t[e].querySelector(".file-drop-input"),
                    a = t[e].querySelector(".file-drop-message"),
                    o = t[e].querySelector(".file-drop-icon");
                t[e].querySelector(".file-drop-btn").addEventListener("click", function () {
                    n.click()
                }), n.addEventListener("change", function () {
                    var e;
                    n.files && n.files[0] && ((e = new FileReader).onload = function (e) {
                        var t, e = e.target.result,
                            r = n.files[0].name;
                        a.innerHTML = r, e.startsWith("data:image") ? ((t = new Image).src = e, t.onload = function () {
                            o.className = "file-drop-preview img-thumbnail rounded", o.innerHTML = '<img src="' + t.src + '" alt="' + r + '">'
                        }) : e.startsWith("data:video") ? (o.innerHTML = "", o.className = "", o.className = "file-drop-icon ci-video") : (o.innerHTML = "", o.className = "", o.className = "file-drop-icon ci-document")
                    }, e.readAsDataURL(n.files[0]))
                })
            }(e)
        }(), window.addEventListener("load", function () {
            var e = document.getElementsByClassName("needs-validation");
            Array.prototype.filter.call(e, function (t) {
                t.addEventListener("submit", function (e) {
                    !1 === t.checkValidity() && (e.preventDefault(), e.stopPropagation()), t.classList.add("was-validated")
                }, !1)
            })
        }, !1), new SmoothScroll("[data-scroll]", {
            speed: 800,
            speedAsDuration: !0,
            offset: 40,
            header: "[data-scroll-header]",
            updateURL: !1
        }), null != (o = document.querySelector(".btn-scroll-top")) && (a = parseInt(600, 10), window.addEventListener("scroll", function (e) {
            e.currentTarget.pageYOffset > a ? o.classList.add("show") : o.classList.remove("show")
        })), [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]')).map(function (e) {
            return new bootstrap.Tooltip(e, {
                trigger: "hover"
            })
        }), [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]')).map(function (e) {
            return new bootstrap.Popover(e)
        }), [].slice.call(document.querySelectorAll(".toast")).map(function (e) {
            return new bootstrap.Toast(e)
        }),
        function () {
            for (var e = document.querySelectorAll(".disable-autohide .form-select"), t = 0; t < e.length; t++) e[t].addEventListener("click", function (e) {
                e.stopPropagation()
            })
        }(),
        function (e, t, r) {
            for (var n = 0; n < e.length; n++) t.call(r, n, e[n])
        }(document.querySelectorAll(".tns-carousel .tns-carousel-inner"), function (e, t) {
            var r = {
                container: t,
                controlsText: ['<i class="ci-arrow-left"></i>', '<i class="ci-arrow-right"></i>'],
                navPosition: "bottom",
                mouseDrag: !0,
                speed: 500,
                autoplayHoverPause: !0,
                autoplayButtonOutput: !1
            };
            null != t.dataset.carouselOptions && (n = JSON.parse(t.dataset.carouselOptions));
            var n = Object.assign({}, r, n);
            tns(n)
        }),
        function () {
            var e = document.querySelectorAll(".gallery");
            if (e.length)
                for (var t = 0; t < e.length; t++) {
                    var r = !!e[t].dataset.thumbnails,
                        n = !!e[t].dataset.video,
                        a = [lgZoom, lgFullscreen],
                        n = n ? [lgVideo] : [],
                        r = r ? [lgThumbnail] : [],
                        r = [].concat(a, n, r);
                    lightGallery(e[t], {
                        selector: ".gallery-item",
                        plugins: r,
                        licenseKey: "D4194FDD-48924833-A54AECA3-D6F8E646",
                        download: !1,
                        autoplayVideoOnSlide: !0,
                        zoomFromOrigin: !1,
                        youtubePlayerParams: {
                            modestbranding: 1,
                            showinfo: 0,
                            rel: 0
                        },
                        vimeoPlayerParams: {
                            byline: 0,
                            portrait: 0,
                            color: "6366f1"
                        }
                    })
                }
        }(),
        function () {
            var c = document.querySelectorAll(".product-gallery");
            if (c.length)
                for (var e = 0; e < c.length; e++) ! function (r) {
                    for (var n = c[r].querySelectorAll(".product-gallery-thumblist-item:not(.video-item)"), a = c[r].querySelectorAll(".product-gallery-preview-item"), e = c[r].querySelectorAll(".product-gallery-thumblist-item.video-item"), t = 0; t < n.length; t++) n[t].addEventListener("click", o);

                    function o(e) {
                        e.preventDefault();
                        for (var t = 0; t < n.length; t++) a[t].classList.remove("active"), n[t].classList.remove("active");
                        this.classList.add("active"), c[r].querySelector(this.getAttribute("href")).classList.add("active")
                    }
                    for (var l = 0; l < e.length; l++) lightGallery(e[l], {
                        selector: "this",
                        download: !1,
                        videojs: !0,
                        youtubePlayerParams: {
                            modestbranding: 1,
                            showinfo: 0,
                            rel: 0,
                            controls: 0
                        },
                        vimeoPlayerParams: {
                            byline: 0,
                            portrait: 0,
                            color: "fe696a"
                        }
                    })
                }(e)
        }(),
        function () {
            for (var e = document.querySelectorAll(".image-zoom"), t = 0; t < e.length; t++) new Drift(e[t], {
                paneContainer: e[t].parentElement.querySelector(".image-zoom-pane")
            })
        }(),
        function () {
            var u = document.querySelectorAll(".countdown");
            if (null != u)
                for (var e = 0; e < u.length; e++) {
                    var t = function (e) {
                        var t, r, n, a, o = u[e].dataset.countdown,
                            l = u[e].querySelector(".countdown-days .countdown-value"),
                            c = u[e].querySelector(".countdown-hours .countdown-value"),
                            s = u[e].querySelector(".countdown-minutes .countdown-value"),
                            i = u[e].querySelector(".countdown-seconds .countdown-value"),
                            o = new Date(o).getTime();
                        if (isNaN(o)) return {
                            v: void 0
                        };
                        setInterval(function () {
                            var e = (new Date).getTime(),
                                e = parseInt((o - e) / 1e3);
                            0 <= e && (t = parseInt(e / 86400), e %= 86400, r = parseInt(e / 3600), e %= 3600, n = parseInt(e / 60), e %= 60, a = parseInt(e), null != l && (l.innerHTML = parseInt(t, 10)), null != c && (c.innerHTML = r < 10 ? "0" + r : r), null != s && (s.innerHTML = n < 10 ? "0" + n : n), null != i && (i.innerHTML = a < 10 ? "0" + a : a))
                        }, 1e3)
                    }(e);
                    if ("object" === _typeof(t)) return t.v
                }
        }(),
        function () {
            function o(e, t) {
                return e + t
            }
            var e = document.querySelectorAll("[data-line-chart]"),
                t = document.querySelectorAll("[data-bar-chart]"),
                l = document.querySelectorAll("[data-pie-chart]");
            if (0 !== e.length || 0 !== t.length || 0 !== l.length) {
                var c, r = document.head || document.getElementsByTagName("head")[0],
                    s = document.createElement("style");
                r.appendChild(s);
                for (var n = 0; n < e.length; n++) {
                    var a, i = JSON.parse(e[n].dataset.lineChart),
                        u = null != e[n].dataset.options ? JSON.parse(e[n].dataset.options) : "",
                        d = e[n].dataset.seriesColor;
                    if (e[n].classList.add("line-chart-" + n), null != d) {
                        a = JSON.parse(d);
                        for (var f = 0; f < a.colors.length; f++) c = "\n          .line-chart-".concat(n, " .ct-series:nth-child(").concat(f + 1, ") .ct-line,\n          .line-chart-").concat(n, " .ct-series:nth-child(").concat(f + 1, ") .ct-point {\n            stroke: ").concat(a.colors[f], " !important;\n          }\n        "), s.appendChild(document.createTextNode(c))
                    }
                    new Chartist.Line(e[n], i, u)
                }
                for (var p = 0; p < t.length; p++) {
                    var m, v = JSON.parse(t[p].dataset.barChart),
                        g = null != t[p].dataset.options ? JSON.parse(t[p].dataset.options) : "",
                        y = t[p].dataset.seriesColor;
                    if (t[p].classList.add("bar-chart-" + p), null != y) {
                        m = JSON.parse(y);
                        for (var h = 0; h < m.colors.length; h++) c = "\n        .bar-chart-".concat(p, " .ct-series:nth-child(").concat(h + 1, ") .ct-bar {\n            stroke: ").concat(m.colors[h], " !important;\n          }\n        "), s.appendChild(document.createTextNode(c))
                    }
                    new Chartist.Bar(t[p], v, g)
                }
                for (var b = 0; b < l.length; b++) ! function (e) {
                    var t, r = JSON.parse(l[e].dataset.pieChart),
                        n = l[e].dataset.seriesColor;
                    if (l[e].classList.add("cz-pie-chart-" + e), null != n) {
                        t = JSON.parse(n);
                        for (var a = 0; a < t.colors.length; a++) c = "\n        .cz-pie-chart-".concat(e, " .ct-series:nth-child(").concat(a + 1, ") .ct-slice-pie {\n            fill: ").concat(t.colors[a], " !important;\n          }\n        "), s.appendChild(document.createTextNode(c))
                    }
                    new Chartist.Pie(l[e], r, {
                        labelInterpolationFnc: function (e) {
                            return Math.round(e / r.series.reduce(o) * 100) + "%"
                        }
                    })
                }(b)
            }
        }(),
        function () {
            var e = document.querySelectorAll('[data-bs-toggle="video"]');
            if (e.length)
                for (var t = 0; t < e.length; t++) lightGallery(e[t], {
                    selector: "this",
                    plugins: [lgVideo],
                    licenseKey: "D4194FDD-48924833-A54AECA3-D6F8E646",
                    download: !1,
                    youtubePlayerParams: {
                        modestbranding: 1,
                        showinfo: 0,
                        rel: 0
                    },
                    vimeoPlayerParams: {
                        byline: 0,
                        portrait: 0,
                        color: "6366f1"
                    }
                })
        }(),
        function () {
            var l = document.querySelectorAll(".subscription-form");
            if (null !== l) {
                for (var e = 0; e < l.length; e++) ! function (e) {
                    var t = l[e].querySelector('button[type="submit"]'),
                        r = t.innerHTML,
                        n = l[e].querySelector(".form-control"),
                        a = l[e].querySelector(".subscription-form-antispam"),
                        o = l[e].querySelector(".subscription-status");
                    l[e].addEventListener("submit", function (e) {
                        e && e.preventDefault(), "" === a.value && c(this, t, n, r, o)
                    })
                }(e);
                var c = function (e, t, r, n, a) {
                    t.innerHTML = "Sending...";
                    var o = e.action.replace("/post?", "/post-json?"),
                        e = "&" + r.name + "=" + encodeURIComponent(r.value),
                        l = document.createElement("script");
                    l.src = o + "&c=callback" + e, document.body.appendChild(l);
                    var c = "callback";
                    window[c] = function (e) {
                        delete window[c], document.body.removeChild(l), t.innerHTML = n, "success" == e.result ? (r.classList.remove("is-invalid"), r.classList.add("is-valid"), a.classList.remove("status-error"), a.classList.add("status-success"), a.innerHTML = e.msg, setTimeout(function () {
                            r.classList.remove("is-valid"), a.innerHTML = "", a.classList.remove("status-success")
                        }, 6e3)) : (r.classList.remove("is-valid"), r.classList.add("is-invalid"), a.classList.remove("status-success"), a.classList.add("status-error"), a.innerHTML = e.msg.substring(4), setTimeout(function () {
                            r.classList.remove("is-invalid"), a.innerHTML = "", a.classList.remove("status-error")
                        }, 6e3))
                    }
                }
            }
        }(),
        function () {
            for (var l = document.querySelectorAll(".range-slider"), e = 0; e < l.length; e++) ! function (e) {
                var t = l[e].querySelector(".range-slider-ui"),
                    r = l[e].querySelector(".range-slider-value-min"),
                    n = l[e].querySelector(".range-slider-value-max"),
                    a = {
                        dataStartMin: parseInt(l[e].dataset.startMin, 10),
                        dataStartMax: parseInt(l[e].dataset.startMax, 10),
                        dataMin: parseInt(l[e].dataset.min, 10),
                        dataMax: parseInt(l[e].dataset.max, 10),
                        dataStep: parseInt(l[e].dataset.step, 10)
                    },
                    o = l[e].dataset.currency;
                noUiSlider.create(t, {
                    start: [a.dataStartMin, a.dataStartMax],
                    connect: !0,
                    step: a.dataStep,
                    pips: {
                        mode: "count",
                        values: 5
                    },
                    tooltips: !0,
                    range: {
                        min: a.dataMin,
                        max: a.dataMax
                    },
                    format: {
                        to: function (e) {
                            return "".concat(o || "$").concat(parseInt(e, 10))
                        },
                        from: function (e) {
                            return Number(e)
                        }
                    }
                }), t.noUiSlider.on("update", function (e, t) {
                    e = (e = e[t]).replace(/\D/g, "");
                    t ? n.value = Math.round(e) : r.value = Math.round(e)
                }), r.addEventListener("change", function () {
                    t.noUiSlider.set([this.value, null])
                }), n.addEventListener("change", function () {
                    t.noUiSlider.set([null, this.value])
                })
            }(e)
        }(),
        function () {
            for (var t = document.querySelectorAll(".widget-filter"), e = 0; e < t.length; e++)(function (e) {
                var r = t[e].querySelector(".widget-filter-search"),
                    n = t[e].querySelector(".widget-filter-list").querySelectorAll(".widget-filter-item");
                if (!r) return;
                r.addEventListener("keyup", function () {
                    for (var e = r.value.toLowerCase(), t = 0; t < n.length; t++) - 1 < n[t].querySelector(".widget-filter-item-text").innerHTML.toLowerCase().indexOf(e) ? n[t].classList.remove("d-none") : n[t].classList.add("d-none")
                })
            })(e)
        }(), e = document.querySelector("[data-filter-trigger]"), l = document.querySelectorAll("[data-filter-target]"), null !== e && e.addEventListener("change", function () {
            var e = this.options[this.selectedIndex].value.toLowerCase();
            if ("all" === e)
                for (var t = 0; t < l.length; t++) l[t].classList.remove("d-none");
            else {
                for (var r = 0; r < l.length; r++) l[r].classList.add("d-none");
                document.querySelector("#" + e).classList.remove("d-none")
            }
        }),
        function () {
            for (var e = document.querySelectorAll("[data-bs-label]"), t = 0; t < e.length; t++) e[t].addEventListener("change", function () {
                var e = this.dataset.bsLabel;
                try {
                    document.getElementById(e).textContent = this.value
                } catch (e) {
                    e.message = "Cannot set property 'textContent' of null", console.error("Make sure the [data-label] matches with the id of the target element you want to change text of!")
                }
            })
        }(),
        function () {
            for (var e = document.querySelectorAll('[data-bs-toggle="radioTab"]'), t = 0; t < e.length; t++) e[t].addEventListener("click", function () {
                var e = this.dataset.bsTarget;
                document.querySelector(this.dataset.bsParent).querySelectorAll(".radio-tab-pane").forEach(function (e) {
                    e.classList.remove("active")
                }), document.querySelector(e).classList.add("active")
            })
        }(), null !== (e = document.querySelector(".credit-card-form")) && new Card({
            form: e,
            container: ".credit-card-wrapper"
        }),
        function () {
            var e = document.querySelectorAll("[data-master-checkbox-for]");
            if (0 !== e.length)
                for (var t = 0; t < e.length; t++) e[t].addEventListener("change", function () {
                    var e = document.querySelector(this.dataset.masterCheckboxFor).querySelectorAll('input[type="checkbox"]');
                    if (this.checked)
                        for (var t = 0; t < e.length; t++) e[t].checked = !0, e[t].dataset.checkboxToggleClass && document.querySelector(e[t].dataset.target).classList.add(e[t].dataset.checkboxToggleClass);
                    else
                        for (var r = 0; r < e.length; r++) e[r].checked = !1, e[r].dataset.checkboxToggleClass && document.querySelector(e[r].dataset.target).classList.remove(e[r].dataset.checkboxToggleClass)
                })
        }(),
        function () {
            var e = document.querySelectorAll(".date-picker");
            if (0 !== e.length)
                for (var t = 0; t < e.length; t++) {
                    var r = void 0;
                    null != e[t].dataset.datepickerOptions && (r = JSON.parse(e[t].dataset.datepickerOptions));
                    var n = e[t].classList.contains("date-range") ? {
                        plugins: [new rangePlugin({
                            input: e[t].dataset.linkedInput
                        })]
                    } : "{}",
                        r = _objectSpread(_objectSpread(_objectSpread({}, {
                            disableMobile: "true"
                        }), n), r);
                    flatpickr(e[t], r)
                }
        }(),
        function () {
            for (var o = document.querySelectorAll('[data-bs-toggle="select"]'), e = 0; e < o.length; e++) ! function (e) {
                for (var t = o[e].querySelectorAll(".dropdown-item"), r = o[e].querySelector(".dropdown-toggle-label"), n = o[e].querySelector('input[type="hidden"]'), a = 0; a < t.length; a++) t[a].addEventListener("click", function (e) {
                    e.preventDefault();
                    e = this.querySelector(".dropdown-item-label").innerText;
                    r.innerText = e, null !== n && (n.value = e)
                })
            }(e)
        }()
}();