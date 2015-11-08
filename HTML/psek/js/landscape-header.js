// JavaScript Document
$(document).ready(function(){
	
	$buildingup = false;
	
	$("#sliders>*").show();
	
	
	$(this).delay(0,function(){
		$("#titlebar").fadeOut(1000);
	});
	
	$(this).delay(300,function(){
		
		//Show the elements
		var next = $("#main-body")
		next.removeClass( "my-hide" );
		next.stop().animate({top:'-100px'}, {queue:false, duration:2000, easing: 'easeInOutBack'});
		//$buildingup = true;	
		
    });


	

	//Change background color of body
	$("a.change").click(function(){
		$('body').css('background-color','#FFF');				 
	});
	 
});

var currentpageid = "#main-body";


function showPage(id){
	var curr = $(currentpageid);
	var next = $(id);
	curr.stop().animate({top:'-1080px'}, {queue:false, duration:1000, easing: 'easeInOutBack'});
	currentpageid = id;

	$(this).delay(500,function(){
		curr.addClass( "my-hide" );
		next.removeClass( "my-hide" );
		//Show the elements	
		next.stop().animate({top:'-100px'}, {queue:false, duration:1000, easing: 'easeInOutBack'});
		//$buildingup = true;	
		
    });

}