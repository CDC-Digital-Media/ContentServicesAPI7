﻿(function(){"use strict";var e=["json","xml"];$(document).delegate("#language a","click",function(e){var t=$(this);e.preventDefault(),$.isReady||$(document).ready(function(){t.click()})}).ready(function(){function o(n){var r=location.hash;s.waypoint("disable");for(var i=e.length;i--;)t.removeClass(e[i]);t.addClass(n),location.hash&&$(location.hash)[0].scrollIntoView(!0),s.waypoint("enable"),$.waypoints("refresh")}var t=$("body"),n=$("#api-docs"),r=$("#guide"),i=$("#language"),s=$("#methods a.section-anchor");n.waypoint(function(){$("body").find("#guide").toggleClass("stick"),$("body").find("#language").toggleClass("stick")}),s.waypoint({continuous:!1,handler:function(e){var t=$(this).attr("name");window.history&&window.history.replaceState&&history.replaceState({},"","#"+t),$("#guide").find("a[href=#"+t+"], a[data-target~="+t+"]").click()}}),r.on("click",".section",function(){r.find(".section.active").removeClass("active"),$(this).addClass("active")}),r.on("click","a.parent, a.child",function(){r.find("a.viewing").removeClass("viewing"),$(this).addClass("viewing");var e=r[0];setTimeout(function(){e.style.display="none",e.offsetHeight,e.style.display="block"},1)}),r.on("click","a.parent, a.child",function(){s.waypoint("disable"),setTimeout(function(){s.waypoint("enable")},200)}),i.find("a").on("click",function(e){e.preventDefault();var t=$(e.currentTarget).attr("href");window.history&&window.history.replaceState&&history.replaceState({},document.title,t+window.location.hash),i.find("a.selected").removeClass("selected"),$(this).addClass("selected");var n=t.split("/"),r=n[n.length-1];o(r),$.cookie("lang",r,{expires:1825,path:"/",domain:"......[domain].....",secure:!0})}),$("a.show-parameters").on("click",function(e){$(e.currentTarget).parent().parent().removeClass("collapsed")})})})();