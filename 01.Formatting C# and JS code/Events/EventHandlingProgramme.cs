namespace Events ///I just want to warn you that I made it possible to build, that's all - don't run it because it's blahhh...
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Events;
    using Wintellect.PowerCollections;

    public class EventHandlingProgramme
    {
        private static StringBuilder output = new StringBuilder();
        private static EventHolder events = new EventHolder();

        public static void Main()
        {
            while (ExecuteNextCommand())
            {
                Console.WriteLine(output);
            }
        }

        public static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();
            if (command[0] == 'A') 
            { 
                AddEvent(command);
                return true; 
            }

            if (command[0] == 'D')
            {
                DeleteEvents(command); 
                return true; 
            }

            if (command[0] == 'E') 
            { 
                return false; 
            }

            if (command[0] == 'L')
            {
                ListEvents(command);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            var events = new MultiDictionary<string, Event>(true);  /// added that to make it stop crashing too
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);   /// events.ListEvents(date,count); commented that to make it build
        }

        private static void DeleteEvents(string command)
        {
            var events = new MultiDictionary<string, Event>(true);  ///added that to make it stop crashing too
            string title = command.Substring("DeleteEvents".Length + 1);
            events.Remove(title); 
        }

        private static void AddEvent(string command)
        {
            var currentEvent = new Event(DateTime.Now, "title", "location");
            ///GetParameters(command, "AddEvent", out date, out title, out location);
            var events = new MultiDictionary<string, Event>(true);  ///added that to make it stop crashing too
            events.Add("title", currentEvent);
        }

        private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle =
                    commandForExecution.Substring(firstPipeIndex
                    + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }
    }
}