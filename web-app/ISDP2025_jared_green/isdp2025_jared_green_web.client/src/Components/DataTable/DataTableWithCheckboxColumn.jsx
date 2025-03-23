import Table from 'react-bootstrap/Table';
import { useState } from 'react';

function DataTable(data) {
    const [checkboxStates, setCheckboxStates] = useState([[]]);

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    {Object.keys(data[0]).map((key, index) => (
                        <th key={index}>{key}</th>
                    ))}
                    <th>Delivered</th>
                </tr>
            </thead>
            <tbody>
                {data.map((row, i) => (
                    <tr key={i}>
                        {Object.values(row).map((value, colIndex) => (
                            <td key={colIndex}>{value}</td>
                        ))}
                        <td>
                            <Form.Check type={'checkbox'} />
                        </td> 
                    </tr>
                ))}
            </tbody>
        </Table>
    )
}

export default DataTable;