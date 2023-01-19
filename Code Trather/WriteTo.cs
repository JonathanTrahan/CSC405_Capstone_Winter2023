
using System.Timers;

public class WriteTo
{


    public static void writeToFile(string fileName, string write)
    {
        File.AppendAllText(fileName, write + Environment.NewLine);
    }
    public static void writeToSnapshot(string write)
    {
        // Variable Creation
        string address = Globals.snapshotsAddress;
        string header = "Snapshot " + Globals.snapshotCounter + " at " + DateTime.Now.ToString("hh:mm:ss tt") + " " + "or Time Elapsed: " + Globals.timeElapsed().ToString();
        string spacer = "''''";
        // Writing To File method calls
        writeToFile(address, header);
        writeToFile(address, spacer);
        writeToFile(address, write);
        writeToFile(address, spacer);
        // Counter Up
        Globals.snapshotCounter += 1;
    }
    public static void writeToClipboard(string write)
    {
        // Variable Creation
        string address = Globals.clipboardAddress;
        string header = "Clipboard " + Globals.clipboardCounter + " at " + DateTime.Now.ToString("hh:mm:ss tt") + " " + "or Time Elapsed: " + Globals.timeElapsed();
        string spacer = "''''";
        // Writing To File method calls
        writeToFile(address, header);
        writeToFile(address, spacer);
        writeToFile(address, write);
        writeToFile(address, spacer);
        // Counter Up
        Globals.clipboardCounter += 1;
    }



}
