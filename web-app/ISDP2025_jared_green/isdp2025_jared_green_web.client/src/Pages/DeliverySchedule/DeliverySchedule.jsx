import Navbar from "../../Components/NavBar/NavBar";
import CalendarContainer from "../../Components/Calendar/Calendar";
import Footer from "../../Components/Footer/Footer";
import { useState, useEffect } from 'react';
import DeliveryModal from '../../Components/Modal/OrderModal';
import axios from 'axios';
import LoadingSpinner from "../../Components/LoadingSpinner/LoadingSpinner";


function Dashboard() {
    const [orders, setOrders] = useState([]);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(null);
    const [selectedEvent, setSelectedEvent] = useState(null);
    const [modalOpen, setModalOpen] = useState(false);

    const selectEvent = (event) => {
        setSelectedEvent(event);
        const ordersForThatDay = event.orders;
        setModalOpen(true);
        console.log("Orders:", ordersForThatDay);
    };

    const loadCalendar = () => {

    }

    function handleModalClose() {
        setModalOpen(false);
    }


    useEffect(() => {
        const fetchDeliveries = async () => {
            try {
                setLoading(true);
                const response = await axios.get(`api/deliveries`);
                setOrders(response.data);
                loadCalendar();
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchDeliveries();
    }, []);

    return (
        <>
            <Navbar />
            <h1>Delivery Schedule</h1>
            {
                loading === null ? null : loading ? (
                    <LoadingSpinner />
                ) : (
                        <CalendarContainer
                            events={!error ? orders || [] : undefined}
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