//*************************************************************
// Le JavaScript de TextBoxAvance utilise les plugins jQuery
// open source suivants:
//
// maxlength - http://www.stjerneman.com/demo/maxlength-with-jquery
// alphanumeric - http://itgroup.com.ph/alphanumeric/
// maskedinput - http://digitalbush.com/projects/masked-input-plugin/ (modifié par la SIQ)
// autonumeric - http://www.decorplanit.com/plugin/ (modifié par la SIQ)
// jQuery UI - http://jqueryui.com/
//
// Tous ces plugins viennent avec une license MIT donc ils peuvent
// être modifiés et utilisés sans problème.
//
// Afin de réduire le nombre de fichiers JavaScript à inclure,
// ils ont tous été insérés dans ce fichier JS.

/**
* jQuery Maxlength plugin
* @version		$Id: jquery.maxlength.js 18 2009-05-16 15:37:08Z emil@anon-design.se $
* @package		jQuery maxlength 1.0.5
* @copyright	Copyright (C) 2009 Emil Stjerneman / http://www.anon-design.se
* @license		GNU/GPL, see LICENSE.txt
*/

(function ($) {

    $.fn.maxlength = function (options) {
        var settings = jQuery.extend(
        {
            events: [], // Array of events to be triggerd
            maxCharacters: 10, // Characters limit
            status: false, // True to show status indicator bewlow the element
            statusClass: "status", // The class on the status div
            statusText: "character left", // The status text
            notificationClass: "notification", // Will be added to the emement when maxlength is reached
            showAlert: false, // True to show a regular alert message
            alertText: "You have typed too many characters.", // Text in the alert message
            slider: false // Use counter slider
        }, options);

        // Add the default event
        $.merge(settings.events, ['keyup']);

        return this.each(function () {
            var item = $(this);
            var charactersLength = $(this).val().length;

            // Update the status text
            function updateStatus() {
                var charactersLeft = settings.maxCharacters - charactersLength;

                if (charactersLeft < 0) {
                    charactersLeft = 0;
                }

                item.next("div").html(charactersLeft + " " + settings.statusText);
            }

            function checkChars() {
                var valid = true;

                // Too many chars?
                if (charactersLength >= settings.maxCharacters) {
                    // Too may chars, set the valid boolean to false
                    valid = false;
                    // Add the notifycation class when we have too many chars
                    item.addClass(settings.notificationClass);
                    // Cut down the string
                    item.val(item.val().substr(0, settings.maxCharacters));
                    // Show the alert dialog box, if its set to true
                    showAlert();
                }
                else {
                    // Remove the notification class
                    if (item.hasClass(settings.notificationClass)) {
                        item.removeClass(settings.notificationClass);
                    }
                }

                if (settings.status) {
                    updateStatus();
                }
            }

            // Shows an alert msg
            function showAlert() {
                if (settings.showAlert) {
                    alert(settings.alertText);
                }
            }

            // Check if the element is valid.
            function validateElement() {
                var ret = false;

                if (item.is('textarea')) {
                    ret = true;
                } else if (item.filter("input[type=text]")) {
                    ret = true;
                } else if (item.filter("input[type=password]")) {
                    ret = true;
                }

                return ret;
            }

            // Validate
            if (!validateElement()) {
                return false;
            }

            // Loop through the events and bind them to the element
            $.each(settings.events, function (i, n) {
                item.bind(n, function (e) {
                    charactersLength = item.val().length;
                    checkChars();
                });
            });

            // Insert the status div
            if (settings.status) {
                item.after($("<div/>").addClass(settings.statusClass).html('-'));
                updateStatus();
            }

            // Remove the status div
            if (!settings.status) {
                var removeThisDiv = item.next("div." + settings.statusClass);

                if (removeThisDiv) {
                    removeThisDiv.remove();
                }

            }

            // Slide counter
            if (settings.slider) {
                item.next().hide();

                item.focus(function () {
                    item.next().slideDown('fast');
                });

                item.blur(function () {
                    item.next().slideUp('fast');
                });
            }

        });
    };
})(jQuery);


/**
* autoNumeric.js
* @author: Bob Knothe
* @version: 1.6.2
/*/

