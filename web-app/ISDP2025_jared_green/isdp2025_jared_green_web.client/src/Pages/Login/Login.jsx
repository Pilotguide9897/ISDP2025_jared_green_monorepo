import { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Logo from '../../assets/bullseye.jpg';
import Footer from '../../Components/Footer/Footer';
import axios from "axios";
import { useNavigate } from "react-router-dom";
import LoginErrorToast from '../../Components/Toast/LoginErrorToast';
import Button from 'react-bootstrap/Button';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';

function Login() {
    const [userEmail, setUserEmail] = useState("");
    const [userPassword, setUserPassword] = useState("");
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);

    const navigate = useNavigate();

    async function handleLogin(evt) {
        evt.preventDefault();
        setLoading(true);

        try {
            const response = await axios.post("/api/login", {
                email: userEmail,
                password: userPassword
            });
            localStorage.setItem("token", response.data.token);
            // Tell axios to use the token.
            axios.defaults.headers.common["Authorization"] = `Bearer ${localStorage.getItem("token")}`;
            console.log("Navigating to dashboard...");
            navigate("/driverdashboard")
        } catch (er) {
            console.log(er);
            setError(true);
        } finally {
            setLoading(false);
        }
    }

    if (loading) {
        return (
            <LoadingSpinner />
        )
    }

    return (
        <Container>
            <Row>
                <Col justify-content="center" align-items="center" xs={12} md={5} className= "d-none d-md-flex justify-content-center">
                    <img src={ Logo } alt="Bullseye Sporting Goods Logo" className='img-fluid'></img>
                </Col>
                <LoginErrorToast show={error} setShow={setError} />
                <Col xs={12} md={7}>
                    <LoginErrorToast show={error} setShow={setError} />
                    <Form onSubmit={handleLogin}>
                        <h2 className="mb-4 fw-bold display-4 text-center text-secondary">
                            Driver Login
                        </h2>

                        <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
                            <Form.Label column sm="2">Email</Form.Label>
                            <Col sm="10">
                                <Form.Control
                                    placeholder="email@example.com"
                                    onChange={(e) => setUserEmail(e.target.value)}
                                />
                            </Col>
                        </Form.Group>

                        <Form.Group as={Row} className="mb-3" controlId="formPlaintextPassword">
                            <Form.Label column sm="2">Password</Form.Label>
                            <Col sm="10">
                                <Form.Control
                                    type="password"
                                    placeholder="Password"
                                    onChange={(e) => setUserPassword(e.target.value)}
                                />
                            </Col>
                            <Form.Text id="passwordHelpBlock" muted>
                                Passwords are at least 8 characters long, contain at least one uppercase letter, one or more numbers, does not contain spaces, and contains at least one special character.
                            </Form.Text>
                        </Form.Group>

                        <Button variant="info" type="submit">Login</Button>
                    </Form>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Footer />
                </Col>
            </Row>
        </Container>
    );
}

export default Login;
