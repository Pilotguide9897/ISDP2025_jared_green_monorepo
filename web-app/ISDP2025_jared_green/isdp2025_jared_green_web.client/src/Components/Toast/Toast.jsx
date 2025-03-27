import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Toast, ToastContainer } from 'react-bootstrap';

function AddToCartToast({ show, onHide }) {

    return (
        <ToastContainer position="top-end" className="p-3">
            <Row>
                <Col xs={6}>
                    <Toast onClose={() => onHide(false)} show={show} delay={3000} autohide>
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
            </Row>
        </ToastContainer>
    );
}

export default AddToCartToast;