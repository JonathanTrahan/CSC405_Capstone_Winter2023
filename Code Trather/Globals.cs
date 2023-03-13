
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using Code_Trather;
using System.Drawing.Text;

public static class Globals
{
    // List of Hot Key word to check inputs for
    public static string[] hotKeys = { "Menu", "Alt", "F11", "F12", "Insert", "Delete", "ControlKey", "Control" };
    //public static string[] usedHotKeys = new string[];

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
    public static string indexAddress = filePath + "index.html";
    // Crypt Folder Addresses
    public static string cryptFolder = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/Cryptog/";
    public static string filePathZip = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs.zip";
    public static string PubKeyFile = cryptFolder + "rsaPublicKey.txt";
    public static string PrivKeyFile = cryptFolder + "rsaPrivateKey.txt";
    public static string encryptedZip = cryptFolder + "TratherLogs.aes";
    public static string decryptedZip = cryptFolder + "TratherLogs.zip";

    //Files to be added - The are premade files to be added the log folder to assist the html log files
    public static string logFile = "/* Style the button that is used to open and close the collapsible content */\r\n.collapsible {\r\n  background-color: #eee;\r\n  color: #444;\r\n  cursor: pointer;\r\n  padding: 18px;\r\n  width: 100%;\r\n  border: none;\r\n  text-align: left;\r\n  outline: none;\r\n  font-size: 15px;\r\n}\r\n\r\n/* Add a background color to the button if it is clicked on (add the .active class with JS), and when you move the mouse over it (hover) */\r\n.active, .collapsible:hover {\r\n  background-color: #ccc;\r\n}\r\n\r\n/* Style the collapsible content. Note: hidden by default */\r\n.content {\r\n  padding: 0 18px;\r\n  display: none;\r\n  overflow: hidden;\r\n  background-color: #f1f1f1;\r\n}\r\n.collapsible:after {\r\n  content: '\\02795'; /* Unicode character for \"plus\" sign (+) */\r\n  font-size: 13px;\r\n  color: white;\r\n  float: right;\r\n  margin-left: 5px;\r\n}\r\n\r\n.active:after {\r\n  content: \"\\2796\"; /* Unicode character for \"minus\" sign (-) */\r\n}";
    public static string collapseFile = "var coll = document.getElementsByClassName(\"collapsible\");\r\nvar i;\r\n\r\nfor (i = 0; i < coll.length; i++) {\r\n  coll[i].addEventListener(\"click\", function() {\r\n    this.classList.toggle(\"active\");\r\n    var content = this.nextElementSibling;\r\n    if (content.style.display === \"block\") {\r\n      content.style.display = \"none\";\r\n    } else {\r\n      content.style.display = \"block\";\r\n    }\r\n  });\r\n}  function ShowAll(){\r\n  for (let i = 0; i<coll.length;i++){\r\n      let bt = coll[i];\r\n      bt.click();\r\n    } \r\n} \r\n";
    public static string indexFile = "\r\n<!DOCTYPE html> \r\n<html> \r\n\t<!-- Inside head tags contain header information for the webpage-->\r\n\t<head>\r\n\t\t<!-- meta -  data about the document -->\r\n\t\t<meta charset=\"utf-8\">\r\n\t\t<meta name = \"description\" content=\"awesome content\">\r\n\t\t<!-- Title tag chenges the title in the web browser tab -->\r\n\t\t<title>\r\n\t\t\tStudent Log Landing Page\r\n\t\t</title>\r\n\r\n\t</head>\r\n\t<!-- Inside body tags contain the contents of the webpage-->\r\n\t<body>\r\n\t\t<header>\r\n\t\t\t<nav></nav>\r\n\t\t</header>\r\n\t\t\r\n\t\t<main>\r\n\t\t\t<h1>Fname Lname, CWID, Log Page</h1>\r\n\t\t\t<p><big><big><b>Assignments</b></big></big></p>\r\n\t\t\t<ul>\r\n\t\t\t\t<li><a href=\"snapshots.html\" target=\"_blank\">Snapshot Log</a></li>\r\n\t\t\t\t<li><a href=\"attention.html\" target=\"_blank\">Attention Log</a></li>\r\n\t\t\t\t<li><a href=\"hotkeys.html\" target=\"_blank\">Hot Key Log</a></li>\r\n\t\t\t\t<li><a href=\"output.html\" target=\"_blank\">Output Log</a></li>\r\n\t\t\t\t<li><a href=\"error.html\" target=\"_blank\">Error Log</a></li>\r\n\t\t\t\t<li><a href=\"clipboard.html\" target=\"_blank\">Clipboard Log</a></li>\r\n\t\t\t\t<li><a href=\"keylogger.html\" target=\"_blank\">Key Logger Html</a></li>\r\n\t\t\t\r\n\t\t</main>\r\n\r\n\t</body>\r\n\r\n\r\n</html>";
   
    // Time
    public static DateTime start = DateTime.Now;

    // HTML
    // Headers for html log files
    public static string getHeader(string title)
    {
        return $"<!DOCTYPE html> \n<html> \n\t<!-- Inside head tags contain header information for the webpage-->\n\t<head>\n\t\t<!-- meta -  data about the document -->\n\t\t<meta charset=\"utf-8\">\n\t\t<meta name = \"description\" content=\"awesome content\">\n        <link rel=\"stylesheet\" type=\"text/css\" href=\"./logs.css\">\n\t\t<!-- Title tag chenges the title in the web browser tab -->\n\t\t<title>\n\t\t\t {title} Log\n\t\t</title>\n\n\t</head>\n\t<!-- Inside body tags contain the contents of the webpage-->\n\t<body>\n\t\t\n\t\t\t<h1>{Program.studentName} {title} Log</h1><button type=\"button\" class=\"showall\" onclick =\"ShowAll()\">Toggle Logs</button>";
    }
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


