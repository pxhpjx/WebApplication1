(function() {

  seajs.use('module/module1', function(init) {
    var $, autoswitch;
    $ = init.jq;
    $(".btnswitch").on("click", function(e) {
      var current, next;
      next = $(e.target).attr("ctr");
      current = $(".on").attr("id");
      $(".on").removeClass("on");
      $("#" + next).addClass("on");
      if (current === next) {
        return false;
      } else {
        $("#" + next).animate({
          opacity: 1
        }, 800, "swing", null);
        return $("#" + current).animate({
          opacity: 0
        }, 800, "swing", null);
      }
    });
    autoswitch = function() {
      return setInterval(function() {
        var current, next;
        current = $(".on").attr("id");
        next = "btn1";
        if ($("#hfisfirst").attr("value") === "1") {
          $("#hfisfirst").attr("value", "0");
        } else if (current === "p1") {
          next = "btn2";
        } else if (current === "p2") {
          next = "btn3";
        }
        return $("#" + next).click();
      }, 15000);
    };
    return autoswitch();
  });

}).call(this);
