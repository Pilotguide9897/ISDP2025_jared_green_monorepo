import { useState } from 'react';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';

function OrderTab({ data }) {
    const [key, setKey] = useState(0);

    return (
        <Tabs
            id="controlled-tab-example"
            activeKey={key}
            onSelect={(k) => setKey(k)}
            className="mb-3"
        >
            {data.map((order, i) => (
                <Tab eventKey={i} title={order.siteName} key={i}>
                    <Card>
                        <Card.Body>
                            <h4>{ order.txnType }</h4>
                            <ListGroup>
                                <ListGroup.Item>{order.address}</ListGroup.Item>
                                <ListGroup.Item>{order.city}</ListGroup.Item>
                                <ListGroup.Item>{order.province}</ListGroup.Item>
                                <ListGroup.Item>{order.postalCode}</ListGroup.Item>
                            </ListGroup>
                        </Card.Body>
                    </Card>
                </Tab>
            ))}
        </Tabs>
    );
}

export default OrderTab;