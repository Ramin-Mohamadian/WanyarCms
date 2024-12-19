var EHandler = {};
if (document.addEventListener) {
    EHandler.add = function(element, eType, eFunc) {
        if (eType == "load") {
            if (typeof window.onload == "function") {
                var existingOnload = window.onload;
                window.onload = function() {
                    existingOnload();
                    eFunc();
                } //end existing onload handler
            } else {
                window.onload = eFunc;
            }
        } else {
            element.addEventListener(eType, eFunc, false);
        }
    };

    EHandler.remove = function(element, eType, eFunc) {
        element.removeEventListener(eType, eFunc, false);
    };
}
else if (document.attachEvent) {
    EHandler.add = function(element, eType, eFunc) {
        if (eType == "load") {
            if (typeof window.onload == "function") {
                var existingOnload = window.onload;
                window.onload = function() {
                    existingOnload();
                    eFunc();
                } //end existing onload handler
            } else {
                window.onload = eFunc;
            }
        } else {
            element.attachEvent("on" + eType, eFunc);
        }
    };
    EHandler.remove = function(element, eType, eFunc) {
        element.detachEvent("on" + eType, eFunc);
    };
}
