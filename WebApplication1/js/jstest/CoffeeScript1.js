(function() {

  seajs.use('module/module1', function(a) {
    var $;
    a.init("coffee1");
    $ = a.jq;
    return alert($("#qwer").html());
  });

}).call(this);
