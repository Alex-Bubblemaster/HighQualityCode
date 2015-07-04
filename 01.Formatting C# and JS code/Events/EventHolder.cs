namespace Events
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();

            int removed = 0;
            foreach (var eventToRemove in this.byTitle[title])
            {
                removed++;
                this.byDate.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public OrderedBag<Event> ViewEventsToShow(object rangeFrom) ///TODO this is just to make it not crash
        {
            var result = new OrderedBag<Events.Event>();

            return result;
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event> eventsToShow = this.ViewEventsToShow(this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true));
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}