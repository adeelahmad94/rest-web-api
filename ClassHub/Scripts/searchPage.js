$(document).ready(function () {



	$('.joinButton').on('click', function(){
		var buttonText = $(this).text();
		buttonText.trim();
		if(buttonText == "Join"){
			$(this).text("Leave");
		}
		if(buttonText == "Leave"){
			$(this).text("Join");
		}
	});

    
	var searchFunc = function () {

	    var data = jQuery("#searchBox").val();
	    if (data) {
	        $.ajax({
	            type: "POST",
	            async: false,
	            url: "/Class/searchClasses", // script to validate in server side
	            data: "searchquery=" + data,
	            success: function (data) {
	                $('#searchList').empty();
	                if (!$.trim(data)) {
	                    document.getElementById("results").innerHTML = " ";
	                }

	                var v = JSON.parse(data);
	                var text = "";
	                var html = "";

	                if (v.length > 0) {
	                    for (var i = 0; i < v.length; i++) {

	                        if (v[i].joined) {
	                            var x = "leave";
	                        }
	                        else {
	                            var x = "join";
	                        }
	                        html = "<li class=\"listItem list-group-item\">" +


                        "<div class=\"row\">" +
                            "<h3 class=\"list-group-item-heading col-md-8\">" + v[i].className + "</h3>" +

                                        "<a type=\"button\"class=\"pull-right btn btn-default joinButton\" href=\"@Url.Action(\"JoinOrLeaveClass\", \"Class\", \new{classId= v.cl.Id, joined = v.joined })\">" + x + "</a>" +

                        "</div>" +
                        "<div class=\"row\">" +
                            "<p class=\"col-xs-12\">" + v[i].classDesc + "</p>" +

                        "</div>" +
                        "<div class=\"row\">" +

                            "<small class=\"pull-right\">Created By:" + v[i].classCreator + "</small>" +
                        "</div>" +


                    "</li>";
	                    }

	                }
	                else {
	                    html = "<h3> No Results To Show</h3>"
	                }
	                $('#searchList').append(html);


	            }

	        });
	    }

	};
	$('#searchBox').keyup(searchFunc);

});

