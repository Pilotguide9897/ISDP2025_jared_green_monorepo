import { useEffect, useState } from 'react';
import { Container, Row, Col, Card } from 'react-bootstrap';
import ComboBox from '../../Components/ComboBox/ComboBox';
import axios from '../../../node_modules/axios/index';
import NavBar from '../../Components/NavBar/NavBar';
import Footer from '../../Components/Footer/Footer';
import DataTable from '../../Components/DataTable/DataTable';
import BasicModal from '../../Components/Modal/BasicModal';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';
import CustomerDetailsForm from '../../Components/CustomerDetailsForm/CustomerDetailsForm';
//import { v4 as uuidV4 } from 'uuid';
import AddToCartToast from '../../Components/Toast/Toast';
import OrderSubmitToast from '../../Components/Toast/OrderSubmitToast';
import AlreadyInCartToast from '../../Components/Toast/AlreadyInCartToast';

function PlaceOrder() {
    const [locations, setLocations] = useState([])
    const [selectedStore, setSelectedStore] = useState(null);
    const [storeInventory, setStoreInventory] = useState(null);
    const [orderData, setOrderData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [modalShow, setModalShow] = useState(false);
    //const [selectedItem, setSelectedItem] = useState();
    const [showToast, setShowToast] = useState(false);
    const [showOrderToast, setShowOrderToast] = useState(false);
    const [showAlreadyInCartToast, setAlreadyInCartToast] = useState(false);
    const [submittedOrderID, setSubmittedOrderID] = useState(null);
    const [image, setImage] = useState("");
    let imagePath = "/images/";

    const subtotal = orderData?.reduce(
        (sum, item) => sum + item.price * item.quantity,
        0
    ) || 0;
    let hst = subtotal * 0.15;
    let total = subtotal + hst;

    const [customerDetails, setCustomerDetails] = useState({
        firstName: '',
        lastName: '',
        email: '',
        address: '',
        province: '',
        phone: ''
    });

    useEffect(() => {

        // Async Await Method
        const fetchLocations = async () => {
            try {
                const response = await axios.get('api/locations');
                console.log(response.data)
                setLocations(response.data);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchLocations();

        // Cleanup function - Not actually needed in this case.
        return () => { };
    }, []);

    useEffect(() => {
        const fetchInventoryData = async () => {
            try {
                const response = await axios.get('')

                const filtered = pickFields(response.data, ["itemId", "sitId", "name", "description", "category", "weight", "retailPrice", "quantity"]);

                setStoreInventory(filtered);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchInventoryData();

    }, [selectedStore])

    const submitOrder = async () => {

        if (orderData != null && orderData.length > 0) {
            try {

                const now = new Date();
                const cutoffHour = 16;
                const currentHour = now.getHours();

                let pickupTime;

                if (currentHour < cutoffHour) {
                    pickupTime = new Date(now.getTime() + 2 * 60 * 60 * 1000);
                } else {
                    pickupTime = new Date(
                        now.getFullYear(),
                        now.getMonth(),
                        now.getDate() + 1,
                    );
                }

                let response = await axios.post('api/orders', {
                    //txnId: 0,
                    //employeeId: 10000,
                    //siteIdto: selectedStore.SiteId,
                    //siteIdfrom: 10000,
                    //txnStatus: "PREPARING",
                    //shipDate: pickupTime().toISOString(),
                    //txnType: "Online",
                    //barCode: uuidV4(),
                    //createdDate: new Date().toISOString(),
                    //deliveryId: null,
                    //emergencyDelivery: 0,
                    //notes: "",
                    //custFirstName: customerDetails.firstName,
                    //custLastName: customerDetails.lastName,
                    //custEmail: customerDetails.email,
                    //custPhone: customerDetails.phone,
                    //txnitems: orderData

                    // Need fields:
                    // TxnId
                    // OrderSite
                    // CustFirstName
                    // CustLastName
                    // CustEmail
                    // CustPhone
                    // txnitems

                    TxnId: 0,
                    OrderSite: selectedStore.SiteId,
                    ShipDate: pickupTime().toISOString(),
                    CustFirstName: customerDetails.firstName,
                    CustLastName: customerDetails.lastName,
                    CustEmail: customerDetails.email,
                    CustPhone: customerDetails.phone,
                    txnitems: orderData
                    // Order data should have fields:
                        // TxnId
                        // ItemId
                        // Quantity
                        // Notes
                })

                setSubmittedOrderID(response.orderID)
                setShowOrderToast(true); 

                setCustomerDetails({
                    firstName: '',
                    lastName: '',
                    email: '',
                    address: '',
                    province: '',
                    phone: ''
                });
                setOrderData(null);
                setSelectedStore(null);
                setStoreInventory(null);
                setSubmittedOrderID(null);

            } catch (error) {
                setError(error);
            }
        }
    }

    const handleQuantityChange = (rowIndex, newQuantity) => {
        const parsedQuantity = parseInt(newQuantity, 10);
        if (isNaN(parsedQuantity) || parsedQuantity < 1) { return; }
        const updatedOrderData = [...orderData];
        updatedOrderData[rowIndex].quantity = parsedQuantity;
        setOrderData(updatedOrderData);
    };

    const handleAddToCart = (row) => {
        // Check if the item exists in the cart
        const existingItem = orderData.find(item => item.itemId == row.itemId);
        if (existingItem) {
            setAlreadyInCartToast(true);
        } else {
            //const { } =
            //const FilteredResult =  
            setOrderData([...orderData, row])
        }

        setShowToast(true);
    };

    const handleRemoveFromCart = (row) => {
        const cartAfterRemove = orderData.filter(item => item.itemId === row.itemId)

        setOrderData(cartAfterRemove);
    };

    const showItemImage = async (row) => {
        let imageSrc = imagePath + row.productName;
        setImage(imageSrc);
    }

    function pickFields(obj, fields) {
        return fields.reduce((result, key) => {
            if (key in obj) {
                result[key] = obj[key];
            }
            return result;
        }, {});
    }


    const handleStoreChange = (evt) => {
        setOrderData([]);
        setSelectedStore(evt.target.value);
        console.log("Selected option:", evt.target.value);
    }

    if (loading) {
        return <div><LoadingSpinner /></div>
    }

    if (error) {
        return <div>Error: { error }</div>
    }


    return (
        <>
            <NavBar />
            <h1>Bullseye Sporting Goods - Order Portal</h1>
            <ComboBox label="Select a Store" items={locations} onChange={() => handleStoreChange()} aria-describedby="storeSelectHelp" />
            {orderData && orderData.length > 0 && (
                <Alert variant="warning" className="mt-2">
                    Changing store locations will reset your cart. Please proceed with caution.
                </Alert>
            )}
            <div className="tables-container">
                <Container fluid className="mt-4">
                    <Row>
                        <Col md={6}>
                            <Card>
                                <Card.Header>Available Inventory</Card.Header>
                                <Card.Body>
                                    <DataTable
                                        data={storeInventory}
                                        onAddItem={handleAddToCart}
                                    />
                                </Card.Body>
                            </Card>
                        </Col>
                        <Col md={6}>
                            <Card>
                                <Card.Header>Your Cart</Card.Header>
                                <Card.Body>
                                    <DataTable
                                        data={orderData}
                                        inventory={storeInventory}
                                        onQuantityChange={handleQuantityChange}
                                        onRemoveItem={handleRemoveFromCart}
                                        onRowDoubleClick={showItemImage}
                                    />
                                </Card.Body>
                            </Card>
                        </Col>
                    </Row>
                    <Row>
                        <div className="d-flex justify-content-end">
                            <h5>Subtotal: ${ subtotal.toFixed(2) }</h5>
                            <h5>HST (15%): ${ hst.toFixed(2) }</h5>
                            <h5>Total: ${ total.toFixed(2) }</h5>
                        </div>
                    </Row>
                </Container>
            </div>
            <BasicModal show={modalShow} onHide={() => setModalShow(false)} image={image} />
            <CustomerDetailsForm customerDetails={customerDetails} setCustomerDetails={setCustomerDetails} />
            <Button variant="info" onClick={ submitOrder }>Submit Order</Button>
            <AddToCartToast show={showToast} onHide={() => setShowToast(false)} />
            <OrderSubmitToast show={showOrderToast} onHide={() => setShowOrderToast(false)} orderID={submittedOrderID ?? "pending"} />
            <AlreadyInCartToast show={showAlreadyInCartToast} onHide={() => { setAlreadyInCartToast(false) }} />
            <Footer />
        </>
    )
}

export default PlaceOrder;