$(document).ready(function() {
	$('#addComment').on("click", function(){
		var text = $('#textBox').val();
		if(!isEmpty(text)){
			var html = "<li class=\"listItem list-group-item\">" +
					
						
						"<div class=\"row\">"+
							"<h3 class=\"list-group-item-heading col-md-11 commentName\">Name</h3>"+
						
							"<button title=\"Remove Comment\" class=\"fa fa-x fa-remove removeButton\"></button>"+
						
						"</div>"+
						"<div class=\"row\">"+
							"<p class=\"col-xs-12 commentText\">"+text+ "</p>"+
						
						"</div>"+
						"<div class=\"row\">"+
							"<small class=\"col-xs-4\"> 12/11/2016 11:43 PM </small>"+
							"<small class=\"pull-right\"> Student</small>"+
						"</div>"+
							
						
					"</li>";
					
			$('#comments').append(html);
			$('#textBox').val('');
		} 
		
	})
	
	function isEmpty(str) {
	return typeof str == 'string' && !str.trim() || typeof str == 'undefined' || str === null;
}
	
});

