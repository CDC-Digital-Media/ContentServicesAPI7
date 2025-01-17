﻿function getElementWidth(id) {
    var size = 0;
    if (document.body && document.body.clientWidth) {
        size = document.body.clientWidth;
    } else {
        if (window.innerWidth && window.innerWidth > 0) {
            size = window.innerWidth;
        }
    }
    var content = document.getElementById(id);
    if (content && content.clientWidth && content.clientWIdth > 0) {
        size = content.clientWidth;
    }
    return size;
}

var c_start, spn, pn, __flash_unloadHandler, __flash_savedUnloadHandler;
if (typeof deconcept == "undefined") {
    var deconcept = new Object();
}
if (typeof deconcept.util == "undefined") {
    deconcept.util = new Object();
}
if (typeof deconcept.SWFObjectUtil == "undefined") {
    deconcept.SWFObjectUtil = new Object();
}
deconcept.SWFObject = function (swf, id, w, h, ver, c, useExpressInstall, quality, xiRedirectUrl, redirectUrl, detectKey, cssClass) {
    if (!document.getElementById) {
        return;
    }
    this.DETECT_KEY = detectKey ? detectKey : "detectflash";
    this.skipDetect = deconcept.util.getRequestParameter(this.DETECT_KEY);
    this.params = new Object();
    this.variables = new Object();
    this.attributes = new Array();
    if (swf) {
        this.setAttribute("swf", swf);
    }
    if (id) {
        this.setAttribute("id", id);
    }
    if (w) {
        this.setAttribute("width", w);
    }
    if (h) {
        this.setAttribute("height", h);
    }
    if (ver) {
        this.setAttribute("version", new deconcept.PlayerVersion(ver.toString().split(".")));
    }
    this.installedVer = deconcept.SWFObjectUtil.getPlayerVersion();
    if (c) {
        this.addParam("bgcolor", c);
    }
    var q = quality ? quality : "high";
    this.addParam("quality", q);
    this.setAttribute("useExpressInstall", useExpressInstall);
    this.setAttribute("doExpressInstall", false);
    var xir = (xiRedirectUrl) ? xiRedirectUrl : window.location;
    this.setAttribute("xiRedirectUrl", xir);
    this.setAttribute("redirectUrl", "");
    if (redirectUrl) {
        this.setAttribute("redirectUrl", redirectUrl);
    }
    if (cssClass) {
        this.setAttribute("cssClass", cssClass);
    }
};
deconcept.SWFObject.prototype = {
    setAttribute: function (name, value) {
        this.attributes[name] = value;
    },
    getAttribute: function (name) {
        return this.attributes[name];
    },
    addParam: function (name, value) {
        this.params[name] = value;
    },
    getParams: function () {
        return this.params;
    },
    addVariable: function (name, value) {
        this.variables[name] = value;
    },
    getVariable: function (name) {
        return this.variables[name];
    },
    getVariables: function () {
        return this.variables;
    },
    getVariablePairs: function () {
        var variablePairs = new Array();
        var key;
        var variables = this.getVariables();
        for (key in variables) {
            variablePairs.push(key + "=" + variables[key]);
        }
        return variablePairs;
    },
    getSWFHTML: function () {
        var swfNode = "";
        if (navigator.plugins && navigator.mimeTypes && navigator.mimeTypes.length) {
            if (this.getAttribute("doExpressInstall")) {
                this.addVariable("MMplayerType", "PlugIn");
            }
            swfNode = '<embed type="application/x-shockwave-flash" src="' + this.getAttribute("swf") + '" width="' + this.getAttribute("width") + '" height="' + this.getAttribute("height") + '"';
            swfNode += ' id="' + this.getAttribute("id") + '" name="' + this.getAttribute("id") + '" ';
            if (typeof this.getAttribute("cssClass") != "undefined") {
                swfNode += ' class="' + this.getAttribute("cssClass") + '" ';
            }
            var params = this.getParams();
            for (var key in params) {
                swfNode += [key] + '="' + params[key] + '" ';
            }
            var pairs = this.getVariablePairs().join("&");
            if (pairs.length > 0) {
                swfNode += 'flashvars="' + pairs + '" ';
            }
            swfNode += "/>";
        } else {
            if (this.getAttribute("doExpressInstall")) {
                this.addVariable("MMplayerType", "ActiveX");
            }
            swfNode = '<object id="' + this.getAttribute("id") + '" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="' + this.getAttribute("width") + '" height="' + this.getAttribute("height");
            if (typeof this.getAttribute("cssClass") != "undefined") {
                swfNode += '" class="' + this.getAttribute("cssClass");
            }
            swfNode += '">';
            swfNode += '<param name="movie" value="' + this.getAttribute("swf") + '" />';
            var params = this.getParams();
            for (var key in params) {
                swfNode += '<param name="' + key + '" value="' + params[key] + '" />';
            }
            var pairs = this.getVariablePairs().join("&");
            if (pairs.length > 0) {
                swfNode += '<param name="flashvars" value="' + pairs + '" />';
            }
            swfNode += "</object>";
        }
        return swfNode;
    },
    write: function (elementId) {
        if (this.getAttribute("useExpressInstall")) {
            var expressInstallReqVer = new deconcept.PlayerVersion([6, 0, 65]);
            if (this.installedVer.versionIsValid(expressInstallReqVer) && !this.installedVer.versionIsValid(this.getAttribute("version"))) {
                this.setAttribute("doExpressInstall", true);
                this.addVariable("MMredirectURL", escape(this.getAttribute("xiRedirectUrl")));
                document.title = document.title.slice(0, 47) + " - Flash Player Installation";
                this.addVariable("MMdoctitle", document.title);
            }
        }
        if (this.skipDetect || this.getAttribute("doExpressInstall") || this.installedVer.versionIsValid(this.getAttribute("version"))) {
            var n = (typeof elementId == "string") ? document.getElementById(elementId) : elementId;
            n.innerHTML = this.getSWFHTML();
            return true;
        } else {
            if (this.getAttribute("redirectUrl") !== "") {
                document.location.replace(this.getAttribute("redirectUrl"));
            }
        }
        return false;
    }
};
deconcept.SWFObjectUtil.getPlayerVersion = function () {
    var PlayerVersion = new deconcept.PlayerVersion([0, 0, 0]);
    if (navigator.plugins && navigator.mimeTypes.length) {
        var x = navigator.plugins["Shockwave Flash"];
        if (x && x.description) {
            PlayerVersion = new deconcept.PlayerVersion(x.description.replace(/([a-zA-Z]|\s)+/, "").replace(/(\s+r|\s+b[0-9]+)/, ".").split("."));
        }
    } else {
        try {
            var axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7");
        } catch (e) {
            try {
                var axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6");
                PlayerVersion = new deconcept.PlayerVersion([6, 0, 21]);
                axo.AllowScriptAccess = "always";
            } catch (e) {
                if (PlayerVersion.major == 6) {
                    return PlayerVersion;
                }
            }
            try {
                axo = new ActiveXObject("ShockwaveFlash.ShockwaveFlash");
            } catch (e) { }
        }
        if (axo != null) {
            PlayerVersion = new deconcept.PlayerVersion(axo.GetVariable("$version").split(" ")[1].split(","));
        }
    }
    return PlayerVersion;
};
deconcept.PlayerVersion = function (arrVersion) {
    this.major = arrVersion[0] != null ? parseInt(arrVersion[0]) : 0;
    this.minor = arrVersion[1] != null ? parseInt(arrVersion[1]) : 0;
    this.rev = arrVersion[2] != null ? parseInt(arrVersion[2]) : 0;
};
deconcept.PlayerVersion.prototype.versionIsValid = function (fv) {
    if (this.major < fv.major) {
        return false;
    }
    if (this.major > fv.major) {
        return true;
    }
    if (this.minor < fv.minor) {
        return false;
    }
    if (this.minor > fv.minor) {
        return true;
    }
    if (this.rev < fv.rev) {
        return false;
    }
    return true;
};
deconcept.util = {
    getRequestParameter: function (param) {
        var q = document.location.search || document.location.hash;
        if (q) {
            var pairs = q.substring(1).split("&");
            for (var i = 0; i < pairs.length; i++) {
                if (pairs[i].substring(0, pairs[i].indexOf("=")) == param) {
                    return pairs[i].substring((pairs[i].indexOf("=") + 1));
                }
            }
        }
        return "";
    }
};
deconcept.SWFObjectUtil.cleanupSWFs = function () {
    if (window.opera || !document.all) {
        return;
    }
    var objects = document.getElementsByTagName("OBJECT");
    for (var i = 0; i < objects.length; i++) {
        objects[i].style.display = "none";
        for (var x in objects[i]) {
            if (typeof objects[i][x] == "function") {
                objects[i][x] = function () { };
            }
        }
    }
};
deconcept.SWFObjectUtil.prepUnload = function () {
    __flash_unloadHandler = function () { };
    __flash_savedUnloadHandler = function () { };
    if (typeof window.onunload == "function") {
        var oldUnload = window.onunload;
        window.onunload = function () {
            deconcept.SWFObjectUtil.cleanupSWFs();
            oldUnload();
        };
    } else {
        window.onunload = deconcept.SWFObjectUtil.cleanupSWFs;
    }
};
if (typeof window.onbeforeunload == "function") {
    var oldBeforeUnload = window.onbeforeunload;
    window.onbeforeunload = function () {
        deconcept.SWFObjectUtil.prepUnload();
        oldBeforeUnload();
    };
} else {
    window.onbeforeunload = deconcept.SWFObjectUtil.prepUnload;
} if (Array.prototype.push == null) {
    Array.prototype.push = function (item) {
        this[this.length] = item;
        return this.length;
    };
}
var getQueryParamValue = deconcept.util.getRequestParameter;
var FlashObject = deconcept.SWFObject;
var SWFObject = deconcept.SWFObject;
if (typeof CDC == "undefined") {
    var CDC = new Object();
}
if (typeof CDC.Video == "undefined") {
    CDC.Video = new Object();
}
CDC.Video = function (xmlData, altContentId, metricButton, isFeature, movieWidth, movieHeight, movieUrl, movieWidthSmall, movieHeightSmall, movieUrlSmall, resize, resizeWidthThreshold, wmode, cssClass) {
    this.attributes = new Array();
    if (typeof xmlData == "undefined") {
        this.setAttribute("xmlData", "/TemplatePackage/images/hlfeatures.xml");
    } else {
        this.setAttribute("xmlData", xmlData);
    } if (typeof altContentId == "undefined") {
        this.setAttribute("altContentId", "flashALTcontent");
    } else {
        this.setAttribute("altContentId", altContentId);
    } if (typeof metricButton == "undefined") {
        this.setAttribute("metricButton", "MyMetricButton");
    } else {
        this.setAttribute("metricButton", metricButton);
    } if (typeof isFeature == "undefined") {
        this.setAttribute("isFeature", true);
    } else {
        this.setAttribute("isFeature", isFeature);
    } if (typeof movieWidth == "undefined") {
        this.setAttribute("movieWidth", 520);
    } else {
        this.setAttribute("movieWidth", movieWidth);
    } if (typeof movieHeight == "undefined") {
        this.setAttribute("movieHeight", 150);
    } else {
        this.setAttribute("movieHeight", movieHeight);
    } if (typeof movieUrl == "undefined") {
        this.setAttribute("movieUrl", "/TemplatePackage/images/2ndTBanner.swf");
    } else {
        this.setAttribute("movieUrl", movieUrl);
    } if (typeof movieWidthSmall == "undefined") {
        if (typeof movieWidth == "undefined") {
            this.setAttribute("movieWidthSmall", 360);
        } else {
            this.setAttribute("movieWidthSmall", movieWidth);
        }
    } else {
        this.setAttribute("movieWidthSmall", movieWidthSmall);
    } if (typeof movieHeightSmall == "undefined") {
        if (typeof movieHeight == "undefined") {
            this.setAttribute("movieHeightSmall", 176);
        } else {
            this.setAttribute("movieHeightSmall", movieHeight);
        }
    } else {
        this.setAttribute("movieHeightSmall", movieHeightSmall);
    } if (typeof movieUrlSmall == "undefined") {
        if (typeof movieUrl == "undefined") {
            this.setAttribute("movieUrlSmall", "/TemplatePackage/images/Features800600.swf");
        } else {
            this.setAttribute("movieUrlSmall", movieUrl);
        }
    } else {
        this.setAttribute("movieUrlSmall", movieUrlSmall);
    } if (typeof resize != "undefined" && resize) {
        CDC_VIDEO_RESIZE_ARRAY.push(this);
    }
    if (typeof resizeWidthThreshold == "undefined") {
        this.setAttribute("resizeWidthThreshold", 546);
    } else {
        this.setAttribute("resizeWidthThreshold", resizeWidthThreshold);
    } if (typeof wmode == "undefined") {
        this.setAttribute("wmode", "window");
    } else {
        this.setAttribute("wmode", wmode);
    } if (typeof cssClass != "undefined") {
        this.setAttribute("cssClass", cssClass);
    }
};
CDC.Video.prototype = {
    setAttribute: function (name, value) {
        this.attributes[name] = value;
    },
    getAttribute: function (name) {
        return this.attributes[name];
    },
    render: function () {
        var stamp = "2009-04-30";
        var xmlData = this.getAttribute("xmlData");
        var metricButton = this.getAttribute("metricButton");
        var isFeature = this.getAttribute("isFeature");
        var movieUrl = this.getAttribute("movieUrl");
        var movieWidth = this.getAttribute("movieWidth");
        var movieHeight = this.getAttribute("movieHeight");
        var movieUrlSmall = this.getAttribute("movieUrlSmall");
        var movieWidthSmall = this.getAttribute("movieWidthSmall");
        var movieHeightSmall = this.getAttribute("movieHeightSmall");
        var altContentId = this.getAttribute("altContentId");
        var altContentElement = document.getElementById(altContentId);
        var resizeWidthThreshold = this.getAttribute("resizeWidthThreshold");
        var wmode = this.getAttribute("wmode");
        var cssClass = this.getAttribute("cssClass");
        var url;
        var x;
        var y;
        if (getElementWidth("branding") < resizeWidthThreshold) {
            this.setAttribute("currentMovieWidth", movieWidthSmall);
            url = movieUrlSmall;
            x = movieWidthSmall;
            y = movieHeightSmall;
        } else {
            this.setAttribute("currentMovieWidth", movieWidth);
            url = movieUrl;
            x = movieWidth;
            y = movieHeight;
        } if (isFeature) {
            metricButton = "FeatureMovie2ndTier%20" + metricButton;
        }
        if (xmlData !== "") {
            url += "?x=" + xmlData + "&n=" + stamp;
        } else {
            url += "?n=" + stamp;
        }
        var newId = "Banner";
        var vids = document.getElementById(newId);
        var uniqueIndex = 0;
        while (vids && uniqueIndex < 50) {
            newId = "Banner" + uniqueIndex;
            vids = document.getElementById(newId);
            uniqueIndex++;
        }
        var so = new SWFObject(url, newId, x, y, "7");
        if (so.installedVer.major > 0) {
            if (cssClass) {
                so.setAttribute("cssClass", cssClass);
            }
            so.addParam("scale", "exactfit");
            so.addParam("allowScriptAccess", "sameDomain");
            so.addParam("quality", "best");
            so.addParam("align", "top");
            so.addParam("type", "application/x-shockwave-flash");
            so.addParam("wmode", wmode);
            so.write(altContentId);
        } else {
            var altDiv = GetElementById(altContentId);
            if (altDiv) {
                var childElements = altDiv.childNodes;
                if (childElements && childElements.length > 0) {
                    for (var i = 0; i < childElements.length; i++) {
                        var childElement = childElements[i];
                        if (childElement.nodeName.toLowerCase() == "ul") {
                            childElement.style.visibility = "visible";
                        } else {
                            if (childElement.nodeName.toLowerCase() == "ul") {
                                childElement.style.visibility = "visible";
                            }
                        }
                    }
                }
            }
        }
    },
    resize: function () {
        var altContentId = this.getAttribute("altContentId");
        var altContentElement = document.getElementById(altContentId);
        var currentMovieWidth = this.getAttribute("currentMovieWidth");
        var movieWidth = this.getAttribute("movieWidth");
        var movieWidthSmall = this.getAttribute("movieWidthSmall");
        var resizeWidthThreshold = this.getAttribute("resizeWidthThreshold");
        if (getElementWidth("branding") < resizeWidthThreshold) {
            if (currentMovieWidth != movieWidthSmall) {
                if (altContentElement) {
                    altContentElement.style.width = movieWidthSmall + "px";
                }
                this.render();
            }
        } else {
            if (currentMovieWidth != movieWidth) {
                if (altContentElement) {
                    altContentElement.style.width = movieWidth + "px";
                }
                this.render();
            }
        }
    }
};
if (typeof CDC.Video.Feature == "undefined") {
    CDC.Video.Feature = new function () {
        return {
            render: function (xmlPath, altId, cssClass) {
                if (!altId) {
                    altId = "flashALTcontent";
                }
                var featureVideo = new CDC.Video(xmlPath, altId, "", true, 520, 150, "/TemplatePackage/images/2ndTBanner.swf", 360, 176, "/TemplatePackage/images/Features800600.swf", true, 1000, "window", cssClass);
                featureVideo.render();
            }
        };
    };
}