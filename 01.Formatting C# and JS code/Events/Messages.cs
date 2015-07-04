namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Messages
    {
        public static void EventAdded(StringBuilder output)
        { 
            output.Append("Event added\n"); 
        }

        public static void EventDeleted(int numberOfEvents, StringBuilder output)
        {
            if (numberOfEvents == 0)
            {
                NoEventsFound(output);
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", numberOfEvents);
            }
        }

        public static void NoEventsFound(StringBuilder output) 
        {
            output.Append("No events found\n"); 
        }

        public static void PrintEvent(Event eventToPrint, StringBuilder output)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }

        internal static void EventAdded() ////TODO implement EventsAdded
        {
            throw new NotImplementedException();
        }

        internal static void EventDeleted(int removed) ////TODO implement EventsDeleted
        {
            throw new NotImplementedException();
        }

        internal static void PrintEvent(Event eventToShow) ////TODO implement PrintEvent
        {
            throw new NotImplementedException();
        }

        internal static void NoEventsFound() ////TODO implement NoEventsFound
        {
            throw new NotImplementedException();
        }
    }
}