(function ($) {
    $.fn.autoNumeric = function (options) {
        var opts = $.extend({}, $.fn.autoNumeric.defaults, options); /* build main options before element iteration */
        return this.each(function () {/* iterate and reformat each matched element */
            var iv = $(this); /* check input value iv */
            var ii = this.id; /* input ID */
            var io = $.metadata ? $.extend({}, opts, iv.metadata()) : opts; /* build element specific options io = input options */
            io.mDec = isNaN(io.mDec * 1) ? $('#' + io.mDec).val() * 1 : io.mDec * 1; /* sets decimal places */
            var kdCode = ''; /* Key down Code */
            var selectLength = 0; /* length of input selected */
            var caretPos = 0; /* caret poistion */
            var inLength = 0; /* length prior to keypress event */
            var charLeft = 0; /* number of characters to the left of the decimal point */
            var numLeft = 0; /* number of numeric characters to the left of the decimal point */
            var numRight = 0; /* number of numeric characters to the right of the decimal point */
            var cmdKey = false; /* MAC command ket pressed */
            $(this).keydown(function (e) {/* start keyDown event */
                io = $.metadata ? $.extend({}, opts, iv.metadata()) : opts; /* build element specific options io = input options */
                io.mDec = isNaN(io.mDec * 1) ? $('#' + io.mDec).val() * 1 : io.mDec * 1; /* sets decimal places */
                cmdKey = false;
                if (!e) {/* routine for key  codes on key down */
                    e = window.event;
                }
                if (e.keyCode) {/* IE support */
                    kdCode = e.keyCode;
                }
                else if (e.which) {/* FF & O support */
                    kdCode = e.which;
                }
                if (e.metaKey) {/* tests for Mac command key being pressed down thanks Bart B. for bring to my attention */
                    cmdKey = true;
                }
                if (document.selection) {/* IE Support to find the caret position */
                    this.focus();
                    var select = document.selection.createRange();
                    selectLength = document.selection.createRange().text.length;
                    select.moveStart('character', -this.value.length);
                    caretPos = (select.text.length - selectLength) * 1;
                }
                else if (this.selectionStart || this.selectionStart == '0') {/* Firefox support  to find the caret position */
                    selectLength = this.selectionEnd * 1 - this.selectionStart * 1;
                    caretPos = this.selectionStart * 1;
                } /* end caret position routine */
                inLength = this.value.length; /* pass string length to keypress event for value left & right of the decimal position & keyUp event to set caret position */
            }).keypress(function (e) {/* start keypress  event*/
                var allowed = io.aNum + io.aNeg + io.aDec; /* sets allowed input, number, negitive sign and decimal seperator */
                charLeft = (this.value.lastIndexOf(io.aDec) == -1) ? inLength : inLength - (inLength - this.value.lastIndexOf(io.aDec)); /* characters to the left of the decimal point */
                numLeft = autoCount(this.value, 0, charLeft); /* the number of intergers to the left of the decimal point */
                if (this.value.lastIndexOf(io.aDec) != -1) {
                    numRight = autoCount(this.value, charLeft, inLength); /* the number of intergers to the right of the decimal point */
                }
                if ((e.ctrlKey || cmdKey) && (kdCode == 65 || kdCode == 67 || kdCode == 86 || kdCode == 88)) {/* allows controll key & select all (v=65) Thanks Jonas Johansson, copy(c=67), past (v=86), cut (v=88)  */
                    return true;
                }
                if (kdCode == 8 || kdCode == 9 || kdCode == 13 || kdCode == 35 || kdCode == 36 || kdCode == 37 || kdCode == 39 || kdCode == 46) {/* allows the backspace (8), tab (9), enter 13, end (35), home(36), left(37) and right(39) arrows key  delete key (46) to function in some browsers (FF & O) - Thanks to Bart Bons on the return key */
                    return true;
                }
                var kpCode = ''; /* Key Press Code */
                if (!e) {/* routine for key  codes on key down */
                    e = window.event;
                }
                if (e.keyCode) {/* IE */
                    kpCode = e.keyCode;
                }
                else if (e.which) {/* FF & O */
                    kpCode = e.which;
                }
                var cCode = String.fromCharCode(kpCode); /* Character code*/
                if (allowed.indexOf(cCode) == -1) {/* checks for allowed characters */
                    e.preventDefault();
                }
                if (cCode == io.aDec) {/* start rules when the decimal charactor key is pressed */
                   
                } /*  end rules when the decimal charactor key is pressed */
                if (kpCode == 45 && (caretPos > 0 || this.value.indexOf('-') != -1 || io.aNeg === '')) {/* start rules when the negative key pressed */
                    if (selectLength >= 1 && caretPos === 0) {/* allows the selected input to be replaced with a number - Thanks Bart V.  */
                        return;
                    }
                    else {
                        e.preventDefault();
                    }
                } /* end rules when the negative key pressed */
            
            }).keyup(function (e) {/* start keyup event routine */
                if (this.value === '') { /* Fix to let you delete what is in the textbox without it adding padded zeroes - bcull - 6 Sep 2010 */
                    return;
                }
                if (io.aSep === '' || e.keyCode == 9 || e.keyCode == 20 || e.keyCode == 35 || e.keyCode == 36 || e.keyCode == 37 || e.keyCode == 39 || kdCode == 9 || kdCode == 13 || kdCode == 20 || kdCode == 35 || kdCode == 36 || kdCode == 37 || kdCode == 39) {/* allows the tab(9), end(35), home(36) left(37) & right(39) arrows and when there is no thousand separator to bypass the autoGroup function  */
                    return; /* key codes 35 & 36 Home and end keys fix thanks to JPM USA  */
                }
                // SIQ
                if (kdCode == 110 && this.value.indexOf(io.aDec) == -1 && io.mDec > 0 && caretPos >= this.value.length - io.mDec && this.value.lastIndexOf(io.aSep) < caretPos && this.value.lastIndexOf('-') < caretPos) { //start modification for period key to enter a comma on numeric pad 
                //    $(this).val(this.value.substring(0, caretPos) + io.aDec + this.value.substring(inLength, caretPos));
                }
               
              //  $(autoId(ii)).val(autoGroup(this.value, io)); /* adds the thousand sepparator */
                
                var outLength = this.value.length;
                charLeft = (this.value.lastIndexOf(io.aDec) == -1) ? outLength : outLength - (outLength - this.value.lastIndexOf(io.aDec));
                numLeft = autoCount(this.value, 0, charLeft); /* the number of intergers to the left of the decimal point */
                if (numLeft > io.mNum) {/* if max number of characters are exceeeded */
                    $(autoId(ii)).val('');
                }
                var setCaret = 0; /* start - determines the new caret position  */
                if (inLength < outLength) {/* new caret position when a number or decimal character has been added */
                    setCaret = (outLength == io.aSign.length + 1 && io.pSign == 's') ? 1 : caretPos + (outLength - inLength);
                }
               
                if (inLength > outLength) { /* new caret position when a number(s) or decimal character(s) has been deleted */
                    if (selectLength === 0) {
                        if ((inLength - 2) == outLength) {/* when two caracters one numeric and one thosand seperator have been deleted */
                            if (kdCode == 8) {/* back space key pressed */
                                setCaret = (caretPos - 2);
                            }
                            else if (kdCode == 46) {/* delete key pressed */
                                setCaret = caretPos;
                            }
                            else {
                                setCaret = (caretPos - 1);
                            }
                        }
                        else {/* back space key pressed */
                            setCaret = (kdCode == 8) ? caretPos - 1 : caretPos;
                        }
                    }
                    if (selectLength > 0 && selectLength < inLength) {/* when multiple characters but not all are deleted */
                        setCaret = (outLength - (inLength - (caretPos + selectLength)));
                    }
                    if (selectLength == inLength) {/* when multiple characters but not all are deleted */
                        setCaret = (outLength == io.aSign.length + 1 && io.pSign == 's') ? 1 : 1 + io.aSign.length;
                    }
                }
                if (inLength == outLength) {/* new caret position when a and equal aount of characters have been added as the amount deleted */
                    if (selectLength >= 0) {
                        setCaret = caretPos + selectLength;
                    }
                    if (this.value.charAt(caretPos - 1) == io.aSep && kdCode == 8) {/* moves caret to the left when trying to delete thousand separartor via the backspace key */
                        setCaret = (caretPos - 1);
                    }
                    else if (this.value.charAt(caretPos) == io.aSep && kdCode == 46) {/* moves caret to the right when trying to delete thousand separartor via the delete key */
                        setCaret = (caretPos + 1);
                    }
                } /*  ends - determines the new caret position  */
                var iField = this; /* start - set caret position */
                iField.focus();
                if (document.selection) {
                    var iRange = iField.createTextRange();
                    iRange.collapse(true);
                    iRange.moveStart("character", setCaret);
                    iRange.moveEnd("character", 0);
                    iRange.select();
                }
                else if (iField.selectionStart || iField.selectionStart == '0') {
                    iField.selectionStart = setCaret;
                    iField.selectionEnd = setCaret;
                } /* end - set caret position */
            }).bind('change focusout', function () {/* start change - thanks to Javier P. corrected the inline onChange event  added focusout version 1.55*/
                if ($(autoId(ii)).val() !== '') {
                    autoCheck(iv, ii, io);
                }
            }).bind('paste', function () { setTimeout(function () { autoCheck(iv, ii, io); }, 0); }); /* thanks to Josh of Digitalbush.com Opera does not fire paste event*/
        });
    };
    function autoId(myid) {/* thanks to Anthony & Evan C */
        myid = myid.replace(/\[/g, "\\[").replace(/\]/g, "\\]");
        return '#' + myid.replace(/(:|\.)/g, '\\$1');
    }
    function autoCount(str, start, end) {/* private function that counts the numeric characters to the left and right of the decimal point */
        var chr = '';
        var numCount = 0;
        for (j = start; j < end; j++) {
            chr = str.charAt(j);
            if (chr >= '0' && chr <= '9') {
                numCount++;
            }
        }
        return numCount;
    }
    function autoGroup(iv, io) {/* private function that places the thousand separtor */
        if (io.aSep !== '') {
            var digitalGroup = '';
            if (io.dGroup == 2) {
                digitalGroup = /(\d)((\d)(\d{2}?)+)$/;
            }
            else if (io.dGroup == 4) {
                digitalGroup = /(\d)((\d{4}?)+)$/;
            }
            else {
                digitalGroup = /(\d)((\d{3}?)+)$/;
            }
            for (k = 0; k < io.aSign.length; k++) {/* clears the currency or other symbols and space */
                iv = iv.replace(io.aSign.charAt(k), '').replace("\u00A0", '');
            }
            iv = iv.split(io.aSep).join(''); /* removes the thousand sepparator */
            var ivSplit = iv.split(io.aDec); /* splits the string at the decimal string */
            var s = ivSplit[0]; /* assigns the whole number to the a varibale (s) */
            while (digitalGroup.test(s)) {
                s = s.replace(digitalGroup, '$1' + io.aSep + '$2'); /*  re-inserts the thousand sepparator via a regualer expression */
            }
            if (io.mDec !== 0 && ivSplit.length > 1) {
                iv = s + io.aDec + ivSplit[1]; /* joins the whole number with the deciaml value */
            }
            else {
                iv = s; /* if whole numers only */
            }
            if (iv.indexOf('-') !== -1 && io.aSign !== '' && io.pSign == 'p') {/* places the currency sign to the left (prefix) */
                iv = iv.replace('-', '');
                return '-' + io.aSign + iv;
            }
            else if (iv.indexOf('-') == -1 && io.aSign !== '' && io.pSign == 'p') {
                return io.aSign + iv;
            }
            if (iv.indexOf('-') !== -1 && io.aSign !== '' && io.pSign == 's') {/* places the currency sign to the right (suffix) */
                iv = iv.replace('-', '');
                return '-' + iv + io.aSign;
            }
            else if (iv.indexOf('-') == -1 && io.aSign !== '' && io.pSign == 's') {
                return iv + io.aSign;
            }
            else {
                return iv;
            }
        }
        else {
            return iv;
        }
    }
    function autoRound(iv, mDec, mRound, aPad) {/* private function for round the number - please note this handled as text - Javascript math function can return inaccurate values */
        iv = (iv === '') ? '0' : iv += ''; /* value to string */
        var ivRounded = '';
        var i = 0;
        var nSign = '';
        if (iv.charAt(0) == '-') {/* Checks if the iv (input Value)is a negative value */
            nSign = (iv * 1 === 0) ? '' : '-'; /* determines if the value is zero - if zero no negative sign */
            iv = iv.replace('-', ''); /* removes the negative sign will be added back later if required */
        }
        if ((iv * 1) > 0) {/* trims leading zero's if needed */
            while (iv.substr(0, 1) == '0' && iv.length > 1) {
                iv = iv.substr(1);
            }
        }
        var dPos = iv.lastIndexOf('.'); /* decimal postion as an integer */
        if (dPos === 0) {/* prefix with a zero if the decimal point is the first character */
            iv = '0' + iv;
            dPos = 1;
        }
        if (dPos == -1 || dPos == iv.length - 1) {/* Has an integer been passed in? */
            if (aPad && mDec > 0) {
                ivRounded = (dPos == -1) ? iv + '.' : iv;
                for (i = 0; i < mDec; i++) {/* pads with zero */
                    ivRounded += '0';
                }
                return nSign + ivRounded;
            }
            else {
                return nSign + iv;
            }
        }
        var cDec = (iv.length - 1) - dPos; /* checks decimal places to determine if rounding is required */
        if (cDec == mDec) {
            return nSign + iv; /* If true return value no rounding required */
        }
        if (cDec < mDec && aPad) {/* Do we already have less than the number of decimal places we want? */
            ivRounded = iv; /* If so, pad out with zeros */
            for (i = cDec; i < mDec; i++) {
                ivRounded += '0';
            }
            return nSign + ivRounded;
        }
        var rLength = dPos + mDec; /* rounded length of the string after rounding  */
        var tRound = iv.charAt(rLength + 1) * 1; /* test round */
        var ivArray = []; /* new array*/
        for (i = 0; i <= rLength; i++) {/* populate ivArray with each digit in rLength */
            ivArray[i] = iv.charAt(i);
        }
        var odd = (iv.charAt(rLength) == '.') ? (iv.charAt(rLength - 1) % 2) : (iv.charAt(rLength) % 2);
        if ((tRound > 4 && mRound === 'S') || /* Round half up symetric */
            (tRound > 4 && mRound === 'A' && nSign === '') || /* Round half up asymetric positive values */
            (tRound > 5 && mRound === 'A' && nSign == '-') || /* Round half up asymetric negative values */
            (tRound > 5 && mRound === 's') || /* Round half down symetric */
            (tRound > 5 && mRound === 'a' && nSign === '') || /* Round half down asymetric positive values */
            (tRound > 4 && mRound === 'a' && nSign == '-') || /* Round half down asymetric negative values */
            (tRound > 5 && mRound === 'B') || /* Round half even "Banker's Rounding" */
            (tRound == 5 && mRound === 'B' && odd == 1) || /* Round half even "Banker's Rounding" */
            (tRound > 0 && mRound === 'C' && nSign === '') || /* Round to ceiling toward positive infinite */
            (tRound > 0 && mRound === 'F' && nSign == '-') || /* Round to floor toward negative inifinte */
            (tRound > 0 && mRound === 'U')) {/* round up away from zero  */
            for (i = (ivArray.length - 1) ; i >= 0; i--) {/* Round up the last digit if required, and continue until no more 9's are found */
                if (ivArray[i] == '.') {
                    continue;
                }
                ivArray[i]++;
                if (ivArray[i] < 10) {/* if i does not equal 10 no more round up required */
                    break;
                }
            }
        }
        for (i = 0; i <= rLength; i++) {/* Reconstruct the string, converting any 10's to 0's */
            if (ivArray[i] == '.' || ivArray[i] < 10 || i === 0) {/* routine to reconstruct non '10' */
                ivRounded += ivArray[i];
            }
            else {/* converts 10's to 0 */
                ivRounded += '0';
            }
        }
        if (mDec === 0) {/* If there are no decimal places, we don't need a decimal point */
            ivRounded = ivRounded.replace('.', '');
        }
        return nSign + ivRounded; /* return rounded value */
    }
    function autoCheck(iv, ii, io) {/*  private function that change event and pasted values  */
        iv = iv.val();
        if (iv.length > 100) {/* maximum length of pasted value */
            $(autoId(ii)).val('');
            return;
        }
        var eNeg = '';
        if (io.aNeg == '-') {/* escape the negative sign */
            eNeg = '\\-';
        }
        var reg = new RegExp('[^' + eNeg + io.aNum + io.aDec + ']', 'gi'); /* regular expreession constructor to delete any characters not allowed for the input field. */
        var testPaste = iv.replace(reg, ''); /* deletes all characters that are not permitted in this field */
        if (testPaste.lastIndexOf('-') > 0 || testPaste.indexOf(io.aDec) != testPaste.lastIndexOf(io.aDec)) {/* deletes input if the negitive sign is incorrectly placed or if the are multiple decimal characters */
            testPaste = '';
        }
        var rePaste = '';
        var nNeg = 0;
        var nSign = '';
        var i = 0;
        var s = testPaste.split(''); /* split the sting into an array */
        for (i = 0; i < s.length; i++) {/* for loop testing pasted value after non allowable characters have been deleted */
            if (i === 0 && s[i] == '-') {/* allows negative symbol to be added if it is the first character */
                nNeg = 1;
                nSign = '-';
                continue;
            }
            if (s[i] == io.aDec && s.length - 1 == i) {/* if the last charter is a decimal point it is dropped */
                break;
            }
            if (rePaste.length === 0 && s[i] == '0' && (s[i + 1] >= 0 || s[i + 1] <= 9)) {/* controls leading zero */
                continue;
            }
            else {
                rePaste = rePaste + s[i];
            }

        }
        rePaste = nSign + rePaste;
        if (rePaste.indexOf(io.aDec) == -1 && rePaste.length > (io.mNum + nNeg)) {/* checks to see if the maximum & minimum values have been exceeded when no decimal point is present */
            rePaste = '';
        }
        if (rePaste.indexOf(io.aDec) > (io.mNum + nNeg)) {/* check to see if the maximum & minimum values have been exceeded when the decimal point is present */
            rePaste = '';
        }
        if (rePaste.indexOf(io.aDec) != -1 && (io.aDec != '.')) {
            rePaste = rePaste.replace(io.aDec, '.');
        }
        rePaste = autoRound(rePaste, io.mDec, io.mRound, io.aPad); /* call round function */
        if (io.aDec != '.') {
            rePaste = rePaste.replace('.', io.aDec); /* replace the decimal point with the proper decimal separator */
        }
        if (rePaste !== '' && io.aSep !== '') {
            rePaste = autoGroup(rePaste, io); /* calls the group function adds digital grouping */
        }
        $(autoId(ii)).val(rePaste);
        return false;
    }
    $.fn.autoNumeric.Strip = function (ii, options) {/* public function that stripes the format and converts decimal seperator to a period */
        var opts = $.extend({}, $.fn.autoNumeric.defaults, options);
        var io = $.metadata ? $.extend({}, opts, $(autoId(ii)).metadata()) : opts;
        io.mDec = isNaN(io.mDec * 1) ? $('#' + io.mDec).val() * 1 : io.mDec * 1; /* decimal places */
        var iv = $(autoId(ii)).val();
        iv = iv.replace(io.aSign, '').replace('\u00A0', '');
        var reg = new RegExp('[^' + '\\-' + io.aNum + io.aDec + ']', 'gi'); /* regular expreession constructor */
        iv = iv.replace(reg, ''); /* deletes all characters that are not permitted in this field */
        var nSign = '';
        if (iv.charAt(0) == '-') {/* Checks if the iv (input Value)is a negative value */
            nSign = (iv * 1 === 0) ? '' : '-'; /* determines if the value is zero - if zero no negative sign */
            iv = iv.replace('-', ''); /*  removes the negative sign will be added back later if required */
        }
        iv = iv.replace(io.aDec, '.');
        if (iv * 1 > 0) {
            while (iv.substr(0, 1) == '0' && iv.length > 1) {
                iv = iv.substr(1);
            }
        }
        iv = (iv.lastIndexOf('.') === 0) ? ('0' + iv) : iv;
        iv = (iv * 1 === 0) ? '0' : iv;
        return nSign + iv;
    };
    $.fn.autoNumeric.Format = function (ii, iv, options) {/* public function that recieves a numeric string and formats to the target input field */
        iv += ''; /* to string */
        var opts = $.extend({}, $.fn.autoNumeric.defaults, options);
        var io = $.metadata ? $.extend({}, opts, $(autoId(ii)).metadata()) : opts;
        io.mDec = isNaN(io.mDec * 1) ? $('#' + io.mDec).val() * 1 : io.mDec * 1; /* decimal places */
        iv = autoRound(iv, io.mDec, io.mRound, io.aPad);
        var nNeg = 0;
        if (iv.indexOf('-') != -1 && io.aNeg === '') {/* deletes negative symbol */
            iv = '';
        }
        else if (iv.indexOf('-') != -1 && io.aNeg == '-') {
            nNeg = 1;
        }
        if (iv.indexOf('.') == -1 && iv.length > (io.mNum + nNeg)) {/* check to see if the maximum & minimum values have been exceeded when no decimal point is present */
            iv = '';
        }
        else if (iv.indexOf('.') > (io.mNum + nNeg)) {/* check to see if the maximum & minimum values have been exceeded when a decimal point is present */
            iv = '';
        }
        if (io.aDec != '.') {/* replaces the decimal point with the new sepatator */
            iv = iv.replace('.', io.aDec);
        }
        return autoGroup(iv, io);
    };
    $.fn.autoNumeric.defaults = {/* plugin defaults */
        aNum: '0123456789', /*  allowed  numeric values */
        aNeg: '', /* allowed negative sign / character */
        aSep: ',', /* allowed thousand separator character */
        aDec: '.', /* allowed decimal separator character */
        aSign: '', /* allowed currency symbol */
        pSign: 'p', /* placement of currency sign prefix or suffix */
        mNum: 9, /* max number of numerical characters to the left of the decimal */
        mDec: 2, /* max number of decimal places */
        dGroup: 3, /* digital grouping for the thousand separator used in Format */
        mRound: 'S', /* method used for rounding */
        aPad: true/* true= always Pad decimals with zeros, false=does not pad with zeros. If the value is 1000, mDec=2 and aPad=true, the output will be 1000.00, if aPad=false the output will be 1000 (no decimals added) Special Thanks to Jonas Johansson */
    };
})(jQuery);

