$("#btnMakePic").on "click", ->
	$("#txtOutputXml").empty()
	if $("#txtCurrencyPer").attr("value")+$("#txtStockPer").attr("value")+$("#txtBondPer").attr("value")+$("#txtSelf1Per").attr("value")+$("#txtSelf2Per").attr("value")!=100
		alert "配置百分比总和不是100%，换算后进行绘图。"

$("#btnUpdate").on "click", ->
	$("#txtOutputXml").empty()
	if $("#txtCurrencyPer").attr("value")+$("#txtStockPer").attr("value")+$("#txtBondPer").attr("value")+$("#txtSelf1Per").attr("value")+$("#txtSelf2Per").attr("value")!=100
		alert "配置百分比总和不是100%，换算后进行绘图。"

$("#btnSave").on "click", ->
	$("#txtOutputXml").empty()
	if $("#txtCurrencyPer").attr("value")+$("#txtStockPer").attr("value")+$("#txtBondPer").attr("value")+$("#txtSelf1Per").attr("value")+$("#txtSelf2Per").attr("value")!=100
		alert "配置百分比总和不是100%，换算后进行绘图。"
