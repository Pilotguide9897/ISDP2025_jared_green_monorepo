import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

function DataTableWithNud({ data, inventory, onQuantityChange, onRemoveItem, onRowDoubleClick }) {

    const columns = ['ItemId', 'Name', 'Weight', 'Price', 'Quantity', 'Remove'];
    console.log(data);

    if (!data || data.length === 0) {
        return null;
    }

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    {columns.map((col, index) => (
                        <th key={index}>{col}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {data.map((row, i) => {
                    const matchingInventory = inventory?.find(item => item.ItemId === row.ItemId);
                    const maxStock = matchingInventory ? matchingInventory.quantityInStock : 1;

                    // Need return because using curly braces!
                    return (
                        <tr key={i} onDoubleClick={() => onRowDoubleClick?.(row)}  >
                        {/*Access arr to see if column is the last row*/}
                            {columns.map((col, colIndex) => (
                                <td key={colIndex}>
                                    {col == "Quantity" ? (
                                        <input style={{ width: "55px" }}
                                            type="number"
                                            min="1"
                                            max={maxStock}
                                            value={row[col]}
                                            onChange={(e) => onQuantityChange(i, e.target.value)}
                                        />
                                    ) : col == "Remove" ? (
                                        <Button
                                            variant="danger"
                                            size="sm"
                                            onClick={() => onRemoveItem(row)}>
                                            Remove
                                        </Button>
                                    ) : (
                                        row[col]
                                    )}
                                </td>
                            ))}
                        </tr>
                    );
                })}
            </tbody>
        </Table>
    )
}

export default DataTableWithNud;