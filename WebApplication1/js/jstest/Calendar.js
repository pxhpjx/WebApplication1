define(function (require, exports, module) {
    var Calendar = function (targetInput, targetHelp, booleanNotAuto, options, callBack) {
        //  最小宽度 最大宽度 主体透明度 主体边框默认样式 主体边框默认颜色 主体背景色 投影透明度 默认投影颜色 今日前景 今日背景 普通over前景 普通over背景 今日over前景 今日over背景 输入框是否只读 是否隐藏select
        this.options = options ? options : [140, 800, 0.95, "solid", "#AACBEC", "#FFF", 3, 3, 0.2, "#000", "#444", "#F6F8FD", "#333", "#0f6eba", "#000", "#EFF3FB", true, true, ""];
        this.toFixedZero = function (n) {
            return n < 10 ? "0" + n : n;
        };
        this.booleanNotAuto = booleanNotAuto;
        this.createContainer = function (elementTargetElement) {
            var getCssTextWHLT = function (arrayWHLT) {
                var stringCssText = ";";
                var arrayWHLTTpl = ["width", "height", "left", "top"];
                for (var i = 0; i < 4; i++) {
                    if (arrayWHLT[i] != "auto") {
                        stringCssText += arrayWHLTTpl[i] + ":" + arrayWHLT[i] + (typeof arrayWHLT[i] == "string" ? "" : "px") + ";";
                    }
                }
                return stringCssText;
            };
            var arrayBorderDirection = ["Top", "Right", "Bottom", "Left"];
            var arrayTargetBorderWidth = [];
            var stringTargetBorderCssText = ";background-color:" + (elementTargetElement.style.backgroundColor ? elementTargetElement.style.backgroundColor : this.options[5]) + ";";
            for (var i = 0; i < 4; i++) {
                var stringBorderWidth = elementTargetElement.style["border" + arrayBorderDirection[i] + "Width"];
                arrayTargetBorderWidth[i] = stringBorderWidth ? stringBorderWidth.replace("px", "") * 1 : 2;
                stringTargetBorderCssText += "border-" + arrayBorderDirection[i].toLowerCase() + "-width:" + arrayTargetBorderWidth[i] + "px;";
                var stringBorderStyle = elementTargetElement.style["border" + arrayBorderDirection[i] + "Style"];
                stringTargetBorderCssText += "border-" + arrayBorderDirection[i].toLowerCase() + "-style:" + (stringBorderStyle ? stringBorderStyle : this.options[3]) + ";";
                var stringBorderColor = elementTargetElement.style["border" + arrayBorderDirection[i] + "Color"];
                stringTargetBorderCssText += "border-" + arrayBorderDirection[i].toLowerCase() + "-color:" + (stringBorderColor ? stringBorderColor : this.options[4]) + ";";
            }
            var intCurrentWidth = elementTargetElement.clientWidth;
            intCurrentWidth = intCurrentWidth < this.options[0] ? this.options[0] : intCurrentWidth;
            intCurrentWidth = this.options[1] < intCurrentWidth ? this.options[1] : intCurrentWidth;

            var stringMainOpacity = "";
            var stringShadowOpacity = "";
            var stringShadowLimited = ";font-size:0px;line-height:0px;";
            if (navigator.appName == "Microsoft Internet Explorer") {
                stringMainOpacity = "filter:alpha(opacity=" + this.options[2] * 100 + ");";
                stringShadowOpacity = "filter:alpha(opacity=" + this.options[8] * 100 + ");";
            }
            else {
                stringMainOpacity = "opacity:" + this.options[2] + ";";
                stringShadowOpacity = "opacity:" + this.options[8] + ";";
            }

            var elementSpan = document.createElement("span");
            elementTargetElement.parentNode.insertBefore(elementSpan, elementTargetElement);
            var intTargetHeight = elementTargetElement.clientHeight + arrayTargetBorderWidth[0] + arrayTargetBorderWidth[2] + (elementTargetElement.offsetTop - elementSpan.offsetTop);
            elementSpan.style.position = "relative";
            elementSpan.style.display = "none";
            elementSpan.style.width = "0px";
            elementSpan.style.margin = "0px";

            var elementDiv = document.createElement("div");
            elementDiv.style.position = "absolute";
            elementDiv.style.cssText += getCssTextWHLT([intCurrentWidth, "auto", 0, intTargetHeight]) + stringTargetBorderCssText + stringMainOpacity;
            elementSpan.appendChild(elementDiv);

            var elementShadowDivRight = document.createElement("div");
            elementShadowDivRight.style.position = "absolute";
            elementShadowDivRight.style.cssText += getCssTextWHLT([this.options[6], elementDiv.clientHeight + arrayTargetBorderWidth[1] + arrayTargetBorderWidth[3], intCurrentWidth + arrayTargetBorderWidth[0] + arrayTargetBorderWidth[2], intTargetHeight + this.options[7]]) + "background-color:" + (elementTargetElement.style.borderRightColor ? elementTargetElement.style.borderRightColor : this.options[9]) + ";" + stringShadowOpacity + stringShadowLimited;
            elementSpan.appendChild(elementShadowDivRight);

            var elementShadowDivBottom = document.createElement("div");
            elementShadowDivBottom.style.position = "absolute";
            elementShadowDivBottom.style.cssText += getCssTextWHLT([intCurrentWidth + arrayTargetBorderWidth[0] + arrayTargetBorderWidth[2] - this.options[6], this.options[7], this.options[6], intTargetHeight + elementDiv.clientHeight + arrayTargetBorderWidth[1] + arrayTargetBorderWidth[3]]) + "background-color:" + (elementTargetElement.style.borderBottomColor ? elementTargetElement.style.borderBottomColor : this.options[9]) + ";" + stringShadowOpacity + stringShadowLimited;
            elementSpan.appendChild(elementShadowDivBottom);

            var elementBorderDiv = document.createElement("div");
            elementBorderDiv.style.position = "absolute";
            elementBorderDiv.style.cssText += getCssTextWHLT([intCurrentWidth < elementTargetElement.clientWidth ? intCurrentWidth : elementTargetElement.clientWidth, arrayTargetBorderWidth[2] + arrayTargetBorderWidth[0], arrayTargetBorderWidth[3], intTargetHeight - arrayTargetBorderWidth[2]]) + ";background-color:" + (elementTargetElement.style.backgroundColor ? elementTargetElement.style.backgroundColor : this.options[5]) + ";" + stringShadowLimited;
            if (elementTargetElement.style.borderBottomWidth) {
                elementSpan.appendChild(elementBorderDiv);
            }

            this.elementSpan = elementSpan;
            this.elementDiv = elementDiv;
            this.elementShadowDivRight = elementShadowDivRight;
            this.elementShadowDivBottom = elementShadowDivBottom;
        };
        this.romance = function (element) {
            element.style.cursor = "pointer";
            element.style.cssText += ";padding:2px 4px; line-height: 16px;";
            element.calendar = this;
            if (element.today) {
                element.style.color = this.options[10];
                element.style.backgroundColor = this.options[11];
            }
            element.onmouseover = function () {
                if (this.today) {
                    this.style.color = this.calendar.options[14];
                    this.style.backgroundColor = this.calendar.options[15];
                }
                else {
                    this.style.color = this.calendar.options[12];
                    this.style.backgroundColor = this.calendar.options[13];
                }
                if (parseInt(this.date) == this.date) {
                    this.calendar.keepShowing = true;
                }
            };
            element.onmouseout = function () {
                if (this.today) {
                    this.style.color = this.calendar.options[10];
                    this.style.backgroundColor = this.calendar.options[11];
                }
                else {
                    this.style.color = "";
                    this.style.backgroundColor = "";
                }
                this.calendar.keepShowing = false;
            };
            element.onmousedown = function () {
                if (parseInt(this.date) == this.date) {
                    this.calendar.keepShowing = true;
                    var arrayDate = this.calendar.date;
                    var date = new Date(arrayDate[0], arrayDate[1] + this.date, arrayDate[2]);
                    this.calendar.date = [date.getFullYear(), date.getMonth(), date.getDate()];
                    this.calendar.elementTarget.value = this.calendar.date[0].toString() + "-" + this.calendar.toFixedZero(this.calendar.date[1] + 1) + "-" + this.calendar.toFixedZero(this.calendar.date[2]);
                    this.calendar.resetCalendar(this.calendar.date);
                }
                else {
                    this.calendar.keepShowing = false;
                    this.calendar.date = this.date;
                    this.calendar.elementTarget.value = this.calendar.date[0].toString() + "-" + this.calendar.toFixedZero(this.calendar.date[1] + 1) + "-" + this.calendar.toFixedZero(this.calendar.date[2]);
                }

                //if (this.calendar.elementTarget.value.match(/^\d{4}-\d{1,2}-\d{1,2}$/) != null) {
                //    this.calendar.elementTarget.style.color = "#333333";
                //}
                if (callBack!=null) 
                    callBack();
            };
        };
        this.resetShadow = function () {
            var intDivHeight = this.elementDiv.clientHeight + this.elementDiv.style.borderTopWidth.replace("px", "") * 1 + this.elementDiv.style.borderBottomWidth.replace("px", "") * 1;
            this.elementShadowDivRight.style.height = intDivHeight + "px";
            this.elementShadowDivBottom.style.top = this.elementDiv.style.top.replace("px", "") * 1 + intDivHeight + "px";
        };

        this.resetCalendar = function (arrayDate) {
            this.elementDiv.innerHTML = "";
            this.elementDiv.id = "divCal";
            var stringCssTextButton = "width:12px; height:auto; font-size:18px;";
            var stringCssTextTable = "width:100%; color:#000; font-size:12px; text-align:center; border:2px solid #98BADD;";
            var tableCal = document.createElement("table");
            tableCal.style.cssText += stringCssTextTable;
            tableCal.cellPadding = 0;
            tableCal.cellSpacing = 0;

            var trHeader = document.createElement("thead");
            tableCal.appendChild(trHeader);
            trHeader.style.cssText += "background-color:#d9e9f6; line-height:20px;";
            var trTh = document.createElement("tr");
            //上一年
            var thPreviousYear = document.createElement("th");
            thPreviousYear.style.cssText += stringCssTextButton;
            thPreviousYear.innerHTML = "&laquo;";
            thPreviousYear.date = -12;
            this.romance(thPreviousYear);
            //上一月
            var thPreviousMonth = document.createElement("th");
            thPreviousMonth.innerHTML = "&lsaquo;";
            thPreviousMonth.style.cssText += stringCssTextButton;
            thPreviousMonth.date = -1;
            this.romance(thPreviousMonth);
            // 当前年月
            var thYearAndMonth = document.createElement("th");
            thYearAndMonth.innerHTML = arrayDate[0] + "年" + this.toFixedZero(arrayDate[1] + 1) + "月";
            thYearAndMonth.colSpan = 3;
            // 下一年
            var thNextYear = document.createElement("th");
            thNextYear.innerHTML = "&rsaquo;";
            thNextYear.style.cssText += stringCssTextButton;
            thNextYear.date = 1;
            this.romance(thNextYear);
            // 下一月
            var thNextMonth = document.createElement("th");
            thNextMonth.innerHTML = "&raquo;";
            thNextMonth.style.cssText += stringCssTextButton;
            thNextMonth.date = 12;
            this.romance(thNextMonth);
            trTh.appendChild(thPreviousYear);
            trTh.appendChild(thPreviousMonth);
            trTh.appendChild(thYearAndMonth);
            trTh.appendChild(thNextYear);
            trTh.appendChild(thNextMonth);
            trHeader.appendChild(trTh);

            this.elementDiv.appendChild(tableCal);

            var trBody = document.createElement("tbody");
            tableCal.appendChild(trBody);
            var tdHeaderDays = document.createElement("tr");
            trBody.appendChild(tdHeaderDays);
            var days = ["日", "一", "二", "三", "四", "五", "六"];
            for (var i = 0; i < 7; i++) {
                var tdHeaderDay = document.createElement("td");
                tdHeaderDay.innerHTML = days[i];
                tdHeaderDay.style.cssText += ";padding:2px 4px; line-height:16px; height:auto;";
                tdHeaderDays.appendChild(tdHeaderDay);
            }

            var day = new Date(arrayDate[0], arrayDate[1], 1).getDay();
            var dates = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if (arrayDate[1] == 1 && ((arrayDate[0] % 4 == 0 && arrayDate[0] % 100 != 0) || arrayDate[0] % 400 == 0)) {
                dates[1] = 29;
            }

            var pos = 0;
            var currentLine = 2;
            var currentTr = tableCal.insertRow(currentLine);
            for (var i = 0; i < day; i++) {
                var currentTd = currentTr.insertCell(i);
                currentTd.style.cssText = "height:auto;";
                pos++;
            }
            for (var i = 1; i < dates[arrayDate[1]] + 1; i++) {
                if (pos == 0) {
                    currentLine++;
                    currentTr = tableCal.insertRow(currentLine);
                }
                currentTd = currentTr.insertCell(pos);
                currentTd.style.cssText = "height:auto;";
                currentTd.innerHTML = i.toString();
                currentTd.today = i == arrayDate[2] ? true : false;
                currentTd.date = [arrayDate[0], arrayDate[1], i];
                this.romance(currentTd);
                pos++;
                pos = pos == 7 ? 0 : pos;
            }
            if (pos != 0) {
                for (var i = pos; i < 7; i++) {
                    var currentTd = currentTr.insertCell(i);
                    currentTd.style.cssText = "height:auto;";
                }
            }
            this.resetShadow();
        };
        this.hideSelects = function () {
            if (navigator.appVersion.indexOf("MSIE 6.0") != -1) {
                var selects = document.getElementsByTagName("select");
                var length = selects.length;
                for (var i = 0; i < length; i++) {
                    selects[i].style.visibility = "hidden";
                }
            }
        }

        this.showSelects = function () {
            if (navigator.appVersion.indexOf("MSIE 6.0") != -1) {
                var selects = document.getElementsByTagName("select");
                var length = selects.length;
                for (var i = 0; i < length; i++) {
                    selects[i].style.visibility = "";
                }
            }
        }
        this.showForce = function () {
            if (this.options[17]) {
                this.hideSelects();
            }
            this.elementSpan.style.display = "";
            this.resetShadow();
        };

        this.show = function () {
            if (this.booleanNotAuto) {
                return;
            }
            if (this.options[17]) {
                this.hideSelects();
            }
            this.elementSpan.style.display = "";
            this.resetShadow();
        };

        this.hide = function () {
            if (this.options[17]) {
                this.showSelects();
            }
            this.elementSpan.style.display = "none";
        };

        this.showStandalone = function () {
            arguments.callee.object.show();
        };
        this.showStandalone.object = this;
        this.bind = function (elementTarget, elementTargetHelp, booleanAuto) {
            if (typeof elementTarget == "string") {
                var elementTargetElement = document.getElementById(elementTarget);
            }
            else {
                var elementTargetElement = elementTarget;
            }
            this.elementTarget = elementTargetElement;
            this.createContainer(elementTargetElement);
            elementTargetElement.readOnly = this.options[16];
            elementTargetElement.oriValue = this.options[18];
            elementTargetElement.autocomplete = "off";
            elementTargetElement.calendar = this;
            if (elementTargetElement.value == "" || elementTargetElement.value.match(/^\d{4}-\d{1,2}-\d{1,2}$/) == null) {
                var now = new Date();
                //elementTargetElement.value = elementTargetElement.value == "" ? "" : now.getFullYear().toString() + "-" + this.toFixedZero(now.getMonth() + 1) + "-" + this.toFixedZero(now.getDate());
                this.date = [now.getFullYear(), now.getMonth(), now.getDate()];
            }
            else {
                var arrayDate = elementTargetElement.value.split("-");
                this.date = [arrayDate[0] * 1, arrayDate[1] * 1 - 1, arrayDate[2] * 1];
            }

            this.resetCalendar(this.date);

            if (!booleanAuto) {
                elementTargetElement.onfocus = function () {
                    if (this.value.match(/^\d{4}-\d{1,2}-\d{1,2}$/) == null) {
                        this.value = "";
                        this.style.color = "#333333";
                    }
                    this.calendar.show();
                };

                elementTargetElement.onblur = function () {
                    if (this.calendar.keepShowing) {
                        this.focus();
                        setTimeout(this.calendar.showStandalone, 1);
                    }
                    else {
                        this.calendar.hide();
                    }
                    if (this.value.match(/^\d{4}-\d{1,2}-\d{1,2}$/) == null) {
                        this.style.color = "#cccccc";
                        this.value = this.oriValue;
                    }
                    else {
                        this.style.color = "#333333";
                    }
                };
            }
            if (elementTargetHelp) {
                if (typeof elementTargetHelp == "string") {
                    var elementTargetElementHelp = document.getElementById(elementTargetHelp);
                }
                else {
                    var elementTargetElementHelp = elementTargetHelp;
                }
                elementTargetElementHelp.style.cursor = "pointer";
                elementTargetElementHelp.calendar = this;
                elementTargetElementHelp.onclick = function () {
                    this.calendar.elementTarget.focus();
                    this.calendar.showForce();
                };
            }
        };
        this.bind(targetInput, targetHelp);
    }
    module.exports = Calendar;
});