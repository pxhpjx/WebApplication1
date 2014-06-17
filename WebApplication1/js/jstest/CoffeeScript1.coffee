seajs.use 'module/module1', (a) ->
	a.init("coffee1")
	$ = a.jq
	alert $("#qwer").html()