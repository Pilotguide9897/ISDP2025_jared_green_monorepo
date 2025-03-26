import Navbar from "../../Components/NavBar/NavBar";
import CalendarContainer from "../../Components/Calendar/Calendar";
import Footer from "../../Components/Footer/Footer";
import { useState, useEffect } from 'react';
import DeliveryModal from '../../Components/Modal/OrderModal';
import axios from 'axios';
import LoadingSpinner from "../../Components/LoadingSpinner/LoadingSpinner";
import { useNavigate } from 'react-router-dom';

function Dashboard() {
    const [orders, setOrders] = useState([]);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(null);
    const [selectedEvent, setSelectedEvent] = useState(null);
    const [modalOpen, setModalOpen] = useState(false);
    const [calendarEvents, setCalendarEvents] = useState(null);
    const navigate = useNavigate();

    const selectEvent = (event) => {
        setSelectedEvent(event);
        const ordersForThatDay = event.orders;
        setModalOpen(true);
        console.log("Orders:", ordersForThatDay);
    };

    function handleModalClose() {
        setModalOpen(false);
    }


    useEffect(() => {
        const fetchDeliveries = async () => {
            try {
                setLoading(true);
                // Pass config object for auth

                const token = localStorage.getItem("token");

                if (!token) {
                    alert("No auth token available, returning to login screen");
                    navigate("/");
                    return;
                }

                const config = {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                }

                const response = await axios.get(`/api/deliveries`, config);
                setOrders(response.data);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchDeliveries();
    }, [navigate]);


    useEffect(() => {
        const loadCalendar = () => {
            let eventsGroupedByDate = {}

            // Group the events
            orders.forEach(order => {
                const shipDate = new Date(order.shipDate);
                // Get just the date
                const dateKey = shipDate.toISOString().split('T')[0];

                if (!eventsGroupedByDate[dateKey]) {
                    eventsGroupedByDate[dateKey] = [];
                }

                eventsGroupedByDate[dateKey].push(order);
            });

            const events = Object.entries(eventsGroupedByDate).map(([dateKey, groupedOrders]) => {
                const start = new Date(dateKey);
                const end = new Date(new Date(dateKey).setHours(18));
                const totalWeight = orders.reduce((sum, order) => {
                    const itemWeights = order.txnitems?.reduce((itemSum, txnItem) => {
                        return itemSum + (txnItem.quantity * (txnItem.item?.weight));
                    }, 0);
                    return sum + itemWeights;
                }, 0);

                return {
                    title: `Deliveries: ${groupedOrders.length} order(s) - Vehicle: ${totalWeight}`,
                    start,
                    end,
                    allDay: true,
                    orders: groupedOrders, 
                    totalWeight
                };
            });

            setCalendarEvents(events)
        }

        if (orders.length > 0) {
            loadCalendar();
        }

    }, [orders]);


    return (
        <>
            <Navbar />
            <h1>Delivery Schedule</h1>
            {
                loading === null ? null : loading ? (
                    <LoadingSpinner />
                ) : (
                        <CalendarContainer
                            events={!error ? calendarEvents || [] : undefined}
                            onSelectEvent={selectEvent}
                        />
                )
            }
            <DeliveryModal show={modalOpen} data={selectedEvent} handleClose={ handleModalClose } />
            <Footer />
        </>
    )
}

export default Dashboard;