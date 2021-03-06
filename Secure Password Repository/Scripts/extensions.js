﻿"use strict";

//add the CSRF token to AJAX requests
var AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('#_CRSFform input[name=__RequestVerificationToken]').val(); return data;
};

//global ajax error handling
$(document).ajaxError(function (event, jqxhr, settings, thrownError) {

    if (thrownError == 'Unauthorized') {

        window.location = '/Login?ReturnUrl=/Password';

    } else if (thrownError == 'Forbidden') {

        alert('You do not have permission');
        return false;

    } else {

        alert('Sorry it looks like something went wrong, please press F5 - if you keep getting this error, please contact support');
        return false;

    }

});