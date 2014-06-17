define(function (require, exports, module) {

    var module2 = require("./module2");
    var module3 = require("./module3");

    exports.init = function (str) {
        module2.fill("qwer", "module1init:" + str);
        module3.m3();
    }

});