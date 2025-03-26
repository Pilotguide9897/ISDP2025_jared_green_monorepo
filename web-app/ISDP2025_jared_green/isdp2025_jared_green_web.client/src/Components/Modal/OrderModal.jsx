import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import OrderTabs from '../../Components/OrderTabs/OrderTab';

function OrderModal({ show, handleClose, data }) {

    if (!data) {
        return null;
    }

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>{data.title}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="mb-3">
                    <strong>Vehicle:</strong> {data.totalWeight > 10000 ? "Heavy" : data.totalWeight > 5000 ? "Medium" : data.totalWeight > 1000 ? "Small" : "Van"} <br />
                    <strong>Total Weight:</strong> {data.totalWeight} kg
                    <strong>Total Deliveries:</strong> {data.orders.length || 0}
                </div>
                {data.orders.length === 0 ? (
                    <p>No orders available for this delivery.</p>
                ) : (
                    <OrderTabs data={data.orders} />
                )}
            </Modal.Body>
            <Modal.Footer>
                <Button variant="info" onClick={handleClose}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    );
}

export default OrderModal;