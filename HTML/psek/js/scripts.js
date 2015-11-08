/*  ✰ Jacktha  ✰ */

// Place your application-specific JavaScript functions and classes here
// This file is automatically included by javascript_include_tag :defaults

//Cufon setting
Cufon.replace('h1');
Cufon.replace('#sub1'); // Requires a selector engine for IE 6-7, see above
Cufon.replace('#menu-header',{hover: 'true'});
Cufon.replace('#menu-footer',{hover: 'true',textShadow: '0px 1px #cccccc'});

//jQuery tipsy setting
jQuery('a.tool_tip').tipsy({fade: true});

//fanybox
	if(jQuery.fancybox){
		   jQuery("a[rel=image_group]").fancybox({
				'transitionIn'		: 'elastic',
				'transitionOut'		: 'elastic',
				'titlePosition' 	: 'over',
				'titleFormat'		: function(title, currentArray, currentIndex, currentOpts) {
					return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
				}
			});
			
			jQuery("a[rel=featured_group]").fancybox({
				'transitionIn'		: 'elastic',
				'transitionOut'		: 'elastic',
				'titlePosition' 	: 'over',
				'titleFormat'		: function(title, currentArray, currentIndex, currentOpts) {
					return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
				}
			});
	}
	
// set the the fade in and out of images
function imageHoverFade(){
	
	$('#applications li a img').animate({'opacity' : 1}).hover(function() {
		$(this).animate({'opacity' : .2});
	}, function() {
		$(this).animate({'opacity' : 1});
	});
}

// Form Validation script - used by the Contact Form script
function validateMyAjaxInputs() {

	$.validity.start();
	// Validator methods go here:
	$("#name").require();
	$("#email").require().match("email");
	$("#subject").require();	

	// End the validation session:
	var result = $.validity.end();
	return result.valid;
}

		

