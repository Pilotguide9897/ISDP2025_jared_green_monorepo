import { useNavigate } from 'react-router';
import Logo from '../../assets/bullseye.jpg';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';

function Error() {
	const navigate = useNavigate();

	function handlePartnerClick() {
		navigate("/")
	}

	function handleCustomerClick() {
		navigate("/PlaceOrder")
	}

	return (
		//<Container style={{
		//	height: "100vh",
		//	backgroundImage: `url(${Background})`,
		//	backgroundRepeat: "no-repeat",
		//	backgroundPosition: "center"
		//}}>
		//	<Row>
		//		<h2 className="mb-4 fw-bold display-2 text-secondary">
		//		  Error: 404
		//		</h2>
		//	</Row>
		//	<Row>
		//		<p className="fs-4 fw-semibold">Sorry, we could not find this page.</p>
		//		<p className="mt-1 mb-4 text-secondary">Do not worry, you can easily return to our page by clicking one of the buttons below.</p>
		//	</Row>
		//	<Row>
		//		<Col>
		//			<Button variant="light" onClick={handlePartnerClick}>Business Partners</Button>
		//		</Col>
		//		<Col>
		//			<Button variant="light" onClick={handleCustomerClick}>Customers</Button>
		//		</Col>
		//	</Row>
		//</ Container>
		<Container>
			<Row>
				<Col className="d-none d-md-flex justify-content-center">
					<img src={Logo} alt="Bullseye Sporting Goods Logo" className='img-fluid'></img>
				</Col>
			</Row>
			<Row>
				<h2 className="mb-4 fw-bold display-2 text-secondary">
				  Error: 404
				</h2>
			</Row>
			<Row>
				<p className="fs-4 fw-semibold">Sorry, we could not find this page.</p>
				<p className="mt-1 mb-4 text-secondary">Do not worry, you can easily return to our page by clicking one of the buttons below.</p>
			</Row>
			<Row>
				<Col className="d-flex justify-content-center">
					<div>
						<Button variant="info" className="me-3" onClick={handlePartnerClick}>Business Partners</Button>
						<Button variant="info" onClick={handleCustomerClick}>Customers</Button>
					</div>

				</Col>
			</Row>
		</ Container>
	)
}

export default Error;

