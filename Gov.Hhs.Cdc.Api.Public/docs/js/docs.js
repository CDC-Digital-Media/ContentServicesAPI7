(function(){var e="",t=null,n={};for(var r=0,i=document.anchors.length;r<i;r++){var s=$(document.anchors[r]),o=s.offset().top,u=document.anchors[r].id;u!=""&&(n[u]=o)}var a=function(){t=null;var r=$(window).scrollTop(),i=Infinity,s;for(var o in n){var u=Math.abs(r-n[o]);u<i&&(s=o,i=u)}s!=e&&(e=s,$("a.flybar-button").each(function(t,n){n.href=n.href.replace(/(#(.+)?)?$/,"#"+e)}))};$(window).scroll(function(){t!==null&&window.clearTimeout(t),t=window.setTimeout(a,300)}),a()})(),$(function(){var e=["You guys should","This page needs","The best feature of this page is","I can't","You should get rid of","I want","I want to be able to"],t=e[Math.floor(Math.random()*e.length)];$("#feedback").attr("placeholder",t+"..."),$("#sugform").submit(function(){var e=$("#feedback").val();return e===""?!1:($.ajax({type:"POST",url:"/suggestion",data:{message:e,prompt:t,at:document.location.href}}),$(this).html('<div id="thanks">Thanks!</div>'),!1)})});