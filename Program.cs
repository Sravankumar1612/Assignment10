using System;
using System.IO;
using System.Runtime.ExceptionServices;

namespace Assignment10
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            try
            {
                Console.WriteLine("Choose the operation do you want to perform\n" +
                    "1. File Creation \n2. File Reading \n3. File Appending \n4. File Deletion");
                first:
                Console.WriteLine("Enter the number");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        {
                            createFile();
                            appendFiles();
                            break;
                        }
                    case 2:
                        {
                            readFiles();
                            break;
                        }
                    case 3:
                        {
                            appendFiles();
                            break;
                        }
                    case 4:
                        {
                            deleteFiles();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice");
                            break;
                        }

                }
                
                Console.WriteLine("Do you want to Continue? then click 1");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    goto first;
                }
                

            }
            catch (FormatException fe) { Console.WriteLine(fe.Message); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }

             static void createFile()
            {
                Console.WriteLine("Enter the Path to store file");
                string fpath = Console.ReadLine();
                Console.WriteLine("Enter the New File name");
                string name = Console.ReadLine();
                string thePath = fpath + name;
                if (File.Exists(thePath))
                {
                    Console.WriteLine("File Already Exists");
                }
                else
                {
                    StreamWriter sw = File.AppendText(thePath);
                    sw.WriteLine("Extra content added");                   
                    sw.Dispose();
                    sw.Close();
                    Console.WriteLine("Now the File is Created in the Directory");
                }
            }
            static void readFiles()
            {
                Console.WriteLine("Enter the File name and its Path to read");
                string readFile = Console.ReadLine();
                StreamReader sr = new StreamReader(readFile);
                string text = "";
                while ((text = sr.ReadLine()) != null)
                {
                    Console.WriteLine(text);
                }
                sr.Close();
            }
            static void appendFiles()
            {
                Console.WriteLine("Enter the Path for the file to Open");
                string openFile = Console.ReadLine();
                Console.WriteLine("Enter the Content to Append");
                string appendFile = Console.ReadLine();
                File.AppendAllText(openFile, appendFile);
            }
            static void deleteFiles()
            {
                Console.WriteLine("Enter the Path for the file to Delete");
                string deleteFile = Console.ReadLine();
                File.Delete(deleteFile);
                Console.WriteLine("The File is Deleted from the Directory");
            }
        }
}