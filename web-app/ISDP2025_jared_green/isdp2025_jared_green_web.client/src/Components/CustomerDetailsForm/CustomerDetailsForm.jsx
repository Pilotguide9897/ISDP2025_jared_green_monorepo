import { useState } from 'react';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';

function CustomerDetailsForm({ customerDetails, setCustomerDetails, submitOrder }) {
    const [validated, setValidated] = useState(false);

    //const handleSubmit = (event) => {
    //    const form = event.currentTarget;
    //    if (form.checkValidity() === false) {
    //        event.preventDefault();
    //        event.stopPropagation();
    //    }

    //    setValidated(true);
    //    submitOrder();
    //};
    const handleSubmit = (event) => {
        event.preventDefault();
        event.stopPropagation();

        const form = event.currentTarget;

        if (!form.checkValidity()) {
            setValidated(true);
            return;
        }

        setValidated(true);
        submitOrder();
    };



    const handleChange = (field, value) => {
        setCustomerDetails({ ...customerDetails, [field]: value });
    };

    return (
        <Form noValidate validated={validated} onSubmit={handleSubmit}>
            <Row>
                <Col>
                    <h4 className="text-start">Customer Details:</h4>
                </Col>
                
            </Row>
            <Row className="mb-3 text-start">
                <Form.Group as={Col} md="4" controlId="validationCustom01">
                    <Form.Label>First name</Form.Label>
                    <Form.Control
                        required
                        type="text"
                        placeholder="First name"
                        value={customerDetails.firstName}
                        onChange={(e) => handleChange('firstName', e.target.value)}
                    />
                    <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                </Form.Group>
                <Form.Group as={Col} md="4" controlId="validationCustom02">
                    <Form.Label>Last name</Form.Label>
                    <Form.Control
                        required
                        type="text"
                        placeholder="Last name"
                        value={customerDetails.lastName}
                        onChange={(e) => handleChange('lastName', e.target.value)}
                    />
                    <Form.Control.Feedback>Looks good!</Form.Control.Feedback>
                </Form.Group>
                <Form.Group as={Col} md="4" controlId="validationCustomUsername">
                    <Form.Label>Email Address</Form.Label>
                    <InputGroup hasValidation>
                        <Form.Control
                            type="email"
                            placeholder="name@example.com"
                            aria-describedby="inputGroupPrepend"
                            required
                            value={customerDetails.email}
                            onChange={(e) => handleChange('email', e.target.value)}
                        />
                        <Form.Control.Feedback type="invalid">
                            Please provide an email.
                        </Form.Control.Feedback>
                    </InputGroup>
                </Form.Group>
            </Row>
            <Row className="mb-3">
                <Form.Group as={Col} md="6" controlId="validationCustom03">
                    <Form.Label>Address</Form.Label>
                    <Form.Control type="text" placeholder="Address" required
                        value={customerDetails.address}
                        onChange={(e) => handleChange('address', e.target.value)}
                    />
                    <Form.Control.Feedback type="invalid">
                        Please provide a valid address
                    </Form.Control.Feedback>
                </Form.Group>
                <Form.Group as={Col} md="3" controlId="validationCustom04">
                    <Form.Label>Phone</Form.Label>
                    <Form.Control type="tel" placeholder="Phone" pattern="^[0-9]{10}$" required
                        value={customerDetails.phone}
                        onChange={(e) => handleChange('phone', e.target.value)}
                    />
                    <Form.Control.Feedback type="invalid">
                        Please provide a valid phone number.
                    </Form.Control.Feedback>
                </Form.Group>
            </Row>
            <Button variant="info" type="submit">Submit Order</Button>
        </Form>
    );
}

export default CustomerDetailsForm;