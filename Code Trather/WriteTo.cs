
using System.Timers;

public class WriteTo
{


    public static void writeToFile(string fileName, string write)
    {
        File.AppendAllText(fileName, write + Environment.NewLine);
    }
    public static void writeToFileCSV(string fileName, string write)
    {
        File.AppendAllText(fileName, write);
    }

    public static void writeToSnapshotHTML(string write)
    {
        if (Globals.DONE == false)
        {
            // Variable Creation
            string address = Globals.snapshothtmlAddress;
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.snapshotCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            Globals.snapshotCounter += 1;
        }
    }

    public static string addDiv(string text)
    {
        string temp = "<div>";
        text = text.ReplaceLineEndings("</div><div>");
        string temp2 = "</div>";
        text = temp + text + temp2;
        return text;
    }

    public static void CreateFiles()
    {
        File.AppendAllText(Globals.snapshothtmlAddress, "");
        System.IO.File.WriteAllText(Globals.snapshothtmlAddress, string.Empty);
        WriteTo.writeToFile(Globals.snapshothtmlAddress, Globals.snapshothtmlHeader);

        File.AppendAllText(Globals.clipboardhtmlAddress, "");
        System.IO.File.WriteAllText(Globals.clipboardhtmlAddress, string.Empty);
        WriteTo.writeToFile(Globals.clipboardhtmlAddress, Globals.clipboardhtmlHeader);
        
        File.AppendAllText(Globals.outputAddress, "");
        System.IO.File.WriteAllText(Globals.outputAddress, string.Empty);
        WriteTo.writeToFile(Globals.outputAddress, Globals.outputhtmlHeader);

        File.AppendAllText(Globals.logcssAddress, "");
        System.IO.File.WriteAllText(Globals.logcssAddress, string.Empty);
        WriteTo.writeToFile(Globals.logcssAddress, Globals.logFile);

        File.AppendAllText(Globals.collapseAddress, "");
        System.IO.File.WriteAllText(Globals.collapseAddress, string.Empty);
        WriteTo.writeToFile(Globals.collapseAddress, Globals.collapseFile);

    }

    public static void writeToClipboard(string write)
    {
        if (Globals.DONE == false)
        {
            // Variable Creation
            string address = Globals.clipboardhtmlAddress;
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.clipboardCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            Globals.clipboardCounter += 1;
        }
    }

    public static void writeToOutput(string write)
    {
        if (Globals.DONE == false)
        {
            // Variable Creation
            string address = Globals.outputAddress;
            string log = $"<button type=\"button\" class=\"collapsible\">Log #{Globals.outputCounter} ; {DateTime.Now.ToString("hh:mm:ss tt")} ; {Globals.timeElapsed().ToString().Remove(8)} time elapsed</button>\r\n\t\t\t<div class=\"content\">\r\n\t\t\t  <p>{addDiv(write)}</p>\r\n\t\t\t</div>";
            writeToFile(address, log);
            Globals.outputCounter += 1;
        }
    }



}
