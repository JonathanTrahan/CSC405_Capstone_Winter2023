namespace Code_Trather
{
    internal static class Program
    {
        public static string filePath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads/assignment/";
        public static string fileName = "assignment.py";
        public static string download = filePath + fileName;
        public static string studentName = "";
        public static int cwid;
        public static string testID = "";
        public static bool hasUnitTest;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SplashScreen());
        }
    }
}