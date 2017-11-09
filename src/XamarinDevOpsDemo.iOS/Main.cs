using System.Diagnostics;
using System.IO;
using UIKit;

namespace XamarinDevOpsDemo.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
            try
            {
                if (File.Exists("Library/my-crash.txt"))
                {
                    Debug.Write(File.ReadAllText("Library/my-crash.txt"));
                    File.Delete("Library/my-crash.txt");
                }
              
                // if you want to use a different Application Delegate class from "AppDelegate"
                // you can specify it here.
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (System.Exception ex)
            {
                StreamWriter file = File.CreateText("Library/my-crash.txt");
                file.Write(ex.ToString()); // save the exception description and clean stack trace
                file.Close();
            }
			
		}
	}
}
