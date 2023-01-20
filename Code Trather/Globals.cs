
public static class Globals
{
    // Counters
    public static int snapshotCounter = 1;
    public static int clipboardCounter = 1;
    // Addresses
    public static string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs/";
    public static string snapshotsAddress = filePath + "snapshots.txt";
    public static string clipboardAddress = filePath + "clipboard.txt";
    public static string downloadAddress = filePath + "assignment.py";
    // Time
    public static DateTime start = DateTime.Now;
    public static TimeSpan timeElapsed()
    {
        DateTime current = DateTime.Now;

        TimeSpan ts = current - start;


        return ts;
    }
}
