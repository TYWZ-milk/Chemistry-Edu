/* Author: Umair Khan @ Pixel Art Inc */

jQuery(document).ready(function() {
		
		
		
		// Slider
		$('.slider .slides').cycle({		
			fx: 		 'fade',		
			next:		 '.next',
			prev: 		 '.prev',
			speed:		 3000,
			cleartypeNoBg: 'true'
		});
		
		
		
		// Toggle
		$(".toggle").tabs(".toggle div.pane", {tabs: 'h5', effect: 'slide'});
		
		
		
		// Tabs
		$(".tabs").tabs("div.panes > article");
		
		
		
		// Light Box
		$(function() {
			$('a.lightbox').lightBox();
		});
		
		
		
		function equalHeight(group) {
		var tallest = 0;
		group.each(function() {
			var thisHeight = $(this).height();
			if(thisHeight > tallest) {
				tallest = thisHeight;
			}
		});
		group.height(tallest);
		}
		
		equalHeight($(".column"));
	
	
	
});







