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
            loading === null ? null : loading ? (<LoadingSpinner />) : order ? (
                <section>
                    <div className="d-flex justify-content-start">
                        <h5>Order ID: { order.orderID }</h5>
                        <h5>Name: { order.custName }</h5>
                        <h5>Email: { order.custEmail }</h5>
                        <h5>Phone: { order.custPhone }</h5>
                    </div>

                    <p>{
                        `This order will be ready to pick up by ${} at our ${} retail store:
                         ${} 
                        `}
                     </p>
                    <DataTable />
                    <div className="d-flex justify-content-end">
                        <h5>Subtotal: { }</h5>
                        <h5>HST (15%): { }</h5>
                        <h5>Total: { }</h5>
                    </div>
                </section>
                )
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