/**
* alphaNumeric.js
*
* ***** Modifié par la SIQ car non mis à jour depuis 2007 *****
/*/
(function ($) {

    $.fn.alphanumeric = function (p) {
        p = $.extend({
            ichars: "!@#$%&*()+=[]\\\';,/{}|\":<>?~`.- ½¼¾³²£¢¤¬¦±¯°»«~¨¶§µ_",
            nchars: "",
            allow: ""
        }, p);
        return this.each(
            function () {

                if (p.nocaps) p.nchars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (p.allcaps) p.nchars += "abcdefghijklmnopqrstuvwxyz";

                s = p.allow.split('');
                for (i = 0; i < s.length; i++) if (p.ichars.indexOf(s[i]) != -1) s[i] = "\\" + s[i];
                p.allow = s.join('|');

                var reg = new RegExp(p.allow, 'gi');
                var ch = p.ichars + p.nchars;
                ch = ch.replace(reg, '');

                $(this).unbind('keypress').bind('keypress',
                    function (e) {
                        if (!e.charCode) k = String.fromCharCode(e.which);
                        else k = String.fromCharCode(e.charCode);

                        if (ch.indexOf(k) != -1) e.preventDefault();
                        // -- SIQ --
                        //if (e.ctrlKey && k == 'v') e.preventDefault();

                    }
                );

                $(this).bind('paste',
                    function (e) {

                        var jqObj = $(this);
                        var val = jqObj.val();

                        var text = val.substring(0, $(this).caret().begin) + window.clipboardData.getData("Text") + val.substring($(this).caret().end, val.length);
                        var len = Math.min(jqObj.attr('maxLength') || text.length, text.length);
                        var resultat = '';
                        // -- SIQ -- 
                        for (var i = 0; i < len; i++) {
                            var caractere = text.substring(i, i + 1);
                            if (p.nchars.indexOf(caractere) == -1) {
                                resultat = resultat + caractere;
                            }
                        }

                        jqObj.val(resultat);
                        return false;
                    }
                );
            }
        );

    };

    $.fn.numeric = function (p) {
        var az = "abcdefghijklmnopqrstuvwxyzéîïìêëèàäâöòôùûü^`¨¸";
        az += az.toUpperCase();

        p = $.extend({
            nchars: az
        }, p);

        return this.each(function () {
            $(this).alphanumeric(p);
        }
        );

    };

    $.fn.alpha = function (p) {
        var nm = "1234567890";

        p = $.extend({
            nchars: nm
        }, p);

        return this.each(function () {
            $(this).alphanumeric(p);
        }
        );

    };

})(jQuery);

