﻿define(function (require, exports, module) {

    var $ = require("../jq/jquery");

    exports.each = function (arr) {
        alert("module2arr:" + arr);
    };

    exports.fill = function (id, cont) {
        $("#" + id).html("module2fill:" + cont);
    };

});


