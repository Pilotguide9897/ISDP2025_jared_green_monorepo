import { useState } from 'react';
import { Calendar, dateFnsLocalizer } from 'react-big-calendar'
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { format, parse, startOfWeek, getDay } from 'date-fns';
import enCA from 'date-fns/locale/en-CA';

const locales = {
    'en-CA': enCA
}

// Takes a config object
const localizer = dateFnsLocalizer({
    format,
    parse,
    startOfWeek,
    getDay,
    locales

});

console.log(localizer);

const MyCalendar = ({ events, setModalOpen, setSelectedEvent }) => {
    const [currentView, setCurrentView] = useState('month');
    const [currentDate, setCurrentDate] = useState(new Date());

    return (
        <>
            <Calendar
                localizer={localizer}
                events={events}
                view={currentView}
                onSelectEvent={(event) => {
                    setSelectedEvent(event);
                    setModalOpen(true);
                } }
                onView={(view) => setCurrentView(view)}
                date={currentDate}
                onNavigate={(newDate) => { setCurrentDate(newDate)}}
                views={['month', 'week', 'day', 'agenda']}
                defaultView="month"
                startAccessor="start"
                endAccessor="end"
                style={{ height: 600 }}
            />
            
        </>

    );
};

export default MyCalendar;