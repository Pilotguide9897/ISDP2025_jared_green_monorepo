import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Logo from '../../assets/bullseye.jpg';
import Button from 'react-bootstrap/Button';
import { useAuth } from '../../Context/AuthContext/AuthContext';

function NavBar() {
    const { token, user, logout } = useAuth();

    return (
        <Navbar className="bg-body-tertiary">
            <Container>
                <Navbar.Brand href="#">
                    <img
                        alt="Bullseye Logo"
                        src={ Logo }
                        width="30"
                        height="30"
                        className="d-inline-block align-top"
                    />{' '}
                    Bullseye Sporting Goods
                </Navbar.Brand>
                {token && (
                    <div className="d-flex align-items-center gap-3">
                        <span className="fw-semibold text-secondary">
                            Signed in as: <strong>{user?.sub}</strong>
                        </span>
                        <Button variant="warning" onClick={logout}>Sign Out</Button>
                    </div>
                )}
            </Container>
        </Navbar>
    )
}

export default NavBar;