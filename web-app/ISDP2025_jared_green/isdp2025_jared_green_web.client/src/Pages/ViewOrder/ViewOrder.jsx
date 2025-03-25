import { useState } from 'react';
import axios from 'axios';
import NavBar from '../../Components/NavBar/NavBar';
import SearchBar from '../../Components/SearchBar/SearchBar';
import DataTable from '../../Components/DataTable/DataTable';
import Button from 'react-bootstrap/Button';
import LoadingSpinner from '../../Components/LoadingSpinner/LoadingSpinner';
import Footer from "../../Components/Footer/Footer";
import ErrorImage from '../../Components/ErrorImage/file';

function ViewOrder( { orderData } ) {
    const [order, setOrder] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(null);

    const handleSearchBarSubmission = async (searchParameter) => {

        try {
            setLoading(true);
            setError(false);
            const response = await axios.get(`/api/orders/search?query=${searchParameter.toString().trim()}`);
            setOrder(response.Data);
        } catch (error) {
            setError(error);
        } finally {
            setLoading(false);
        }
    }

    return (
        <>
            <NavBar />
            <h1>Bullseye Curbside Order System - Order View</h1>
            <section>
                <SearchBar placeholderText="Search by order ID or customer email address" buttonClickHandler={handleSearchBarSubmission} />
            </section>
            {
                loading === null ? null : loading ? (<LoadingSpinner />) : order ? (
                    <section>
                        <div className="d-flex justify-content-start">
                            <h5>Order ID: { }</h5>
                            <h5>Name: { }</h5>
                            <h5>Email: { }</h5>
                            <h5>Phone: { }</h5>
                        </div>

                        <p>{
                            `This order will be ready to pick up by ${10} at our ${10} retail store:
                             ${10} 
                     
                        `}</p>
                        <DataTable data={ orderData } />
                        <div className="d-flex justify-content-end">
                            <h5>Subtotal: { }</h5>
                            <h5>HST (15%): { }</h5>
                            <h5>Total: { }</h5>
                        </div>
                        <Button variant="info">OK</Button>
                    </section>
                ) : error ? ( <ErrorImage /> ) : null
            }
            <Footer />
        </>
    )
}

export default ViewOrder;