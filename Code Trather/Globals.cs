
public static class Globals
{
    // Counters
    public static int snapshotCounter = 1;
    public static int clipboardCounter = 1;
    public static int outputCounter = 1;
    // Addresses
    public static string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs/";
    public static string snapshotsAddress = filePath + "snapshots.txt";
    public static string clipboardhtmlAddress = filePath + "clipboard.html";
    public static string downloadAddress = filePath + "assignment.py";
    public static string snapshothtmlAddress = filePath + "snapshots.html";
    public static string outputAddress = filePath + "output.html";
    public static string inputFilePath = "";
    public static string logcssAddress = filePath + "logs.css";
    public static string collapseAddress = filePath + "collapse.js";

    //Files to be added
    public static string logFile = "/* Style the button that is used to open and close the collapsible content */\r\n.collapsible {\r\n  background-color: #eee;\r\n  color: #444;\r\n  cursor: pointer;\r\n  padding: 18px;\r\n  width: 100%;\r\n  border: none;\r\n  text-align: left;\r\n  outline: none;\r\n  font-size: 15px;\r\n}\r\n\r\n/* Add a background color to the button if it is clicked on (add the .active class with JS), and when you move the mouse over it (hover) */\r\n.active, .collapsible:hover {\r\n  background-color: #ccc;\r\n}\r\n\r\n/* Style the collapsible content. Note: hidden by default */\r\n.content {\r\n  padding: 0 18px;\r\n  display: none;\r\n  overflow: hidden;\r\n  background-color: #f1f1f1;\r\n}\r\n.collapsible:after {\r\n  content: '\\02795'; /* Unicode character for \"plus\" sign (+) */\r\n  font-size: 13px;\r\n  color: white;\r\n  float: right;\r\n  margin-left: 5px;\r\n}\r\n\r\n.active:after {\r\n  content: \"\\2796\"; /* Unicode character for \"minus\" sign (-) */\r\n}";
    public static string collapseFile = "var coll = document.getElementsByClassName(\"collapsible\");\r\nvar i;\r\n\r\nfor (i = 0; i < coll.length; i++) {\r\n  coll[i].addEventListener(\"click\", function() {\r\n    this.classList.toggle(\"active\");\r\n    var content = this.nextElementSibling;\r\n    if (content.style.display === \"block\") {\r\n      content.style.display = \"none\";\r\n    } else {\r\n      content.style.display = \"block\";\r\n    }\r\n  });\r\n}\r\nfor (let i = 0; i<btns.length;i++){\r\n    let bt = btns[i];\r\n    bt.click();\r\n  } \r\n";

    // Time
    public static DateTime start = DateTime.Now;

    // HTML
    public static string snapshothtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tSnapshot Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Snapshot Log</h1>";
    public static string clipboardhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tClipboard Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Clipboard Log</h1>";
    public static string outputhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tOutput Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Output Log</h1>";
    public static string htmlFoot = "</body>\r\n\t<script src=\"./collapse.js\"></script>\r\n<style>\r\n.content {\r\n  padding: 0 18px;\r\n  background-color: white;\r\n  max-height: 0;\r\n  overflow: hidden;\r\n  transition: max-height 0.2s ease-out;\r\n}\r\n</style>\r\n\r\n<script>\r\nvar coll = document.getElementsByClassName(\"collapsible\");\r\nvar i;\r\n\r\nfor (i = 0; i < coll.length; i++) {\r\n  coll[i].addEventListener(\"click\", function() {\r\n    this.classList.toggle(\"active\");\r\n    var content = this.nextElementSibling;\r\n    if (content.style.maxHeight){\r\n      content.style.maxHeight = null;\r\n    } else {\r\n      content.style.maxHeight = content.scrollHeight + \"px\";\r\n    }\r\n  });\r\n}\r\n</script>\r\n\r\n</html>";
    public static bool DONE = false;

    public static TimeSpan timeElapsed()
    {
        DateTime current = DateTime.Now;

        TimeSpan ts = current - start;


        return ts;
    }
}


