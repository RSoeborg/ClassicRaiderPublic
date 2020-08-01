(function ($, website) {

	'use strict';

	// Init
	$(function () {

		$('a.cr-popup').magnificPopup({
			type: 'inline',
			closeOnBgClick: true,
			enableEscapeKey: true,
			closeBtnInside: true,
			showCloseBtn: true,
			preloader: false
		});

	});

}).apply(this, [jQuery, window.website]);
