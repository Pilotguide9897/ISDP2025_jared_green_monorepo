import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import DataTable from '../../Components/DataTable/DataTable';
import Button from 'react-bootstrap/Button';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';
import Footer from "../../Components/Footer/Footer";
import SignatureBox from '../../Components/SignatureBox/SignatureBox';
import { useState, useEffect } from 'react'
import axios from 'axios';
import AlertMessage from '../../Components/Alert/Alert';

function PickupStoreOrder({ OrderNumber }) {
    const [order, setOrder] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(null);

    useEffect(() => {

        const fetchOrders = async () => {
            try {
                setLoading(true);
                const response = await axios.get(`/api/orders?query=${OrderNumber}`);
                setOrder(response.data);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchOrders();
    }, [])


    return (
        <>
            <NavBar />
            <h1>Bullseye Curbside Order System - Order Pickup</h1>
            <section>

            </section>
            {
                loading === null ? null : loading ? (<LoadingSpinner />) : error ? (
                    <>
                        <AlertMessage variant="danger" message="Something went wrong while loading the order." />
                        <DataTable data={[]} />
                    </>

                ) :order ? (
                <section>
                    <div className="d-flex justify-content-start">
                        <h5>Order ID: { order.orderID }</h5>
                        <h5>Name: { order.custName }</h5>
                        <h5>Email: { order.custEmail }</h5>
                        <h5>Phone: { order.custPhone }</h5>
                    </div>

                    <p>{
                        `This order will be ready to pick up by ${10} at our ${10} retail store:
                         ${10} 
                        `}
                     </p>
                    <DataTable data={ order } />
                    <div className="d-flex justify-content-end">
                        <h5>Subtotal: { 10 }</h5>
                        <h5>HST (15%): { 10 }</h5>
                        <h5>Total: { 10 }</h5>
                    </div>
                </section>
                ) : null
            }
            <Container>
                <Row>
                    <Col>

                    </Col>
                </Row>
            </Container>
            <SignatureBox />
            <Footer />
        </>
    )
}

export default PickupStoreOrder;