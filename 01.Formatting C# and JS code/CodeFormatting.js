var webBrowser = navigator.appName,
    addScroll  = false, //I did not move the variables definitions because I don't know what order the JS will be executed in and they may change their values
    pX         = 0,
    pY         = 0,
    args,
    theLayer;

if (navigator.userAgent.indexOf('MSIE 5') > 0 || navigator.userAgent.indexOf('MSIE 6') > 0) {
    addScroll = true;
}

document.onmousemove = mouseMove;
if (webBrowser == "Netscape") {
    document.addEventListener('MouseEvent', mouseMove);
    //captureEvents(Event.MOUSEMOVE)
    // I replaced this code here because it is deprecated
}

function mouseMove(evn) {
    if (webBrowser == "Netscape") {
        pX = evn.pageX - 5;
        pY = evn.pageY;
    } else {
        pX = event.x - 5;
        pY = event.y;
    }
    if (webBrowser == "Netscape") {
        if (document.layers['ToolTip'].visibility == 'show') {
            PopTip();
        }
    } else {
        if (document.all['ToolTip'].style.visibility == 'visible') {
            PopTip();
        }
    }
}

function PopTip() {
    if (webBrowser == "Netscape") {
        theLayer = eval('document.layers[\'ToolTip\']');

        if ((pX + 120) > window.innerWidth) {
            pX = window.innerWidth - 150;
        }

        theLayer.left = pX + 10;
        theLayer.top = pY + 15;
        theLayer.visibility = 'show';

    } else {
        theLayer = eval('document.all[\'ToolTip\']');

        if (theLayer) {
            pX = event.x - 5;
            pY = event.y;

            if (addScroll) {
                pX += document.body.scrollLeft;
                pY += document.body.scrollTop;
            }

            if ((pX + 120) > document.body.clientWidth) {
                pX -= 150;
            }

            theLayer.style.pixelLeft = pX + 10;
            theLayer.style.pixelTop = pY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function HideTip() {
    args = HideTip.arguments;
    if (webBrowser == "Netscape") {
        document.layers['ToolTip'].visibility = 'hide';
    } else {
        document.all['ToolTip'].style.visibility = 'hidden';
    }
}

function hideMenu1() {
    if (webBrowser == "Netscape") {
        document.layers['menu1'].visibility = 'hide';
    } else {
        document.all['menu1'].style.visibility = 'hidden';
    }
}

function hideMenu2() {
    if (webBrowser == "Netscape") {
        document.layers['menu2'].visibility = 'hide';
    } else {
        document.all['menu2'].style.visibility = 'hidden';
    }
}

function showMenu1() {
    if (webBrowser == "Netscape") {
        theLayer = eval('document.layers[\'menu1\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'menu1\']');
        theLayer.style.visibility = 'visible';
    }
}

function showMenu2() {
    if (webBrowser == "Netscape") {
        theLayer = eval('document.layers[\'menu2\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'menu2\']');
        theLayer.style.visibility = 'visible';
    }
}

