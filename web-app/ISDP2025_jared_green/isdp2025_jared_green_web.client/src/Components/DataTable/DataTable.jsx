import Table from 'react-bootstrap/Table';

function DataTable({ data, onRowDoubleClick }) {
    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    {Object.keys(data[0]).map((key, index) => (
                        <th key={index}>{key}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {data.map((row, i) => (
                    //On double row click is optional lets me add double clicks if I pass the function prop.
                    <tr key={i} onDoubleClick={() => onRowDoubleClick?.(row)}>
                        {Object.values(row).map((value, colIndex) => (
                            <td key={colIndex}>{value}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </Table>
    );
}


export default DataTable;