seajs.use 'module/module1', (init) ->

	$ = init.jq

	$(".btnswitch").on "click",(e)->
		next=$(e.target).attr("ctr")
		current = $(".on").attr("id")
		$(".on").removeClass("on")
		$("#"+next).addClass("on")
		if current == next
			return false
		else
			$("#"+next).animate({opacity:1},800,"swing",null)
			$("#"+current).animate({opacity:0},800,"swing",null)

	autoswitch=()->
		setInterval(()->
			current = $(".on").attr("id")
			next="btn1"
			if $("#hfisfirst").attr("value") == "1"
				$("#hfisfirst").attr("value","0")
			else if current == "p1"
					next="btn2"
				else if current == "p2"
					next="btn3"
			$("#"+next).click()
		,15000)

	autoswitch()
