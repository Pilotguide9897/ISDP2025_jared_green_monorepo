import { useState } from 'react';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';

function OrderTab({ data }) {
    const [key, setKey] = useState(0);
    
    let keys = Object.keys(data[0])
    console.log(keys);

    console.log(data[0].orderSite);


    return (
        <Tabs
            id="controlled-tab-example"
            activeKey={key}
            onSelect={(k) => setKey(k)}
            className="mb-3"
        >
            {data.map((order, i) => (
                <Tab eventKey={i} title={order.orderSite.siteName} key={i}>
                    <Card>
                        <Card.Body>
                            <h4>{ order.txnType }</h4>
                            <ListGroup>
                                <ListGroup.Item>Site ID: {order.orderSite.siteId} </ListGroup.Item>
                                <ListGroup.Item>Address: {order.orderSite.address}</ListGroup.Item>
                                <ListGroup.Item>City:  {order.orderSite.city}</ListGroup.Item>
                                <ListGroup.Item>Postal Code: {order.orderSite.postalCode}</ListGroup.Item>

                            </ListGroup>
                        </Card.Body>
                    </Card>
                </Tab>
            ))}
        </Tabs>
    );
}

export default OrderTab;