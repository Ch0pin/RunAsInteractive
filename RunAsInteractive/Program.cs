using System;
using System.Security;
using System.ComponentModel;
using System.Diagnostics;

namespace RunAsInteractive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the secure string.
            SecureString securePwd = new SecureString();
            String username, exe, parameters,domain,password;
           
           

            ConsoleKeyInfo key;

            Console.Write("Enter Username: ");
            username = Console.ReadLine();

            Console.Write("Enter password: ");
            password = Console.ReadLine();

            foreach (char c in password.ToCharArray())
            {
                securePwd.AppendChar(c);
            }
            
            //Read exe to execute
            Console.Write("Enter full path of the file to run: ");
            exe = Console.ReadLine();

            //Read parameters
            Console.Write("Enter parameters to apply, or CR-LF for no parameters: ");
            parameters = Console.ReadLine();
            if (parameters == null)
                parameters = "";

            //ReadDomain 
            Console.Write("Enter your Domain: ");
            domain = Console.ReadLine();
            if (domain == null)
                domain = "";

            try
            {
                Process.Start(exe, parameters, username, securePwd, domain) ;
            }
            catch (Win32Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                securePwd.Dispose();
            }
        }
    }
}
