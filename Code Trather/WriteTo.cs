
using System.Diagnostics;
using System.Timers;

public class WriteTo
{

    /// <summary>
    /// Method to be run when the submit button is pressed
    /// </summary>
    public static void Complete()
    {
        writeToFile(Globals.snapshothtmlAddress, Globals.htmlFoot);
        writeToFile(Globals.clipboardhtmlAddress, Globals.htmlFoot);
        writeToFile(Globals.outputAddress, Globals.htmlFoot);
        writeToFile(Globals.attentionAddress, Globals.htmlFoot);
        writeToFile(Globals.errorAddress, Globals.htmlFoot);
        writeToFile(Globals.keyloggerAddress, Globals.htmlFoot);
        writeToFile(Globals.hotkeyAddress, Globals.htmlFoot);
    }

    /// <summary>
    /// Method to write to a specific File 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="write"></param>
    public static void writeToFile(string fileName, string write)
    {
        File.AppendAllText(fileName, write + Environment.NewLine);
    }
    public static void writeToFileCSV(string fileName, string write)
    {
        File.AppendAllText(fileName, write);
    }

    ///<summary>
    /// Method to replace all "\n" with "</div><div>" so that the logs are not all on one line
    ///</summary> 
    public static string addDiv(string text)
    {

        string temp = "<div>";
        text = text.ReplaceLineEndings("</div><div>");
        string temp2 = "</div>";
        text = temp + text + temp2;
        return text;
    }

    /// <summary>
    /// Method to clear the files if the exist and create the files if they don't
    /// </summary>
    public static void CreateFiles()
    {
        // Clears the text of the given file
        File.AppendAllText(Globals.snapshothtmlAddress, "");
        System.IO.File.WriteAllText(Globals.snapshothtmlAddress, string.Empty);
        // Writes the HTML header to the file
        WriteTo.writeToFile(Globals.snapshothtmlAddress, Globals.snapshothtmlHeader);

        File.AppendAllText(Globals.clipboardhtmlAddress, "");
        System.IO.File.WriteAllText(Globals.clipboardhtmlAddress, string.Empty);
        WriteTo.writeToFile(Globals.clipboardhtmlAddress, Globals.clipboardhtmlHeader);

        File.AppendAllText(Globals.outputAddress, "");
        System.IO.File.WriteAllText(Globals.outputAddress, string.Empty);
        WriteTo.writeToFile(Globals.outputAddress, Globals.outputhtmlHeader);

        File.AppendAllText(Globals.attentionAddress, "");
        System.IO.File.WriteAllText(Globals.attentionAddress, string.Empty);
        WriteTo.writeToFile(Globals.attentionAddress, Globals.attentionhtmlHeader);

        File.AppendAllText(Globals.errorAddress, "");
        System.IO.File.WriteAllText(Globals.errorAddress, string.Empty);
        WriteTo.writeToFile(Globals.errorAddress, Globals.errorhtmlHeader);

        File.AppendAllText(Globals.keyloggerAddress, "");
        System.IO.File.WriteAllText(Globals.keyloggerAddress, string.Empty);
        WriteTo.writeToFile(Globals.keyloggerAddress, Globals.keyloggerhtmlHeader);

        File.AppendAllText(Globals.hotkeyAddress, "");
        System.IO.File.WriteAllText(Globals.hotkeyAddress, string.Empty);
        WriteTo.writeToFile(Globals.hotkeyAddress, Globals.hotkeyhtmlHeader);

        // Creates premade files to the log folder
        File.AppendAllText(Globals.logcssAddress, "");
        System.IO.File.WriteAllText(Globals.logcssAddress, string.Empty);
        WriteTo.writeToFile(Globals.logcssAddress, Globals.logFile);

        // Creates premade files to the log folder
        File.AppendAllText(Globals.collapseAddress, "");
        System.IO.File.WriteAllText(Globals.collapseAddress, string.Empty);
        WriteTo.writeToFile(Globals.collapseAddress, Globals.collapseFile);



    }

    /// <summary>
    /// Method to write to the Snapshot HTML log file
    /// </summary>
    /// <param name="write"></param>
    public static void writeToSnapshotHTML(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // Address of the file that will be written to
            string address = Globals.snapshothtmlAddress;
            // String that will be written to the file
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.snapshotCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            // Increments the counter so that the Counter is up to date
            Globals.snapshotCounter += 1;
        }
    }

    /// <summary>
    /// Method to write to the Key Logger HTML log file
    /// </summary>
    /// <param name="write"></param>
    public static void writeToKeyLoggerHTML(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // Address of the file that will be written to
            string address = Globals.keyloggerAddress;
            // String that will be written to the file
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.keyloggerCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            // Increments the counter so that the Counter is up to date
            Globals.keyloggerCounter += 1;
        }
    }
    /// <summary>
    /// Method to write to the Hot Key Logger HTML log file
    /// </summary>
    /// <param name="write"></param>
    public static void writeToHotKeyHTML(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // Address of the file that will be written to
            string address = Globals.hotkeyAddress;
            // String that will be written to the file
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.hotkeyCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            // Increments the counter so that the Counter is up to date
            Globals.hotkeyCounter += 1;
        }
    }
    /// <summary>
    /// Method to write to the Clipboard HTML log file 
    /// </summary>
    /// <param name="write"></param>
    public static void writeToClipboard(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // If there is nothing in the clipboard don't log anything
            if (write != "")
            {
                // Address of the file that will be written to
                string address = Globals.clipboardhtmlAddress;
                // String that will be written to the file
                string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.clipboardCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
                writeToFile(address, log);
                // Increments the counter so that the Counter is up to date
                Globals.clipboardCounter += 1;
            }
        }
    }

    /// <summary>
    /// Method to write to the Output HTML log file
    /// </summary>
    /// <param name="write"></param>
    public static void writeToOutput(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // Address of the file that will be written to
            string address = Globals.outputAddress;
            // String that will be written to the file
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.outputCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            // Increments the counter so that the Counter is up to date
            Globals.outputCounter += 1;
        }
    }

    /// <summary>
    /// Method to write to the Attention HTML log file
    /// </summary>
    /// <param name="write"></param>
    public static void writeToAttention(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // Address of the file that will be written to
            string address = Globals.attentionAddress;
            // String that will be written to the file
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.attentionCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            // Increments the counter so that the Counter is up to date
            Globals.attentionCounter += 1;
        }
    }

    /// <summary>
    /// Method to write to the Error HTML log file
    /// </summary>
    /// <param name="write"></param>
    public static void writeToError(string write)
    {
        // If project is not complete then update log file
        if (Globals.DONE == false)
        {
            // Address of the file that will be written to
            string address = Globals.errorAddress;
            // String that will be written to the file
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.errorCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            // Increments the counter so that the Counter is up to date
            Globals.attentionCounter += 1;
        }
    }


}