/*
Masked Input plugin for jQuery
Copyright (c) 2007-@Year Josh Bush (digitalbush.com)
Licensed under the MIT license (http://digitalbush.com/projects/masked-input-plugin/#license) 
Version: March 26, 2011 (GitHub)

***** Petite modification par la SIQ pour problème avec AltGr qui permet l'insertion de caractères *****
*/
(function ($) {
    var pasteEventName = ($.browser.msie ? 'paste' : 'input') + ".mask";
    var iPhone = (window.orientation != undefined);

    $.mask = {
        //Predefined character definitions
        definitions: {
            '9': "[0-9]",
            'a': "[A-Za-z]",
            '*': "[A-Za-z0-9]"
        },
        dataName: "rawMaskFn"
    };

    $.fn.extend({
        //Helper Function for Caret positioning
        caret: function (begin, end) {
            if (this.length == 0) return;
            if (typeof begin == 'number') {
                end = (typeof end == 'number') ? end : begin;
                return this.each(function () {
                    if (this.setSelectionRange) {
                        this.setSelectionRange(begin, end);
                    } else if (this.createTextRange) {
                        var range = this.createTextRange();
                        range.collapse(true);
                        range.moveEnd('character', end);
                        range.moveStart('character', begin);
                        range.select();
                    }
                });
            } else {
                if (this[0].setSelectionRange) {
                    begin = this[0].selectionStart;
                    end = this[0].selectionEnd;
                } else if (document.selection && document.selection.createRange) {
                    var range = document.selection.createRange();
                    begin = 0 - range.duplicate().moveStart('character', -100000);
                    end = begin + range.text.length;
                }
                return { begin: begin, end: end };
            }
        },
        unmask: function () { return this.trigger("unmask"); },
        mask: function (mask, settings) {
            if (!mask && this.length > 0) {
                var input = $(this[0]);
                return input.data($.mask.dataName)();
            }
            settings = $.extend({
                placeholder: "_",
                completed: null
            }, settings);

            var defs = $.mask.definitions;
            var tests = [];
            var partialPosition = mask.length;
            var firstNonMaskPos = null;
            var len = mask.length;

            $.each(mask.split(""), function (i, c) {
                if (c == '?') {
                    len--;
                    partialPosition = i;
                } else if (defs[c]) {
                    tests.push(new RegExp(defs[c]));
                    if (firstNonMaskPos == null)
                        firstNonMaskPos = tests.length - 1;
                } else {
                    tests.push(null);
                }
            });

            return this.trigger("unmask").each(function () {
                var input = $(this);
                var buffer = $.map(mask.split(""), function (c, i) { if (c != '?') return defs[c] ? settings.placeholder : c });
                var focusText = input.val();

                function seekNext(pos) {
                    while (++pos <= len && !tests[pos]);
                    return pos;
                };
                function seekPrev(pos) {
                    while (--pos >= 0 && !tests[pos]);
                    return pos;
                };

                function shiftL(begin, end) {
                    if (begin < 0)
                        return;
                    for (var i = begin, j = seekNext(end) ; i < len; i++) {
                        if (tests[i]) {
                            if (j < len && tests[i].test(buffer[j])) {
                                buffer[i] = buffer[j];
                                buffer[j] = settings.placeholder;
                            } else
                                break;
                            j = seekNext(j);
                        }
                    }
                    writeBuffer();
                    input.caret(Math.max(firstNonMaskPos, begin));
                };

                function shiftR(pos) {
                    for (var i = pos, c = settings.placeholder; i < len; i++) {
                        if (tests[i]) {
                            var j = seekNext(i);
                            var t = buffer[i];
                            buffer[i] = c;
                            if (j < len && tests[j].test(t))
                                c = t;
                            else
                                break;
                        }
                    }
                };

                function keydownEvent(e) {
                    var k = e.which;

                    //backspace, delete, and escape get special treatment
                    if (k == 8 || k == 46 || (iPhone && k == 127)) {
                        var pos = input.caret(),
                            begin = pos.begin,
                            end = pos.end;

                        if (end - begin == 0) {
                            begin = k != 46 ? seekPrev(begin) : (end = seekNext(begin - 1));
                            end = k == 46 ? seekNext(end) : end;
                        }
                        clearBuffer(begin, end);
                        shiftL(begin, end - 1);

                        return false;
                    } else if (k == 27) {//escape
                        input.val(focusText);
                        input.caret(0, checkVal());
                        return false;
                    }
                };

                function keypressEvent(e) {
                    var k = e.which,
                        pos = input.caret();
                    // Modif SIQ ligne suivante (gestion AltGr)
                    // Ancienne version: if (e.ctrlKey || e.altKey || e.metaKey || k < 32) {//Ignore
                    if (!(e.ctrlKey && e.altKey) && (e.ctrlKey || e.altKey || e.metaKey || k < 32)) {//Ignore
                        return true;
                    } else if (k) {
                        if (pos.end - pos.begin != 0) {
                            clearBuffer(pos.begin, pos.end);
                            shiftL(pos.begin, pos.end - 1);
                        }
                        var p = seekNext(pos.begin - 1);
                        if (p < len) {
                            var c = String.fromCharCode(k);
                            if (tests[p].test(c)) {
                                shiftR(p);
                                buffer[p] = c;
                                writeBuffer();
                                var next = seekNext(p);
                                input.caret(next);
                                if (settings.completed && next >= len)
                                    settings.completed.call(input);
                            }
                        }
                        return false;
                    }
                };

                function clearBuffer(start, end) {
                    for (var i = start; i < end && i < len; i++) {
                        if (tests[i])
                            buffer[i] = settings.placeholder;
                    }
                };

                function writeBuffer() { return input.val(buffer.join('')).val(); };

                function checkVal(allow) {
                    //try to place characters where they belong
                    var test = input.val();
                    var lastMatch = -1;
                    for (var i = 0, pos = 0; i < len; i++) {
                        if (tests[i]) {
                            buffer[i] = settings.placeholder;
                            while (pos++ < test.length) {
                                var c = test.charAt(pos - 1);
                                if (tests[i].test(c)) {
                                    buffer[i] = c;
                                    lastMatch = i;
                                    break;
                                }
                            }
                            if (pos > test.length)
                                break;
                        } else if (buffer[i] == test.charAt(pos) && i != partialPosition) {
                            pos++;
                            lastMatch = i;
                        }
                    }
                    if (!allow && lastMatch + 1 < partialPosition) {
                        input.val("");
                        clearBuffer(0, len);
                    } else if (allow || lastMatch + 1 >= partialPosition) {
                        writeBuffer();
                        if (!allow) input.val(input.val().substring(0, lastMatch + 1));
                    }
                    return (partialPosition ? i : firstNonMaskPos);
                };

                input.data($.mask.dataName, function () {
                    return $.map(buffer, function (c, i) {
                        return tests[i] && c != settings.placeholder ? c : null;
                    }).join('');
                })

                if (!input.attr("readonly"))
                    input
                    .one("unmask", function () {
                        input
                            .unbind(".mask")
                            .removeData($.mask.dataName);
                    })
                    .bind("focus.mask", function () {
                        focusText = input.val();
                        var pos = checkVal();
                        writeBuffer();
                        var moveCaret = function () {
                            if (pos == mask.length)
                                input.caret(0, pos);
                            else
                                input.caret(pos);
                        };
                        ($.browser.msie ? moveCaret : function () { setTimeout(moveCaret, 0) })();
                    })
                    .bind("blur.mask", function () {
                        checkVal();
                        if (input.val() != focusText)
                            input.change();
                    })
                    .bind("keydown.mask", keydownEvent)
                    .bind("keypress.mask", keypressEvent)
                    .bind(pasteEventName, function () {
                        setTimeout(function () { input.caret(checkVal(true)); }, 0);
                    });

                checkVal(); //Perform initial check for existing values
            });
        }
    });
})(jQuery);


