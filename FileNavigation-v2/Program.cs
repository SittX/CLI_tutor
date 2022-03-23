using FileNavigation_v2;
Run();

void Run(){
    CheckOS();
}


 void CheckOS()
{
    if (OperatingSystem.IsMacOS() && OperatingSystem.IsLinux())
    {
        System.Console.WriteLine("Sorry our app is not currently working in MacOS and Linux distributions.");
    }
    else if (OperatingSystem.IsWindows())
    {
        Window window = new Window();
        window.Run();
    }
    else
    {
        System.Console.WriteLine("Can't detect the OS. Please try again.");
    }
}