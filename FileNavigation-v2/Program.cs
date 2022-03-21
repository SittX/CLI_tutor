





 void CheckOS()
{
    if (OperatingSystem.IsMacOS() && OperatingSystem.IsLinux())
    {
        System.Console.WriteLine("Sorry our app is not currently working in MacOS and Linux distributions.");
    }
    else if (OperatingSystem.IsWindows())
    {
        Console.WriteLine("Window");
    }
    else
    {
        System.Console.WriteLine("Can't detect the OS. Please try again.");
    }
}