/**
* datepicker-fr.js (jQuery UI)
/*/
jQuery(function ($) {
    $.datepicker.regional['fr'] = {
        closeText: 'Fermer',
        prevText: '&#x3c;Préc',
        nextText: 'Suiv&#x3e;',
        currentText: 'Courant',
        monthNames: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin',
        'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
        monthNamesShort: ['Jan', 'Fév', 'Mar', 'Avr', 'Mai', 'Jun',
        'Jul', 'Aoû', 'Sep', 'Oct', 'Nov', 'Déc'],
        dayNames: ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi'],
        dayNamesShort: ['Dim', 'Lun', 'Mar', 'Mer', 'Jeu', 'Ven', 'Sam'],
        dayNamesMin: ['Di', 'Lu', 'Ma', 'Me', 'Je', 'Ve', 'Sa'],
        weekHeader: 'Sm',
        dateFormat: 'dd-mm-yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        showAnim: '',
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['fr']);
});

// Encore un hack pour Datepicker, cette fois pour corriger un problème de
// zIndex.
if ($.datepicker._showDatepickerOrig == undefined) {
    $.datepicker._showDatepickerOrig = $.datepicker._showDatepicker;
    $.datepicker._showDatepicker = function (input) {
        $.datepicker._showDatepickerOrig(input);
        $('#ui-datepicker-div').maxZIndex({ group: '.groupeBoite,.fenetreDialogue' });
    };
}

