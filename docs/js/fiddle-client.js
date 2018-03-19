function SqlFiddle() {

	////////////
	// constructors
	////////////
	initializeMessage();
	createConsole();
	
	////////////
	// variable
	////////////
	var defaultOptions = null;

	////////////
	// console - public API
	////////////
	this.closeConsole = function () {
		hideConsole();
	}
	this.openConsole = function (options) {
		showConsole(options);
	}
	this.toggleConsole = function (options) {
		if(getConsole().style.display == "") {
			showConsole(options);
		} else {
			hideConsole();
		}
	}

	////////////
	// console - private API
	////////////
	function createConsole() {
		createConsoleCss();
		
		document.addEventListener('DOMContentLoaded', function () {
			// create div
			var div = document.createElement("DIV");
			div.id = "sqlfiddle-console";
			div.style.display = "none";
			
			// create iframe
			var iframe = document.createElement("IFRAME");
			iframe.id = "sqlfiddle-console-iframe";
			//iframe.setAttribute("src", "http://localhost:8001/Fiddle/FiddleConsole");
			iframe.setAttribute("src", "http://nugetmusthaves.com/Fiddle/FiddleConsole");
			
			// append element
			div.appendChild(iframe);
			document.body.appendChild(div);	
		});		
	}
	function createConsoleCss() {
		document.write("\
			<style>\
			#sqlfiddle-console {\
				background: #333;\
				background: -webkit-radial-gradient(circle, #333, #111);\
				background: -o-radial-gradient(circle, #333, #111);\
				background: -moz-radial-gradient(circle, #333, #111);\
				background: radial-gradient(circle, #333, #111);\
				height: 400px;\
				width: 100%;\
				position: fixed;\
				bottom: 0;\
				left: 0;\
				z-index: 199999;\
			}\
			#sqlfiddle-console #sqlfiddle-console-iframe {\
				height: 100%;\
				width: 100%;\
				border:0;\
			}\
			</style>\
		");
	}
	function getConsole() {
		return document.getElementById("sqlfiddle-console");
	}
	function getConsoleWindow() {
		return document.getElementById("sqlfiddle-console-iframe").contentWindow;
	}		
	function showConsole(options) {
		// show console
		getConsole().style.display = "";
		
		// send message
		data = { 
			action: 'console-initialize', 
			defaultOptions: defaultOptions,
			options: options
		};
		sendMessageConsole(data);
	}
	function hideConsole() {
		getConsole().style.display = "none";
	}
	
	////////////
	// options - public API
	////////////
	this.setDefaultOptions = function (options) {
		defaultOptions = options;
	}

	////////////
	// message - private API
	////////////
	function initializeMessage() {
		if (window.addEventListener) {
			window.addEventListener("message", receiveMessage, false);
		}
		else {
			window.attachEvent("onmessage", receiveMessage);
		}
	}
	function sendMessageConsole(msg) {
		getConsoleWindow().postMessage(msg,'*');
	}
	function sendMessageFiddle(id, msg) {
		var console = document.getElementsByTagName("fiddle-" + id).contentWindow;
		console.postMessage(msg,'*');
	}
	function receiveMessage(event) {
		// console
		if(event.data.action == "console.hide") {
			hideConsole();
		}
	}
}

var sqlFiddle = new SqlFiddle();