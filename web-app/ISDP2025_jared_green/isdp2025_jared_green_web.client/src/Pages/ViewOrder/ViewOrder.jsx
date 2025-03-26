import { useState } from 'react';
import axios from 'axios';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import DataTable from '../../Components/DataTable/DataTable';
import Button from 'react-bootstrap/Button';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';
import Footer from "../../Components/Footer/Footer";
import ErrorImage from '../../Components/ErrorImage/file';

function ViewOrder() {
    const [order, setOrder] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(null);
    const [modalShow, setModalShow] = useState(false);
    const [image, setImage] = useState("");
    //const [readyTime, setReadyTime] = useState((new Date(Date.now() + 2 * 60 * 60 * 1000)).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }))
    let imagePath = "/images/";

    const subtotal = order.txnitems.reduce((sum, item) => sum + item.quantity * item.item.retailPrice, 0) || 0;
    const hst = subtotal * 0.15;
    const total = subtotal + hst;

    const handleSearchBarSubmission = async (searchParameter) => {

        try {
            setLoading(true);
            setError(false);
            const response = await axios.get(`/api/orders/search?query=${searchParameter.toString().trim()}`);
            console.log(response.data)
            setOrder(response.data);
        } catch (error) {
            setError(error);
        } finally {
            setLoading(false);
        }
    }

    const showItemImage = async (row) => {
        let imageSrc = imagePath + row.productName; 
        setImage(imageSrc);
    }

    return (
        <>
            <NavBar />
            <h1>Bullseye Curbside Order System - Order View</h1>
            <section>
                <SearchBar placeholderText="Search by order ID or customer email address" buttonClickHandler={handleSearchBarSubmission} />
            </section>
            {
                loading === null ? null : loading ? (<LoadingSpinner />) : order ? (
                    <section>
                        <div className="d-flex justify-content-start">
                            <h5>Order ID: { order.txnId }</h5>
                            <h5>Name: {order.custFirstName} {order.custLastName}</h5>
                            <h5>Email: { order.custEmail }</h5>
                            <h5>Phone: { order.custPhone }</h5>
                        </div>

                        {/*<p>{*/}
                        {/*    `This order will be ready to pick up at our ${order.orderSite.siteName} retail store: ${order.orderSite.address}, ${order.orderSite.city}, ${order.orderSite.postalCode} by ${10} at our ${10}.*/}
                     
                        {/*`}</p>*/}
                        {/*<DataTable data={orderData} handlDoubleClick={showItemImage} />*/}
                        <DataTable data={order.txnitems} onRowDoubleClick={showItemImage} />
                        <BasicModal show={modalShow} onHide={() => setModalShow(false)} image={image} />
                        <div className="d-flex justify-content-end">
                            <h5>Subtotal: { subtotal.toFixed(2) }</h5>
                            <h5>HST (15%): { hst.toFixed(2) }</h5>
                            <h5>Total: { total.toFixed(2) }</h5>
                        </div>
                        <Button variant="info">Exit</Button>
                    </section>
                ) : error ? ( <ErrorImage /> ) : null
            }
            <Footer />
        </>
    )
}

export default ViewOrder;