/*
* Mise en forme de la valeur initiale pour le plugin "autoNumeric".
* On passe les options en paramètre car il semble y avoir un bug avec la fonction.
*/
$.fn.autoNumericFormat = function (opts) {
    var valeurCourante = this.val();
    if (valeurCourante.length > 0) {
        var objId = this.attr('id');
        var nouvelleValeur = valeurCourante;
        if (!valeurCourante.match(/\./)) {
            // Les string formatées doivent également être gérées
            nouvelleValeur = $.fn.autoNumeric.Strip(objId, opts);
        }
        nouvelleValeur = $.fn.autoNumeric.Format(objId, nouvelleValeur, opts);
        this.val(nouvelleValeur);
    }
    return this;
};

/**
* Code propre à la SIQ pour initialiser les fonctionnalités des
* plugins jQuery aux contrôles d'édition
/*/
if ($.ATMTECH == undefined) $.ATMTECH = {};
$.extend($.ATMTECH, {
    // Permet de ne pas initialiser une deuxième fois en cas de mise à jour asynchrone,
    // si le contrôle ne fait pas partie d'un UpdatePanel mis à jour.
    initialiserControles: function (selecteur, func) {
        $(selecteur).each(function (index, obj) {
            this.estInitialise = this.estInitialise || {};
            if (this.estInitialise[selecteur] == undefined || !this.estInitialise[selecteur]) {
                func($(obj), obj);
                this.estInitialise[selecteur] = true;
            }
        });
    },

    padZeros: function () {
        var jqObj = $(this);
        var val = jqObj.val();
        if (val.length == 0) return;
        var maxlen = jqObj.attr('maxlength') || -1;
        var entier = jqObj.attr('NombreEntiers') || -1;
        if (entier > 0 && entier < 100) {
            var arr = val.split(',');
            while (arr[0].length < entier) {
                arr[0] = '0' + arr[0];
            }
            val = arr.join(',');
            jqObj.val(val);
        } else if (maxlen > 0 && maxlen < 100) {
            while (val.length < maxlen) {
                val = '0' + val;
            }
            if (jqObj.hasClass("viderZero") && val.match(/^0+$/)) {
                this.value = '';
            } else {
                this.value = val;
            }
        }
    },

    initControlesEdition: function () {
        $.ATMTECH.initialiserControles('input.monnaieTextBoxAvance,input.decimalTextBoxAvance', function (jqObj) {
            var num = jqObj.attr('NombreEntiers');
            var dec = jqObj.attr('NombreDecimaux');
            var numValide = (typeof num != "undefined" && num >= 0 && num <= 80);
            var decValide = (typeof dec != "undefined" && dec >= 0 && dec <= 19);

            // Maximum de 80 entiers et 19 décimales
            if (!decValide) {
                dec = 0;
            }
            if (!numValide || (num == 0 && dec == 0)) {
                // Par défaut, 9 entiers
                num = 9;
            }

            var aNeg = jqObj.hasClass('positifSeul') ? '' : '-';
            var opts = { aNeg: aNeg, aSep: ' ', aDec: ',', mDec: dec, mNum: num };
            // Mise en forme de la valeur initiale
            jqObj.autoNumeric(opts).autoNumericFormat(opts);
        });

        $.ATMTECH.initialiserControles('textarea.multiLigneTextBoxAvance', function (jqObj) {
            var max = jqObj.prop('MaxLength');
            var maxValide = (typeof max != "undefined" && max >= 0);
            if (maxValide) {
                var opts = { maxCharacters: max };
                jqObj.maxlength(opts);
            }
        });

        $.ATMTECH.initialiserControles('input.alphaNumTextBoxAvance', function (jqObj) {
            jqObj.alphanumeric();
        });

        $.ATMTECH.initialiserControles('input.alphaTextBoxAvance', function (jqObj) {
            jqObj.alpha();
        });

        $.ATMTECH.initialiserControles('input.numTextBoxAvance', function (jqObj) {
            var len = jqObj.attr('maxlength');
            if (typeof len == "undefined" || len < 0 || len > 90000) {
                len = 9;
            } else if (len > 100) {
                len = 100;
                jqObj.attr("maxlength", "100");
            }
            var opts = { aNeg: '', aSep: '', aDec: ',', mDec: 0, mNum: len };
            jqObj.autoNumeric(opts).autoNumericFormat(opts);
        });

        $.ATMTECH.initialiserControles('input.codePostalTextBox', function (jqObj) {
            jqObj.mask('a9a 9a9').focusout(function (e) {
                jqObj.val(jqObj.val().toUpperCase());
            });
        });

        $.ATMTECH.initialiserControles('input.telephoneTextBox', function (jqObj) {
            jqObj.mask('(999) 999-9999');
        });
        $.ATMTECH.initialiserControles("input.dateTextBoxAvance", function (jqObj) {
            jqObj.mask("9999-99-99").datepicker({
                dateFormat: 'yy-mm-dd',
                constrainInput: false,
                showOn: 'button',
                buttonImage: $.ATMTECH.imgCalUrl,
                buttonImageOnly: true,
                buttonText: 'Calendrier'
            });

            // http://dev.jqueryui.com/ticket/6042 + problèmes avec datepicker et mask utilisés ensemble
            // Cette patch ne semble plus nécessaire, mais gardons-la quelque temps au cas où, car il me semble
            // que le problème était plus aigu dans un popin ou popup.
            /*jqObj.unbind('keyup', $.datepicker._doKeyUp).keypress(function() {
            if ($.datepicker._datepickerShowing && $(this).val().match( /\d{4}-\d{2}-\d{2}/ )) {
            $.datepicker._doKeyUp({ target: this });
            }
            });*/
        });

        // Dates en lecture seule
        $("input.dateSansCalendrierTextBoxAvance").unmask().mask("9999-99-99");

        /**
        * SIQ - pour prefixer des 0 jusqu'au maxLength d'un champ
        *       sur le LostFocus (et lors du chargement initial)
        */
        $.ATMTECH.initialiserControles("input.numZeroPrefixTextBoxAvance", function (jqObj) {
            jqObj.bind('focusout', $.ATMTECH.padZeros).each($.ATMTECH.padZeros);
        });

        // On désactive le form reset. On ne l'utilise nulle part et cela prévient
        // le comportement par défaut de MSIE (deux fois Escape sur un champ = form reset).
        // Voir: Job 3254.
        $('form').unbind('reset').bind('reset', function () { return false; });
    }
});

$(function () {

    $.datepicker.setDefaults($.datepicker.regional['fr']);
    $.ATMTECH.initControlesEdition();

    // Pour rebinder les plugins jQuery dans les UpdatePanel.
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        $.ATMTECH.initControlesEdition();
    });
});

if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();