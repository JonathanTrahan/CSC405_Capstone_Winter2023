
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

public static class Globals
{
    // List of Hot Key word to check inputs for
    public static string[] hotKeys = { "Menu", "Alt", "F11", "F12", "Insert", "Delete", "ControlKey", "Control" };

    // Makes a long list of every key press over a time interval
    public static string keyTracker = "";
    // Counters - These keep track of what the log number is currently next
    public static int snapshotCounter = 1;
    public static int clipboardCounter = 1;
    public static int outputCounter = 1;
    public static int attentionCounter = 1;
    public static int errorCounter = 1;
    public static int pressCounter = 1;
    public static int keyloggerCounter = 1;
    public static int hotkeyCounter = 1;
    // Addresses - FilePaths to a specified file or folder to be used by the program
    // Log Folder addresses
    public static string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs/";
    public static string snapshotsAddress = filePath + "snapshots.txt";
    public static string clipboardhtmlAddress = filePath + "clipboard.html";
    public static string downloadAddress = filePath + "assignment.py";
    public static string snapshothtmlAddress = filePath + "snapshots.html";
    public static string outputAddress = filePath + "output.html";
    public static string inputFilePath = "";
    public static string logcssAddress = filePath + "logs.css";
    public static string collapseAddress = filePath + "collapse.js";
    public static string attentionAddress = filePath + "attention.html";
    public static string errorAddress = filePath + "error.html";
    public static string keyloggerAddress = filePath + "keylogger.html";
    public static string hotkeyAddress = filePath + "hotkeys.html";
    public static string unitTestFilePath = filePath + "unitTest.py";
    // Crypt Folder Addresses
    /// <summary>
    /// Downloads/Cryptog/
    /// </summary>
    public static string cryptFolder = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/Cryptog/";
    /// <summary>
    /// Downloads/TratherLogs.zip
    /// </summary>
    public static string filePathZip = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs.zip";
    /// <summary>
    /// Downloads/Cryptog/aeskey.txt
    /// </summary>
    public static string aesKeyFile = cryptFolder + "aeskey.txt";
    /// <summary>
    /// Downloads/Cryptog/aesIV.txt
    /// </summary>
    public static string aesIVFile = cryptFolder + "aesIV.txt";
    /// <summary>
    /// Downloads/Cryptog/aeskey.rsa
    /// </summary>
    public static string aesKeyFile_encrypted = cryptFolder + "aeskey.rsa";
    /// <summary>
    /// Downloads/Cryptog/aesIV.rsa
    /// </summary>
    public static string aesIVFile_encrypted = cryptFolder + "aesIV.rsa";
    /// <summary>
    /// Downloads/Cryptog/TratherLogs.aes
    /// </summary>
    public static string encryptedZip = cryptFolder + "TratherLogs.aes";
    /// <summary>
    /// Downloads/Cryptog/TratherLogs_decrypted.zip
    /// </summary>
    public static string decryptedZip = cryptFolder + "TratherLogs_decrypted.zip";

    //Files to be added - The are premade files to be added the log folder to assist the html log files
    public static string logFile = "/* Style the button that is used to open and close the collapsible content */\r\n.collapsible {\r\n  background-color: #eee;\r\n  color: #444;\r\n  cursor: pointer;\r\n  padding: 18px;\r\n  width: 100%;\r\n  border: none;\r\n  text-align: left;\r\n  outline: none;\r\n  font-size: 15px;\r\n}\r\n\r\n/* Add a background color to the button if it is clicked on (add the .active class with JS), and when you move the mouse over it (hover) */\r\n.active, .collapsible:hover {\r\n  background-color: #ccc;\r\n}\r\n\r\n/* Style the collapsible content. Note: hidden by default */\r\n.content {\r\n  padding: 0 18px;\r\n  display: none;\r\n  overflow: hidden;\r\n  background-color: #f1f1f1;\r\n}\r\n.collapsible:after {\r\n  content: '\\02795'; /* Unicode character for \"plus\" sign (+) */\r\n  font-size: 13px;\r\n  color: white;\r\n  float: right;\r\n  margin-left: 5px;\r\n}\r\n\r\n.active:after {\r\n  content: \"\\2796\"; /* Unicode character for \"minus\" sign (-) */\r\n}";
    public static string collapseFile = "var coll = document.getElementsByClassName(\"collapsible\");\r\nvar i;\r\n\r\nfor (i = 0; i < coll.length; i++) {\r\n  coll[i].addEventListener(\"click\", function() {\r\n    this.classList.toggle(\"active\");\r\n    var content = this.nextElementSibling;\r\n    if (content.style.display === \"block\") {\r\n      content.style.display = \"none\";\r\n    } else {\r\n      content.style.display = \"block\";\r\n    }\r\n  });\r\n}  function ShowAll(){\r\n  for (let i = 0; i<coll.length;i++){\r\n      let bt = coll[i];\r\n      bt.click();\r\n    } \r\n} \r\n";

    // Time
    public static DateTime start = DateTime.Now;

    // HTML
    // Headers for html log files
    public static string snapshothtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tSnapshot Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Snapshot Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    public static string clipboardhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tClipboard Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Clipboard Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    public static string outputhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tOutput Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Output Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    public static string attentionhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tAttention Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Attention Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    public static string errorhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tError Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Error Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    public static string keyloggerhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tKey Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Key Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    public static string hotkeyhtmlHeader = "<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\tKey Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>Hot Key Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    /// <summary>
    /// Footer for the html log files
    /// </summary>
    public static string htmlFoot = "</body>\r\n\t<script src=\"./collapse.js\"></script>\r\n<style>\r\n.content {\r\n  padding: 0 18px;\r\n  background-color: white;\r\n  max-height: 0;\r\n  overflow: hidden;\r\n  transition: max-height 0.2s ease-out;\r\n}\r\n</style>\r\n\r\n<script>\r\nvar coll = document.getElementsByClassName(\"collapsible\");\r\nvar i;\r\n\r\nfor (i = 0; i < coll.length; i++) {\r\n  coll[i].addEventListener(\"click\", function() {\r\n    this.classList.toggle(\"active\");\r\n    var content = this.nextElementSibling;\r\n    if (content.style.maxHeight){\r\n      content.style.maxHeight = null;\r\n    } else {\r\n      content.style.maxHeight = content.scrollHeight + \"px\";\r\n    }\r\n  });\r\n}\r\n</script>\r\n\r\n</html>";

    /// <summary>
    /// Boolean to mark the project as complete
    /// </summary>
    public static bool DONE = false;

    /// <summary>
    /// Used to get the time elasped from the start of the project to the current time
    /// </summary>
    /// <returns> TimeSpan aka time between the start of the program and the current time</returns>
    public static TimeSpan timeElapsed()
    {
        DateTime current = DateTime.Now;

        TimeSpan ts = current - start;


        return ts;
    }
}


