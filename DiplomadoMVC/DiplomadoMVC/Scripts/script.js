function foo() { $("body").css("padding-bottom", $("footer").outerHeight()); }

$(document).ready(() => { foo(); });
$(window).resize(() => { foo(); });