using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void CreateCommand(string command)
        {
            /*
             GradeBook.UserInterfaces.StartingUserInterface didn't write
             'Command not valid, Create requires a name and type of gradebook.' 
             to the console when the create command didn't contain both a name and type.
             */

            var parts = command.Split(' ');
            if (parts.Length != 3)
            {
                Console.WriteLine("Command not valid, Create requires a name and type of gradebook.");
                return;
            }
            else if (parts.Length == 3 && (parts[1] == null || parts[2] == null))
            {
                Console.WriteLine("Command not valid, Create requires a name and type of gradebook.");
                return;
            }
            var name = parts[1];
            var type = parts[2].ToLower();
            if (name == null && type == null)
            {
                Console.WriteLine("Command not valid, Create requires a name and type of gradebook.");
            }

            BaseGradeBook gradeBook;
            if (type == "standard")
            {
                gradeBook = new StandardGradeBook(name);
            }
            else if (type == "ranked")
            {
                gradeBook = new RankedGradeBook(name);
            }
            else
            {
                Console.WriteLine("{0} is not a supported type of gradebook, please try again", type);
                return;
            }
            Console.WriteLine("Created gradebook {0}.", name);
            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' 'Type' - Creates a new gradebook where 'Name' is the name of the gradebook and 'Type' is what type of grading it should use.");
            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }
    }
}