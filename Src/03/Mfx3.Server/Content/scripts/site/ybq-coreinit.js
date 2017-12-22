///////////////////////////////////////////////////////////////////
//
// Youbiquitous YBQ : app starter 
// Copyright (c) Youbiquitous srls 2017
//
// Author: Dino Esposito (http://youbiquitous.net)
//

(function () {
    Ybq.configureCommonElements();
    Ybq.mobilize();

    // Enable date picking all the way through
    $("input[date]").datepicker({
        format: 'd M yyyy',
        clearBtn: true,
        orientation: "bottom left"
    });

    // Add hyperlink to table rows
    $("tbody tr[data-gotourl]").click(function() {
        var url = $(this).data("gotourl");
        Ybq.gotoRelative(url);
    });

})();