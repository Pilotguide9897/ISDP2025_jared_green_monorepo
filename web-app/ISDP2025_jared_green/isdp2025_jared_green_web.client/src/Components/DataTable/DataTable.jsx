import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

function DataTable({ data, onRowDoubleClick, handleAddItem }) {
    const showAddButton = typeof handleAddItem === 'function';

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    {Object.keys(data[0] || {}).map((key, index) => (
                        <th key={index}>{key}</th>
                    ))}
                    {showAddButton && <th>Add to Cart</th>}
                </tr>
            </thead>
            <tbody>
                {data.map((row, i) => {
                    const values = Object.values(row);
                    return (
                        <tr key={i} onDoubleClick={() => onRowDoubleClick?.(row)}>
                            {values.map((value, colIndex) => (
                                <td key={colIndex}>
                                    {value}</td>
                            ))}
                            {
                            showAddButton && (
                                <td>
                                    <Button
                                        variant="info"
                                        size="sm"
                                        onClick={() => handleAddItem?.(row)}>
                                        Add Item
                                    </Button>
                                </td>
                            )}
                        </tr>
                    );
                })}
            </tbody>
        </Table>
    );
}

export default DataTable;
