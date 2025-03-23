import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Toast, ToastContainer } from 'react-bootstrap';

function AddToCartToast({ show, setShow }) {

    return (
        <Row>
            <Col xs={6}>
                <Toast onClose={() => setShow(false)} show={show} delay={3000} autohide>
                    <Toast.Header>
                        <img
                            src="holder.js/20x20?text=%20"
                            className="rounded me-2"
                            alt=""
                        />
                        <strong className="me-auto">Cart</strong>
                        <small>Now</small>
                    </Toast.Header>
                    <Toast.Body>Item added to cart</Toast.Body>
                </Toast>
            </Col>
            <Col xs={6}>
                <Button variant="info" onClick={() => setShow(true)}>Show Toast</Button>
            </Col>
        </Row>
    );
}

export default AddToCartToast;