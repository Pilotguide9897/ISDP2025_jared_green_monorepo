import { useEffect, useState } from 'react';
import { Container, Row, Col, Card } from 'react-bootstrap';
import ComboBox from '../../Components/ComboBox/ComboBox';
import axios from '../../../node_modules/axios/index';
import NavBar from '../../Components/NavBar/NavBar';
import Footer from '../../Components/Footer/Footer';
import DataTable from '../../Components/DataTable/DataTable';
import DataTableWithNud from '../../Components/DataTable/DataTableWithNud';
import BasicModal from '../../Components/Modal/BasicModal';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';
import CustomerDetailsForm from '../../Components/CustomerDetailsForm/CustomerDetailsForm';
//import { v4 as uuidV4 } from 'uuid';
import AddToCartToast from '../../Components/Toast/Toast';
import OrderSubmitToast from '../../Components/Toast/OrderSubmitToast';
import AlreadyInCartToast from '../../Components/Toast/AlreadyInCartToast';
import Alert from '../../Components/Alert/Alert';


function PlaceOrder() {
    const [locations, setLocations] = useState([])
    const [selectedStore, setSelectedStore] = useState(null);
    const [storeInventory, setStoreInventory] = useState(null);
    const [orderData, setOrderData] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [modalShow, setModalShow] = useState(false);
    //const [selectedItem, setSelectedItem] = useState();
    const [showToast, setShowToast] = useState(false);
    const [showOrderToast, setShowOrderToast] = useState(false);
    const [showAlreadyInCartToast, setAlreadyInCartToast] = useState(false);
    const [submittedOrderID, setSubmittedOrderID] = useState(null);
    const [image, setImage] = useState("");
    const [subtotal, setSubtotal] = useState(0);
    const [quantityAvailable, setQuantityAvailable] = useState(0);
    let imagePath = "/images/";

    //const subtotal = orderData?.reduce(
    //    (sum, item) => sum + item.price * item.quantity,
    //    0
    //) || 0;
    //let hst = subtotal * 0.15;
    //let total = subtotal + hst;

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
                const response = await axios.get('api/locations/retail');
                // console.log(response.data)
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
        console.log("Effect triggered!");
        const fetchInventoryData = async () => {
            try {
                setLoading(true);

                // console.log("About to search siteID");

                if (!selectedStore || !selectedStore.siteId) return;

                const response = await axios.get(`api/inventory/${selectedStore.siteId}`)

                const invData = response.data.map((item) => ({
                    ItemId: item.itemId,
                    Quantity: item.quantity,
                    Name: item.item.name,
                    Sku: item.item.sku,
                    //Description: item.item.description,
                    Weight: item.item.weight,
                    Price: item.item.retailPrice
                }));

                setStoreInventory(invData);

            } catch (error) {
                console.log("Error with the fetching inventory data");
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchInventoryData();

    }, [selectedStore])

    useEffect(() => {
        if (locations.length > 0 && !selectedStore) {
            setSelectedStore(locations[0]);
        }
    }, [locations]);


    useEffect(() => {
        if (orderData.length < 1) {return};
        console.log(JSON.stringify(orderData));
        const amt = orderData.reduce((sum, current) => sum + (current.Quantity * current.Price), 0);
        console.log("amt: " + amt)

        setSubtotal(amt); 

    }, [orderData])


    const submitOrder = async () => {
        console.log("Order Data: " + JSON.stringify(orderData));
        console.log("Selected Store: " + JSON.stringify(selectedStore));
        console.log("Customer Details: " + JSON.stringify(customerDetails));
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

                //const { siteId, siteName, address, provinceId, postalCode, city } = selectedStore;
                const { siteId } = selectedStore;

                //const storeDetails = {
                //    SiteId: siteId, 
                //    SiteName: siteName,
                //    Address: address,
                //    Province: provinceId,
                //    PostalCode: postalCode,
                //    City: city
                //}

                const cleanedTxnItems = orderData.map(item => ({
                    TxnId: 0,
                    ItemId: item.ItemId,
                    Quantity: item.Quantity,
                    Notes: ""
                }));


                const payload = {
                    TxnId: 0,
                    OrderSite: siteId,
                    ShipDate: pickupTime.toISOString(),
                    CustFirstName: customerDetails.firstName,
                    CustLastName: customerDetails.lastName,
                    CustEmail: customerDetails.email,
                    CustPhone: customerDetails.phone,
                    txnitems: cleanedTxnItems
                }

                console.log("Payload:", JSON.stringify(payload, null, 2));

                let response = await axios.post('api/orders', payload);

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
                setOrderData([]);
                setSelectedStore(locations[0]);
                setStoreInventory([]);
                setSubtotal(0);
                //setSubmittedOrderID(null);

            } catch (error) {
                setError(error);
            }
        } else {
            alert("No items to submit");
        }
    }

    const handleQuantityChange = (rowIndex, newQuantity) => {
        const parsedQuantity = parseInt(newQuantity, 10);
        console.log(parsedQuantity);
        if (isNaN(parsedQuantity) || parsedQuantity < 1) { return; }
        const updatedOrderData = orderData.map((item, index) =>
            index === rowIndex
                ? { ...item, Quantity: parsedQuantity }
                : item
        );
        setOrderData(updatedOrderData);
    };

    const handleAddToCart = (row) => {
        // Check if the item exists in the cart
        console.log(row);
        console.log(orderData.length);
        if (orderData && orderData.length > 0) {
            console.log(JSON.stringify(orderData));
            const existingItem = orderData.find((item) => item.ItemId == row.ItemId);
            console.log(existingItem);
            if (existingItem) {
                setAlreadyInCartToast(true);
                return;
            }
        } 

        // Map the row data!
        const { ItemId, Name, Weight, Price } = row; 
        //const { ItemId, Name, Weight, Quantity, Price } = row; 
        //setQuantityAvailable(Quantity);
        setOrderData([...orderData, { ItemId, Name, Weight, Price, Quantity: 1, Remove: 0 }]);
        setShowToast(true);
    };

    const handleRemoveFromCart = (row) => {
        console.log(row);
        const cartAfterRemove = orderData.filter(item => item.ItemId !== row.ItemId)
        console.log(cartAfterRemove);
        setOrderData(cartAfterRemove);
    };

    const showItemImage = async (row) => {
        console.log(row);
        let imageSrc = imagePath + row.itemId + ".png";
        let imageName = row.name;
        imageSrc = imageSrc.replaceAll(" ", "");
        setImage({ imageSrc, imageName });
        console.log(image);
        setModalShow(true);
    }

    const handleStoreChange = (evt) => {
        console.log("Triggered");
        console.log(locations);
        setOrderData([]);
        console.log(Object.keys(evt.target.value));
        const selectedSiteId = parseInt(evt.target.value, 10);
        console.log(selectedSiteId);
        const selected = locations.find((location) => location.siteId === selectedSiteId);

        if (selected) {
            setSelectedStore(selected);
            setOrderData([]);
            console.log("Switching stores");
            console.log("Selected option:", selected);
        }
    }

    if (error) {
        return <div>Error: { error.message }</div>
    }

    return (
        <>
            <NavBar />
            <h1>Bullseye Sporting Goods - Order Portal</h1>
            <ComboBox label="Select a Store" items={locations} onChange={handleStoreChange} aria-describedby="storeSelectHelp" />
            {orderData && orderData.length > 0 && (
                <Alert variant="warning" className="mt-5 mb-5" message="Changing store locations will reset your cart. Please proceed with caution." />
            )}
            {loading ?  (<LoadingSpinner />) : (
            
                <div className="tables-container h-50 overflow-hidden mt-2 mb-5">
                    <Container fluid className="mt-4">
                        <Row>
                            <Col md={7}>
                                <Card>
                                    <Card.Header>Available Inventory</Card.Header>
                                    <Card.Body style={{maxHeight: '35vh'}} className="h-100 overflow-auto ">
                                        <DataTable
                                            data={storeInventory}
                                            handleAddItem={ handleAddToCart }
                                        />
                                    </Card.Body>
                                </Card>
                            </Col>
                            <Col md={5}>
                                <Card>
                                    <Card.Header>Your Cart</Card.Header>
                                    <Card.Body style={{ maxHeight: '35vh' }} className="h-100 overflow-auto ">
                                        <DataTableWithNud
                                            data={orderData}
                                            inventory={storeInventory}
                                            onQuantityChange={handleQuantityChange}
                                            onAddItem={handleAddToCart}
                                            onRemoveItem={handleRemoveFromCart}
                                            onRowDoubleClick={showItemImage}
                                        />
                                    </Card.Body>
                                </Card>
                            </Col>
                        </Row>
                        <Row >
                            <Col className="d-flex justify-content-end">
                                <h5>Subtotal: ${subtotal.toFixed(2)}</h5>
                            </Col>
                        </Row>
                        <Row>
                            <Col className="d-flex justify-content-end">
                                <h5>HST (15%): ${(subtotal * 0.15).toFixed(2)}</h5>
                            </Col>
                        </Row>
                        <Row>
                            <Col className="d-flex justify-content-end">
                                <h5>Total: ${((subtotal * 0.15) + subtotal).toFixed(2)}</h5>
                            </Col>
                        </Row>
                    </Container>
                </div>
            )}
            
            <BasicModal show={modalShow} onHide={() => setModalShow(false)} image={image} />
            <CustomerDetailsForm customerDetails={customerDetails} setCustomerDetails={setCustomerDetails} submitOrder={ submitOrder } />
            <AddToCartToast show={showToast} onHide={setShowToast} />
            <OrderSubmitToast show={showOrderToast} onHide={setShowOrderToast} orderID={submittedOrderID ?? "pending"} />
            <AlreadyInCartToast show={showAlreadyInCartToast} onHide={setAlreadyInCartToast} />
            <Footer />
        </>
    )
}

export default PlaceOrder;