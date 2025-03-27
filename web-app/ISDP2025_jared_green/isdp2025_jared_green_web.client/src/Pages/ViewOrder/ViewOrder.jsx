import { useState, useEffect } from 'react';
import axios from 'axios';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import DataTable from '../../Components/DataTable/DataTable';
import Button from 'react-bootstrap/Button';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';
import Footer from "../../Components/Footer/Footer";
import ErrorImage from '../../Components/ErrorImage/file';
import BasicModal from '../../Components/Modal/BasicModal';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Container from 'react-bootstrap/Container';

function ViewOrder() {
    const [order, setOrder] = useState(null);
    const [orderDetails, setOrderDetails] = useState({});
    const [error, setError] = useState(false);
    const [loading, setLoading] = useState(false);
    const [modalShow, setModalShow] = useState(false);
    const [image, setImage] = useState("");
    const [subtotal, setsubtotal] = useState(0);
    const [hst, setHst] = useState(0);
    const [total, setTotal] = useState(0);
    //const [readyTime, setReadyTime] = useState((new Date(Date.now() + 2 * 60 * 60 * 1000)).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }))
    let imagePath = "/images/";

    const handleSearchBarSubmission = async (searchParameter) => {

        try {
            setLoading(true);
            setError(false);
            const response = await axios.get(`/api/orders/search?query=${searchParameter.toString().trim()}`);
            console.log(response.data.txnitems);

            const orderItems = response.data.txnitems;

            const { txnId, custFirstName, custLastName, custEmail, custPhone } = response.data;

            setOrderDetails({
                txnId,
                custFirstName,
                custLastName,
                custEmail,
                custPhone
            });

            const dataRows = orderItems.map(({ quantity, item }) => ({
                itemId: item.itemId,
                name: item.name,
                description: item.description,
                sku: item.sku,
                category: item.category,
                quantity: quantity,
                weight: item.weight,
                price: item.retailPrice
            }));

            setOrder(dataRows);
            console.log(dataRows);

        } catch (error) {
            setError(error);
        } finally {
            setLoading(false);
        }
    }

    //useEffect(() => {
    //    if (!order || !Array.isArray(order.txnitems)) return;

    //    setsubtotal(order.reduce((sum, item) => sum + (item.quantity * item.price), 0) || 0);
    //    setHst(subtotal * 0.15);
    //    setTotal(subtotal + hst);
    //}, [subtotal, hst, order])

    // Do not rely on react state values inside the same useEffect where I update them...
    useEffect(() => {
        if (!Array.isArray(order)) return;

        const subtotalCalc = order.reduce((sum, item) => sum + item.quantity * item.price, 0);
        const hstCalc = subtotalCalc * 0.15;
        const totalCalc = subtotalCalc + hstCalc;

        setsubtotal(subtotalCalc);
        setHst(hstCalc);
        setTotal(totalCalc);
    }, [order]);

    const showItemImage = async (row) => {
        console.log(row);
        let imageSrc = imagePath + row.itemId + ".png";
        let imageName = row.name;
        imageSrc = imageSrc.replaceAll(" ", "");
        setImage({ imageSrc, imageName });
        console.log(image);
        setModalShow(true);
    }

    return (
        <>
            <NavBar />
            <h1>Search Order</h1>
            <section>
                <SearchBar placeholderText="Search by order ID or customer email address" buttonClickHandler={handleSearchBarSubmission} />
            </section>
            {
                loading === null ? null : loading ? (<LoadingSpinner />) : order ? (
                    <section>
                        <div className="d-flex justify-content-start">
                            <Container>
                                <Row >
                                    <Col className="d-flex justify-content-start">
                                        <h5>Order ID: {orderDetails.txnId}</h5>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className="d-flex justify-content-start">
                                        <h5>Name: {orderDetails.custFirstName} {orderDetails.custLastName}</h5>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className="d-flex justify-content-start">
                                        <h5>Email: {orderDetails.custEmail}</h5>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className="d-flex justify-content-start">
                                        <h5>Phone: {orderDetails.custPhone}</h5>
                                    </Col>
                                </Row>
                            </Container>
                        </div>

                        {/*<p>{*/}
                        {/*    `This order will be ready to pick up at our ${order.orderSite.siteName} retail store: ${order.orderSite.address}, ${order.orderSite.city}, ${order.orderSite.postalCode} by ${10} at our ${10}.*/}
                     
                        {/*`}</p>*/}
                        {/*<DataTable data={orderData} handlDoubleClick={showItemImage} />*/}
                        <DataTable data={order} onRowDoubleClick={showItemImage} />
                        <BasicModal show={modalShow} onHide={() => setModalShow(false)} image={image} />
                        <div className="d-flex justify-content-end">
                            <Container>
                                <Row >
                                    <Col className="d-flex justify-content-end">
                                        <h5>Subtotal: ${subtotal.toFixed(2)}</h5>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className="d-flex justify-content-end">
                                        <h5>HST (15%): ${hst.toFixed(2)}</h5>
                                    </Col>
                                </Row>
                                <Row>
                                    <Col className="d-flex justify-content-end">
                                        <h5>Total: ${total.toFixed(2)}</h5>
                                    </Col>
                                </Row>
                            </Container>
                        </div>
                        {/*<Button variant="info">Exit</Button>*/}
                    </section>
                ) : error ? ( <ErrorImage /> ) : null
            }
            <Footer />
        </>
    )
}

export default ViewOrder;